#pragma checksum "..\..\..\Pages\RealizationPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2D03E7B10CD23AE737D154C928878879F6454641B3390D67A7FCF1A48B4FF13A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using WpfApp7.Pages;


namespace WpfApp7.Pages
{


    /// <summary>
    /// RealizationPage
    /// </summary>
    public partial class RealizationPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector
    {


#line 21 "..\..\..\Pages\RealizationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox HowManyRealizeTextBox;

#line default
#line hidden


#line 24 "..\..\..\Pages\RealizationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid RealizationDataGrid;

#line default
#line hidden

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
            System.Uri resourceLocater = new System.Uri("/WpfApp7;component/pages/realizationpage.xaml", System.UriKind.Relative);

#line 1 "..\..\..\Pages\RealizationPage.xaml"
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
            switch (connectionId)
            {
                case 1:

#line 9 "..\..\..\Pages\RealizationPage.xaml"
                    ((WpfApp7.Pages.RealizationPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);

#line default
#line hidden

#line 9 "..\..\..\Pages\RealizationPage.xaml"
                    ((WpfApp7.Pages.RealizationPage)(target)).Unloaded += new System.Windows.RoutedEventHandler(this.Page_Unloaded_1);

#line default
#line hidden
                    return;
                case 2:
                    this.HowManyRealizeTextBox = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 3:
                    this.RealizationDataGrid = ((System.Windows.Controls.DataGrid)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.ComboBox WheelsComboBox;
        internal System.Windows.Controls.Button ExecuteButton;
    }
}

