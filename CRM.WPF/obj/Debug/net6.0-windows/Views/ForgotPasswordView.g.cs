#pragma checksum "..\..\..\..\Views\ForgotPasswordView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "96639679321EBDC780B748D037EE4895B0C39BBD"
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


namespace CRM.WPF.Views {
    
    
    /// <summary>
    /// ForgotPasswordView
    /// </summary>
    public partial class ForgotPasswordView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\..\Views\ForgotPasswordView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CRM.WPF.Views.ForgotPasswordView SignIn_Window;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Views\ForgotPasswordView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost DialogHost;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Views\ForgotPasswordView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnHelp;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Views\ForgotPasswordView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExit;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Views\ForgotPasswordView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtEmail;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Views\ForgotPasswordView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCode;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Views\ForgotPasswordView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtNewPassword;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Views\ForgotPasswordView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtNewPasswordCopy;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Views\ForgotPasswordView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSignIn;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Views\ForgotPasswordView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/CRM.WPF;component/views/forgotpasswordview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\ForgotPasswordView.xaml"
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
            this.SignIn_Window = ((CRM.WPF.Views.ForgotPasswordView)(target));
            return;
            case 2:
            this.DialogHost = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            case 3:
            this.btnHelp = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.btnExit = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\Views\ForgotPasswordView.xaml"
            this.btnExit.Click += new System.Windows.RoutedEventHandler(this.exitApp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtCode = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtNewPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 8:
            this.txtNewPasswordCopy = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 9:
            this.btnSignIn = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\Views\ForgotPasswordView.xaml"
            this.btnSignIn.Click += new System.Windows.RoutedEventHandler(this.SendAutenticationCode);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\Views\ForgotPasswordView.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.CancelForgotPassword);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

