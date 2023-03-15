using System.Windows.Input;

namespace ShowcaseRVHub.MAUI.Commands
{
    public abstract class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);

        protected virtual void OnCanExecuteChanged(object parameter)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
