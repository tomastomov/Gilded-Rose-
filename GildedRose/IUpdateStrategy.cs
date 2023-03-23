using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    public interface IUpdateStrategy
    {
        void Execute(Item item);
    }
}
