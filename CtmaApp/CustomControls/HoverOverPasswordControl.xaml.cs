using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CtmaApp.CustomControls
{
    /// <summary>
    /// Interaction logic for HoverOverPasswordControl.xaml
    /// </summary>
    /// 
    [ContentProperty("OverlayText")]
    public partial class HoverOverPasswordControl : UserControl
    {
        public string OverlayText
        {
            get { return (string)GetValue(OverlayTextProperty); }
            set { SetValue(OverlayTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OverlayText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OverlayTextProperty =
            DependencyProperty.Register("OverlayText", typeof(string), typeof(HoverOverPasswordControl), new PropertyMetadata("未输入"));


        public HoverOverPasswordControl()
        {
            InitializeComponent();
        }

        private void MouseEvent(object sender, MouseEventArgs e)
        {
            PasswordBox pbx = (PasswordBox)sender;
            //鼠标进入时到hover状态
            if (pbx.IsMouseOver || pbx.Password.Length > 0 || pbx.IsFocused)
            {
                VisualStateManager.GoToElementState(pbx,
                    "OverlayHover", true);
                return;
            }
            else
            {
                VisualStateManager.GoToElementState(pbx,
                "OverlayCover", true);
                return;
            }
        }

        private void FocusEvent(object sender, RoutedEventArgs e)
        {
            PasswordBox pbx = (PasswordBox)sender;
            if (pbx.Password.Length > 0 || pbx.IsFocused)
            {
                VisualStateManager.GoToElementState(pbx,
                    "OverlayHover", true);
                return;
            }
            else
            {
                VisualStateManager.GoToElementState(pbx,
                "OverlayCover", true);
                return;
            }
        }
    }
}
