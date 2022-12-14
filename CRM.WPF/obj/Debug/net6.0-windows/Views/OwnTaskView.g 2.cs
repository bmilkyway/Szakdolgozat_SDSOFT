#pragma checksum "..\..\..\..\Views\OwnTaskView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "406F93CDDE50B64F7B4485C321C1D2A67463AE21"
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
    /// OwnTaskView
    /// </summary>
    public partial class OwnTaskView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\Views\OwnTaskView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbTaskList;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\Views\OwnTaskView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbPlanning;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\Views\OwnTaskView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbStarted;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\Views\OwnTaskView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbClosed;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\Views\OwnTaskView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbNearDeadline;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Views\OwnTaskView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbExpired;
        
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
            System.Uri resourceLocater = new System.Uri("/CRM.WPF;component/views/owntaskview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\OwnTaskView.xaml"
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
            this.lbTaskList = ((System.Windows.Controls.ListBox)(target));
            
            #line 28 "..\..\..\..\Views\OwnTaskView.xaml"
            this.lbTaskList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.openSelectedTask);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cbPlanning = ((System.Windows.Controls.CheckBox)(target));
            
            #line 55 "..\..\..\..\Views\OwnTaskView.xaml"
            this.cbPlanning.Click += new System.Windows.RoutedEventHandler(this.setFilterTaskList);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cbStarted = ((System.Windows.Controls.CheckBox)(target));
            
            #line 56 "..\..\..\..\Views\OwnTaskView.xaml"
            this.cbStarted.Click += new System.Windows.RoutedEventHandler(this.setFilterTaskList);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbClosed = ((System.Windows.Controls.CheckBox)(target));
            
            #line 57 "..\..\..\..\Views\OwnTaskView.xaml"
            this.cbClosed.Click += new System.Windows.RoutedEventHandler(this.setFilterTaskList);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cbNearDeadline = ((System.Windows.Controls.CheckBox)(target));
            
            #line 58 "..\..\..\..\Views\OwnTaskView.xaml"
            this.cbNearDeadline.Click += new System.Windows.RoutedEventHandler(this.setFilterTaskList);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cbExpired = ((System.Windows.Controls.CheckBox)(target));
            
            #line 59 "..\..\..\..\Views\OwnTaskView.xaml"
            this.cbExpired.Click += new System.Windows.RoutedEventHandler(this.setFilterTaskList);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

