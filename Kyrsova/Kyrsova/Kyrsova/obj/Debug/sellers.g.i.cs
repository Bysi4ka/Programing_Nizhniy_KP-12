﻿#pragma checksum "..\..\sellers.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "034FF5D11D5C720AA78E260CF9BDB898A50A95B5184A391D6D8CCB5FC1827B57"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Kyrsova;
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


namespace Kyrsova {
    
    
    /// <summary>
    /// sellers
    /// </summary>
    public partial class sellers : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\sellers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addB;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\sellers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameT;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\sellers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox surnameT;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\sellers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CB;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\sellers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteB;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\sellers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameT2;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\sellers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox surnameT2;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\sellers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button changeB;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\sellers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button mw;
        
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
            System.Uri resourceLocater = new System.Uri("/Kyrsova;component/sellers.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\sellers.xaml"
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
            this.addB = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\sellers.xaml"
            this.addB.Click += new System.Windows.RoutedEventHandler(this.addB_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.nameT = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.surnameT = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.CB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 19 "..\..\sellers.xaml"
            this.CB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CB_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.deleteB = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\sellers.xaml"
            this.deleteB.Click += new System.Windows.RoutedEventHandler(this.deleteB_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.nameT2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.surnameT2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.changeB = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\sellers.xaml"
            this.changeB.Click += new System.Windows.RoutedEventHandler(this.changeB_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.mw = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\sellers.xaml"
            this.mw.Click += new System.Windows.RoutedEventHandler(this.mw_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

