using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Multi_Threading.Commands
{
    public class RelayCommandGeneric<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;
        public RelayCommandGeneric(Action<T> execute, Func<T, bool> canExecute)
        {
            if (execute == null) throw new ArgumentNullException(nameof(execute));

            _execute = execute;
            _canExecute = canExecute;
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;

            return parameter == null ? _canExecute.Invoke(default(T)) : _canExecute.Invoke((T)parameter);
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
                _execute.Invoke((T)parameter);
        }
    }
}
