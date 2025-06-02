using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MVVMLight_Sample.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMLight_Sample.ViewModel
{
    public class ViewAViewModel : ViewModelBase
    {
        public RelayCommand SendMessageCommand { get; private set; }

        private string _messageText;
        public string MessageText
        {
            get { return _messageText; }
            set
            {
                Set<string>(nameof(MessageText), ref _messageText, value);
            }
        }

        public ViewAViewModel()
        {
            SendMessageCommand = new RelayCommand(SendMessage);
        }

        private void SendMessage()
        {
            Messenger.Default.Send(new TextMessage(MessageText));
        }
    }
}
