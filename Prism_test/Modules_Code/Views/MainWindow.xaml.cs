using Prism.Regions;
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

namespace Modules_Code.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IRegionManager _regionManager;
        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();
            _regionManager = regionManager;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var region = _regionManager.Regions["ContentRegion"];
            region.Activate(region.Views.FirstOrDefault(v => v is ModuleB.UserControl1)); // Activate the last view in the region
        }
    }
}
