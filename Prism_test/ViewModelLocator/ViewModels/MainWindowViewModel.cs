using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelLocator.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Main Window";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {
            // Initialize any properties or commands here
            Title = "Welcome to the Main Window";
        }
    }
}
