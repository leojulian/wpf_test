using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navagation_BasicRegion.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        private string _title = "Prism Navigation Basic Region";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand<string> NavigateCommand { get; private set; }
        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string viewName)
        {
            if (!string.IsNullOrEmpty(viewName))
            {
                _regionManager.RequestNavigate("ContentRegion", viewName, NavigationComplete);
            }
        }

        private void NavigationComplete(NavigationResult result)
        {
            System.Windows.MessageBox.Show(String.Format("Navigation to {0} complete. ", result.Context.Uri));
        }
    }
}
