using Gildedrose;

namespace GildedRose.Domain
{
    internal class ConjuredItem : ItemBase
    {
        public ConjuredItem(Item i) : base(i)
        {
        }

        public override Item UpdateQuality()
        {
            if (SellIn >= 0)
                base.UpdateQuality(2, DegradeType.Decrease);
            else
                base.UpdateQuality(4, DegradeType.Decrease);
            base.UpdateSellIn(1);
            Deconstruct(out var item);

            return item;
        }
    }
}