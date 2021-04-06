﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using CtmaApp.Commands;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Principal;
using CtmaApp.AppSecurityService;
using System.Windows;

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

        private ICommand _loginCommand;
        public ICommand LoginCommand
        {
            //TODO: How to handle commands
            get => _loginCommand ?? (_loginCommand = 
                new ActionCommand((0) => LogIn_Action(0), (0) => CheckUserAndPass(0)));
        }

        private bool CheckUserAndPass(object parameter)
        {
            return _username != string.Empty && 
                _username.Length > 0 && 
                _password != null && 
                _password.Length > 0;
        }

        private void LogIn_Action(object parameter)
        {
            CurrentUser = CryptoServices.LogIn(UserName, Password);
            if (CurrentUser == null)
            {
                MessageBox.Show("Login Not successful");
            }
            else
            {
                MessageBox.Show($"Welcome, {CurrentUser.Identity.Name}, Is Authenticated: {CurrentUser.Identity.IsAuthenticated}");
            }
        }
    }
}