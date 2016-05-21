using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Dvd : MediaAbstract
    {
        private uint m_runtime; 

        public Dvd(string title, decimal price, Currency unit, DateTime publishingDate, uint runtime)
        {
            UpdateTitle(title);
            UpdatePrice(price, unit);
            UpdatePublishingDate(publishingDate);
            UpdateRuntime(runtime); 
        }

        private void UpdateRuntime(uint runtime)
        {
            if (runtime > 0)
            {
                m_runtime = runtime; 
            }
            else
            {
                throw new ArgumentException("Die Laufzeit muss länger als 0 Minuten sein: ", nameof(runtime)); 
            }
        }

        public uint Runtime => m_runtime; 
    }
}
