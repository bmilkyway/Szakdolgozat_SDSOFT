   M S B A M L   `   `   `  ????B  >CRM.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CRM.WPF.ViewsCRM.WPF.Views  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      7 clr-namespace:CRM.WPF.ViewModelsCRM.WPF.ViewModels  5           CRM.WPF.Views.OverViewView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:CRM.WPF.Views     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      6	viewModel clr-namespace:CRM.WPF.ViewModels     5      
??????????#41518F.??5      ?? .??5      ?   ? ColumnDefinitions  5   
   ?? 5      $	??300 ?6   ?? 5      $	??400 ?6   ?? 5      $??* ?6    ? RowDefinitions 5   
   ?? 5      $??25 ?6   ?? 5      $??40 ?6   ?? 5      $	??400 ?6   ?? 5      $??40 ?6   ?? 5      $??* ?6   ?? 5      $??40 ?6   ?? 5      $??* ?6   .+?5!   
   ?? $??0??6   $??0??6"   $??5??62   ???#31407B.+?5"      ?   5#      ?? 5$      $	??150 ?6'   ?? 5%      $??* ?6'    5'      ?? 5(      $??25 ?6$   .+?5+      ?? $??0??6   $??0??6)   $??Áttekintés??66   
???????$??15(?6^   
?????? 
?????? 6?   5,      5-      ]? 5/   
   $??0??6   $??1??6%   $??2??62   $??20 10 10 10q?6C   .+?50      ??  ?? CornerRadius$ 10??6   ???#31407B._?52      ?? $	??Top=?6&   $??Center=?6>   .+?54      ?? $??5 30 5 0q?55      $	??Top=?56      $??Center=?57      $
??Auto=?58      $??Hidden=?59      .??5:   "   ?? -   5         ??Name$ detailsItemsControl??5:   /   ??5;   &   ?? 5<   *    ?? DataType   CRM.WPF.Views.Category"  67   .R?5=   *   ??  ?? Orientation$ 
Horizontal=?65   .+?5>   .   ?? $??13??68   $??13??5?   (   $??Center=?5B   (   ??5@   (   ?? *
ColorBrush+5B   (   ?? 5C   .   $??15(?5D   (   $??5,0,5,0q?5E   6   $
??Bold"?5F   4   $??Center=?5G   (   ??5C   8   ?? *Title+5G   (   ?? 5H   .   $??15(?5J   (   $
??Bold"?5K   (   $??5,0,5,0q?5L   (   $??Center=?5M   (   ??5H   8   ?? *
Percentage+??5I   (   ?? *
ColorBrush+5M   (   5N   +   5O   '   5Q   #   5R      (? 5S       (? Stretch$ UniformToFill=?6   $??10q?67   .??5T      ?? -   5         ??Name$ 
cvPieChart??5T   !   $??10q?65   5U      5W      5Y      5Z      ?? 5[   
   $??0??6   $??1??6$   $??Saját feladatok??62   $??	30 15 0 0q?6I   $
??Bold"?6]   $??15(?6o   ]? 5]   
   $??0??6   $??3??6%   $??2??62   $??20 10 10 10q?6C   .+?5^      ?? $ 10??6   ???#31407B._?5`      ?? $	??Top=?6   $??Center=?65   .+?5b      ?? $??5 30 5 0q?5c      $	??Top=?5d      $??Center=?5e      $
??Auto=?5f      $??Hidden=?5g      .??5h      ?? -   5        $ detailsItemsControl2??5h   '   ??5i      ?? 5j   "   "  6/   .R?5k   *   ?? $ 
Horizontal=?65   .+?5l   .   ?? $??13??68   $??13??5m   (   $??Center=?5p   (   ??5n   (   ?? *
ColorBrush+5p   (   ?? 5q   .   $??15(?5r   (   $??5,0,5,0q?5s   6   $
??Bold"?5t   4   $??Center=?5u   (   ??5q   8   ?? *Title+5u   (   ?? 5v   .   $??15(?5x   (   $
??Bold"?5y   (   $??5,0,5,0q?5z   (   $??Center=?5{   (   ??5v   8   ?? *
Percentage+??5w   (   ?? *
ColorBrush+5{   (   5|   +   5}   '   5      5?      (? 5?      $ UniformToFill=?6"   $??10q?6;   .??5?      ?? -   5        $ cvPieChart2??5?   %   $??10q?6:   5?      5?      5?      5?      ?? 5?   
   $??0??6   $??3??6$   $??Összes feladat??62   $??	30 15 0 0q?6H   $
??Bold"?6\   $??15(?6n   ]? 5?   
   $??0??6   $??5??6$   $??2??61   $??20 10 10 20q?6B   .+?5?      ?? $ 10??6   ???#31407B._?5?      ?? $	??Top=?6   $??Center=?65   .+?5?      ?? $??5 30 5 0q?5?      $	??Top=?5?      $??Center=?5?      $
??Auto=?5?      $??Hidden=?5?      .??5?      ?? -   5        $ detailsItemsControl3??5?   '   ??5?      ?? 5?   "   "  6/   .R?5?   &   ?? $ 
Horizontal=?61   .+?5?   *   ?? $??13??64   $??13??5?   (   $??Center=?5?   (   ??5?   (   ?? *
ColorBrush+5?   (   ?? 5?   *   $??15(?5?   (   $??5,0,5,0q?5?   6   $
??Bold"?5?   4   $??Center=?5?   (   ??5?   4   ?? *Title+5?   (   ?? 5?   *   $??15(?5?   (   $
??Bold"?5?   (   $??5,0,5,0q?5?   (   $??Center=?5?   (   ??5?   4   ?? *
Percentage+??5?   (   ?? *
ColorBrush+5?   (   5?   '   5?   #   5?      5?      (? 5?      $ UniformToFill=?6   $??10q?67   .??5?      ?? -   5        $ cvPieChart3??5?   !   $??10q?66   5?      5?      5?      5?      ?? 5?   
   $??0??6   $??5??6$   $??Hatéridők??62   $??	30 15 0 0q?6C   $
??Bold"?6W   $??15(?6i   ]? 5?   	   $??1??6   $??1??6#   $??2??60   $??1??6A   $??10 10 10 10q?6U   .+?5?      ?? $ 10??6   ???#31407B._?5?      (? $??Center=?6   $??Center=?6<   $??10q?6W   .??5?      #  LiveCharts.Wpf.CartesianChart  &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$	 Top=?6Q   $	??300??6g   $	??300??6t   	   Series	 6-   ?? *SeriesCollection+
   AxisX
 5?   "     LiveCharts.Wpf.Axis     Title$ Salesman??6+      Labels 6<   ?? *Labels+6X      AxisY 5?   "     $ 	Sold Apps??6+      LabelFormatter 6=   ?? *	Formatter+6d   5?      5?      5?      5?      ]? 5?      $??1??6   $??3??6(   $??2??65   $??10 10 10 10q?6F   .+?5?      ?? $ 10??6   ???#31407B._?5?      (? $??Center=?6   $??Center=?6;   .??5?      ?? -   5        $ cvColumnChart??5?   !   5?      5?      5?      ?? 5?      $??1??6   $??1??6(   $??	Feladatok??66   $??	20 15 0 0q?6G   $
??Bold"?6[   $??20(?6m   ]? 5?   
   $??1??6   $??5??6$   $??2??61   $??10 10 10 20q?6B   .+?5?      ?? $ 10??6   ???#31407B._?5?      ?? 5?      5?      5?      5?      5?      5?      