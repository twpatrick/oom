using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Dvd a = new Dvd("Hallo", 9.99m, DateTime.Now);
            Console.WriteLine(a.Title); 
        }
    }
}
