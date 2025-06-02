using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MVVMLight_Sample.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMLight_Sample.ViewModel
{
    public class ViewBViewModel : ViewModelBase
    {
        private ObservableCollection<string> items;
        public ObservableCollection<string> Items
        {
            get { return items; }
            set { Set<ObservableCollection<string>>(nameof(Items), ref items, value); }
        }

        public ViewBViewModel()
        {
            Items = new ObservableCollection<string>();
            Messenger.Default.Register<TextMessage>(this, HandleTextMessage);
        }

        private void HandleTextMessage(TextMessage textMessage)
        {
            if (!string.IsNullOrEmpty(textMessage.Text))
                Items.Add(textMessage.Text);
        }
    }
}
