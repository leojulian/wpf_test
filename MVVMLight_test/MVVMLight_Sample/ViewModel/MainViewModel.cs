using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace MVVMLight_Sample.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        IMessenger _messenger;
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}

            //Messenger.Default.Send(new NotificationMessage("DataUpdated"));
            //Messenger.Default.Register<NotificationMessage>(this, msg => { /* 处理消息 */ });
        }

        private string _title = "MVVMLight Sample Application";
        public string Title
        {
            get { return _title; }
            set
            {
                Set<string>(nameof(Title), ref _title, value);
            }
        }
    }
}