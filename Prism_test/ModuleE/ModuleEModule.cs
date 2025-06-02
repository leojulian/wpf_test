using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleE
{
    public class ModuleEModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
          var regionManager = containerProvider.Resolve<Prism.Regions.IRegionManager>();
            regionManager.RegisterViewWithRegion("RightContentRegion", typeof(Views.MessageList));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
