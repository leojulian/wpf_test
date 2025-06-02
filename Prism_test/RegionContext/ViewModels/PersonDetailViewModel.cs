using Prism.Mvvm;
using RegionContext.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionContext.ViewModels
{
    public class PersonDetailViewModel : BindableBase
    {
        private Person _selectedPerson;
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                SetProperty(ref _selectedPerson, value);
            }
        }

        public PersonDetailViewModel()
        { 
        }
    }
}