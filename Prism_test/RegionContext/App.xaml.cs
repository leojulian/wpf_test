using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RegionContext
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var regionManager = Container.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(Views.PersonList));
            regionManager.RegisterViewWithRegion("PersonDetailsRegion", typeof(Views.PersonDetail));
        }
    }
}
