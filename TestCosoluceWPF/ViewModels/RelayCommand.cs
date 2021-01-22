using System;
using System.Windows.Input;

namespace TestCosoluceWPF.ViewModels {
    public class RelayCommand : ICommand {
        private Action<object> _handler;

        public RelayCommand(Action<object> handler) {
            this._handler = handler;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            this._handler(parameter);
        }
    }
}
