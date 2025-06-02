using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingEventAggregator.Core;

namespace ModuleE.ViewModels
{
    public class MessageListViewModel : BindableBase
    {

        public ObservableCollection<string> Messages { get; } = new ObservableCollection<string>();

        private string _message = "Message Recieved.";
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DelegateCommand SendMessageCommand { get; private set; }

        public MessageListViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<MessageSentEvent>().Subscribe(msg => Messages.Add(msg));
        }
    }
}
