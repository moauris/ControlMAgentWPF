using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Principal;
using CtmaApp.AppSecurityService;
using System.Windows;
using CtmaApp.Views;
using System.Diagnostics;

namespace CtmaApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _username;

        public string UserName
        {
            get { return _username; }
            set
            {
                if(value != _username)
                {
                    _username = value;
                    OnPropertyChanged();
                }
            }

        }
        private SecureString _password;

        public SecureString Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public GenericPrincipal CurrentUser { get; set; }


        public bool CheckUserAndPass()
        {
            return _username != null && 
                _username.Length > 0 && 
                _password != null && 
                _password.Length > 0;
        }

        public void LogIn_Action()
        {
            CurrentUser = CryptoServices.LogIn(UserName, Password);
            if (CurrentUser == null)
            {
                MessageBox.Show("Login Not successful");
                Password = null;
            }
            else
            {
#if DEBUG
                Trace.WriteLine($"[LoginViewModel]: Welcome, {CurrentUser.Identity.Name}, Is Authenticated: {CurrentUser.Identity.IsAuthenticated}");
                Trace.Flush();
#endif

                Window wkspace = new WorkspaceWindow();
                wkspace.Show();
                Application.Current.MainWindow = wkspace;
                Application.Current.Windows[0].Close();
            }
        }
    }
}
