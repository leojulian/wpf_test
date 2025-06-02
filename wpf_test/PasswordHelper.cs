using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace wpf_test
{
    public static class PasswordHelper
    {
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordHelper),
                new PropertyMetadata(string.Empty, OnPasswordPropertyChanged));

        public static string GetPassword(DependencyObject obj) => (string)obj.GetValue(PasswordProperty);
        public static void SetPassword(DependencyObject obj, string value) => obj.SetValue(PasswordProperty, value);

        private static void OnPasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBox box && !_isUpdating)
            {
                box.PasswordChanged -= HandlePasswordChanged;
                box.Password = (string)e.NewValue;
                box.PasswordChanged += HandlePasswordChanged;
            }
        }

        private static bool _isUpdating = false;
        private static void HandlePasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox box)
            {
                _isUpdating = true;
                SetPassword(box, box.Password);
                _isUpdating = false;
            }
        }
    }
}
