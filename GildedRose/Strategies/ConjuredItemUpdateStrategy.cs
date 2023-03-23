using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Strategies
{
    public class ConjuredItemUpdateStrategy : IUpdateStrategy
    {
        private IList<IUpdateAdjuster> updateAdjusters;
        public ConjuredItemUpdateStrategy(IList<IUpdateAdjuster> updateAdjusters)
        {
            this.updateAdjusters = updateAdjusters;
        }
        public void Execute(Item item)
        {
            var qualityChangeAmount = -2;

            if (item.SellIn <= 0)
            {
                qualityChangeAmount *= 2;
            }

            item.Quality += qualityChangeAmount;
            item.SellIn--;

            updateAdjusters.ToList().ForEach(updateAdjuster => updateAdjuster.Adjust(item));
        }
    }
}
