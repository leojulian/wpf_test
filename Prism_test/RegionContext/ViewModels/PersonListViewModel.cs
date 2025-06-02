using Prism.Mvvm;
using RegionContext.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionContext.ViewModels
{
    public class PersonListViewModel : BindableBase
    {
        private ObservableCollection<Person> _personList;
        public ObservableCollection<Person> PersonList
        {
            get { return _personList; }
            set
            {
                SetProperty(ref _personList, value);
            }
        }

        public PersonListViewModel()
        {
            CreatePeople();
        }

        private void CreatePeople()
        {
            var personList = new ObservableCollection<Person>
            {
                new Person { FirstName = "John", LastName = "Doe", Age = "30" },
                new Person { FirstName = "Jane", LastName = "Smith", Age = "25" },
                new Person { FirstName = "Mike", LastName = "Johnson", Age = "40" }
            };

            PersonList = personList;
        }
    }
}
