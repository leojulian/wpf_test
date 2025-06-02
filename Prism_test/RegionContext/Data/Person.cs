using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RegionContext.Data
{
    public class Person : BindableBase
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                SetProperty(ref _firstName, value);
            }
        }


        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                SetProperty(ref _lastName, value);
            }
        }

        private string _age;


        public string Age
        {
            get { return _age; }
            set
            {
                SetProperty(ref _age, value);
            }
        }

        public override string ToString()
        {
            return $"{LastName}, {FirstName}";
        }
    }
}
