﻿#pragma checksum "..\..\..\CategoryEditing.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B76A1606B8E26EB0D6606B5F8DEA1D6FB8DE7DB3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using WinClientWPF;


namespace WinClientWPF {
    
    
    /// <summary>
    /// CategoryEditing
    /// </summary>
    public partial class CategoryEditing : WinClientWPF.Editing, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\CategoryEditing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxCategoryName;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\CategoryEditing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxCategoryDescription;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\CategoryEditing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbxParts;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\CategoryEditing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRefresh;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WinClientWPF;component/categoryediting.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CategoryEditing.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.tbxCategoryName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tbxCategoryDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.lbxParts = ((System.Windows.Controls.ListBox)(target));
            
            #line 12 "..\..\..\CategoryEditing.xaml"
            this.lbxParts.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.lbxParts_MouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 12 "..\..\..\CategoryEditing.xaml"
            this.lbxParts.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lbxParts_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 15 "..\..\..\CategoryEditing.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.menuEdit_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 17 "..\..\..\CategoryEditing.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.menuDeleteSelected_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnRefresh = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\CategoryEditing.xaml"
            this.btnRefresh.Click += new System.Windows.RoutedEventHandler(this.btnRefresh_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

