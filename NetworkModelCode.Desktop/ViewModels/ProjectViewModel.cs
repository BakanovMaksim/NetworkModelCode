using LiveCharts.Wpf.Charts.Base;

using NetworkModelCode.Core.Application.Calculators;
using NetworkModelCode.Core.Domain.Builders;
using NetworkModelCode.Core.Domain.Entities;
using NetworkModelCode.Desktop.DTO;
using NetworkModelCode.Desktop.Infrastructure;
using NetworkModelCode.Desktop.Services;
using NetworkModelCode.Desktop.Views;
using NetworkModelCode.Infrastructure.Business;
using NetworkModelCode.Infrastructure.Data;

using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Diagnostics;

namespace NetworkModelCode.Desktop.ViewModels
{
    internal class ProjectViewModel
    {
        private IDialogService DefaultDialogService { get; }
        private UnitOfWork UnitOfWork { get; }
        private ProjectImporter Importer { get; }
        private ProjectExporter Exporter { get; }
        public ObservableCollection<TechnologicalConditionDTO> TechnologicalConditionDTOs { get; set; }
        public ObservableCollection<TimeCharacteristicDTO> TimeCharacteristicDTOs { get; set; }
        public ObservableCollection<ResourceDTO> ResourceDTOs { get; set; }
        public ObservableCollection<VariableParameterDTO> VariableParameterDTOs { get; set; }
        public Project Project { get; private set; }
        public ProjectDTO ProjectDTO { get; set; }

        public ProjectViewModel()
        {
            DefaultDialogService = new DefaultDialogService();
            UnitOfWork = new UnitOfWork(new NetworkModelContext());
            Importer = new();
            Exporter = new();
            TechnologicalConditionDTOs = new();
            TimeCharacteristicDTOs = new();
            ResourceDTOs = new();
            VariableParameterDTOs = new();
            ProjectDTO = new();
        }

        public void CalculateProjectData()
        {
            var technologicalConditions = Mapper
                .MapCollection<
                    TechnologicalConditionDTO,
                    TechnologicalCondition,
                    ObservableCollection<TechnologicalConditionDTO>,
                    ObservableCollection<TechnologicalCondition>>
                    (TechnologicalConditionDTOs).ToList();

            var resources = Mapper
                .MapCollection<
                ResourceDTO,
                Resource,
                ObservableCollection<ResourceDTO>,
                ObservableCollection<Resource>>
                (ResourceDTOs).ToList();

            try
            {
                var timeCharacteristicCalculator = new TimeCharacteristicCalculator(technologicalConditions);
                var timeCharacteristics = timeCharacteristicCalculator.Calculate().ToList();

                var variableParameterCalculator = new VariableParameterCalculator(technologicalConditions);
                var cycleCount = timeCharacteristics.Max(p => p.EarlyFinish);
                var variableParameters = variableParameterCalculator.Calculate(cycleCount);

                foreach (var item in timeCharacteristics)
                {
                    var timeCharacteristicDTO = Mapper.Map<TimeCharacteristic, TimeCharacteristicDTO>(item);
                    TimeCharacteristicDTOs.Add(timeCharacteristicDTO);
                }

                foreach (var parameter in variableParameters)
                {
                    var variableParameterDTO = Mapper.Map<VariableParameter, VariableParameterDTO>(parameter);

                    var buffer = string.Empty;
                    foreach (var item in parameter.CycleNumberConsumptions)
                    {
                        buffer += $"{item} ";
                    }

                    variableParameterDTO.CycleNumberConsumptions = buffer;
                    VariableParameterDTOs.Add(variableParameterDTO);
                }

                Project = new ProjectBuilder()
                    .SetTitle(ProjectDTO.Title)
                    .SetWorkCount(ProjectDTO.WorkCount)
                    .SetTechnologicalConditions(technologicalConditions)
                    .SetResources(resources)
                    .SetTimeCharacteristics(timeCharacteristics)
                    .Build();
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public async Task SaveProjecAsync()
        {
            await UnitOfWork.Projects.AddAsync(Project);
            await UnitOfWork.TechnologicalConditions.AddRangeAsync(Project.TechnologicalConditions);
            await UnitOfWork.TimeCharacteristics.AddRangeAsync(Project.TimeCharacteristics);
        }

        public async Task ImportWorkDataSourceAsync()
        {
            var openFileDialog = DefaultDialogService.OpenFile();

            if (openFileDialog)
            {
                var project = await Importer.ImportAsync(DefaultDialogService.FileName);

                foreach (var item in project.TechnologicalConditions)
                {
                    var workDataSourceDTO = Mapper.Map<TechnologicalCondition, TechnologicalConditionDTO>(item);
                    TechnologicalConditionDTOs.Add(workDataSourceDTO);
                }
            }
        }

        public async Task ExportWorkComplexAsync()
        {
            var saveFileDialog = DefaultDialogService.SaveFile();

            if (saveFileDialog)
            {
                await Exporter.ExportAsync(DefaultDialogService.FileName, Project);
            }
        }

        public void ConfigureProject()
        {
            var projectSettingWindow = new ProjectSettingWindow(ProjectDTO);
            projectSettingWindow.ShowDialog();
        }

        public Chart GetChart()
        {
            return ChartConfiguration.Configure(TechnologicalConditionDTOs, TimeCharacteristicDTOs);
        }
    }
}
