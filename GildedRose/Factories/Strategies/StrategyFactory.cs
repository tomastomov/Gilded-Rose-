using GildedRoseKata.Factories.Adjusters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Factories.Strategies
{
    public class StrategyFactory : IStrategyFactory
    {
        private readonly IAdjusterFactory adjusterFactory;
        public StrategyFactory(IAdjusterFactory adjusterFactory)
        {
            this.adjusterFactory = adjusterFactory;
        }
        public IUpdateStrategy Create<T>() where T : IUpdateStrategy
        {
            return (T)Activator.CreateInstance(typeof(T), adjusterFactory.CreateDefaultAdjusters());
        }
    }
}
