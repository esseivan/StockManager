using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagerDB
{
    public abstract class PartUtils
    {
        /// <summary>
        /// Get the quantity to order for the selected material
        /// </summary>
        /// <param name="material">material to order</param>
        /// <param name="takeFromStock">Use the material from stock</param>
        /// <param name="guaranteeLowStock">Is the lowstock guaranteed. If true and stock greater than lowstock, it will no go under lowstock</param>
        /// <param name="targetStockIsLowStock">Is the lowstock the (minimum) target for the stock. If true and stock is lower than lowstock, it will add quantity to target lowstock</param>
        /// <returns>The quantity to order, <paramref name="material"/> is not modified</returns>
        public static float GetActualOrderQuantity(Material material, bool takeFromStock, bool guaranteeLowStock, bool targetStockIsLowStock)
        {
            float quantity = material.Quantity;

            if (!material.HasPartLink)
            {
                return quantity;
            }

            float currentStock = material.PartLink.Stock;
            float currentLowStock = material.PartLink.LowStock;

            if (takeFromStock)
            {
                // Order only what is not in actual stock
                quantity = Math.Min(currentStock - quantity, 0);
            }

            if (targetStockIsLowStock)
            {

            }

            // We don't take from stock, so order what is requested
            if (!takeFromStock)
            {
                return material.Quantity;
            }

            // Do not go under lowstock but don't order more than initially
            if (guaranteeLowStock)
            {

            }

            //        Material mat = materials[i];

            //        // If no partlink, keep as is
            //        if (!mat.HasPartLink)
            //        {
            //            continue;
            //        }

            //    if (e.GuaranteeLowStock)
            //    {
            //        // We are not authorized to go under the LowStock value
            //        // If the current stock already is under the lowStock, we will not order more.
            //        // Only if the stock is lower than 0 (e.g. -2), we will order to go to 0
            //        float availableStock = (mat.PartLink.Stock >= mat.PartLink.LowStock) ? (mat.PartLink.Stock - mat.PartLink.LowStock) : 0;
            //        if (availableStock >= mat.Quantity)
            //        {
            //            // Enough stock
            //            mat.Quantity = 0;
            //        }
            //        else
            //        {
            //            // Order what is required
            //            mat.Quantity -= availableStock;
            //            if (mat.PartLink.Stock < 0)
            //            {
            //                mat.Quantity += -(mat.PartLink.Stock); // Add quantity for stock to go to 0, if negative
            //            }
            //        }
            //    }
            //    else
            //    {
            //        // We do not guarantee the LowStock value

            //        // Just check according to actual stock
            //        if (mat.PartLink.Stock >= mat.Quantity)
            //        {
            //            // Enough stock, order nothing
            //            mat.Quantity = 0;
            //        }
            //        else
            //        {
            //            // Order just the necessary
            //            mat.Quantity -= mat.PartLink.Stock;
            //        }
            //    }

            return 0;
        }



    }
}
