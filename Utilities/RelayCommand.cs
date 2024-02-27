using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace csharp_project.Utilities
{
    public class RelayCommand(Func<object, bool> canExecute, Action<object> execute) : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private readonly Func<object, bool> _canExecute = canExecute;
        private readonly Action<object> _execute = execute;

        public bool CanExecute(object? parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}
