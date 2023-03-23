using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    public class ItemUpdater : IItemUpdater
    {
        private readonly IUpdateStrategyResolver strategyResolver;
        public ItemUpdater(IUpdateStrategyResolver strategyResolver)
        {
            this.strategyResolver = strategyResolver;
        }
        public void Update(Item item)
        {
            var strategy = this.strategyResolver.Resolve(item);
            strategy.Execute(item);
        }
    }
}
