using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class MusicCD : Media
    {
        private decimal m_price;
        /// <summary>
        /// Creates a new dvd object.
        /// </summary>
        /// <param name="title">Title must not be empty.</param>
        /// <param name="playingTime">Playing time must be positive.</param>
        /// <param name="price">Price must be positive.</param>
        public MusicCD(string title, string author, uint playingTime, decimal price, Currency currency)
        {
            //check if input is correct
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title must not be empty.", nameof(title));
            if (playingTime <= 0) throw new ArgumentException("playingTime must more than 0.", nameof(playingTime));
            if (string.IsNullOrWhiteSpace(author)) throw new ArgumentException("Author must not be empty.", nameof(author));

            //set valid values
            this.author = author;
            this.title = title;
            this.playingTime = playingTime;
            UpdatePrice(price, currency);
        }

        /// <summary>
        /// Gets the author.
        /// </summary>
        public string author { get; }

        /// <summary>
        /// Gets the dvd title.
        /// </summary>
        public string title { get; }

        /// <summary>
        /// Gets the playing time of dvd.
        /// </summary>
        public uint playingTime { get; }

        /// <summary>
        /// Gets the currency of this dvd's price.
        /// </summary>
        public Currency Currency { get; private set; }

        /// <summary>
        /// Gets the dvd's price in the given currency.
        /// </summary>
        public decimal GetPrice(Currency currency)
        {
            // if the price is requested in it's own currency, then simply return the stored price
            if (currency == Currency) return m_price;

            // use web service to query current exchange rate
            // request : http://download.finance.yahoo.com/d/quotes.csv?s=EURUSD=X&f=sl1d1t1c1ohgv&e=.csv
            // response: "EURUSD=X",1.0930,"12/29/2015","6:06pm",-0.0043,1.0971,1.0995,1.0899,0
            var key = string.Format("{0}{1}", Currency, currency); // e.g. EURUSD means "How much is 1 EUR in USD?".

            // create the request URL, ...
            var url = string.Format(@"http://download.finance.yahoo.com/d/quotes.csv?s={0}=X&f=sl1d1t1c1ohgv&e=.csv", key);
            // download the response as string
            var data = new WebClient().DownloadString(url);
            // split the string at ','
            var parts = data.Split(',');
            // convert the exchange rate part to a decimal 
            var rate = decimal.Parse(parts[1], CultureInfo.InvariantCulture);

            // and finally perform the currency conversion
            return m_price * rate;
        }

        /// <summary>
        /// Updates the dvd's price.
        /// </summary>
        /// <param name="newPrice">Price must not be negative.</param>
        /// <param name="newCurrency">Currency.</param>
        public void UpdatePrice(decimal newPrice, Currency currency)
        {
            if (newPrice < 0) throw new ArgumentException("Price must be positive.", nameof(newPrice));
            m_price = newPrice;
            Currency = currency;
        }
    }
}
