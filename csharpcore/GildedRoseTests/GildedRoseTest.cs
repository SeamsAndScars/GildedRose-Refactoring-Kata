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

        
    }
}
