﻿#pragma checksum "..\..\..\..\View\Appointments\ManageAppointment .xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C07D5F435C3FFF1813161D119B9CC732"
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


namespace amHealth.View.Appointments {
    
    
    /// <summary>
    /// ManageAppointment
    /// </summary>
    public partial class ManageAppointment : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 10 "..\..\..\..\View\Appointments\ManageAppointment .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDialogOk;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\View\Appointments\ManageAppointment .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView AppointmentlistView;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\View\Appointments\ManageAppointment .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker selectdate;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\View\Appointments\ManageAppointment .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label appointmentcount;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\View\Appointments\ManageAppointment .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label prac;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\View\Appointments\ManageAppointment .xaml"
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
            System.Uri resourceLocater = new System.Uri("/amHealth;component/view/appointments/manageappointment%20.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Appointments\ManageAppointment .xaml"
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
            this.btnDialogOk = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\..\View\Appointments\ManageAppointment .xaml"
            this.btnDialogOk.Click += new System.Windows.RoutedEventHandler(this.btnDialogOk_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AppointmentlistView = ((System.Windows.Controls.ListView)(target));
            
            #line 13 "..\..\..\..\View\Appointments\ManageAppointment .xaml"
            this.AppointmentlistView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.AppointlistView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.selectdate = ((System.Windows.Controls.DatePicker)(target));
            
            #line 59 "..\..\..\..\View\Appointments\ManageAppointment .xaml"
            this.selectdate.LostFocus += new System.Windows.RoutedEventHandler(this.selectdate_LostFocus);
            
            #line default
            #line hidden
            return;
            case 7:
            this.appointmentcount = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.prac = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.btnExport_Copy = ((System.Windows.Controls.Button)(target));
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
            
            #line 17 "..\..\..\..\View\Appointments\ManageAppointment .xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 32 "..\..\..\..\View\Appointments\ManageAppointment .xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditButton_Click);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 41 "..\..\..\..\View\Appointments\ManageAppointment .xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteButton_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

