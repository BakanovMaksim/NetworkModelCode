using AutoMapper;

using NetworkModelCode.Core.Application.Calculators;
using NetworkModelCode.Core.Domain.Entities;
using NetworkModelCode.Desktop.DTO;
using NetworkModelCode.Desktop.Models;
using NetworkModelCode.Infrastructure.Business.Parsers;

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetworkModelCode.Desktop.ViewModels
{
    internal class ProjectViewModel
    {
        public Project Project { get; }
        public IReadOnlyList<WorkDataSource> workDataSource;
        public ObservableCollection<WorkTimeCharacteristicDTO> WorkTimeCharacteristicsDTO { get; set; }
        public WorkTextParser Parser { get; }

        public ProjectViewModel()
        {
            Project = new();
            Parser = new();
            WorkTimeCharacteristicsDTO = new();
        }

        public void CalculateMathModelTemporary()
        {
            var isTry = Parser.TryParseWorkDataSource(Project.Data, out workDataSource);

            if (isTry)
            {
                var calculator = new WorkTimeCharacteristicCalculator(workDataSource);
                var workTimeCharacteristics = calculator.Calculate();

                var configuration = new MapperConfiguration(cfg => cfg.CreateMap<WorkTimeCharacteristic, WorkTimeCharacteristicDTO>());
                var mapper = new Mapper(configuration);

                foreach (var workTimeCharacteristic in workTimeCharacteristics)
                {
                    var workTimeCharacteristicDto = mapper.Map<WorkTimeCharacteristicDTO>(workTimeCharacteristic);
                    WorkTimeCharacteristicsDTO.Add(workTimeCharacteristicDto);
                }
            }
        }
    }
}
