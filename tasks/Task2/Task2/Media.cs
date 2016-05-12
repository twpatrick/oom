using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    interface Media
    {
        /// <summary>
        /// Gets the title of the item
        /// </summary>
        string title { get; }

        /// <summary>
        /// Gets the item's price in the specified currency.
        /// </summary>
        decimal GetPrice(Currency currency);
    }
}
