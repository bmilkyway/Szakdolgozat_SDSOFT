   M S B A M L   `   `   `  ????B  >CRM.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CRM.WPF.ViewsCRM.WPF.Views  5      7 clr-namespace:CRM.WPF.ViewModelsCRM.WPF.ViewModels  5          CRM.WPF.Views.OwnTaskView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:CRM.WPF.Views     5      6	viewModel clr-namespace:CRM.WPF.ViewModels     5      
??????????#41518F.??5      ?   ? ColumnDefinitions  5   
   ?? 5      $??* ?6   ?? 5      $	??300 ?6    ? RowDefinitions 5   
   ?? 5      $??10 ?6   ?? 5      $??50 ?6   ?? 5      $	??200 ?6   ?? 5      $??* ?6   .+?5   
   ]? $??0??6   $??1??6$   $??3??61   .+?5      ?? ???#31407B ?? CornerRadius$ 10??6*   ._?5      ?? -   5        $??
lbTaskList??5      $??10 50 10 10q?6-   $??20(?6B   
???????6u   5      5      ?? 5   
   $??Saját feladatok??6   $??20(?6+   $??0??69   $??1??6I   
???????$
??Bold"?6i   $??20 10q?6{   ]? 5   
   $??1??6   $??1??6$   $??2??61   $
??10 0q?6B   .+?5       ?? ???#31407B$ 10??6*   ._?5!      ?? .+?5"      ?? $??Áttekintés??6    
???????$??20(?6E   $
??Bold"?6S   $??20 10q?6e   ?? 5#      
???????$??13(?6{   $
??Bold"?6?   $??20 50 20 10q?6?   ??6    ?? *ownTasks.Count+ ?? StringFormat$" Saját feladatok száma: {0}?? ? DataContext 5$      )   #CRM.WPF.ViewModels.OwnTaskViewModel  5%      5'      ?? 5(      
???????$??13(?6|   $
??Bold"?6?   $??20 10q?6?   ??6    ?? *closeTaskCount+$# Lezárt feladatok száma: {0}?? 5)        5*      5,      ?? 5-      
???????$??13(?6?   $
??Bold"?6?   $??20 10q?6?   ??6    ?? *planedTaskCount+$2 ,Tervezés alatt álló feladatok száma: {0}?? 5.        5/      51      ?? 52      
???????$??13(?6x   $
??Bold"?6?   $??20 10q?6?   ??6    ?? *nearDeadline+$! 10 napon belül lejár: {0}?? 53        54      56      57      58      59      5=      5>      