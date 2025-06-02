using Prism.Common;
using Prism.Regions;
using RegionContext.Data;
using RegionContext.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegionContext.Views
{
    /// <summary>
    /// Interaction logic for PersonDetail.xaml
    /// </summary>
    public partial class PersonDetail : UserControl
    {
        public PersonDetail()
        {
            InitializeComponent();
            Prism.Regions.RegionContext.GetObservableContext(this).PropertyChanged += PersonDetail_PropertyChanged;
        }

        private void PersonDetail_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var context = (ObservableObject<object>)sender;
            var selectedPerson = context.Value as Person;
            (DataContext as PersonDetailViewModel).SelectedPerson = selectedPerson;
        }
    }
}
