using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    public interface IUpdateAdjuster
    {
        void Adjust(Item item);
    }
}
