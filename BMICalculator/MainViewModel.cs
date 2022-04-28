using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;

namespace BMICalculator
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private double? length;
        private double? weight;
        private double? bmi;
        private Brush color;

        public double? Length
        {
            get { return length; }
            set
            {
                length = value;
                OnPropertyChanged();
            }
        }

        public double? Weight
        {
            get { return weight; }
            set
            {
                weight = value;
                OnPropertyChanged();
            }
        }

        public double? Bmi
        {
            get { return bmi; }
            private set
            {
                bmi = value;
                OnPropertyChanged();
                UpdateColor();
            }
        }

        public Brush Color
        {
            get { return color; }
            set
            {
                color = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ICommand ClickCommand { get; private set; }
        public ICommand ResetCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            ClickCommand = new MyCommand(ClickCommandAction);
            ResetCommand = new MyCommand(ResetCommandAction);
        }

        private void ClickCommandAction()
        {
            if (Length != null && weight != null)
            {
                Bmi = Math.Round((double)(Weight / (Length * Length)), 2);
            }
        }

        private void ResetCommandAction()
        {
            Length = null;
            Weight = null;
            Bmi = 0;
        }

        private void UpdateColor()
        {

            if (Bmi == 0)
            {
                Color = null;
            }
            else if (Bmi < 18.5)
            {
                Color = Brushes.LightBlue;
            }
            else if (Bmi < 25)
            {
                Color = Brushes.Green;
            }
            else if (Bmi < 30)
            {
                Color = Brushes.Yellow;
            }
            else if (Bmi < 35)
            {
                Color = Brushes.Orange;
            }
            else if (Bmi < 40)
            {
                Color = Brushes.OrangeRed;
            }
            else
            {
                Color = Brushes.DarkRed;
            }
        }

    }
}
