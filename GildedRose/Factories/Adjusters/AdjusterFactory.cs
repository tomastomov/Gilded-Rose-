using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Factories.Adjusters
{
    public class AdjusterFactory : IAdjusterFactory
    {
        public IUpdateAdjuster Create<T>() where T : IUpdateAdjuster
        {
            return (T)Activator.CreateInstance(typeof(T));
        }

        public IList<IUpdateAdjuster> CreateDefaultAdjusters()
        {
            return Assembly
                .GetAssembly(typeof(IUpdateAdjuster))
                .GetTypes()
                .Where(t => t.IsClass && t.IsAssignableTo(typeof(IUpdateAdjuster)))
                .Select(t => (IUpdateAdjuster)Activator.CreateInstance(t))
                .ToList();
        }
    }
}
