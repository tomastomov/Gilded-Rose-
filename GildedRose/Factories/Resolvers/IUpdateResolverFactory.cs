using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Factories.Resolvers
{
    public interface IUpdateResolverFactory
    {
        IUpdateStrategyResolver CreateResolver();
    }
}
