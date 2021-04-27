using CtmaApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CtmaApp.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
#if DEBUG
            
            Trace.WriteLine("[LoginWindow]: Started.");
#endif
            InitializeComponent();
            //This initialization happens before xaml data binding

        }
        private void txb_MouseEvent(object sender, MouseEventArgs e)
        {
            TextBox tbx = (TextBox)sender;
            //鼠标进入时到hover状态
            if (tbx.IsMouseOver || tbx.Text.Length > 0 || tbx.IsFocused)
            {
                VisualStateManager.GoToElementState(tbx,
                    "OverlayHover", true);
                return;
            }
            else
            {
                VisualStateManager.GoToElementState(tbx,
                "OverlayCover", true);
                return;
            }
        }

        private void txb_FocusEvent(object sender, RoutedEventArgs e)
        {
            TextBox tbx = (TextBox)sender;
            if (tbx.Text.Length > 0 || tbx.IsFocused)
            {
                VisualStateManager.GoToElementState(tbx,
                    "OverlayHover", true);
                return;
            }
            else
            {
                VisualStateManager.GoToElementState(tbx,
                "OverlayCover", true);
                return;
            }
        }
        private void pasb_MouseEvent(object sender, MouseEventArgs e)
        {
            PasswordBox pbx = (PasswordBox)sender;
            //鼠标进入时到hover状态
            if (pbx.IsMouseOver)
            {
                VisualStateManager.GoToElementState(pbx,
                    "PassOverlayHover", true);
            }
            else if (pbx.Password.Length == 0)
            {
                VisualStateManager.GoToElementState(pbx,
                "PassOverlayCover", true);
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CanExecute_Login(object sender, CanExecuteRoutedEventArgs e)
        {
            var vm = (LoginViewModel)MainStackPanel.DataContext;
            e.CanExecute = vm.CheckUserAndPass();
        }

        private void Executed_Login(object sender, ExecutedRoutedEventArgs e)
        {
            var vm = (LoginViewModel)MainStackPanel.DataContext;
            vm.LogIn_Action();
        }
    }
}
