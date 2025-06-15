using Multi_Threading.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Threading.Data
{
    internal class TaskPlanItem : BaseViewModel
    {
        public int MaxValue { get; set; }

        private int _currentValue;
        public int CurrentValue
        {
            get { return _currentValue; }
            set
            {
                _currentValue = value;
                OnPropertyChanged();
            }
        }
    }
}
