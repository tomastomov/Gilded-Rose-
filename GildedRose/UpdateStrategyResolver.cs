using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GildedRoseKata.Constants;

namespace GildedRoseKata
{
    public class UpdateStrategyResolver : IUpdateStrategyResolver
    {
        private readonly IDictionary<string, IUpdateStrategy> updateStrategies;
        public UpdateStrategyResolver(IDictionary<string, IUpdateStrategy> updateStrategies)
        {
            this.updateStrategies = updateStrategies;
        }
        public IUpdateStrategy Resolve(Item item)
        {
            if (!updateStrategies.TryGetValue(item.Name, out IUpdateStrategy strategy))
            {
                return updateStrategies[DEFAULT_STRATEGY];
            }

            return strategy;
        }
    }
}
