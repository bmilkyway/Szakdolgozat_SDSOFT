﻿#pragma checksum "..\..\..\..\Views\FeedbackForUserView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4649237AB81A41B0239897EB3680DD010369B52D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CRM.WPF.Views;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
    /// FeedbackForUserView
    /// </summary>
    public partial class FeedbackForUserView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 52 "..\..\..\..\Views\FeedbackForUserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFeedbackName;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Views\FeedbackForUserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbFeedbackType;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\Views\FeedbackForUserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTaskDescription;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Views\FeedbackForUserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSend;
        
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
            System.Uri resourceLocater = new System.Uri("/CRM.WPF;component/views/feedbackforuserview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\FeedbackForUserView.xaml"
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
            this.txtFeedbackName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.cbFeedbackType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.txtTaskDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnSend = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\..\Views\FeedbackForUserView.xaml"
            this.btnSend.Click += new System.Windows.RoutedEventHandler(this.sendFeedback);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

