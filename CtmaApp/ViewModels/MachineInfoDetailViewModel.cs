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
    public class MachineInfoDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private protected virtual void OnPropertyChanged([CallerMemberName]string Property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Property));
        }

        internal event _osDetailUpdatedEventHandler _osDetailUpdated;
        private protected virtual void _onOsDetailUpdated(bool IsL0)
        {
            _osDetailUpdated?.Invoke(this, new _osDetailUpdatedEventArgs(IsL0));
        }
        internal event _osDetailCompletedEventHandler _osDetailCompleted;


        private DataContext _context;

        public MachineInfoDetailViewModel()
        {
            _machineInfo = new MachineInfo();

            OSInfo1_List = new List<string>();
            OSInfo2_List = new List<string>();

            _osDetailUpdated += _osDetailUpdatedHandler;
            _osDetailCompleted += _osDetailCompletedHandler;
            _context = new DataContext();

            OSInfo0_List = (from o in _context.tbl_OSInfo
                            select o.Platform).Distinct().ToList();
        }

        private void _osDetailCompletedHandler(object sender, _osDetailCompletedEventArgs e)
        {
            //Completed, injecting values to make a new OSInfo object

            OSInfo _osInfo = new OSInfo();
            _osInfo.Platform = e.Platform;
            _osInfo.Version = e.Version;
            _osInfo.Architecture = e.Arch;
            _machineInfo.OS = _osInfo;
        }

        private void _osDetailUpdatedHandler(object sender, _osDetailUpdatedEventArgs e)
        {
            if (e.IsLv0orLv1Updated)
            {
                OSInfo1_List =
                    (from v in _context.tbl_OSInfo
                     where v.Platform == OSInfo0
                     select v.Version)
                    .Distinct().ToList();
            }
            else
            {
                OSInfo2_List =
                    (from a in _context.tbl_OSInfo
                     where a.Platform == OSInfo0 && a.Version == OSInfo1
                     select a.Architecture)
                     .Distinct().ToList();
            }
        }

        private MachineInfo _machineInfo;

        public MachineInfo MachineInfo
        {
            get { return _machineInfo; }
            set { _machineInfo = value; OnPropertyChanged(); }
        }

        private string _osInfo0;

        public string OSInfo0
        {
            get { return _osInfo0; }
            set 
            {
                _osInfo0 = value;
                _onOsDetailUpdated(true);
                OnPropertyChanged(); 
            }
        }
        private string _osInfo1;

        public string OSInfo1
        {
            get { return _osInfo1; }
            set
            {
                _osInfo1 = value;
                _onOsDetailUpdated(false);
                OnPropertyChanged();
            }
        }
        private string _osInfo2;

        public string OSInfo2
        {
            get { return _osInfo2; }
            set 
            { 
                _osInfo2 = value; 
                OnPropertyChanged();
                _osDetailCompleted?.Invoke(this,
                    new _osDetailCompletedEventArgs(_osInfo0, _osInfo1, _osInfo2));
            }
        }

        public List<string> OSInfo0_List { get; set; }
        private List<string> _osInfo1_List;
        public List<string> OSInfo1_List { get => _osInfo1_List;

            set { _osInfo1_List = value; OnPropertyChanged(); }
        }
        private List<string> _osInfo2_List;
        public List<string> OSInfo2_List
        {
            get => _osInfo2_List;

            set { _osInfo2_List = value; OnPropertyChanged(); }
        }
    }

    internal class _osDetailUpdatedEventArgs : EventArgs
    {
        internal _osDetailUpdatedEventArgs(bool isLv0)
        {
            IsLv0orLv1Updated = isLv0;
        }
        internal bool IsLv0orLv1Updated;
    }

    internal delegate void _osDetailUpdatedEventHandler(object sender, _osDetailUpdatedEventArgs e);

    internal class _osDetailCompletedEventArgs : EventArgs
    {
        internal _osDetailCompletedEventArgs(string platform, string version, string arch)
        {
            Platform = platform;
            Version = version;
            Arch = arch;
        }
        public string Platform { get; set; }
        public string Version { get; set; }
        public string Arch { get; set; }
    }

    internal delegate void _osDetailCompletedEventHandler(object sender, _osDetailCompletedEventArgs e);


}
