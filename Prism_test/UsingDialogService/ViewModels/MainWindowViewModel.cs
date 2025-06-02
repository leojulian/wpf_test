using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingDialogService.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private DelegateCommand _showDialogCommand;
        public DelegateCommand ShowDialogCommand =>
            _showDialogCommand ?? (_showDialogCommand = new DelegateCommand(GetShowDialog));


        private string _title = "DialogService Sample";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private IDialogService _dialogService;
        public MainWindowViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            // Initialization logic can go here if needed
        }
        private void GetShowDialog()
        {
            string message = "test message";
            _dialogService.ShowDialog("NotificationDialog", new DialogParameters($"message={message}"), r =>
            {
                if (r.Result == ButtonResult.None)
                    Title = "Result is None";
                else if (r.Result == ButtonResult.OK)
                    Title = "Result is OK";
                else if (r.Result == ButtonResult.Cancel)
                    Title = "Result is Cancel";
                else
                    Title = "I Don't know what you did!?";
            });
        }
    }
}
