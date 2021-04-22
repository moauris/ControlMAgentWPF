using CtmaApp.Models;
using CtmaApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CtmaApp.Commands
{
    public class AddMachineInfoToDatabaseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //TODO: Need to check if the MachineInfoDetail is complete
            return true;
        }

        public void Execute(object parameter)
        {
            MachineInfoDetailViewModel vm = (MachineInfoDetailViewModel)parameter;
            DataContext ctx = new DataContext();

            ctx.tbl_MachineInfo.Add(vm.MachineInfo);

            ctx.SaveChanges();
        }
    }
}
