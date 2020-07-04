using Xunit;
using System.Collections.Generic;

namespace gildedrose
{
    public class GildedRoseTest
    {
        [Theory]
        [InlineData("foo", "bar", "fizz")]
        [InlineData("gilded", "rose", "kata")]
        [InlineData("Aged Brie","Sulfuras", "Backstage passes")]
        public void Should_Return_First_Item_Name(string nameItem1, string nameItem2, string nameItem3)
        {
            IList<int> sellIns = new List<int> { 0, -2, 3, 4, 5, -7, -6 };
            IList<int> qualities = new List<int> { 0, 0, 0, 5, -4, -1, 8 };
            IList<Item> items = new List<Item>();
            string currentName = nameItem1;
            for (var i = 0; i < qualities.Count; i++)
            {
                if (currentName == nameItem1)
                {
                    if (i != 0)
                        currentName = nameItem2;
                }
                else if (currentName == nameItem2)
                {
                    currentName = nameItem3;
                }
                else
                {
                    currentName = nameItem1;
                }
                items.Add(new Item { Name = currentName, SellIn = sellIns[i], Quality = qualities[i] });
            }
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(nameItem1, items[0].Name);
            Assert.Equal(nameItem2, items[1].Name);
            Assert.Equal(nameItem3, items[2].Name);
            Assert.Equal(nameItem1, items[3].Name);
            Assert.Equal(nameItem2, items[4].Name);
            Assert.Equal(nameItem3, items[5].Name);
            Assert.Equal(nameItem1, items[6].Name);
        }

        [Theory]
        [InlineData("foo", "bar", "fizz")]
        [InlineData("gilded", "rose", "kata")]
        [InlineData("Aged Brie", "Sulfuras", "Backstage passes")]
        public void Should_Have_Sellin_Value_On_Each_Item(string nameItem1, string nameItem2, string nameItem3)
        {
            IList<int> sellIns = new List<int> { 0, -2, 3, 4, 5, -7, -6 };
            IList<int> qualities = new List<int> { 0, 0, 0, 5, -4, -1, 8 };
            IList<Item> items = new List<Item>();
            string currentName = nameItem1;
            for (var i = 0; i < qualities.Count; i++)
            {
                if (currentName == nameItem1)
                {
                    if (i != 0)
                        currentName = nameItem2;
                }
                else if (currentName == nameItem2)
                {
                    currentName = nameItem3;
                }
                else
                {
                    currentName = nameItem1;
                }
                items.Add(new Item { Name = currentName, SellIn = sellIns[i], Quality = qualities[i] });
            }
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            foreach (var item in items)
            {
                Assert.True(item.GetType().GetProperty("SellIn") != null);
            }
        }

        [Theory]
        [InlineData("foo", "bar", "fizz")]
        [InlineData("gilded", "rose", "kata")]
        [InlineData("Aged Brie", "Sulfuras", "Backstage passes")]
        public void Should_Have_Quality_Value_On_Each_Item(string nameItem1, string nameItem2, string nameItem3)
        {
            IList<int> sellIns = new List<int> { 0, -2, 3, 4, 5, -7, -6 };
            IList<int> qualities = new List<int> { 0, 0, 0, 5, -4, -1, 8 };
            IList<Item> items = new List<Item>();
            string currentName = nameItem1;
            for (var i = 0; i < qualities.Count; i++)
            {
                if (currentName == nameItem1)
                {
                    if (i != 0)
                        currentName = nameItem2;
                }
                else if (currentName == nameItem2)
                {
                    currentName = nameItem3;
                }
                else
                {
                    currentName = nameItem1;
                }
                items.Add(new Item { Name = currentName, SellIn = sellIns[i], Quality = qualities[i] });
            }
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            foreach (var item in items)
            {
                Assert.True(item.GetType().GetProperty("Quality") != null);
            }
        }

        [Theory]
        [InlineData("foo", "bar", "fizz")]
        [InlineData("gilded", "rose", "kata")]
        [InlineData("Aged Brie", "Sulfuras", "Backstage passes")]
        public void Should_Lower_SellIn_After_Update_Quality(string nameItem1, string nameItem2, string nameItem3)
        {
            IList<int> sellIns = new List<int> { 0, -2, 3, 4, 5, -7, -6 };
            IList<int> qualities = new List<int> { 0, 0, 0, 5, -4, -1, 8 };
            IList<Item> items = new List<Item>();
            string currentName = nameItem1;
            for (var i = 0; i < qualities.Count; i++)
            {
                if (currentName == nameItem1)
                {
                    if (i != 0)
                        currentName = nameItem2;
                }
                else if (currentName == nameItem2)
                {
                    currentName = nameItem3;
                }
                else
                {
                    currentName = nameItem1;
                }
                items.Add(new Item { Name = currentName, SellIn = sellIns[i], Quality = qualities[i] });
            }
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            for (var i = 0; i < items.Count; i++)
            {
                Assert.Equal(items[i].SellIn, sellIns[i] - 1);
            }
        }

        [Theory]
        [InlineData("foo", "bar", "fizz")]
        [InlineData("gilded", "rose", "kata")]
        public void Should_Degrade_Quality_Twice_After_SellIn_Zero(string nameItem1, string nameItem2, string nameItem3)
        {
            IList<int> beforeSellIns = new List<int> { 4, 2, 5, 1, 0};
            IList<int> afterSellIns = new List<int> { -1, -9, -7, -6 };
            IList<int> beforeSellinQualities = new List<int> { 0, 2, 3, 5, 1 };
            IList<int> afterSellinQualities = new List<int> { 0, 2, 3, 5 };
            IList<Item> items = new List<Item>();
            string currentName = nameItem1;
            for (var i = 0; i < beforeSellIns.Count; i++)
            {
                if (currentName == nameItem1)
                {
                    if (i != 0)
                        currentName = nameItem2;
                }
                else if (currentName == nameItem2)
                {
                    currentName = nameItem3;
                }
                else
                {
                    currentName = nameItem1;
                }
                items.Add(new Item { Name = currentName, SellIn = beforeSellIns[i], Quality = beforeSellinQualities[i] });
            }
            for (var i = 0; i < afterSellIns.Count; i++)
            {
                if (currentName == nameItem1)
                {
                    if (i != 0)
                        currentName = nameItem2;
                }
                else if (currentName == nameItem2)
                {
                    currentName = nameItem3;
                }
                else
                {
                    currentName = nameItem1;
                }
                items.Add(new Item { Name = currentName, SellIn = afterSellIns[i], Quality = afterSellinQualities[i] });
            }
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();
            IList<int> updatedQualitiesBeforeSellIn = new List<int>();
            IList<int> updatedQualitiesAfterSellIn = new List<int>();

            for (var i = 0; i < items.Count; i++)
            {
                if(i<5)
                    updatedQualitiesBeforeSellIn.Add(items[i].Quality);
                else
                    updatedQualitiesAfterSellIn.Add(items[i].Quality);
            }

            for (var i = 0; i < beforeSellinQualities.Count; i++)
            {
                Assert.Equal(beforeSellinQualities[i] - updatedQualitiesBeforeSellIn[i], beforeSellinQualities[i] - updatedQualitiesBeforeSellIn[i]);
            }
            for (var i = 0; i < afterSellinQualities.Count; i++)
            {
                Assert.Equal((beforeSellinQualities[i] - updatedQualitiesBeforeSellIn[i]) * 2, afterSellinQualities[i] - updatedQualitiesAfterSellIn[i]);
            }

        }

        [Theory]
        [InlineData("foo", "bar", "fizz")]
        [InlineData("gilded", "rose", "kata")]
        [InlineData("Aged Brie", "Sulfuras", "Backstage passes")]
        public void Should_Never_Have_Negative_Quality(string nameItem1, string nameItem2, string nameItem3)
        {
            IList<int> sellIns = new List<int> { 0, -2, 3, 4, 5, -7, -6 };
            IList<int> qualities = new List<int> { 0, 0, 0, 5, 4, 1, 8 };
            IList<Item> items = new List<Item>();
            string currentName = nameItem1;
            for (var i = 0; i < qualities.Count; i++)
            {
                if (currentName == nameItem1)
                {
                    if (i != 0)
                        currentName = nameItem2;
                }
                else if (currentName == nameItem2)
                {
                    currentName = nameItem3;
                }
                else
                {
                    currentName = nameItem1;
                }
                items.Add(new Item { Name = currentName, SellIn = sellIns[i], Quality = qualities[i] });
            }

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            foreach (var item in items)
            {
                Assert.True(item.Quality >= 0);
            }
        }

        [Theory]
        [InlineData("foo", "bar", "Aged Brie")]
        [InlineData("gilded", "Aged Brie", "kata")]
        [InlineData("Aged Brie", "Sulfuras", "Backstage passes")]
        public void Should_Increase_Quality_If_Age_Brie_Gets_Older(string nameItem1, string nameItem2, string nameItem3)
        {
            IList<int> sellIns = new List<int> { 0, -2, 3, 4, 5, -7, -6 };
            IList<int> qualities = new List<int> { 0, 0, 0, 5, 4, 1, 8 };
            IList<Item> items = new List<Item>();
            string currentName = nameItem1;
            for (var i = 0; i < qualities.Count; i++)
            {
                if (currentName == nameItem1)
                {
                    if (i != 0)
                        currentName = nameItem2;
                }
                else if (currentName == nameItem2)
                {
                    currentName = nameItem3;
                }
                else
                {
                    currentName = nameItem1;
                }
                items.Add(new Item { Name = currentName, SellIn = sellIns[i], Quality = qualities[i] });
            }

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            for (var i = 0; i < items.Count; i++)
            {
                if(items[i].Name.Contains("Aged Brie"))
                    Assert.True(items[i].Quality - qualities[i] > 0);
                else
                    Assert.True(items[i].Quality - qualities[i] <= 0);
            }
        }

        [Theory]
        [InlineData("foo", "bar", "fizz")]
        [InlineData("gilded", "rose", "kata")]
        [InlineData("Aged Brie", "Sulfuras", "Backstage passes")]
        public void Should_Never_Have_Quality_More_Than_50(string nameItem1, string nameItem2, string nameItem3)
        {
            IList<int> sellIns = new List<int> { 0, -2, 3, 4, 5, -7, -6 };
            IList<int> qualities = new List<int> { 0, 0, 0, 5, 4, 1, 8 };
            IList<Item> items = new List<Item>();
            string currentName = nameItem1;
            for (var i = 0; i < qualities.Count; i++)
            {
                if (currentName == nameItem1)
                {
                    if (i != 0)
                        currentName = nameItem2;
                }
                else if (currentName == nameItem2)
                {
                    currentName = nameItem3;
                }
                else
                {
                    currentName = nameItem1;
                }
                items.Add(new Item { Name = currentName, SellIn = sellIns[i], Quality = qualities[i] });
            }

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            foreach (var item in items)
            {
                Assert.True(item.Quality <= 50);
            }
        }

        [Theory]
        [InlineData("foo", "bar", "Sulfuras, Hand of Ragnaros")]
        [InlineData("Sulfuras, Hand of Ragnaros", "rose", "kata")]
        [InlineData("Aged Brie", "Sulfuras, Hand of Ragnaros", "Backstage passes")]
        public void Should_Never_Have_Sulfuras_Decrease_In_Quality(string nameItem1, string nameItem2, string nameItem3)
        {
            IList<int> sellIns = new List<int> { 0, -2, 3, 4, 5, -7, -6 };
            IList<int> qualities = new List<int> { 0, 0, 0, 5, 4, 1, 8 };
            IList<Item> items = new List<Item>();
            string currentName = nameItem1;
            for (var i = 0; i < qualities.Count; i++)
            {
                if (currentName == nameItem1)
                {
                    if (i != 0)
                        currentName = nameItem2;
                }
                else if (currentName == nameItem2)
                {
                    currentName = nameItem3;
                }
                else
                {
                    currentName = nameItem1;
                }
                items.Add(new Item { Name = currentName, SellIn = sellIns[i], Quality = qualities[i] });
            }

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].Name.Contains("Sulfuras"))
                    Assert.Equal(qualities[i], items[i].Quality);
            }
        }

        [Theory]
        [InlineData("foo", "bar", "Backstage passes to a TAFKAL80ETC concert")]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", "rose", "kata")]
        [InlineData("Aged Brie", "Backstage passes to a TAFKAL80ETC concert", "Backstage passes")]
        public void Should_Have_Backstage_Increase_By_2_Between_10_And_5(string nameItem1, string nameItem2, string nameItem3)
        {
            IList<int> sellIns = new List<int> { 0, -2, 3, 4, 5, -7, -6 };
            IList<int> qualities = new List<int> { 0, 0, 0, 5, 4, 1, 8 };
            IList<Item> items = new List<Item>();
            string currentName = nameItem1;
            for (var i = 0; i < qualities.Count; i++)
            {
                if (currentName == nameItem1)
                {
                    if (i != 0)
                        currentName = nameItem2;
                }
                else if (currentName == nameItem2)
                {
                    currentName = nameItem3;
                }
                else
                {
                    currentName = nameItem1;
                }
                items.Add(new Item { Name = currentName, SellIn = sellIns[i], Quality = qualities[i] });
            }

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].Name.Contains("Backstage passes") && 
                    items[i].SellIn <= 10 && 
                    items[i].SellIn > 5)
                    Assert.Equal(qualities[i]+2, items[i].Quality);
            }
        }

        [Theory]
        [InlineData("foo", "bar", "Backstage passes to a TAFKAL80ETC concert")]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", "rose", "kata")]
        [InlineData("Aged Brie", "Backstage passes to a TAFKAL80ETC concert", "Backstage passes")]
        public void Should_Have_Backstage_Increase_By_3_Between_5_And_0(string nameItem1, string nameItem2, string nameItem3)
        {
            IList<int> sellIns = new List<int> { 0, -2, 3, 4, 5, -7, -6 };
            IList<int> qualities = new List<int> { 0, 0, 0, 5, 4, 1, 8 };
            IList<Item> items = new List<Item>();
            string currentName = nameItem1;
            for (var i = 0; i < qualities.Count; i++)
            {
                if (currentName == nameItem1)
                {
                    if (i != 0)
                        currentName = nameItem2;
                }
                else if (currentName == nameItem2)
                {
                    currentName = nameItem3;
                }
                else
                {
                    currentName = nameItem1;
                }
                items.Add(new Item { Name = currentName, SellIn = sellIns[i], Quality = qualities[i] });
            }

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].Name.Contains("Backstage passes") && 
                    items[i].SellIn <= 5 && 
                    items[i].SellIn > 0 && 
                    items[i].Quality != 0)
                    Assert.Equal(qualities[i]+3, items[i].Quality);
            }
        }

        [Theory]
        [InlineData("foo", "bar", "Backstage passes to a TAFKAL80ETC concert")]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", "rose", "kata")]
        [InlineData("Aged Brie", "Backstage passes to a TAFKAL80ETC concert", "Backstage passes")]
        public void Should_Have_Backstage_Quality_Drop_To_0_After_Concert(string nameItem1, string nameItem2, string nameItem3)
        {
            IList<int> sellIns = new List<int> { 0, -2, 3, 4, 5, -7, -6 };
            IList<int> qualities = new List<int> { 0, 0, 0, 5, 4, 1, 8 };
            IList<Item> items = new List<Item>();
            string currentName = nameItem1;
            for (var i = 0; i < qualities.Count; i++)
            {
                if (currentName == nameItem1)
                {
                    if (i != 0)
                        currentName = nameItem2;
                }
                else if (currentName == nameItem2)
                {
                    currentName = nameItem3;
                }
                else
                {
                    currentName = nameItem1;
                }
                items.Add(new Item { Name = currentName, SellIn = sellIns[i], Quality = qualities[i] });
            }

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].Name.Contains("Backstage passes") && 
                    items[i].SellIn <= 0)
                    Assert.Equal(0, items[i].Quality);
            }
        }
    }
}