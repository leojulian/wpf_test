using Prism.Commands;

namespace CompositeCommands.Core
{
    public interface IApplicationCommands
    {
        CompositeCommand SaveCommand { get; }
    }

    public class ApplicationCommands : IApplicationCommands
    {
        private CompositeCommand _saveCommand = new CompositeCommand(true);//new CompositeCommand();
        public CompositeCommand SaveCommand
        {
            get { return _saveCommand; }
        }
    }
}

