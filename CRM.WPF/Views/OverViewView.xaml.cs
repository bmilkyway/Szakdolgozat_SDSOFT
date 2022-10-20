using System.Windows.Controls;

using CRM.WPF.ViewModels;

namespace CRM.WPF.Views
{
    /// <summary>
    /// Interaction logic for OverViewView.xaml
    /// </summary>
    public partial class OverViewView : UserControl
    {
        private OverViewViewModel overViewViewModel;
        public OverViewView()
        {
            InitializeComponent();
            overViewViewModel = new OverViewViewModel();
        }
    }
}
