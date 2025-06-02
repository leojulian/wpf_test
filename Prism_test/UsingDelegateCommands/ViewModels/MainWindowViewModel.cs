using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingDelegateCommands.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public bool _isEnabled;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetProperty(ref _isEnabled, value);
                ExecuteDelegateCommand.RaiseCanExecuteChanged();
            }
        }

        private string _updateText;
        public string UpdateText
        {
            get { return _updateText; }
            set { SetProperty(ref _updateText, value); }
        }

        public DelegateCommand ExecuteDelegateCommand { get; private set; }
        public DelegateCommand<string> ExecuteGenericDelegateCommand { get; private set; }
        public DelegateCommand DelegateCommandObservesProperty { get; private set; }
        public DelegateCommand DelegateCommandObservesCanExecute { get; private set; }

        public MainWindowViewModel()
        {
            ExecuteDelegateCommand = new DelegateCommand(Execute, CanExecute);
            ExecuteGenericDelegateCommand = new DelegateCommand<string>(ExecuteGeneric).ObservesCanExecute(() => IsEnabled);
            DelegateCommandObservesProperty = new DelegateCommand(Execute, CanExecute).ObservesProperty(() => IsEnabled);
            DelegateCommandObservesCanExecute = new DelegateCommand(Execute).ObservesCanExecute(() => IsEnabled);
        }

        private void Execute()
        {
            UpdateText = $"Updated: {DateTime.Now}";
        }

        private void ExecuteGeneric(string parameter)
        {
            UpdateText = parameter;
        }

        private bool CanExecute()
        {
            return IsEnabled;
        }
    }
}
