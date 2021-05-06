using CtmaApp.Commands;
using CtmaApp.Models;
using CtmaApp.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CtmaApp.ViewModels
{
    public class WorkspaceViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private DataContext _datacontext;

        private ObservableCollection<MachineInfo> _machineInfos;
        public ObservableCollection<MachineInfo> MachineInfos
        {
            get => _machineInfos;
            set
            {
                _machineInfos = value;
                OnPropertyChanged();
            }
        }

        public WorkspaceViewModel()
        {
            _datacontext = new DataContext();
            //Need to include OSInfo here or else it won't show
            RefreshMachineInfo();
        }

        public void RefreshMachineInfo()
        {
#if DEBUG
            Trace.WriteLine("[WorkspaceViewModel]::RefreshMachineInfo()");
#endif
            MachineInfos = new
                ObservableCollection<MachineInfo>(_datacontext.tbl_MachineInfo
                .Include(o => o.OS).ToArray());
#if DEBUG
            Trace.IndentLevel = 2;
            Trace.WriteLine("[WorkspaceViewModel]::RefreshMachineInfo()");
            foreach (var mc in MachineInfos)
            {
                Trace.WriteLine(mc.GetFQDN());
            }
            Trace.IndentLevel = 0;
#endif
        }

        private bool hasNoActiveDetailView = true;
        private RelayCommand _addNewInfoCommand;

        public RelayCommand AddNewInfoCommand
        {
            get {
                RelayCommand result = _addNewInfoCommand ?? (_addNewInfoCommand =
                    new RelayCommand
                    (
                        () =>
                        {
                            var detailView = new MachineInfoDetailView();
                            detailView.Closed += (s, e) =>
                            {
                                hasNoActiveDetailView = true;
                            };
                            hasNoActiveDetailView = false;
                            detailView.Show();
                        },
                        () => hasNoActiveDetailView
                    ));
                return result;
            }
        }

    }
}
