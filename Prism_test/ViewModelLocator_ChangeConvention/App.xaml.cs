using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using ViewModelLocator_ChangeConvention.Views;

namespace ViewModelLocator_ChangeConvention
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
        }
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(
                (viewType) =>
                {
                    // Change the convention to use "ViewModel" suffix instead of "ViewModel"
                    var viewName = viewType.FullName;
                    var viewAssemblyName = viewType.Assembly.FullName;
                    var viewModeleType = $"{viewName}ViewModel, {viewAssemblyName}";

                    return Type.GetType(viewModeleType);
                });
        }
    }
}
