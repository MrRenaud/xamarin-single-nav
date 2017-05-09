using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XamarinNav
{
    public class SingleNavigationCommand : ICommand
    {
        readonly Action<object> _execute;
        static bool _canExecute = true;

        public SingleNavigationCommand(Action<object> execute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            _execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public int Delay { get; set; } = 1000;

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public async void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                try
                {
                    _canExecute = false;
                    RaiseCanExecuteChanged();

                    _execute(parameter);
                    await Task.Delay(Delay);
                }
                finally
                {
                    _canExecute = true;
                    RaiseCanExecuteChanged();
                }
            }
        }

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                try
                {
                    handler(this, EventArgs.Empty);
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
