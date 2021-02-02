using NetworkModelCode.Core.Domain.Builders;
using NetworkModelCode.Core.Domain.Entities;

using System.Collections.Generic;
using System.Linq;

namespace NetworkModelCode.Infrastructure.Business.Parsers
{
    public class ProjectTextParser
    {
        public static bool TryParseProject(string buffer, out Project project)
        {
            if (string.IsNullOrWhiteSpace(buffer))
            {
                project = null;
                return false;
            }

            var lines = buffer.Split('\n');

            var linesDataSource = lines.Where(p => p.Split(" ").Count() == 4);
            var linesTimeCharacteristic = lines.Where(p => p.Split(" ").Count() == 6);

            var workCount = linesDataSource.Count();

            var itemsDataSource = new List<ItemDataSource>(workCount);
            foreach (var line in linesDataSource)
            {
                var isTry = TryParseItemDataSource(line, out var itemDataSource);

                if (isTry)
                {
                    itemsDataSource.Add(itemDataSource);
                }
            }

            var itemsTimeCharacteristic = new List<ItemTimeCharacteristic>(workCount);
            foreach (var line in linesTimeCharacteristic)
            {
                var isTry = TryParseItemTimeCharacteristic(line, out var itemTimeCharacteristic);

                if (isTry)
                {
                    itemsTimeCharacteristic.Add(itemTimeCharacteristic);
                }
            }

            project = new ProjectBuilder()
                    .SetWorkCount(workCount)
                    .SetItemsDataSource(itemsDataSource)
                    .SetItemsTimeCharacteristic(itemsTimeCharacteristic)
                    .Build();

            return true;
        }

        private static bool TryParseItemDataSource(string line, out ItemDataSource itemDataSource)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                itemDataSource = null;
                return false;
            }

            var items = line.Split(" ");

            var title = items[0];
            var isTryCodeI = int.TryParse(items[1], out var codeI);
            var isTryCodeJ = int.TryParse(items[2], out var codeJ);
            var isTryTime = int.TryParse(items[3], out var time);

            if (!isTryCodeI && !isTryCodeJ && !isTryTime)
            {
                itemDataSource = null;
                return false;
            }

            itemDataSource = new ItemDataSourceBuilder()
                .SetTitle(title)
                .SetCode(codeI, codeJ)
                .SetTime(time)
                .Build();

            return true;
        }

        private static bool TryParseItemTimeCharacteristic(string line, out ItemTimeCharacteristic itemTimeCharacteristic)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                itemTimeCharacteristic = null;
                return false;
            }

            var items = line.Split(" ");

            var isTryEarlyStart = int.TryParse(items[0], out var earlyStart);
            var isTryEarlyFinish = int.TryParse(items[1], out var earlyFinish);
            var isTryLateStart = int.TryParse(items[2], out var lateStart);
            var isTryLateFinish = int.TryParse(items[3], out var lateFinish);
            var isTryReserveFullTime = int.TryParse(items[4], out var reserveFullTime);
            var isTryReserveFreeTime = int.TryParse(items[5], out var reserveFreeTime);

            if (!isTryEarlyStart && !isTryEarlyFinish && !isTryLateStart
                && !isTryLateFinish && !isTryReserveFullTime && !isTryReserveFreeTime)
            {
                itemTimeCharacteristic = null;
                return false;
            }

            itemTimeCharacteristic = new ItemTimeCharacteristicBuilder()
                .SetEarly(earlyStart, earlyFinish)
                .SetLate(lateStart, lateFinish)
                .SetReserve(reserveFullTime, reserveFreeTime)
                .Build();

            return true;
        }
    }
}
