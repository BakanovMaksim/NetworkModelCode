using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Definitions.Series;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;

using NetworkModelCode.Desktop.DTO;

using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace NetworkModelCode.Desktop.Infrastructure
{
    public class ChartConfiguration
    {
        public static Chart Configure(
            ObservableCollection<ItemDataSourceDTO> itemsDataSourceDTO,
            ObservableCollection<ItemTimeCharacteristicDTO> itemsTimeCharacteristicDTO)
        {
            var series = GetSeries(itemsDataSourceDTO, itemsTimeCharacteristicDTO);
            var seriesCollection = new SeriesCollection();

            seriesCollection.AddRange(series);

            var axisX = new AxesCollection();
            axisX.Add(new Axis { Title = "Продолжительность", MinValue = 0, Position = AxisPosition.RightTop });

            var labels = itemsDataSourceDTO.Select((p, i) => (++i).ToString());

            var axisY = new AxesCollection();
            axisY.Add(new Axis { Title = "Работа", Labels = labels.ToList() });
       
            return new CartesianChart
            {
                AxisX = axisX,
                AxisY = axisY,
                Series = seriesCollection
            };
        }

        private static IEnumerable<ISeriesView> GetSeries(
            ObservableCollection<ItemDataSourceDTO> itemsDataSourceDTO,
            ObservableCollection<ItemTimeCharacteristicDTO> itemsTimeCharacteristicDTO)
        {
            var fill = Brushes.Transparent;

            for (int k = 0; k < itemsDataSourceDTO.Count; k++)
            {
                var xStart = itemsTimeCharacteristicDTO[k].EarlyStart;
                var xFinish = itemsTimeCharacteristicDTO[k].EarlyFinish;

                yield return new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(xStart,k),
                        new ObservablePoint(xFinish,k)
                    },
                    Fill = fill,
                    Title = itemsDataSourceDTO[k].Title
                };
            }
        }
    }
}
