   M S B A M L   `   `   `  ????B  >CRM.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CRM.WPF.ViewsCRM.WPF.Views  5      C&clr-namespace:CRM.WPF.State.NavigatorsCRM.WPF.State.Navigators  5      7 clr-namespace:CRM.WPF.ViewModelsCRM.WPF.ViewModels  5          CRM.WPF.Views.TaskView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:CRM.WPF.Views     5      6nav&clr-namespace:CRM.WPF.State.Navigators     5      7
ViewModels clr-namespace:CRM.WPF.ViewModels     5      ???#41518F.??5      ?   ? ColumnDefinitions  5   
   ?? 5      $??20 ?6   ?? 5      $??* ?6   ?? 5      $??20 ?6    ? RowDefinitions 5   
   ?? 5      $??25 ?6   ?? 5      $??* ?6   ?? 5      $??20 ?6   .+?5   
   ?? $??0??6   $??0??6%   ???#31407B$??10??6G   .+?5      ?   5      ?? 5       $	??150 ?6'   ?? 5!      $	??150 ?6'   ?? 5"      $	??150 ?6'    5&      ?? 5'      $??25 ?6$   .+?5)      ?? $??0??6   $??0??6)   $??Saját feladatok??67   $??15(?6Q   
?????? 
?????? 
???????'   !CRM.WPF.State.Navigators.ViewType   OwnTask#??Z 6?   ??6?   ?? *)'Navigator.UpdateCurrentViewModelCommand+ ? DataContext 6  ?? *DataContext+ ?? RelativeSource ?? *FindAncestor+ ?? AncestorType   CRM.WPF.Views.TaskView"  ?? 5,      $??1??6   $??0??6)   $??Összes feladat??66   $??15(?6O   
?????? 
?????? 
???????   AllTask#??Z 6?   ??6?   ?? *)'Navigator.UpdateCurrentViewModelCommand+ 6  ?? *DataContext+ ?? *FindAncestor+"  ?? 5.      -   5         ??Name$ 
btnNewTask??5.   *   $??2??6   $??0??6?   $??Új feladat??6L   $??15(?6a   
?????? 
?????? 
???????   NewTask#??Z 6?   ??6?   ?? *)'Navigator.UpdateCurrentViewModelCommand+ 6$  ?? *DataContext+ ?? *FindAncestor+"  50      51      ?? 53   
   $??1??6   $??1??6&   ??66   ?? *Navigator.CurrentViewModel+55      56      