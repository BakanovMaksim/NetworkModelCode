using NetworkModelCode.Core.Domain.Entities;

using System.Collections.Generic;
using System.Linq;

namespace NetworkModelCode.Infrastructure.Business.Parsers
{
    public class WorkTextParser
    {
        public bool TryParseWorkDataSource(string buffer, out IReadOnlyList<WorkDataSource> workDataSource)
        {
            if (string.IsNullOrWhiteSpace(buffer))
            {
                workDataSource = null;
                return false;
            }

            var lines = buffer.Split('\n');

            var workCount = int.Parse(lines[0][2].ToString());
            var codeIs = ParseLine(lines[1]);
            var codeJs = ParseLine(lines[2]);
            var times = ParseLine(lines[3]);

            var workData = new List<WorkDataSource>();
            for(int k = 0;k<workCount;k++)
            {
                workData.Add(
                    new WorkDataSource()
                    {
                        CodeI = codeIs[k],
                        CodeJ = codeJs[k],
                        Time = times[k]
                    });
            }

            workDataSource = workData;
            return true;
        }

        private IReadOnlyList<int> ParseLine(string line)
        {
            return line
                .Remove(0, 2)
                .Split(',')
                .Select(p => int.Parse(p))
                .ToList();
        }
    }
}
