using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace wpf_test
{
    public class PasswordBehavior : Behavior<PasswordBox>
    {
        // Constructor to fix CS1729 error  
        //public PasswordBehavior()
        //{
        //    // The associated type for this behavior is PasswordBox
        //    var AssociatedType = typeof(System.Windows.Controls.PasswordBox);
        //}

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.PasswordChanged += AssociatedObject_PasswordChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.PasswordChanged -= AssociatedObject_PasswordChanged;
        }

        private void AssociatedObject_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Console.WriteLine($"{(sender as PasswordBox).Password}");
        }
    }
}
