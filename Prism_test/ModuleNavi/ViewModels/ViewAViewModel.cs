using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModuleNavi.ViewModels
{
    internal class ViewAViewModel : BindableBase, IConfirmNavigationRequest
    {
        private string _title = "View A";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            bool result = true;

            if (MessageBox.Show("Do you to navigate?", "Navigate?", MessageBoxButton.YesNo) == MessageBoxResult.No)
                result = false;

            continuationCallback(result);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }
    }
}
