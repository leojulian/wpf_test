using CompositeCommands.Core;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleC.ViewModels
{
    public class TabViewModel : BindableBase, IActiveAware
    {
        IApplicationCommands _applicationCommands;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _canUpdate = true;
        public bool CanUpdate
        {
            get { return _canUpdate; }
            set { SetProperty(ref _canUpdate, value); }
        }

        private string _updatedText;

      

        public string UpdateText
        {
            get { return _updatedText; }
            set { SetProperty(ref _updatedText, value); }
        }

        public DelegateCommand UpdateCommand { get; private set; }

        public TabViewModel(IApplicationCommands applicationCommands)
        {
            _applicationCommands = applicationCommands;

            UpdateCommand = new DelegateCommand(Update).ObservesCanExecute(() => CanUpdate);

            _applicationCommands.SaveCommand.RegisterCommand(UpdateCommand);
        }

        private void Update()
        {
            UpdateText = $"Updated: {DateTime.Now}";
        }

        private bool _isActive;
        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                onIsActiveChanged();
            }
        }

        private void onIsActiveChanged()
        {
            UpdateCommand.IsActive = IsActive;
            IsActiveChanged?.Invoke(this, new EventArgs());
        }

        public event EventHandler IsActiveChanged;
    }
}
