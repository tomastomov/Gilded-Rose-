using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Strategies
{
    public class BackstagePassesUpdateStrategy : IUpdateStrategy
    {
        private IList<IUpdateAdjuster> updateAdjusters;
        public BackstagePassesUpdateStrategy(IList<IUpdateAdjuster> updateAdjusters)
        {
            this.updateAdjusters = updateAdjusters;
        }
        public void Execute(Item item)
        {
            var qualityChangeAmount = 0;

            if (item.SellIn > 10)
            {
                qualityChangeAmount = 1;
            }
            else if (item.SellIn <= 10 && item.SellIn > 5)
            {
                qualityChangeAmount = 2;
            }
            else if (item.SellIn <= 5 && item.SellIn > 0)
            {
                qualityChangeAmount = 3;
            }

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
            else
            {
                item.Quality += qualityChangeAmount;
            }
            item.SellIn--;

            this.updateAdjusters.ToList().ForEach(updateAdjuster => updateAdjuster.Adjust(item));
        }
    }
}
