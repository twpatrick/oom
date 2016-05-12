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

            //task3 todo 
            var media = new Media[]
            {
                new Dvd("Hör mal wer da hämmert - Staffel 1", 569, 9.99m, Currency.EUR),
                new MusicCD("Chaos and the Calm", "James Bay", 120, 6.90m, Currency.EUR)
            };

            foreach (var mediaItem in media)
            {
                printInformation(mediaItem);
            }

        }

        //just a helper print function
        static void printInformation(Media mediaItem)
        {
            var currency = Currency.EUR;
            Console.WriteLine("Title ist: " + mediaItem.title + "\t Der Preis ist: " + mediaItem.GetPrice(currency) + currency);
        }
    }
}
