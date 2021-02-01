using NetworkModelCode.Core.Domain.Entities;
using NetworkModelCode.Infrastructure.Business.Parsers;

using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NetworkModelCode.Infrastructure.Business
{
    public class ProjectExporter
    {
        public async Task ExportAsync(string fileName,Project project)
        {
            var isTry = ProjectTableParser.TryParseProject(project, out var buffer);

            if(isTry)
            {
                await WriteFileWorkComplexAsync(fileName, buffer);
            }
        }

        private async Task WriteFileWorkComplexAsync(string fileName, string buffer)
        {
            if(!string.IsNullOrWhiteSpace(buffer))
            {
                using(var fileStream = new FileStream(fileName,FileMode.OpenOrCreate))
                {
                    var bytes = Encoding.Default.GetBytes(buffer);
                    await fileStream.WriteAsync(bytes);
                }
            }
        }
    }
}
