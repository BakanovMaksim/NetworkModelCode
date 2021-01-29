using NetworkModelCode.Core.Domain.Entities;

using System.Collections.Generic;

namespace NetworkModelCode.Core.Domain.Builders
{
    public class ProjectBuilder
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

        public ProjectBuilder SetWorkDataSource(IReadOnlyList<ItemDataSource> workDataSource)
        {
            Project.WorkDataSource = workDataSource;
            return this;
        }

        public ProjectBuilder SetWorkTimeCharacteristics(IReadOnlyList<ItemTimeCharacteristic> workTimeCharacteristics)
        {
            Project.WorkTimeCharacteristics = workTimeCharacteristics;
            return this;
        }

        public ProjectBuilder SetCriticalPathLength(int length)
        {
            Project.CriticalPathLength = length;
            return this;
        }

        public Project Build()
        {
            return Project;
        }
    }
}
