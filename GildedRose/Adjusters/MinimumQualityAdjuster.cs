using static GildedRoseKata.Constants;

namespace GildedRoseKata.Adjusters
{
    public class MinimumQualityAdjuster : IUpdateAdjuster
    {
        public void Adjust(Item item)
        {
            if (item.Quality < MIN_ITEM_QUALITY)
            {
                item.Quality = MIN_ITEM_QUALITY;
            }
        }
    }
}
