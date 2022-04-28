using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BMICalculator
{
    internal class MyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action action;


        public MyCommand(Action action)
        {
            this.action = action;
        }
        public bool CanExecute(object parameter)
        {
            if(action != null)
            {
                return true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            action();  
        }
    }
}
