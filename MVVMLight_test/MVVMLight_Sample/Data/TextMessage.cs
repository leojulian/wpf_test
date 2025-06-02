using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMLight_Sample.Data
{
    public class TextMessage : MessageBase
    {
        public string Text { get; private set; }
        public TextMessage(string msg)
        {
            Text = msg;
        }
    }
}
