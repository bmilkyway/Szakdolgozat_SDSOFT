   M S B A M L   `   `   `  ????B  >CRM.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CRM.WPF.ViewsCRM.WPF.Views  5   	   C&clr-namespace:CRM.WPF.State.NavigatorsCRM.WPF.State.Navigators  5   	   7 clr-namespace:CRM.WPF.ViewModelsCRM.WPF.ViewModels  5   	   &     CRM.WPF.Views.ActualTaskOpenView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CRM.WPF.Views     5   	   6nav&clr-namespace:CRM.WPF.State.Navigators     5   	   7
ViewModels clr-namespace:CRM.WPF.ViewModels     5   	   ???#7666FF
???????$	??700??5   	   $	??750??6   $	??500??6)   $	??500??68   .??5      ?   ? ColumnDefinitions  5   
   ?? 5      $	??250 ?6   ?? 5      $	??250 ?6    ? RowDefinitions 5   
   ?? 5      $??50 ?6   ?? 5      $??50 ?6   ?? 5      $??50 ?6   ?? 5      $??50 ?6   ?? 5      $	??250 ?6   ?? 5      $	??300 ?6   .+?5   
   ?? -   5        $??	txtStatus??5      $??
Státusz: ??6&   $??0??67   $??0??6G   $??15(?6T   $
??Bold"?6b   $??10q?6t   ?? 5   
   -   5        $??txtDeadline??5      $??Határidő: ??6(   $??1??6:   $??0??6J   $??15(?6W   $
??Bold"?6e   $??10q?6w   ?? 5   
   -   5        $??txtResponsibleUser??5      $??
Felelős: ??6/   $??1??6@   $??0??6M   $??2??6]   $??15(?6q   $
??Bold"?6   $??10q?6?   ?? 5   
   -   5        $??txtCategory??5      $??Kategória: ??6(   $??1??6;   $??1??6H   $??2??6X   $??15(?6l   $
??Bold"?6z   $??10q?6?   ?? 5    
   -   5        $??txtCreatedDate??5       $??Létrehozás dátuma: ??6+   $??2??6F   $??0??6S   $??2??6c   $??15(?6w   $
??Bold"?6?   $??10q?6?   ?? 5!   
   $??Feladat leírása??6   $??3??6-   $??0??6:   $??2??6J   $??15(?6^   $
??Bold"?6l   $??10q?6~   $??Bottom=?6?   ]? 5"   
   $??0??6   $??2??6$   $??4??68   $??10q?6E   .+?5#      ?? ???#41518F ?? CornerRadius$ 20??6*   ._?5$      ?? -   5        $??tbTaskDescription??5$      $??10q?63   ${?false??6?   5%      5&      ?? 5(   
   $??5??6   $??2??6"   $??20 30 20 10q?66   .+?5)      ?? -   5        $??	btnTakeOn??5)      $??	Elvállal??6&   $??20(?69   $??10q?6H   ${?False??6T   6f   ?? 5*      -   5        $??btnClose??5*      $??Lezár??6%   $??20(?65   $??10q?6C   6O   ?? 5+      -	   5        $??	btnModify??5+      $??	Módosít??6&   $??20(?68   $??10q?6F   '   !CRM.WPF.State.Navigators.ViewType   ActualTaskOpen#??Z 6?   ??6R   ?? *)'Navigator.UpdateCurrentViewModelCommand+ ? DataContext 6?   ?? *DataContext+ ?? RelativeSource ?? *FindAncestor+ ?? AncestorType&    CRM.WPF.Views.ActualTaskOpenView"  ?? 5,      -
   5        $??btnGive??5,      $??Átad??6$   $??20(?63   $??10q?6A   5-      5/      50      