using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    public interface IUpdateStrategyResolver
    {
        IUpdateStrategy Resolve(Item item);
    }
}
