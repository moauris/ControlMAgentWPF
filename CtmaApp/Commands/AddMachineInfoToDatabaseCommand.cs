using CtmaApp.Models;
using CtmaApp.ViewModels;
using CtmaApp.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            vm.MachineInfo.OS = vm.OSInfo;
            //BUG: MachineInfo uses a FK OSInfo
            //but when saving changes EF kept on adding it
            //and throwing Identity key cannot be added fir OSInfo

            //Manually prevent FK change
            //See article: 
            //https://docs.microsoft.com/en-us/archive/msdn-magazine/2013/april/data-points-why-does-entity-framework-reinsert-existing-objects-into-my-database
            // In case of an object carrying a FK referenced object
            // If the FK is added with the entity,
            // the FK will also be added
            // If the entity missing the FK is added first,
            // then the entity's FK field populate
            // It will be modified instead of added
#if DEBUG

            ctx.ChangeTracker.DetectChanges();
            Trace.WriteLine("[AddMachineInfoCommand]:");
            Trace.WriteLine(ctx.ChangeTracker.DebugView.LongView);


            var changes = ctx.ChangeTracker.Entries();
            //Need to manually detach the ChangeTracker for OS
            foreach (var change in changes)
            {
                Trace.IndentLevel = 2;
                Trace.Write("[Change Entries] : ");
                Trace.Write(change.Entity.ToString());
                Trace.Write(change.Entity.GetHashCode());
                Trace.Write(" ");
                Trace.WriteLine(change.State);


                Trace.IndentLevel = 0;
            }
            Trace.Write("[vm.MachineInfo.OS] Hash Code is: ");
            Trace.WriteLine(vm.MachineInfo.OS.GetHashCode());
            Trace.Flush();
#endif
            
            var ans = MessageBox.Show("Confirm Sync?", "Completed", MessageBoxButton.OKCancel);

            if (ans == MessageBoxResult.OK)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                ctx.SaveChanges();

                WorkspaceWindow window = Application.Current.MainWindow as WorkspaceWindow;
                WorkspaceViewModel model = window.MainGrid.DataContext as WorkspaceViewModel;
                model.RefreshMachineInfo();


                MessageBox.Show($"SaveChanges Completed. Took: {sw.ElapsedMilliseconds} ms");
            }
        }
    }
}
