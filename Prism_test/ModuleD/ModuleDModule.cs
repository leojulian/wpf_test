using ModuleD.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleD
{
    public class ModuleDModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("LeftContentRegion", typeof(MessageList));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
