using NetworkModelCode.Core.Domain.Entities;

using System.Text;

namespace NetworkModelCode.Infrastructure.Business.Parsers
{
    public class WorkComplexTableParser
    {
        public bool TryParseWorkComplex(WorkComplex workComplex, out string buffer)
        {
            if (workComplex == null)
            {
                buffer = null;
                return false;
            }

            var stringBuilder = new StringBuilder()
                .AppendLine($"{workComplex.WorkCount}");

            foreach(var item in workComplex.WorkDataSources)
            {
                stringBuilder.AppendLine(item.ToStringCustom());
            }

            foreach(var item in workComplex.WorkTimeCharacteristics)
            {
                stringBuilder.AppendLine(item.ToStringCustom());
            }

            buffer = stringBuilder.ToString();
            return true;
        }
    }
}
