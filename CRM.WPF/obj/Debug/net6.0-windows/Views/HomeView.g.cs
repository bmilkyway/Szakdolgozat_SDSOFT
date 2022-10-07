﻿#pragma checksum "..\..\..\..\Views\HomeView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42FFF7017120534D1F83B8C6C34DC3B800D12F13"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CRM.WPF.ViewModels;
using CRM.WPF.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace CRM.WPF.Views {
    
    
    /// <summary>
    /// HomeView
    /// </summary>
    public partial class HomeView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\..\Views\HomeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbPlanning;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Views\HomeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbStarted;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Views\HomeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbClosed;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Views\HomeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbNearDeadline;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Views\HomeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbExpired;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Views\HomeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtNearDeadline;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\Views\HomeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel mainGrid;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\Views\HomeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl detailsItemsControl;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\..\Views\HomeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas mainCanvas;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\..\Views\HomeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbOwnTasks;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.7.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CRM.WPF;component/views/homeview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\HomeView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.cbPlanning = ((System.Windows.Controls.CheckBox)(target));
            
            #line 32 "..\..\..\..\Views\HomeView.xaml"
            this.cbPlanning.Click += new System.Windows.RoutedEventHandler(this.setFilterTaskList);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cbStarted = ((System.Windows.Controls.CheckBox)(target));
            
            #line 33 "..\..\..\..\Views\HomeView.xaml"
            this.cbStarted.Click += new System.Windows.RoutedEventHandler(this.setFilterTaskList);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cbClosed = ((System.Windows.Controls.CheckBox)(target));
            
            #line 34 "..\..\..\..\Views\HomeView.xaml"
            this.cbClosed.Click += new System.Windows.RoutedEventHandler(this.setFilterTaskList);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbNearDeadline = ((System.Windows.Controls.CheckBox)(target));
            
            #line 35 "..\..\..\..\Views\HomeView.xaml"
            this.cbNearDeadline.Click += new System.Windows.RoutedEventHandler(this.setFilterTaskList);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cbExpired = ((System.Windows.Controls.CheckBox)(target));
            
            #line 36 "..\..\..\..\Views\HomeView.xaml"
            this.cbExpired.Click += new System.Windows.RoutedEventHandler(this.setFilterTaskList);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtNearDeadline = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.mainGrid = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.detailsItemsControl = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 9:
            this.mainCanvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 10:
            this.lbOwnTasks = ((System.Windows.Controls.ListBox)(target));
            
            #line 107 "..\..\..\..\Views\HomeView.xaml"
            this.lbOwnTasks.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.openThisTask);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

