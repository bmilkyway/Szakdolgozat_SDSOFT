﻿#pragma checksum "..\..\..\..\Views\FeedbackForUsersView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24897DC50FF6346A4AE993BD7D9F21F5F4A5A68F"
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
    /// FeedbackForUsersView
    /// </summary>
    public partial class FeedbackForUsersView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 52 "..\..\..\..\Views\FeedbackForUsersView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnModify;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Views\FeedbackForUsersView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\Views\FeedbackForUsersView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtName;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\Views\FeedbackForUsersView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtUserName;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\Views\FeedbackForUsersView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtEmail;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\Views\FeedbackForUsersView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbPermission;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\Views\FeedbackForUsersView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbAllUsers;
        
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
            System.Uri resourceLocater = new System.Uri("/CRM.WPF;component/views/feedbackforusersview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\FeedbackForUsersView.xaml"
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
            this.btnModify = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\..\Views\FeedbackForUsersView.xaml"
            this.btnModify.Click += new System.Windows.RoutedEventHandler(this.saveSelectedUserModify);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\..\Views\FeedbackForUsersView.xaml"
            this.btnDelete.Click += new System.Windows.RoutedEventHandler(this.selectedUserDelete);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtUserName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.cbPermission = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.lbAllUsers = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

