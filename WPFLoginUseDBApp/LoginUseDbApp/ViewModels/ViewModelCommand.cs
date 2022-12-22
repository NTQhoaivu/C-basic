using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LoginUseDbApp.ViewModels
{
    public class ViewModelCommand : ICommand
    {
        //Fields
        private readonly Action<object> _executeAction;//luu cac ham duoc uy thac lam viec gi do 
        private readonly Predicate<object> _canExecuteAction;//luu tru thuc hien command-thuc hien ham uy thac

        //Constructors
        public ViewModelCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = null;
        }

        public ViewModelCommand(Action<object> executeAction, Predicate<object> canExecuteAction)
        {
            if (executeAction==null)
            {
                throw new ArgumentNullException("execute");
            }
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        //Events
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //Methods
        public bool CanExecute(object parameter)
        {
            return _canExecuteAction == null ? true : _canExecuteAction(parameter);
        }
         
        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }
    }
}
