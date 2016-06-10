using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace Task4
{
    public static class Subject
    {
        public static void Run()
        {

            //some dvds for testing.. 
            var dvdArray = new Dvd[]
            {
                new Dvd("moin", new Price(1000, Currency.EUR), DateTimeOffset.Now, 100),
                new Dvd("moin", new Price(2000, Currency.EUR), DateTimeOffset.Now, 100),
                new Dvd("moin", new Price(3000, Currency.EUR), DateTimeOffset.Now, 100),
                new Dvd("moin", new Price(4000, Currency.EUR), DateTimeOffset.Now, 100),
                new Dvd("moin", new Price(5000, Currency.EUR), DateTimeOffset.Now, 100),
                new Dvd("moin", new Price(6000, Currency.EUR), DateTimeOffset.Now, 100),
                new Dvd("moin", new Price(7000, Currency.EUR), DateTimeOffset.Now, 100)
            };

            var source = new Subject<Dvd>();

            source
                .Where(x => x.Price.Amount <= 4000) //output only price.amount <= 4000
                .Subscribe(x => Console.WriteLine($"Empfangen: {x.Price.Amount}"))
                ;

            int i = 0; 
            var t = new Thread(() => //thread push dvds into source
            {
                while (i < dvdArray.Length)
                {
                    source.OnNext(dvdArray[i]);
                    Console.WriteLine($"Geschickt: {dvdArray[i].Price.Amount}");
                    i++;
                }
            });

            t.Start();
        }
    }
}
