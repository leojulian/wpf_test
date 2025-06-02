using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UsingInvokeCommandAction.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "InvokeCommandAction Sample";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _selectedItemText;
        public string SelectedItemText
        {
            get { return _selectedItemText; }
            set { SetProperty(ref _selectedItemText, value); }
        }

        public IList<string> Items { get; private set; }
        // 1 using TriggerParameterPath
        public DelegateCommand<object[]> SelectedCommand { get; private set; }
        // 2 Or using SelectionChangedEventArgs
        public DelegateCommand<SelectionChangedEventArgs> SelectedEventCommand { get; private set; }

        public MainWindowViewModel()
        {
            Items = new List<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5"
            };

            SelectedCommand = new DelegateCommand<object[]>(OnSelectedItemChanged);
            SelectedEventCommand = new DelegateCommand<SelectionChangedEventArgs>(OnSelectedItemEventChanged);
        }

        private void OnSelectedItemEventChanged(SelectionChangedEventArgs args)
        {
            OnSelectedItemChanged(args.AddedItems as object[]);
        }

        private void OnSelectedItemChanged(object[] obj)
        {
            if(obj != null && obj.Length > 0)
            {
                SelectedItemText = obj.FirstOrDefault().ToString();
            }
            else
            {
                SelectedItemText = "No item selected";
            }
        }
    }
}
