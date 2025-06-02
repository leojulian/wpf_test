using Prism.Unity;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Prism.Modularity;

namespace Modules_LoadManual
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Views.MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            var moduleAType = typeof(ModuleA.ModuleAModule);
            moduleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = moduleAType.Name,
                ModuleType = moduleAType.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable
            });

            var moduleBType = typeof(ModuleB.ModuleBModule);
            moduleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = moduleBType.Name,
                ModuleType = moduleBType.AssemblyQualifiedName,
                InitializationMode = InitializationMode.OnDemand
            });
        }
    }
}
