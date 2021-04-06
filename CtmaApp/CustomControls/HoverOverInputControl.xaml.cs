using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for HoverOverInputControl.xaml
    /// </summary>
    /// 
    [ContentProperty("OverlayText")]
    public partial class HoverOverInputControl : UserControl
    {
        public string OverlayText
        {
            get { return (string)GetValue(OverlayTextProperty); }
            set { SetValue(OverlayTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OverlayText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OverlayTextProperty =
            DependencyProperty.Register("OverlayText", typeof(string), typeof(HoverOverInputControl), new PropertyMetadata("未输入"));



        public string InputText
        {
            get { return (string)GetValue(InputTextProperty); }
            set { SetValue(InputTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InputText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InputTextProperty =
            DependencyProperty.Register("InputText", typeof(string), typeof(HoverOverInputControl), new PropertyMetadata(string.Empty));




        public HoverOverInputControl()
        {
            InitializeComponent();
        }

        private void MouseEvent(object sender, MouseEventArgs e)
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

        private void FocusEvent(object sender, RoutedEventArgs e)
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
    }
}
