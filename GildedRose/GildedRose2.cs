using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    public class GildedRose2
    {
        private readonly IItemUpdater itemUpdater;
        private readonly IList<Item> items;
        public GildedRose2(IList<Item> items, IItemUpdater updater)
        {
            this.items = items;
            this.itemUpdater = updater;
        }
        
        public void UpdateQuality()
        {
            items.ToList().ForEach(item => itemUpdater.Update(item));
        }
    }
}
