using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BMICalculator
{
    internal class MainViewModel: INotifyPropertyChanged
    {
        private double? length;

        public double? Length
        {
            get { return length; }
            set { length = value;
                OnPropertyChanged();
            }
        }

        private double? weight;

        public double? Weight
        {
            get { return weight; }
            set { weight = value;
                OnPropertyChanged();
            }
        }

        private double bmi;

        public double Bmi
        {
            get { return bmi; }
            private set { 
                bmi = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ICommand ClickCommand { get; private set; }
        public ICommand ResetCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            ClickCommand = new MyCommand(clickCommandAction); 
            ResetCommand = new MyCommand(resetCommandAction);  
        }

        public void clickCommandAction()
        {
            if(Length != null && weight != null) { 
                Bmi = (double)(Weight / (Length * Length));
            }
        }

        public void resetCommandAction()
        {
            Length = null;
            Weight = null;
            Bmi = 0;
        }
    }
}
