using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {

            tasks();
            json(); 
        }

        static private void json()
        {
            var dvd1 = new Dvd("Dr. House - Staffel 1", 12.99m, Currency.EUR, new DateTime(2006, 12, 24), 925);

            Console.WriteLine(JsonConvert.SerializeObject(dvd1, Formatting.Indented));

            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            Console.WriteLine(JsonConvert.SerializeObject(dvd1, settings));

            var text = JsonConvert.SerializeObject(dvd1,settings);
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, "dvd.json");
            File.WriteAllText(filename, text);

            var textFromFile = File.ReadAllText(filename);
            var dvd2 = JsonConvert.DeserializeObject<Dvd>(textFromFile,settings);
            Console.WriteLine("Titel ist: " + dvd2.Title); 
        }

        static private void tasks()
        {
            //create dvd array 
            var dvds = new[]
            {
                new Dvd("Dr. House - Staffel 1", 12.99m, Currency.EUR, new DateTime(2006, 12, 24), 925),
                new Dvd("Californation - Staffel 2", 9.99m, Currency.EUR, new DateTime(2007, 08, 30),324),
                new Dvd("Game of Thrones - Staffel 6", 40.50m, Currency.EUR, DateTime.Now, 524),
            };

            //print all dvds in array, change the value, and print it again
            foreach (var dvd in dvds)
            {
                printInformation(dvd);
                dvd.UpdatePrice(100, Currency.EUR);
                printInformation(dvd);
            }

            //task3 todo 
            var media = new MediaAbstract[]
            {
                new Dvd("Dr. House - Staffel 1", 12.99m, Currency.EUR, new DateTime(2006, 12, 24), 925),
                new MusicCd("Highway to hell", 9.99m, Currency.USD, new DateTime(2014, 07, 01), "AC/DC")
            };

            foreach (var mediaItem in media)
            {
                printInformation(mediaItem);
            }
        }

        //just a helper print function
        static private void printInformation(MediaAbstract mediaItem)
        {
            Console.WriteLine("Title ist: " + mediaItem.Title + "\t kostet: " + mediaItem.Price.Amount + "\t wurde veröffentlicht am: " + mediaItem.PublishingDate); 
        }
    }
}
