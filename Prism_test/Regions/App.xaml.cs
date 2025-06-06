﻿using Prism.Ioc;
using Prism.Unity;
using Regions.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Regions
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
            // Register any types needed for the application here
            // For example, you can register views, view models, services, etc.
            // containerRegistry.RegisterForNavigation<SomeView>();
        }
    }
}
