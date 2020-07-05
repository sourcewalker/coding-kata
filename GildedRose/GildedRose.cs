using GildedRose.Factory;
using System;
using System.Collections.Generic;

namespace Gildedrose
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                try
                {
                    var itemWrapper = ItemFactory.Create(Items[i]);
                    Items[i] = itemWrapper.UpdateQuality();
                }
                catch (ArgumentOutOfRangeException e)
                {
                    continue;
                }
            }
        }
    }
}
