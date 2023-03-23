using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Factories.Adjusters
{
    public interface IAdjusterFactory
    {
        IUpdateAdjuster Create<T>() where T : IUpdateAdjuster;

        IList<IUpdateAdjuster> CreateDefaultAdjusters();
    }
}
