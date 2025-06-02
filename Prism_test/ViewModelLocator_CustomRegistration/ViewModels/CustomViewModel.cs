using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelLocator_CustomRegistration.ViewModels
{
    public class CustomViewModel : BindableBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public CustomViewModel()
        {
            Title = "ViewModelLocator CustomRegistration Example";
        }

    }
}
