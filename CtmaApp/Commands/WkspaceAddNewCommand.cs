using CtmaApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CtmaApp.Commands
{
    public class WkspaceAddNewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private bool hasActiveDetailView = false;

        public bool CanExecute(object parameter)
        {
            return !hasActiveDetailView;
        }

        public void Execute(object parameter)
        {
            var detailView = new MachineInfoDetailView();
            hasActiveDetailView = true;
            CanExecuteChanged?.Invoke(this, new EventArgs());
            detailView.Show();
        }
    }
}
