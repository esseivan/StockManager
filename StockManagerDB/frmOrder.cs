using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagerDB
{
    public partial class frmOrder : Form
    {
        Dictionary<string, Material> PartsToOrder = new Dictionary<string, Material>();

        public frmOrder()
        {
            InitializeComponent();
        }

        private void PartsHaveChanged()
        {

        }

        /// <summary>
        /// Add parts to order to the list according to lowstock and stock parameters
        /// </summary>
        /// <param name="parts"></param>
        public void AddPartsToOrder(IEnumerable<Part> parts)
        {
            foreach (Part part in parts)
            {
                float qty = part.LowStock - part.Stock;
                if (PartsToOrder.ContainsKey(part.MPN))
                {
                    // Add to existing
                    PartsToOrder[part.MPN].Quantity += qty;
                }
                else
                {
                    PartsToOrder[part.MPN] = new Material()
                    {
                        MPN = part.MPN,
                        Quantity = qty,
                    };
                }
            }
        }

        /// <summary>
        /// Add materials to order according to quantites
        /// </summary>
        /// <param name="parts"></param>
        public void AddPartsToOrder(IEnumerable<Material> materials)
        {
            foreach (Material mat in materials)
            {
                float qty = mat.Quantity;
                if (PartsToOrder.ContainsKey(mat.MPN))
                {
                    // Add to existing
                    PartsToOrder[mat.MPN].Quantity += qty;
                }
                else
                {
                    PartsToOrder[mat.MPN] = new Material()
                    {
                        MPN = mat.MPN,
                        Quantity = qty,
                    };
                }
            }
        }
    }
}
