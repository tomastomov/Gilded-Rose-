using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Factories.Strategies
{
    public interface IStrategyFactory
    {
        IUpdateStrategy Create<T>() where T : IUpdateStrategy;
    }
}
