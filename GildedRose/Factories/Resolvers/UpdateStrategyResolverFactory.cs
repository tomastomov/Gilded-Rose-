using GildedRoseKata.Factories.Strategies;
using GildedRoseKata.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GildedRoseKata.Constants;

namespace GildedRoseKata.Factories.Resolvers
{
    public class UpdateStrategyResolverFactory : IUpdateResolverFactory
    {
        private readonly IStrategyFactory strategyFactory;
        public UpdateStrategyResolverFactory(IStrategyFactory strategyFactory)
        {
            this.strategyFactory = strategyFactory;
        }
        public IUpdateStrategyResolver CreateResolver()
        {
            return new UpdateStrategyResolver(new Dictionary<string, IUpdateStrategy>()
            {
                [DEFAULT_STRATEGY] = this.strategyFactory.Create<OrdinaryItemUpdateStrategy>(),
                [AGED_BRIE] = this.strategyFactory.Create<AgedBrieUpdateStrategy>(),
                [SULFURAS] = this.strategyFactory.Create<SulfurasUpdateStrategy>(),
                [BACKSTAGE_PASSES] = this.strategyFactory.Create<BackstagePassesUpdateStrategy>(),
                [CONJURED] = this.strategyFactory.Create<ConjuredItemUpdateStrategy>(),
            });
        }
    }
}
