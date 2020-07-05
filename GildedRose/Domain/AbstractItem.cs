using Gildedrose;
using System;

namespace GildedRose.Domain
{
    public abstract class AbstractItem : IDegradableItem, ISellableItem
    {
        private const int QualityMinValue = 0;
        private const int QualityMaxValue = 50;
        private const string QualityValidationExceptionMessage = "Item quality is not acceptable.";
        private const string QualityOperationExceptionMessage = "Operation on Quality is not supported";

        public AbstractItem(Item item)
        {
            CheckQuality(item.Quality);

            Name = item.Name;
            Quality = item.Quality;
            SellIn = item.SellIn;
        }

        public AbstractItem(string name, int sellIn, int quality)
        {
            CheckQuality(quality);

            Name = name;
            Quality = quality;
            SellIn = sellIn;
        }

        public void Deconstruct(out Item item)
        {
            item = new Item
            {
                Name = Name,
                SellIn = SellIn,
                Quality = Quality
            };
        }

        public void Deconstruct(out string name, out int sellIn, out int quality)
        {
            name = Name;
            sellIn = SellIn;
            quality = Quality;
        }

        protected string Name { get; set; }
        protected int SellIn { get; set; }
        protected int Quality { get; set; }

        public virtual void UpdateQuality(int updateValue, DegradeType updateType)
        {
            CheckQuality(Quality);

            if (updateType == DegradeType.Decrease)
            {
                Quality = Quality >= updateValue ? Quality - updateValue : QualityMinValue;
            }
            else if (updateType == DegradeType.Increase)
            {
                Quality = Quality + updateValue <= QualityMaxValue ? Quality + updateValue : QualityMaxValue;
            }
            else
            {
                throw new InvalidOperationException(QualityOperationExceptionMessage);
            }
            
        }

        public virtual void UpdateSellIn(int updateValue)
        {
            SellIn = SellIn - updateValue;
        }

        private void CheckQuality(int value)
        {
            if (value < QualityMinValue || value > QualityMaxValue)
                throw new ArgumentOutOfRangeException(QualityValidationExceptionMessage);
        }
    }
}
