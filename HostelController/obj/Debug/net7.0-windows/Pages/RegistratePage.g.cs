﻿#pragma checksum "..\..\..\..\Pages\RegistratePage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "05D6AA3AB9863D574EE4D3FE3130BF5E53EC15B0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro;
using MahApps.Metro.Accessibility;
using MahApps.Metro.Actions;
using MahApps.Metro.Automation.Peers;
using MahApps.Metro.Behaviors;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Converters;
using MahApps.Metro.Markup;
using MahApps.Metro.Theming;
using MahApps.Metro.ValueBoxes;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace HostelController {
    
    
    /// <summary>
    /// RegistratePage
    /// </summary>
    public partial class RegistratePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\Pages\RegistratePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameTxtBx;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Pages\RegistratePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RoomCmbBx;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Pages\RegistratePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateOfEnty;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Pages\RegistratePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SurnameTxtBx;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Pages\RegistratePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox BedCmbBx;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Pages\RegistratePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.TimePicker TimeOfEntry;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Pages\RegistratePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.NumericUpDown ValueOfDays;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Pages\RegistratePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddButt;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HostelController;component/pages/registratepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\RegistratePage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.NameTxtBx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.RoomCmbBx = ((System.Windows.Controls.ComboBox)(target));
            
            #line 13 "..\..\..\..\Pages\RegistratePage.xaml"
            this.RoomCmbBx.LostFocus += new System.Windows.RoutedEventHandler(this.InitializeBedCmbBxOnChoosingRoom);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DateOfEnty = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.SurnameTxtBx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.BedCmbBx = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.TimeOfEntry = ((MahApps.Metro.Controls.TimePicker)(target));
            return;
            case 7:
            this.ValueOfDays = ((MahApps.Metro.Controls.NumericUpDown)(target));
            return;
            case 8:
            this.AddButt = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\Pages\RegistratePage.xaml"
            this.AddButt.Click += new System.Windows.RoutedEventHandler(this.AddButt_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

