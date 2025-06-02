using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_test
{
    internal class People : IEnumerable
    {
        public delegate void FeendBack(string a);
        private Person[] _people;

        public People(Person[] people)
        {
            _people = people;

            Nullable<int> num = 5;

        }

        public IEnumerator GetEnumerator()
        {
            return _people.GetEnumerator();
        }
    }
}
