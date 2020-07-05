using Gildedrose;

namespace GildedRose.Domain
{
    class AgedBrieItem : ItemBase
    {
        public AgedBrieItem(Item i) : base(i)
        {
        }

        public override Item UpdateQuality()
        {
            if (SellIn > 0)
                base.UpdateQuality(1, DegradeType.Increase);
            else
                base.UpdateQuality(2, DegradeType.Increase);
            base.UpdateSellIn(1);
            Deconstruct(out var item);

            return item;
        }
    }
}
