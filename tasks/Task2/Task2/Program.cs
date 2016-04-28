using System;

namespace Task2
{
    class Program
    {

        static void Main(string[] args)
        {
            //create dvd array 
            var dvds = new[]
            {
                new Dvd("Dr. House - Staffel 1", 925, 12.99m, Currency.EUR),
                new Dvd("Californation - Staffel 2", 324, 9.99m, Currency.EUR),
                new Dvd("Game of Thrones - Staffel 4", 524, 26.97m, Currency.EUR),
            };

            //print all dvds in array, change the value, and print it again
            foreach(var dvd in dvds)
            {
                printInformation(dvd);
                dvd.UpdatePrice(dvd.GetPrice(Currency.EUR) + 5m, Currency.EUR);
                printInformation(dvd);
            }

        }

        //just a helper print function
        static void printInformation(Dvd dvd)
        {
            var currency = Currency.EUR;
            Console.WriteLine("Title ist: " + dvd.title + "\t Spielzeit ist: " + dvd.playingTime + "\t Der Preis ist: " + dvd.GetPrice(currency) + currency);
        }
    }
}
