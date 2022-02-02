﻿using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }
        [Test]
        public void TestCheese()
        {
            IList<Item> ExpectedItems = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 6 } };

            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(Items[0].Quality, ExpectedItems[0].Quality);
        }
        [Test]
        public void TestCheeseOver()
        {
            IList<Item> ExpectedItems = new List<Item> { new Item { Name = "Aged Bried", SellIn = 0, Quality = 3 } };

            IList<Item> Items = new List<Item> { new Item { Name = "Aged Bried", SellIn = 0, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(Items[0].Quality, ExpectedItems[0].Quality);
        }

        [Test]
        public void TestCheeseMax()
        {
            IList<Item> ExpectedItems = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 } };

            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 3, Quality = 49 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            app.UpdateQuality();

            Assert.AreEqual(Items[0].Quality, ExpectedItems[0].Quality);
        }
        [Test]
        public void TestConcert5d()
        {
            IList<Item> ExpectedItems = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 8 } };

            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(Items[0].Quality, ExpectedItems[0].Quality);
        }[Test]
        public void TestConcert10d()
        {
            IList<Item> ExpectedItems = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 8, Quality = 7 } };

            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(Items[0].Quality, ExpectedItems[0].Quality);
        }
        [Test]
        public void TestConcertOver()
        {
            IList<Item> ExpectedItems = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 0 } };

            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(Items[0].Quality, ExpectedItems[0].Quality);
        }
        [Test]
        public void TestSulfuras()
        {
            IList<Item> ExpectedItems = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 5 } };

            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(Items[0].Quality, ExpectedItems[0].Quality);
        }
        [Test]
        public void TestCommunOver()
        {
            IList<Item> ExpectedItems = new List<Item> { new Item { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 3 } };

            IList<Item> Items = new List<Item> { new Item { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(Items[0].Quality, ExpectedItems[0].Quality);
        }
        [Test]
        public void TestCommunNegative()
        {
            IList<Item> ExpectedItems = new List<Item> { new Item { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 0 } };

            IList<Item> Items = new List<Item> { new Item { Name = "Elixir of the Mongoose", SellIn = 1, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            app.UpdateQuality();

            Assert.AreEqual(Items[0].Quality, ExpectedItems[0].Quality);
        }
    }
}