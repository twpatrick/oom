using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Dvd : IMedia
    {
        private Price Price;
        private DateTime PublishingDate;

        public Price Price
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void UpdatePublishingDate(DateTime newDate)
        {
            //TODO: Check NULL 
            if (newDate.Year > 1995 && newDate.Year <= DateTime.Now.Year)
            {
                PublishingDate = newDate; 
            }
        }

        public string Title { get; }
    }
}
