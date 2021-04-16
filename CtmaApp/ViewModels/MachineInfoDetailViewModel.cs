using CtmaApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CtmaApp.ViewModels
{
    public class MachineInfoDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private protected virtual void OnPropertyChanged([CallerMemberName]string Property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Property));
        }

        public MachineInfoDetailViewModel()
        {
            _machineInfo = new MachineInfo();
        }

        private MachineInfo _machineInfo;

        public MachineInfo MachineInfo
        {
            get { return _machineInfo; }
            set { _machineInfo = value; OnPropertyChanged(); }
        }



    }
}
