   M S B A M L   `   `   `  ????B  >CRM.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:CRM.WPFCRM.WPF  5   	   3clr-namespace:CRM.WPF.ControlsCRM.WPF.Controls  5   	       CRM.WPF.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:CRM.WPF     5   	   3controlsclr-namespace:CRM.WPF.Controls     5   	     ? WindowStartupLocation$  CenterScreen=?5	   	    ? WindowStyle$ SingleBorderWindow=?5
   
    ? Title$ SD-SOFT Feladatkezelő??5   	   $	??740??6'   $
??1280??64   $	??740??6A   $
??1280??6Q   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $	??250 ?6   ?? 5      $??* ?6    ? RowDefinitions 5   
   ?? 5      $??* ?6   .+?5   
   $   CRM.WPF.Controls.NavigationBar  $??2??6"   $??0??63   $??0??6@    ? DataContext 6Q   ?? *	Navigator+?? 5   
   
?????? $??0??6-   $??1??6:   $?? ??6L   ?? 5   
   $??0??6   $??1??6&   ??66   ?? *Navigator.CurrentViewModel+5      5       5"      