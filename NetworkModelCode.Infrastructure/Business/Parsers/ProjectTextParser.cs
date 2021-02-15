﻿using NetworkModelCode.Core.Domain.Builders;
using NetworkModelCode.Core.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Globalization;
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

            var technologicalConditionLines = lines.Where(p => p.Split(" ").Count() == 5);
            var timeCharacteristicLines = lines.Where(p => p.Split(" ").Count() == 6);

            var workCount = technologicalConditionLines.Count();

            var technologicalConditions = new List<TechnologicalCondition>(workCount);
            foreach (var line in technologicalConditionLines)
            {
                var isTry = TryParseTechnologicalCondition(line, out var technologicalCondition);

                if (isTry)
                {
                    technologicalConditions.Add(technologicalCondition);
                }
            }

            var itemsTimeCharacteristic = new List<TimeCharacteristic>(workCount);
            foreach (var line in timeCharacteristicLines)
            {
                var isTry = TryParseTimeCharacteristic(line, out var timeCharacteristic);

                if (isTry)
                {
                    itemsTimeCharacteristic.Add(timeCharacteristic);
                }
            }

            project = new ProjectBuilder()
                    .SetWorkCount(workCount)
                    .SetTechnologicalConditions(technologicalConditions)
                    .SetTimeCharacteristics(itemsTimeCharacteristic)
                    .Build();

            return true;
        }

        private static bool TryParseTechnologicalCondition(string line, out TechnologicalCondition technologicalCondition)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                technologicalCondition = null;
                return false;
            }

            var items = line.Split(" ");

            var title = items[0];
            var isTryCodeI = int.TryParse(items[1], out var codeI);
            var isTryCodeJ = int.TryParse(items[2], out var codeJ);
            var isTryTimeMin = double.TryParse(items[3], NumberStyles.Float, CultureInfo.InvariantCulture, out var timeMin);
            var isTryTimeMax = double.TryParse(items[4], NumberStyles.Float, CultureInfo.InvariantCulture, out var timeMax);

            if (!isTryCodeI && !isTryCodeJ
                && !isTryTimeMin && !isTryTimeMax)
            {
                technologicalCondition = null;
                return false;
            }

            technologicalCondition = new TechnologicalConditionBuilder()
                .SetTitle(title)
                .SetCode(codeI, codeJ)
                .SetTime(timeMin, timeMax)
                .Build();

            return true;
        }

        private static bool TryParseTimeCharacteristic(string line, out TimeCharacteristic timeCharacteristic)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                timeCharacteristic = null;
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
                timeCharacteristic = null;
                return false;
            }

            timeCharacteristic = new TimeCharacteristicBuilder()
                .SetEarly(earlyStart, earlyFinish)
                .SetLate(lateStart, lateFinish)
                .SetReserve(reserveFullTime, reserveFreeTime)
                .Build();

            return true;
        }
    }
}
