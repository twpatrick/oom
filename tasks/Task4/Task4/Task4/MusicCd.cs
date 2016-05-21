using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class MusicCd : MediaAbstract
    {
        private string m_author; 

        public MusicCd(string title, decimal price, Currency unit, DateTime publishingDate, string author)
        {
            UpdateTitle(title);
            UpdatePrice(price, unit);
            UpdatePublishingDate(publishingDate);
            UpdateAuthor(author); 
        }

        private void UpdateAuthor(string author)
        {
            if (!(string.IsNullOrWhiteSpace(author)))
            {
                m_author = author; 
            }
            else
            {
                throw new ArgumentException("Der Autor darf nicht leer sein oder nur aus Leerzeichen bestehen: ", nameof(author)); 
            }
        }

        public string Author => m_author; 
    }
}
