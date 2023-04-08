using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagerDB
{
    public class DBWrapper : IDisposable
    {
        private readonly string filename;
        private Dictionary<string, PartClass> remoteParts = new Dictionary<string, PartClass>();

        public DBWrapper(string filename)
        {
            this.filename = filename;
        }

        /// <summary>
        /// Create a brand new database. All changes will be erased
        /// </summary>
        /// <returns>True if new database created. False if already existing</returns>
        public bool CreateDatabase(bool createTemplatePart = false, bool overwriteDB = false)
        {
            if ((!overwriteDB) && File.Exists(filename))
                return false;

            // Create a new SQLite database file
            SQLiteConnection.CreateFile(filename);

            // Create a connection to the database
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={filename};Version=3;"))
            {
                connection.Open();
                // Create a new table called "StockParts"
                using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE StockParts ( mpn VARCHAR(255) PRIMARY KEY, manufacturer VARCHAR(255), description VARCHAR(255), category VARCHAR(255), storage VARCHAR(255), stock FLOAT, low_stock FLOAT, price FLOAT, supplier VARCHAR(255), spn VARCHAR(255));"
                    , connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            // Create dummy part
            if (createTemplatePart)
            {
                PartClass part = new PartClass()
                {
                    MPN = "Template",
                    Description = "Template part",
                    Stock = 0,
                    Price = 0,
                    Category = "Template catergory",
                    Location = "Undefined",
                };
                AddPart(part);
            }

            return true;
        }

        /// <summary>
        /// Load the parts from the database
        /// </summary>
        /// <returns></returns>
        public List<PartClass> LoadDatabase()
        {
            // Create a connection to the database
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={filename};Version=3;"))
            {
                connection.Open();

                // Create a new DataTable object to hold the data retrieved from the SQLite database
                DataTable dataTable = new DataTable();

                // Retrieve the data from the SQLite database
                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter("SELECT * FROM StockParts", connection);
                dataAdapter.Fill(dataTable);

                List<PartClass> newParts = PartClass.CreateFromDB(dataTable);

                remoteParts = new Dictionary<string, PartClass>();
                foreach (PartClass part in newParts)
                {
                    remoteParts.Add(part.MPN, part.Clone());
                }

                dataAdapter.Dispose();
                connection.Close();
                return newParts;
            }
        }

        /// <summary>
        /// Apply changes to a part to the database
        /// </summary>
        /// <param name="updatedPart">The updated PartClass part</param>
        /// <returns>True if success. False if failed</returns>
        public bool UpdatePart(PartClass updatedPart)
        {
            // Find changes
            if (!remoteParts.ContainsKey(updatedPart.MPN))
            {
                // Part not found in remote DB. Add new instead

                throw new InvalidOperationException("MPN not found in remote parts");
                return false;
            }

            PartClass remotePart = remoteParts[updatedPart.MPN];
            Dictionary<string, string> changes = new Dictionary<string, string>();
            foreach (var item in updatedPart.Parameters)
            {
                PartClass.Parameter param = item.Key;
                string value = item.Value;

                // Verify if parameter has changed
                if (!value.Equals(remotePart.Parameters[param]))
                {
                    Console.WriteLine("Change in part : " + param.ToString());
                    changes.Add(PartClass.DatabaseLinkStr[param], value);
                }
            }

            if (changes.Count == 0)
            {
                // No change made
                return false;
            }

            // Apply change to remote

            IEnumerable<string> changeStr = changes.Select((kv) => $"{kv.Key}='{kv.Value}'");
            string editText = string.Join(", ", changeStr);
            string mpnStr = updatedPart.MPN;

            // Create a connection to the database
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={filename};Version=3;"))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand($"UPDATE StockParts SET {editText} WHERE mpn='{mpnStr}';"
                        , connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            // Save to remote buffer
            remoteParts[updatedPart.MPN] = updatedPart.Clone();

            return true;
        }

        /// <summary>
        /// Remove the specified part from the database
        /// </summary>
        /// <param name="part"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public bool RemovePart(string partMPN)
        {
            if (!remoteParts.ContainsKey(partMPN))
            {
                // Part not found in remote DB. Add new instead

                throw new InvalidOperationException("MPN not found in remote parts");
                return false;
            }

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={filename};Version=3;"))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand($"DELETE FROM StockParts WHERE mpn='{partMPN}';"
                        , connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            remoteParts.Remove(partMPN);

            return true;
        }

        /// <summary>
        /// Remove the specified part from the database
        /// </summary>
        /// <param name="part"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public bool RemovePart(PartClass part)
        {
            return RemovePart(part.MPN);
        }

        /// <summary>
        /// Add a part to the database
        /// </summary>
        /// <param name="part"></param>
        /// <returns></returns>
        public bool AddPart(PartClass part)
        {
            if (remoteParts.ContainsKey(part.MPN))
            {
                // Old MPN not found
                throw new InvalidOperationException("New MPN already existing in remote parts");
            }

            // Create a connection to the database
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={filename};Version=3;"))
            {
                connection.Open();

                // Insert part
                using (SQLiteCommand command = new SQLiteCommand("INSERT INTO StockParts (mpn, manufacturer, description, category, storage, stock, low_stock, price, supplier, spn)\r\nVALUES (@MPN, @Manufacturer, @Description, @Category, @Storage, @Stock, @LowStock, @Price, @Supplier, @SPN);"
                    , connection))
                {
                    command.Parameters.AddWithValue("@MPN", part.MPN);
                    command.Parameters.AddWithValue("@Manufacturer", part.Manufacturer);
                    command.Parameters.AddWithValue("@Description", part.Description);
                    command.Parameters.AddWithValue("@Category", part.Category);
                    command.Parameters.AddWithValue("@Storage", part.Location);
                    command.Parameters.AddWithValue("@Stock", part.Stock);
                    command.Parameters.AddWithValue("@LowStock", part.LowStock);
                    command.Parameters.AddWithValue("@Price", part.Price);
                    command.Parameters.AddWithValue("@Supplier", part.Supplier);
                    command.Parameters.AddWithValue("@SPN", part.SPN);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            remoteParts.Add(part.MPN, part);

            return true;
        }

        /// <summary>
        /// Define a new ID (MPN) for the part.
        /// </summary>
        /// <param name="newPart">The new PartClass part</param>
        /// <param name="oldMPN">The MPN of the old version of the part</param>
        /// <returns>True if success. False if failed</returns>
        public bool RenamePart(string oldMPN, string newMPN)
        {
            if (!remoteParts.ContainsKey(oldMPN))
            {
                // Old MPN not found
                throw new InvalidOperationException("Old MPN not found in remote parts");
            }
            if (remoteParts.ContainsKey(newMPN))
            {
                // Old MPN not found
                throw new InvalidOperationException("New MPN already existing in remote parts");
            }

            PartClass part = remoteParts[oldMPN];
            part.MPN = newMPN;

            // Remove from DB
            RemovePart(oldMPN);

            // Add new
            AddPart(part);

            return true;
        }

        public void Dispose()
        {

        }
    }
}
