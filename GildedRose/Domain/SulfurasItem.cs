using Gildedrose;

namespace GildedRose.Domain
{
    internal class SulfurasItem : ItemBase
    {
        public SulfurasItem(Item i) : base(i)
        {
        }

        public override Item UpdateQuality()
        {
            Deconstruct(out var item);
            return item;
        }
    }
}