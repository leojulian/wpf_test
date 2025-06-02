using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelLocator_ChangeConvention.Views
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public MainWindowViewModel()
        {
            Title = "ViewModelLocator Change Convention Example";
        }

        // Additional properties and methods can be added here as needed
    }
}
