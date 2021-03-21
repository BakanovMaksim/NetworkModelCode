using NetworkModelCode.Core.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;

namespace NetworkModelCode.Core.Application.Calculators
{
    public class WorkOrderCalculator
    {
        public static IEnumerable<TimeCharacteristic> Calculate(
            IReadOnlyList<TimeCharacteristic> timeCharacteristics,
            IReadOnlyList<VariableParameter> variableParameters)
        {
            if (timeCharacteristics == null)
            {
                throw new ArgumentNullException("Передана пустая ссылка.", nameof(timeCharacteristics));
            }

            if (variableParameters == null)
            {
                throw new ArgumentNullException("Передана пустая ссылка.", nameof(variableParameters));
            }

            var maxCycle = variableParameters
                .LastOrDefault()
                .CycleNumberConsumptions
                    .LastOrDefault();

            for (var cycle = 0; cycle < maxCycle; cycle++)
            {
                var front = new List<TimeCharacteristic>();

                for (var index = 0; index < variableParameters.Count; index++)
                {
                    var currentCycle = variableParameters[index].CycleNumberConsumptions.FirstOrDefault();

                    if (currentCycle == cycle)
                    {
                        front.Add(timeCharacteristics[index]);
                    }
                }

                var orderFront = front.OrderBy(p => p.ReserveFullTime);

                foreach (var item in orderFront)
                {
                    yield return item;
                }
            }
        }
    }
}
