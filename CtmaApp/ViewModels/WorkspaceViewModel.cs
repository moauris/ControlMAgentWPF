using CtmaApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        private IEnumerable<MachineInfo> _machineInfos;

        
        public IEnumerable<MachineInfo> MachineInfos
        {
            get { return _machineInfos; }
            set { _machineInfos = value; OnPropertyChanged(); }
        }

        public WorkspaceViewModel()
        {
            _datacontext = new DataContext();
            MachineInfos = (
                from m in _datacontext.tbl_MachineInfo 
                select m).ToArray();
        }
    }
}
