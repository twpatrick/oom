using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Dvd : IMedia
    {
        private Price m_price;
        private DateTime m_publishingDate;

        public Dvd(string title, decimal price, DateTime PublishingDate)
        {
            if (String.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Der Titel darf nicht NULL sein oder nur aus Leertasten bestehen: ", nameof(title));
            }
            else
            {
                Title = title;
                UpdatePrice(price, Currency.EUR);
                UpdatePublishingDate(PublishingDate);
            }
        }

        /*There is no UpdatePrice without currency - so nobody can change the price and wonder about currency */
        public void UpdatePrice(decimal newPrice, Currency unit)
        {
            
            if (newPrice > 0)
            {
                m_price = new Price(newPrice, unit); 
            }
            else
            {
                throw new ArgumentException("Der Preis muss mehr als 0 sein: ", nameof(newPrice)); 
            }
        }

        public void UpdatePublishingDate(DateTime newDate)
        {
            //TODO: Check NULL and next year in unit test
            if (newDate.Year > 1995 && newDate.Year <= (DateTime.Now.Year)+1)
            {
                m_publishingDate = newDate; 
            }
            else
            {
                throw new ArgumentException("Das Datum muss minimal 1996 betragen und maximal das nächste Jahr: ", nameof(newDate));
            }
        }

        public string Title { get; }

        public Price Price => m_price;

        public DateTime PublishingDate => m_publishingDate;
    }
}
