using NetworkModelCode.Core.Domain.Entities;
using NetworkModelCode.Desktop.DTO;
using NetworkModelCode.Desktop.Models;

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetworkModelCode.Desktop.Infrastructure
{
    public class ChartConfiguration
    {
        public static Chart Configure(ObservableCollection<ItemDataSourceDTO> itemsDataSourceDTO)
        {
            var xAxisLabels = GetXAxisLabels(itemsDataSourceDTO);
            var yAxisLabels = GetYAxisLabels(itemsDataSourceDTO);

            return new()
            {
                XAxisLabels = new ObservableCollection<string>(xAxisLabels),
                YAxisLabels = new ObservableCollection<string>(yAxisLabels)
            };
        }

        private static IEnumerable<string> GetXAxisLabels(ObservableCollection<ItemDataSourceDTO> itemsDataSourceDTO)
        {
            foreach(var item in itemsDataSourceDTO)
            {
                yield return item.Time.ToString();
            }
        }

        private static IEnumerable<string> GetYAxisLabels(ObservableCollection<ItemDataSourceDTO> itemsDataSourceDTO)
        {
            foreach(var item in itemsDataSourceDTO)
            {
                yield return item.Title;
            }
        }
    }
}
