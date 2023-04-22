using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagerDB
{
    public class ExtensionAssociation
    {
        public static bool SetAssociation()
        {
            var imgKey = Registry.ClassesRoot.OpenSubKey(".smd");
            var imgType = imgKey.GetValue("");

            string myExecutable = Assembly.GetEntryAssembly().Location;
            string command = "\"" + myExecutable + "\"" + " \"%1\"";

            string keyName = imgType + @"\shell\Open\command";
            var execKey = Registry.ClassesRoot.OpenSubKey(keyName);
            var currentExecutable = execKey.GetValue("");

            // Already set. Nothing more to do...
            if (command.Equals(currentExecutable))
            {
                LoggerClass.Write("Already set. Aborting...");
                return true;
            }

            // Check if admin rights
            if (!ESNLib.Tools.MiscTools.HasAdminPrivileges())
            {
                // Run with admin rights
                MessageBox.Show($"The application will ask you to grant administrator privileges in order to register the \".smd\" extension for this application.\nPlease approve.", "Admin Privileges Requested", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo(myExecutable, "--register")
                };
                if (process.StartInfo.Verb == string.Empty)
                {
                    process.StartInfo.Verb = "runas";
                }
                else
                {
                    process.StartInfo.Verb += "runas";
                }

                try
                {
                    process.Start();
                }
                catch (Win32Exception)
                {
                    return false;
                }

                return false;
            }

            using (var key = Registry.ClassesRoot.CreateSubKey(keyName))
            {
                key.SetValue("", command);
            }

            return true;
        }
    }
}
