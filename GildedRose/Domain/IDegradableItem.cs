namespace GildedRose.Domain
{
    public interface IDegradableItem
    {
        void UpdateQuality(int updateValue, DegradeType updateType);
    }
}
