using Gildedrose;

namespace GildedRose.Domain
{
    public class ItemBase : AbstractItem
    {
        public ItemBase(Item item) : base(item)
        {
        }

        public virtual Item UpdateQuality()
        {
            if(SellIn > 0)
                base.UpdateQuality(1, DegradeType.Decrease);
            else
                base.UpdateQuality(2, DegradeType.Decrease);
            base.UpdateSellIn(1);
            Deconstruct(out var item);

            return item;
        }
    }
}
