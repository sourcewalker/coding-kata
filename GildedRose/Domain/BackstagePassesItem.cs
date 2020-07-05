using Gildedrose;

namespace GildedRose.Domain
{
    internal class BackstagePassesItem: ItemBase
    {
        public BackstagePassesItem(Item i): base(i)
        {
        }

        public override Item UpdateQuality()
        {
            if (SellIn <= 0)
            {
                Quality = 0;
            }
            else if (0 < SellIn && SellIn <= 5)
            {
                base.UpdateQuality(3, DegradeType.Increase);
            }
            else if (5 < SellIn && SellIn <= 10)
            {
                base.UpdateQuality(2, DegradeType.Increase);
            }
            else
            {
                base.UpdateQuality(1, DegradeType.Increase);
            }
                
            base.UpdateSellIn(1);
            Deconstruct(out var item);

            return item;
        }
    }
}