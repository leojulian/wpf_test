﻿using Prism.Ioc;
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

namespace ViewInjection.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IContainerExtension _contaner;
        IRegionManager _regionManager;

        public MainWindow(IContainerExtension container, IRegionManager regionManager)
        {
            InitializeComponent();
            _contaner = container;
            _regionManager = regionManager;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var view = _contaner.Resolve<ViewA>();
            IRegion region = _regionManager.Regions["ContentRegion"];
            region.Add(view);
        }
    }
}
