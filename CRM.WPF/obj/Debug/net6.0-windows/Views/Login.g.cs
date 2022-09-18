﻿#pragma checksum "..\..\..\..\Views\Login.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D7B65B763597DC9D027C35CD26C6B5BE4123FB7E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace CRM.WPF {
    
    
    /// <summary>
    /// Login
    /// </summary>
    public partial class Login : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\..\Views\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CRM.WPF.Login Login_Window;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Views\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost DialogHost;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Views\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnHelp;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Views\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExit;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Views\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgLoginLogo;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Views\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtUsername;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Views\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtPassword;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Views\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogin;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Views\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnForgetPasswd;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Views\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSignUp;
        
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
            System.Uri resourceLocater = new System.Uri("/CRM.WPF;component/views/login.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Login.xaml"
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
            this.Login_Window = ((CRM.WPF.Login)(target));
            return;
            case 2:
            this.DialogHost = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            case 3:
            this.btnHelp = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.btnExit = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\Views\Login.xaml"
            this.btnExit.Click += new System.Windows.RoutedEventHandler(this.exitApp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.imgLoginLogo = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.txtUsername = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 8:
            this.btnLogin = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\..\Views\Login.xaml"
            this.btnLogin.Click += new System.Windows.RoutedEventHandler(this.Log_in);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnForgetPasswd = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\..\Views\Login.xaml"
            this.btnForgetPasswd.Click += new System.Windows.RoutedEventHandler(this.btnForgetPasswd_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnSignUp = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\..\Views\Login.xaml"
            this.btnSignUp.Click += new System.Windows.RoutedEventHandler(this.btnSignUp_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
