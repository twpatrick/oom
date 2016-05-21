using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    interface IMedia
    {
        string Title { get; }

        Price Price { get; }

        DateTime PublishingDate { get; } 
    }
}
