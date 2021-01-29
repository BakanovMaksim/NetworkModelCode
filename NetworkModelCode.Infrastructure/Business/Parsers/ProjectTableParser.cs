using NetworkModelCode.Core.Domain.Entities;

using System.Text;

namespace NetworkModelCode.Infrastructure.Business.Parsers
{
    public class ProjectTableParser
    {
        public bool TryParseProject(Project project, out string buffer)
        {
            if (project == null)
            {
                buffer = null;
                return false;
            }

            var stringBuilder = new StringBuilder()
                .AppendLine($"{project.WorkCount}");

            foreach(var item in project.WorkDataSource)
            {
                stringBuilder.AppendLine(item.ToStringCustom());
            }

            foreach(var item in project.WorkTimeCharacteristics)
            {
                stringBuilder.AppendLine(item.ToStringCustom());
            }

            buffer = stringBuilder.ToString();
            return true;
        }
    }
}
