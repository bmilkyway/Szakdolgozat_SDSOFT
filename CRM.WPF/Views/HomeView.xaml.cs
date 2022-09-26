using CRM.Domain.Models;
using CRM.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace CRM.WPF.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private List<Category> Categories { get; set; }
        float pieWidth = 650, pieHeight = 650;

        private readonly  HomeViewModel homeViewModel;
        public HomeView()
        {
            InitializeComponent();
            mainCanvas.Width = pieWidth;
            mainCanvas.Height = pieHeight;
            homeViewModel = new HomeViewModel();

          


            Categories = new List<Category>()
            {
                #region Kördiagramm részei
                new Category
                {
                    Title = "Elkezdett feladatok:",
                    Percentage = homeViewModel.activeTaskCount,
                    ColorBrush = Brushes.Green,
                },

                new Category
                {
                    Title = "Lezárt feladatok:",
                    Percentage = homeViewModel.closedTaskCount,
                    ColorBrush = Brushes.Gray,
                },

                new Category
                {
                    Title = "Tervezés alatti feladatok:",
                    Percentage = homeViewModel.plannedTaskCount,
                    ColorBrush = Brushes.Yellow,
                }
                #endregion

            };

            detailsItemsControl.ItemsSource = Categories;
            if (homeViewModel.ownTasks!.Count != 0)
            {
                printChart();
            }
        }
        public void printChart()
        {
            float centerX = pieWidth / 2, centerY = pieHeight / 2, radius = pieWidth / 2;
            int tasksCount = homeViewModel.ownTasks!.Count;
            float angle = 0, prevAngle = 0;
            foreach (var category in Categories)
            {
                double line1X = (radius * Math.Cos(angle * Math.PI / 180)) + centerX;
                double line1Y = (radius * Math.Sin(angle * Math.PI / 180)) + centerY;

                angle = category.Percentage * (float)359 / tasksCount + prevAngle;
                Debug.WriteLine(angle);

                double arcX = (radius * Math.Cos(angle * Math.PI / 180)) + centerX;
                double arcY = (radius * Math.Sin(angle * Math.PI / 180)) + centerY;

                var line1Segment = new LineSegment(new Point(line1X, line1Y), false);
                double arcWidth = radius, arcHeight = radius;
                bool isLargeArc = category.Percentage > tasksCount / 2;
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
                mainCanvas.Children.Add(path);

                prevAngle = angle;



                var outline1 = new Line()
                {
                    X1 = centerX,
                    Y1 = centerY,
                    X2 = line1Segment.Point.X,
                    Y2 = line1Segment.Point.Y,
                    Stroke = Brushes.White,
                    StrokeThickness = 5,
                };
                var outline2 = new Line()
                {
                    X1 = centerX,
                    Y1 = centerY,
                    X2 = arcSegment.Point.X,
                    Y2 = arcSegment.Point.Y,
                    Stroke = Brushes.White,
                    StrokeThickness = 5,
                };

                mainCanvas.Children.Add(outline1);
                mainCanvas.Children.Add(outline2);
            }
        }
        private void openThisTask(object sender, SelectionChangedEventArgs e)
        {
            if(lbOwnTasks.SelectedIndex!=-1)
            {
                ActualTask actual = new ActualTask(homeViewModel.ownTasks![lbOwnTasks.SelectedIndex],true,homeViewModel.active_User,lbOwnTasks);
                actual.ShowDialog();
                lbOwnTasks.Items.Refresh();

            }
           
        }
    }

    public class Category
    {
        public float Percentage { get; set; }
        public string? Title { get; set; }
        public Brush? ColorBrush { get; set; }
    }
}
