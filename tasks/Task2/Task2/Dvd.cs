using System;
using System.Net;
using System.Globalization;

namespace Task2
{
    class Dvd
    {
        private decimal m_price; 
        /// <summary>
		/// Creates a new book object.
		/// </summary>
		/// <param name="title">Title must not be empty.</param>
		/// <param name="playingTime">Playing time must be positive.</param>
		/// <param name="price">Price must be positive.</param>
		public Dvd(string title, uint playingTime, decimal price, Currency currency)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title must not be empty.", nameof(title));
            if (playingTime <= 0) throw new ArgumentException("playingTime must more than 0.", nameof(playingTime));
            this.title = title;
            this.playingTime = playingTime; //auch set methode
            UpdatePrice(price, currency);
        }

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
        /// Updates the book's price.
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
