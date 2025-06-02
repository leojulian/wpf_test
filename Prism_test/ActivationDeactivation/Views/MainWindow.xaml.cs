using Prism.Ioc;
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

namespace ActivationDeactivation.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IContainerExtension _container;
        IRegionManager _regionManager;
        IRegion _region;

        ViewA _viewA;
        ViewB _viewB;

        public MainWindow(IContainerExtension container, IRegionManager regionManager)
        {
            InitializeComponent();
            _container = container;
            _regionManager = regionManager;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _viewA = _container.Resolve<ViewA>();
            _viewB = _container.Resolve<ViewB>();
            _region  = _regionManager.Regions["ContentRegion"];
            _region.Add(_viewA);
            _region.Add(_viewB);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_region.ActiveViews.Count(va => va.GetType() == typeof(ViewA)) > 0)
                _region.Deactivate(_viewA);
            else
                _region.Activate(_viewA);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (_region.ActiveViews.Count(va => va.GetType() == typeof(ViewB)) > 0)
                _region.Deactivate(_viewB);
            else
                _region.Activate(_viewB);
        }
    }
}
