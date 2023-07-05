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
        /// <param name="takeMaterialFromStock">Use the material from stock</param>
        /// <param name="doNotExceedLowStock">Is the lowstock guaranteed. If true and stock greater than lowstock, it will no go under lowstock</param>
        /// <param name="orderMoreWhenBelowLowStock">Is the lowstock the (minimum) target for the stock. If true and stock is lower than lowstock, it will add quantity to target lowstock</param>
        /// <returns>The quantity to order, <paramref name="material"/> is not modified</returns>
        public static float GetActualOrderQuantity(Material material, bool takeMaterialFromStock, bool doNotExceedLowStock, bool orderMoreWhenBelowLowStock)
        {
            if (!material.HasPartLink)
            {
                return material.Quantity;
            }

            float baseQuantity = material.Quantity;
            float currentStock = material.PartLink.Stock;
            float currentLowStock = material.PartLink.LowStock;

            float orderQuantity;

            // Not taking from current stock
            if (!takeMaterialFromStock)
            {
                orderQuantity = baseQuantity;

                if (currentStock < currentLowStock)
                {
                    if (orderMoreWhenBelowLowStock)
                    {
                        orderQuantity += (currentLowStock - currentStock); // Adding difference
                    }
                }
                else // currentStock >= currentLowStock
                {
                    // No change
                }
            }
            // Taking from current stock
            else
            {
                orderQuantity = Math.Max(baseQuantity - currentStock, 0);

                if (currentStock < currentLowStock)
                {
                    if (orderMoreWhenBelowLowStock)
                    {
                        orderQuantity = baseQuantity + (currentLowStock - currentStock); // Adding difference
                    }
                    else if (doNotExceedLowStock)
                    {
                        // In this case, we just don't use the current stock
                        orderQuantity = baseQuantity;
                    }
                }
                else // currentStock >= currentLowStock
                {
                    if (doNotExceedLowStock)
                    {
                        orderQuantity = Math.Max(baseQuantity - (currentStock - currentLowStock), 0);
                    }
                }
            }

            return orderQuantity;
        }



    }
}
