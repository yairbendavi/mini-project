#pragma checksum "..\..\LINQwindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4B8446949CDFA02538C4083818E52A7F"
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
using UI;


namespace UI
{


    /// <summary>
    /// LINQwindow
    /// </summary>
    public partial class LINQwindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/UI;component/linqwindow.xaml", System.UriKind.Relative);

#line 1 "..\..\LINQwindow.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.Grid hooo;
        internal System.Windows.Controls.Button Button1;
        internal System.Windows.Controls.Button Button2;
        internal System.Windows.Controls.Button Button3;
        internal System.Windows.Controls.ComboBox EntityComboBox;
        internal System.Windows.Controls.ListView ShowAllChildrenListView;
        internal System.Windows.Controls.ListView ShowAllNanniesListView;
        internal System.Windows.Controls.ListView ShowAllMothersListView;
        internal System.Windows.Controls.ListView ShowAllContractsListView;
        internal System.Windows.Controls.ListView SignedContractsListView;
        internal System.Windows.Controls.ListView GroupByChildrenAgeListView;
        internal System.Windows.Controls.ListView ShowAllTamatListView;
        internal System.Windows.Controls.ListView GetAllChildrenWithoutNannyListView;
        internal System.Windows.Controls.ListView GroupAllContractsByDistanceListView;
    }
}

