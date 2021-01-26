using AutoMapper;

using NetworkModelCode.Core.Application.Calculators;
using NetworkModelCode.Core.Domain.Entities;
using NetworkModelCode.Desktop.DTO;
using NetworkModelCode.Desktop.Models;
using NetworkModelCode.Infrastructure.Business.Parsers;
using NetworkModelCode.Desktop.Infrastructure;

using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetworkModelCode.Desktop.ViewModels
{
    internal class ProjectViewModel
    {
        public Project Project { get; }
        public ObservableCollection<WorkDataSourceDTO> WorkDataSourceDTOs { get; set; }
        public ObservableCollection<WorkTimeCharacteristicDTO> WorkTimeCharacteristicsDTOs { get; set; }
        public WorkTextParser Parser { get; }

        public ProjectViewModel()
        {
            Project = new();
            Parser = new();
            WorkDataSourceDTOs = new();
            WorkTimeCharacteristicsDTOs = new();
        }

        public void CalculateWorkTimeCharacteristic()
        {
            //var configuration = new MapperConfiguration(cfg => cfg.CreateMap<WorkDataSourceDTO, WorkDataSource>());
            //var mapper = new AutoMapper.Mapper(configuration);

            //var workDataSource = mapper.Map<ObservableCollection<WorkDataSource>>(WorkDataSourceDTOs);

            var workDataSource = Infrastructure.Mapper.MapCollection<WorkDataSourceDTO,WorkDataSource, ObservableCollection<WorkDataSourceDTO>,ObservableCollection<WorkDataSource>>(WorkDataSourceDTOs);

            var calculator = new WorkTimeCharacteristicCalculator(workDataSource.ToList());
            var workTimeCharacteristics = calculator.Calculate();

            foreach (var workTimeCharacteristic in workTimeCharacteristics)
            {
                var workTimeCharacteristicDto = Infrastructure.Mapper.Map<WorkTimeCharacteristic, WorkTimeCharacteristicDTO>(workTimeCharacteristic);
                WorkTimeCharacteristicsDTOs.Add(workTimeCharacteristicDto);
            }
        }
    }
}
