using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using CRM.WPF.ViewModels;

namespace CRM.WPF.Views
{
    /// <summary>
    /// Interaction logic for OverViewView.xaml
    /// </summary>
    public partial class OverViewView : UserControl
    {
       
        private List<Item> Items { get; set; }
        float pieWidth = 150, pieHeight = 150;
        private OverViewViewModel overViewViewModel;
        public OverViewView()
        {
            InitializeComponent();
          
          overViewViewModel = new OverViewViewModel();
            cvPieChart.Width = pieWidth;
            cvPieChart.Height = pieHeight;
            cvPieChart2.Width = pieWidth;
            cvPieChart2.Height = pieHeight;
            cvPieChart3.Width = pieWidth;
            cvPieChart3.Height = pieHeight;
            detailsItemsControl.ItemsSource = overViewViewModel.OwnTaskCategories;
            detailsItemsControl2.ItemsSource = overViewViewModel.AllTaskCategories;
            detailsItemsControl3.ItemsSource = overViewViewModel.DeadlineTaskCategories;








            Items = new List<Item>()
            {
              
                new Item(){Header= "Item1", Value = 101},
                new Item(){Header= "Item2", Value = 208},
                new Item(){Header= "Item3", Value = 75},
                new Item(){Header= "Item4", Value = 135},
                new Item(){Header= "Item5", Value = 300},
                new Item(){Header= "Item6", Value = 400},
                new Item(){Header= "Item7", Value = 360},
                new Item(){Header= "Item8", Value = 499},
                new Item(){Header= "Item9", Value = 233},
                new Item(){Header= "Item10", Value = 122},
            };
            if(overViewViewModel.ownTasks!.Count!=0)
            PaintPieChart(overViewViewModel.OwnTaskCategories, overViewViewModel.ownTasks!.Count,cvPieChart);
            if (overViewViewModel.allTasks!.Count != 0)
            PaintPieChart(overViewViewModel.AllTaskCategories, overViewViewModel.allTasks!.Count, cvPieChart2);
            if (overViewViewModel.freeTaskCount+overViewViewModel.activeTaskCount+overViewViewModel.plannedTaskCount!=0)
            PaintPieChart(overViewViewModel.DeadlineTaskCategories, overViewViewModel.freeTaskCount+overViewViewModel.plannedTaskCount+overViewViewModel.activeTaskCount, cvPieChart3);

            //  Paint();
        }

        private void Paint()
        {
           
                float chartWidth = 300, chartHeight = 175, axisMargin = 10, yAxisInterval = 10,blockWidth = 10, blockMargin = 20;
                cvColumnChart.Width = chartWidth;
                cvColumnChart.Height = chartHeight;
                Point yAxisEndPoint = new Point(axisMargin, axisMargin);
                Point origin = new Point(axisMargin, chartHeight - axisMargin);
                Point xAxisEndPoint = new Point(chartWidth - axisMargin, chartHeight - axisMargin);
                double yValue = 0;
                var yAxisValue = origin.Y;
                while (yAxisValue >= yAxisEndPoint.Y)
                {
                  
                    Line yLine = new Line()
                    {
                        Stroke = Brushes.LightGray,
                        StrokeThickness = 1,
                        X1 = origin.X,
                        Y1 = yAxisValue,
                        X2 = xAxisEndPoint.X,
                        Y2 = yAxisValue,
                    };
                    cvColumnChart.Children.Add(yLine);

                    TextBlock yAxisTextBlock = new TextBlock()
                    {
                        Text = $"{yValue}",
                        Foreground = Brushes.Black,
                        FontSize = 16,
                    };
                    cvColumnChart.Children.Add(yAxisTextBlock);

                    Canvas.SetLeft(yAxisTextBlock, origin.X - 35);
                    Canvas.SetTop(yAxisTextBlock, yAxisValue - 12.5);

                    yAxisValue -= yAxisInterval;
                    yValue += yAxisInterval;
                }

                var margin = origin.X + blockMargin;
                foreach (var item in Items)
                {
                    Rectangle block = new Rectangle()
                    {
                        Fill = Brushes.Gold,
                      
                        Width = blockWidth,
                        Height = item.Value,
                    };

                    cvColumnChart.Children.Add(block);
                    Canvas.SetLeft(block, margin);
                    Canvas.SetTop(block, origin.Y - block.Height);

                    TextBlock blockHeader = new TextBlock()
                    {
                        Text = item.Header,
                        FontSize = 16,
                        Foreground = Brushes.Black,
                    };
                    cvColumnChart.Children.Add(blockHeader);
                    Canvas.SetLeft(blockHeader, margin + 10);
                    Canvas.SetTop(blockHeader, origin.Y + 5);
                    margin += (blockWidth + blockMargin);
                }
            
        }

        private void PaintPieChart(List<ViewModels.Category> categories, int countOfListItems,Canvas canvas)
        {
            float centerX = pieWidth / 2, centerY = pieHeight / 2, radius = pieWidth / 2;

          

            int dataCount = countOfListItems;
            float angle = 0, prevAngle = 0;
            foreach (var category in categories)
            {
                double line1X = (radius * Math.Cos(angle * Math.PI / 180)) + centerX;
                double line1Y = (radius * Math.Sin(angle * Math.PI / 180)) + centerY;

                angle = category.Percentage * (float)359 / dataCount + prevAngle;
                Debug.WriteLine(angle);

                double arcX = (radius * Math.Cos(angle * Math.PI / 180)) + centerX;
                double arcY = (radius * Math.Sin(angle * Math.PI / 180)) + centerY;

                var line1Segment = new LineSegment(new Point(line1X, line1Y), false);
                double arcWidth = radius, arcHeight = radius;
                bool isLargeArc = category.Percentage > dataCount / 2;
                var arcSegment = new ArcSegment()
                {
                    Size = new Size(arcWidth, arcHeight),
                    Point = new Point(arcX, arcY),
                    SweepDirection = SweepDirection.Clockwise,
                    IsLargeArc = isLargeArc,
                };
                var line2Segment = new LineSegment(new Point(centerX, centerY), false);

                var pathFigure = new PathFigure(
                    new Point(centerX, centerY),
                    new List<PathSegment>()
                    {
                        line1Segment,
                        arcSegment,
                        line2Segment,
                    },
                    true);

                var pathFigures = new List<PathFigure>() { pathFigure, };
                var pathGeometry = new PathGeometry(pathFigures);
                var path = new Path()
                {
                    Fill = category.ColorBrush,
                    Data = pathGeometry,
                };
                canvas.Children.Add(path);

                prevAngle = angle;



                var outline1 = new Line()
                {
                    X1 = centerX,
                    Y1 = centerY,
                    X2 = line1Segment.Point.X,
                    Y2 = line1Segment.Point.Y,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                };
                var outline2 = new Line()
                {
                    X1 = centerX,
                    Y1 = centerY,
                    X2 = arcSegment.Point.X,
                    Y2 = arcSegment.Point.Y,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                };

                canvas.Children.Add(outline1);
                canvas.Children.Add(outline2);
            }
        }
    }

    public class Item
    {
        public string? Header { get; set; }
        public int Value { get; set; }
    }
}
