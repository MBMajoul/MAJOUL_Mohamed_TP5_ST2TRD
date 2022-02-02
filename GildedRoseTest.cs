using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Commun { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }
        [Test]
        public void QualityCheeseBeforeExpiration()
        {
            IList<Item> ExpectedItems = new List<Item> { new Cheese { Name = "Aged Brie", SellIn = 1, Quality = 6 } };

            IList<Item> Items = new List<Item> { new Cheese { Name = "Aged Brie", SellIn = 2, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(Items[0].Quality, ExpectedItems[0].Quality);
        }
        [Test]
        public void QualityCheeseAfterExpiration()
        {
            IList<Item> ExpectedItems = new List<Item> { new Cheese { Name = "Aged Bried", SellIn = -1, Quality = 6 } };

            IList<Item> Items = new List<Item> { new Cheese { Name = "Aged Bried", SellIn = 0, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(Items[0].Quality, ExpectedItems[0].Quality);
        }

        [Test]
        public void QualityMax50()
        {
            IList<Item> ExpectedItems = new List<Item> { new Cheese { Name = "Aged Brie", SellIn = 1, Quality = 50 } };

            IList<Item> Items = new List<Item> { new Cheese { Name = "Aged Brie", SellIn = 3, Quality = 49 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            app.UpdateQuality();

            Assert.AreEqual(Items[0].Quality, ExpectedItems[0].Quality);
        }
        [Test]
        public void QualityConcert5d()
        {
            IList<Item> ExpectedItems = new List<Item> { new Concert { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 8 } };

            IList<Item> Items = new List<Item> { new Concert { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(Items[0].Quality, ExpectedItems[0].Quality);
        }
        [Test]
        public void QualityConcert10d()
        {
            IList<Item> ExpectedItems = new List<Item> { new Concert { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 8, Quality = 7 } };

            IList<Item> Items = new List<Item> { new Concert { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(Items[0].Quality, ExpectedItems[0].Quality);
        }
        [Test]
        public void QualityConcert7d()
        {
            IList<Item> ExpectedItems = new List<Item> { new Concert { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 13 } };

            IList<Item> Items = new List<Item> { new Concert { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 7, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();

            Assert.AreEqual(Items[0].SellIn, ExpectedItems[0].SellIn);
        }
        [Test]
        public void QualityNullConcertExpiration()
        {
            IList<Item> ExpectedItems = new List<Item> { new Concert { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 0 } };

            IList<Item> Items = new List<Item> { new Concert { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(Items[0].Quality, ExpectedItems[0].Quality);
        }
        [Test]
        public void QualityConstLegendary()
        {
            IList<Item> ExpectedItems = new List<Item> { new Legendary { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 5 } };

            IList<Item> Items = new List<Item> { new Legendary { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(Items[0].Quality, ExpectedItems[0].Quality);
        }
        [Test]
        public void NoExpirationLegendary()
        {
            IList<Item> ExpectedItems = new List<Item> { new Legendary { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 5 } };

            IList<Item> Items = new List<Item> { new Legendary { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(Items[0].SellIn, ExpectedItems[0].SellIn);
        }
        [Test]
        public void QualityDecreaseExpiration()
        {
            IList<Item> ExpectedItems = new List<Item> { new Commun { Name = "Elixir of the Mongoose", SellIn = -1, Quality = 3 } };

            IList<Item> Items = new List<Item> { new Commun { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(Items[0].Quality, ExpectedItems[0].Quality);
        }
        [Test]
        public void QualityNonNegative()
        {
            IList<Item> ExpectedItems = new List<Item> { new Commun { Name = "Elixir of the Mongoose", SellIn = -1, Quality = 0 } };

            IList<Item> Items = new List<Item> { new Commun { Name = "Elixir of the Mongoose", SellIn = 1, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            app.UpdateQuality();

            Assert.AreEqual(Items[0].Quality, ExpectedItems[0].Quality);
        }
    }
}
