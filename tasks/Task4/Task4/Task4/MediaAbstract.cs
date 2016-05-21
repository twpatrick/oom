using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class MediaAbstract : IMedia
    {
        private Price m_price;
        private DateTime m_publishingDate;
        private string m_title; 

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

        public void UpdateTitle(string title)
        {
            if (!(String.IsNullOrWhiteSpace(title)))
            {
                m_title = title; 
            }
            else
            {
                throw new ArgumentException("Der Title darf nicht leer oder nur aus Whitespaces bestehen: ", nameof(title));

            }
        }

        public void UpdatePublishingDate(DateTime newDate)
        {
            //TODO: Check NULL and next year in unit test
            if (newDate.Year > 1995 && newDate.Year <= (DateTime.Now.Year) + 1)
            {
                m_publishingDate = newDate;
            }
            else
            {
                throw new ArgumentException("Das Datum muss minimal 1996 betragen und maximal das nächste Jahr: ", nameof(newDate));
            }
        }

        public string Title => m_title;

        public Price Price => m_price;

        public DateTime PublishingDate => m_publishingDate;
    }
}
