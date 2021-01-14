using NetworkModelCode.Core.Domain.Entities;
using NetworkModelCode.Core.Domain.Builders;

using System.Collections.Generic;
using System.Linq;

namespace NetworkModelCode.Infrastructure.Business.Parsers
{
    public class MathModelFileParser 
    {
        public bool TryParseSource(string buffer, out MathModelSource mathModelSource)
        {
            if (string.IsNullOrWhiteSpace(buffer))
            {
                mathModelSource = null;
                return false;
            }

            var lines = buffer.Split('\n');

            var numberWorkCount = int.Parse(lines[0][2].ToString());
            var workCodeIs = ParseLine(lines[1]);
            var workCodeJs = ParseLine(lines[2]);
            var executionTimes = ParseLine(lines[3]);

            mathModelSource = new MathModelSourceBuilder()
                .SetNumberWorkCount(numberWorkCount)
                .SetWorkCodes(workCodeIs, workCodeJs)
                .SetExecutionTimes(executionTimes)
                .Build();

            return true;
        }

        private IReadOnlyList<int> ParseLine(string line)
        {
            return line
                .Remove(0,2)
                .Split(',')
                .Select(p => int.Parse(p))
                .ToList();
        }
    }
}
