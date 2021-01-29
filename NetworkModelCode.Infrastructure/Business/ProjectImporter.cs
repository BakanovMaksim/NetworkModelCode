using NetworkModelCode.Infrastructure.Business.Parsers;
using NetworkModelCode.Core.Domain.Entities;

using System.IO;
using System.Collections.Generic;
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

        public async Task<IReadOnlyList<ItemDataSource>> ImportAsync(string fileName)
        {
            var buffer = await ReadWorkDataSourceFileAsync(fileName);
            var isTry = Parser.TryParseWorkDataSource(buffer, out var workDataSource);

            return isTry ? workDataSource : null;
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
