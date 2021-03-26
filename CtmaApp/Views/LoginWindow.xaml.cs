﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            InitializeComponent();
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

    }
}
