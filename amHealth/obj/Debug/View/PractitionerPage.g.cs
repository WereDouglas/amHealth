﻿#pragma checksum "..\..\..\View\PractitionerPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5569BEF4BD9D8D2EACD287DC484AD478"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.33440
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace amHealth {
    
    
    /// <summary>
    /// PractitionerPage
    /// </summary>
    public partial class PractitionerPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 9 "..\..\..\View\PractitionerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox groupBox7;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\View\PractitionerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView PractitionerlistView;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\View\PractitionerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\View\PractitionerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd_Copy;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\View\PractitionerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExport;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\View\PractitionerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblName;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\View\PractitionerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFilter;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\View\PractitionerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkSelectAll;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\View\PractitionerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExport_Copy;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/amHealth;component/view/practitionerpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\PractitionerPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.groupBox7 = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 2:
            this.PractitionerlistView = ((System.Windows.Controls.ListView)(target));
            
            #line 11 "..\..\..\View\PractitionerPage.xaml"
            this.PractitionerlistView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.PatientlistView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\View\PractitionerPage.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.btnAdd_Click_1);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnAdd_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 88 "..\..\..\View\PractitionerPage.xaml"
            this.btnAdd_Copy.Click += new System.Windows.RoutedEventHandler(this.btnDeleteAll_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnExport = ((System.Windows.Controls.Button)(target));
            
            #line 98 "..\..\..\View\PractitionerPage.xaml"
            this.btnExport.Click += new System.Windows.RoutedEventHandler(this.Button_Click_export);
            
            #line default
            #line hidden
            return;
            case 11:
            this.lblName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.txtFilter = ((System.Windows.Controls.TextBox)(target));
            
            #line 111 "..\..\..\View\PractitionerPage.xaml"
            this.txtFilter.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtFilter_TextChanged);
            
            #line default
            #line hidden
            return;
            case 13:
            this.chkSelectAll = ((System.Windows.Controls.CheckBox)(target));
            
            #line 113 "..\..\..\View\PractitionerPage.xaml"
            this.chkSelectAll.Click += new System.Windows.RoutedEventHandler(this.chkSelectAll_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.btnExport_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 114 "..\..\..\View\PractitionerPage.xaml"
            this.btnExport_Copy.Click += new System.Windows.RoutedEventHandler(this.Button_Click_export);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 3:
            
            #line 17 "..\..\..\View\PractitionerPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.image_Click);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 30 "..\..\..\View\PractitionerPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditButton_Click);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 39 "..\..\..\View\PractitionerPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteButton_Click);
            
            #line default
            #line hidden
            break;
            case 6:
            
            #line 48 "..\..\..\View\PractitionerPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MessageButton_Click);
            
            #line default
            #line hidden
            break;
            case 7:
            
            #line 58 "..\..\..\View\PractitionerPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.appointmentsButton_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

