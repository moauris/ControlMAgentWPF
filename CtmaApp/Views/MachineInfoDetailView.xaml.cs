using CtmaApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CtmaApp.Views
{
    /// <summary>
    /// Interaction logic for MachineInfoDetailView.xaml
    /// </summary>
    public partial class MachineInfoDetailView : Window
    {
        public MachineInfoDetailView()
        {
            InitializeComponent();
        }

        private void btnCheckClicked(object sender, RoutedEventArgs e)
        {
            var vm = (MachineInfoDetailViewModel)MainGrid.DataContext;

            MessageBox.Show(vm.MachineInfo.ToSummary());
        }
    }
}
