using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;


namespace GildedRoseTests
{
    [TestFixture]
    public class GildedRoseTest
    {
        // Once the sell by date has passed, Quality degrades twice as fast
        [Test]
        public void UpdateQuality_PastSellByDate_DegradesTwiceAsFast()
        {
            var items = new List<Item> { new Item { Name = "Normal Item", SellIn = 0, Quality = 10 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual("Normal Item", items[0].Name);
            Assert.AreEqual(-1, items[0].SellIn);
            Assert.AreEqual(8, items[0].Quality);
        }

        // The Quality of an item is never negative
        [Test]
        public void UpdateQuality_QualityNeverNegative()
        {
            var items = new List<Item> { new Item { Name = "Normal Item", SellIn = 5, Quality = 0 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual("Normal Item", items[0].Name);
            Assert.AreEqual(4, items[0].SellIn);
            Assert.AreEqual(0, items[0].Quality);
        }

        // “Aged Brie” actually increases in Quality the older it gets
        [Test]
        public void UpdateQuality_AgedBrie_IncreasesQualityAsItGetsOlder()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual("Aged Brie", items[0].Name);
            Assert.AreEqual(4, items[0].SellIn);
            Assert.AreEqual(11, items[0].Quality);
        }

        // The Quality of an item is never more than 50
        [Test]
        public void UpdateQuality_AgedBrie_QualityNeverMoreThan50()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 50 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual("Aged Brie", items[0].Name);
            Assert.AreEqual(4, items[0].SellIn);
            Assert.AreEqual(50, items[0].Quality);
        }

        // “Sulfuras”, being a legendary item, never has to be sold or decreases in Quality
        [Test]
        public void UpdateQuality_Sulfuras_LegendaryItemNeverChanges()
        {
            var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual("Sulfuras, Hand of Ragnaros", items[0].Name);
            Assert.AreEqual(5, items[0].SellIn);
            Assert.AreEqual(80, items[0].Quality);
        }
    }
}
