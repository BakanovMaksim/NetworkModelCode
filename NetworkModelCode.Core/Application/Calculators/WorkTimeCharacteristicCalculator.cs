using NetworkModelCode.Core.Domain.Builders;
using NetworkModelCode.Core.Domain.Entities;

using System.Collections.Generic;
using System.Linq;

namespace NetworkModelCode.Core.Application.Calculators
{
    public class WorkTimeCharacteristicCalculator
    {
        private IReadOnlyList<ItemDataSource> ItemsDataSource { get; set; }

        public IEnumerable<ItemTimeCharacteristic> Calculate(IReadOnlyList<ItemDataSource> itemsDataSource)
        {
            ItemsDataSource = itemsDataSource;

            var earlys = CalculateEarlyStartAndFinish();
            var earlyStarts = earlys.Item1.ToList();
            var earlyFinishes = earlys.Item2.ToList();
            var lateFinishes = CalculateLateFinishes(earlyFinishes).ToList();
            var lateStarts = CalculateLateStarts(lateFinishes).ToList();
            var reserveFullTimes = CalculateReserveFullTimes(lateFinishes, earlyFinishes).ToList();
            var reserveFreeTimes = CalculateReserveFreeTimes(lateStarts, earlyStarts).ToList();

            for (int k = 0;k < ItemsDataSource.Count; k++)
            {
                yield return 
                    new ItemTimeCharacteristicBuilder()
                    .SetEarly(earlyStarts[k], earlyFinishes[k])
                    .SetLate(lateStarts[k], lateFinishes[k])
                    .SetReserve(reserveFullTimes[k], reserveFreeTimes[k])
                    .Build();
            }
        }

        private (IEnumerable<int>, IEnumerable<int>) CalculateEarlyStartAndFinish()
        {
            var earlyStarts = new List<int>();
            var earlyFinishes = new List<int>();

            for (int k = 0; k < ItemsDataSource.Count; k++)
            {
                if (ItemsDataSource[k].CodeI == 1)
                {
                    earlyStarts.Add(0);
                    earlyFinishes.Add(ItemsDataSource[k].Time);
                    continue;
                }

                var counts = new List<int>();
                for (int j = 0; j < ItemsDataSource.Count; j++)
                {
                    if (ItemsDataSource[k].CodeI == ItemsDataSource[j].CodeJ)
                    {
                        counts.Add(earlyFinishes[j]);
                    }
                }

                var earlyStart = counts.Max();
                var earlyFinish = earlyStart + ItemsDataSource[k].Time;

                earlyStarts.Add(earlyStart);
                earlyFinishes.Add(earlyFinish);
            }

            return (earlyStarts, earlyFinishes);
        }

        private IEnumerable<int> CalculateLateFinishes(IReadOnlyList<int> earlyFinishes)
        {
            var keys = ItemsDataSource.GroupBy(p => p.CodeJ);           

            foreach (var key in keys)
            {
                var earlys = new List<int>();
                for (int k = 0; k < ItemsDataSource.Count; k++)
                {
                    if (ItemsDataSource[k].CodeJ == key.Key)
                    {
                        earlys.Add(earlyFinishes[k]);
                    }
                }

                for (int k = 0; k < earlys.Count; k++)
                    yield return earlys.Max();
            }
        }

        private IEnumerable<int> CalculateLateStarts(IReadOnlyList<int> lateFinishes)
        {
            for (int k = 0; k < ItemsDataSource.Count; k++)
            {
                yield return lateFinishes[k] - ItemsDataSource[k].Time;
            }
        }

        private IEnumerable<int> CalculateReserveFullTimes(IReadOnlyList<int> lateFinishes, IReadOnlyList<int> earlyFinishes)
        {
            for (int k = 0; k < ItemsDataSource.Count; k++)
            {
                yield return lateFinishes[k] - earlyFinishes[k];
            }
        }
        
        private IEnumerable<int> CalculateReserveFreeTimes(IReadOnlyList<int> lateStarts, IReadOnlyList<int> earlyStarts)
        {
            for(int k = 0;k< ItemsDataSource.Count; k++)
            {
                yield return lateStarts[k] - earlyStarts[k];
            }     
        }
    }
}
