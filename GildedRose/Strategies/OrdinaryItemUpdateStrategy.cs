using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Strategies
{
    public class OrdinaryItemUpdateStrategy : IUpdateStrategy
    {
        private IList<IUpdateAdjuster> updateAdjusters;
        public OrdinaryItemUpdateStrategy(IList<IUpdateAdjuster> updateAdjusters)
        {
            this.updateAdjusters = updateAdjusters;
        }
        public void Execute(Item item)
        {
            var qualityChangeAmount = -1;

            if (item.SellIn <= 0)
            {
                qualityChangeAmount--;
            }

            item.Quality += qualityChangeAmount;
            item.SellIn--;

            this.updateAdjusters.ToList().ForEach(updateAdjuster => updateAdjuster.Adjust(item));
        }
    }
}
