using NetworkModelCode.Core.Domain.Entities;
using NetworkModelCode.Infrastructure.Business.Parsers;

using System.IO;
using System.Threading.Tasks;

namespace NetworkModelCode.Infrastructure.Business
{
    public class ProjectImporter
    {
        private ProjectTextParser Parser { get; }

        public ProjectImporter()
        {
            Parser = new();
        }

        public async Task<Project> ImportAsync(string fileName)
        {
            var buffer = await ReadWorkDataSourceFileAsync(fileName);
            var isTry = ProjectTextParser.TryParseProject(buffer, out var project);

            return isTry ? project : null;
        }

        private async Task<string> ReadWorkDataSourceFileAsync(string fileName)
        {
            if(!File.Exists(fileName))
            {
                return null;
            }

            using (var streamReader = new StreamReader(fileName))
            {
                return await streamReader.ReadToEndAsync();
            }
        }
    }
}
