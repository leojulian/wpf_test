using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingEventAggregator.Core;

namespace ModuleD.ViewModels
{
    public class MessageListViewModel : BindableBase
    {
        IEventAggregator _eventAggregator;
        private string _message = "Message to Send";
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DelegateCommand SendMessageCommand { get; private set; }

        public MessageListViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            SendMessageCommand = new DelegateCommand(PublishMessage);
        }

        void PublishMessage()
        {
            _eventAggregator.GetEvent<MessageSentEvent>().Publish(Message);
        }

    }
}
