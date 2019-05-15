using System;
using System.Collections.Generic;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;

namespace Wpf.CartesianChart.Basic_Bars
{
    public partial class BasicColumn : UserControl
    {
        public BasicColumn()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection
            {
            };
            
            txt = logParser.ReadLog("D:/2019-04-16.log");
            txt = logParser.FindWorkSections(txt);
            points = logParser.GetPoints(txt);

            currentPoints.AddRange(points[0]);
            
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Opens",
                Values = currentPoints
            });

            currentPoints = new ChartValues<int>();
            currentPoints.AddRange(points[1]);

            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Closes",
                Values = currentPoints
            });


            MakeLabels();

            DataContext = this;
        }
        ChartValues<int> currentPoints = new ChartValues<int>();
        private int[][] points;
        private List<string> txt;
        private LogParser logParser = new LogParser();
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        private void MakeLabels()
        {
            Labels = new string[11];
            string time;
            int stepTime = 8;
            for (int i = 0; i < Labels.Length; i++)
            {
                time = $"{stepTime}:00-{stepTime + 1}:00";
                Labels[i] = time;
                stepTime++;
            }
        }

    }
}