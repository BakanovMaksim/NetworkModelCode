using NetworkModelCode.Core.Domain.Entities;

using System.Collections.Generic;

namespace NetworkModelCode.Core.Domain.Builders
{
    public sealed class ProjectBuilder
    {
        private Project Project { get; }

        public ProjectBuilder()
        {
            Project = new();
        }

        public ProjectBuilder SetWorkCount(int count)
        {
            Project.WorkCount = count;
            return this;
        }

        public ProjectBuilder SetItemsDataSource(IReadOnlyList<ItemDataSource> itemsDataSource)
        {
            Project.ItemsDataSource = itemsDataSource;
            return this;
        }

        public ProjectBuilder SetItemsTimeCharacteristic(IReadOnlyList<ItemTimeCharacteristic> itemsTimeCharacteristic)
        {
            Project.ItemsTimeCharacteristic = itemsTimeCharacteristic;
            return this;
        }

        public Project Build()
        {
            return Project;
        }
    }
}
