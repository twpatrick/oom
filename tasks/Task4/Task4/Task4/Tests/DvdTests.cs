using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task4.Tests
{
    [TestFixture]
    class DvdTests
    {
        [Test]
        public void CanCreateDvd()
        {
            var x = new Dvd("Dr. House - Staffel 1", 12.99m, Currency.EUR, new DateTime(2006, 12, 24), 925);
            Assert.IsTrue(x.Title == "Dr. House - Staffel 1");
            Assert.IsTrue((decimal)x.Price.Amount == 12.99m);
            Assert.IsTrue(x.PublishingDate == new DateTime(2006, 12, 24));
            Assert.IsTrue(x.Runtime == 925); 
        }

        [Test]
        public void CannotCreateDvdWithEmptyTitle()
        {
            Assert.Catch(() =>
            {
                var x = new Dvd("", 12.99m, Currency.EUR, new DateTime(2006, 12, 24), 925);
            }); 
        }

        [Test]
        public void CannotCreateDvdWithEmptyTitleWhitespace()
        {
            Assert.Catch(() =>
            {
                var x = new Dvd("         ", 12.99m, Currency.EUR, new DateTime(2006, 12, 24), 925);
            });
        }

        [Test]
        public void CannotCreateDvdWithZeroPrice()
        {
            Assert.Catch(() =>
            {
                var x = new Dvd("Dr. House - Staffel 1", 0m, Currency.EUR, new DateTime(2006, 12, 24), 925);
            });
        }

        [Test]
        public void CannotCreateDvdWithNegativePrice()
        {
            Assert.Catch(() =>
            {
                var x = new Dvd("Dr. House - Staffel 1", -33.3m, Currency.EUR, new DateTime(2006, 12, 24), 925);
            });
        }

        [Test]
        public void CanCreateDvdWithPublishingDateFuture()
        {
            var x = new Dvd("Dr. House - Staffel 1", 12.99m, Currency.EUR, DateTime.Now.AddMonths(11), 925);
            Assert.True(x.GetType() == typeof(Dvd)); 
        }

        [Test]
        public void CannotCreateDvdWithPublishingDateFuture()
        {
            Assert.Catch(() =>
            {
                var x = new Dvd("Dr. House - Staffel 1", 12.99m, Currency.EUR, DateTime.Now.AddMonths(13), 925);
            });
        }

        [Test]
        public void CannotCreateDvdWithZeroRuntime()
        {
            Assert.Catch(() =>
            {
                var x = new Dvd("Dr. House - Staffel 1", 12.99m, Currency.EUR, new DateTime(2006, 12, 24), 0);
            });
        }
    }
}
