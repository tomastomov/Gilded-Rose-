using static GildedRoseKata.Constants;

namespace GildedRoseKata.Adjusters
{
    public class MaximumQualityAdjuster : IUpdateAdjuster
    {
        public void Adjust(Item item)
        {
            if (item.Quality > MAX_ITEM_QUALITY)
            {
                item.Quality = MAX_ITEM_QUALITY;
            }
        }
    }
}
