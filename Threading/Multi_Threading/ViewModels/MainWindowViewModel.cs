using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Multi_Threading.Abstractions;
using Multi_Threading.Commands;
using Multi_Threading.Views;

namespace Multi_Threading.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private int _index = 0;
        private readonly Dictionary<int, FrameworkElement> _views = new Dictionary<int, FrameworkElement>();

        private string _title = "Threading Practise Demo";
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private FrameworkElement _viewContent;
        public FrameworkElement ViewContent
        {
            get { return _viewContent; }
            set
            {
                _viewContent = value;
                if (_viewContent != null)
                    Title = (_viewContent.DataContext as IDisplayControl).Tittle;
                OnPropertyChanged();
            }
        }

        public ICommand PreviousCommand { get; set; }
        public ICommand NextCommand { get; set; }

        public MainWindowViewModel()
        {
            _views.Add(0, new ThreadingControlView() { DataContext = new ThreadingControlViewModel() });
            _views.Add(1, new MultiThreadsHandleView() { DataContext = new MultiThreadsHandleViewModel() });
            PreviousCommand = new RelayCommand(() => Previous(), () => CanPrevious());
            NextCommand = new RelayCommand(() => Next(), () => CanNext());
            ViewContent = _views[_index];
        }

        private bool CanPrevious()
        {
            if (_views.Count == 0 || _index == 0)
                return false;
            return true;
        }

        private void Previous()
        {
            _index--;
            ViewContent = _views[_index];
        }

        private bool CanNext()
        {
            if (_views.Count == 0 || _index == _views.Count - 1)
                return false;

            return true;
        }

        private void Next()
        {
            _index++;
            ViewContent = _views[_index];
        }
    }
}
