using Gildedrose;
using GildedRose.Domain;

namespace GildedRose.Factory
{
    public static class ItemFactory
    {
        public static ItemBase Create(Item item) =>
            item switch
            {
                Item i when i.Name.Contains("Aged Brie") => new AgedBrieItem(i),
                Item i when i.Name.Contains("Sulfuras") => new SulfurasItem(i),
                Item i when i.Name.Contains("Backstage passes") => new BackstagePassesItem(i),
                Item i when i.Name.Contains("Conjured") => new ConjuredItem(i),
                _ => new ItemBase(item)
            };
    }
}