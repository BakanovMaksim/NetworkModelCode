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

        public ProjectBuilder SetTitle(string title)
        {
            Project.Title = title;
            return this;
        }

        public ProjectBuilder SetWorkCount(int count)
        {
            Project.WorkCount = count;
            return this;
        }

        public ProjectBuilder SetTechnologicalConditions(IReadOnlyList<TechnologicalCondition> technologicalConditions)
        {
            Project.TechnologicalConditions = technologicalConditions;
            return this;
        }

        public ProjectBuilder SetTimeCharacteristics(IReadOnlyList<TimeCharacteristic> timeCharacteristics)
        {
            Project.TimeCharacteristics = timeCharacteristics;
            return this;
        }

        public Project Build()
        {
            return Project;
        }
    }
}
