using NetworkModelCode.Core.Domain.Entities;

using System.Text;

namespace NetworkModelCode.Infrastructure.Business.Parsers
{
    public class ProjectTableParser
    {
        public static bool TryParseProject(Project project, out string buffer)
        {
            if (project == null)
            {
                buffer = null;
                return false;
            }

            var stringBuilder = new StringBuilder();

            foreach(var item in project.TechnologicalConditions)
            {
                stringBuilder.AppendLine(item.ToStringCustom());
            }

            foreach(var item in project.TimeCharacteristics)
            {
                stringBuilder.AppendLine(item.ToStringCustom());
            }

            buffer = stringBuilder.ToString();
            return true;
        }
    }
}
