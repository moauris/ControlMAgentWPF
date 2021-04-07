using CtmaApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace CtmaApp.ViewModels
{
    public class MachineBadgeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private protected virtual void OnPropertyChanged([CallerMemberName]string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        private MachineInfo _machine;
        public MachineInfo MachineInfo
        {
            get => _machine;
            set
            {
                if (_machine != value)
                {
                    _machine = value;
                    OnPropertyChanged();
                }
            }
        }
        public MachineBadgeViewModel() { }

        #region Properties

        public string HostName
        {
            get { return MachineInfo.HostName; }
            set 
            {
                if (MachineInfo.HostName != value)
                {
                    MachineInfo.HostName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Domain
        {
            get { return MachineInfo.Domain; }
            set
            {
                if (MachineInfo.Domain != value)
                {
                    MachineInfo.Domain = value;
                    OnPropertyChanged();
                }
            }
        }

        public IPAddress IPv4
        {
            get { return MachineInfo.IPv4; }
            set
            {
                if (MachineInfo.IPv4.ToString() != value.ToString())
                {
                    MachineInfo.IPv4 = value;
                    OnPropertyChanged();
                }
            }
        }

        public IPAddress IPv6
        {
            get { return MachineInfo.IPv6; }
            set
            {
                if (MachineInfo.IPv6.ToString() != value.ToString())
                {
                    MachineInfo.IPv6 = value;
                    OnPropertyChanged();
                }
            }
        }


        public OSInfo OS
        {
            get { return MachineInfo.OS; }
            set
            {
                if (MachineInfo.OS.ToString() != value.ToString())
                {
                    MachineInfo.OS = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

    }
}
