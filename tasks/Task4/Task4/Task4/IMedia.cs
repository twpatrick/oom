using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /* I think abstract class would be better but T3.1 expect an interface */
    public interface IMedia
    {
        string Title { get; }

        Price Price { get; }

        DateTime PublishingDate { get; } 
    }
}
