using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace wpf_test
{
    [MarkupExtensionReturnType(typeof(Person))]
    internal class PersonExtension : MarkupExtension
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new Person(Name, Age);
        }
    }

    internal class Person : ICloneable
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
