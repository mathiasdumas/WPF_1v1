using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_WPF_1v1
{
    public class Opponent : INotifyPropertyChanged
    {
        public string Name { get; set; }
        private int healthPoints;
        public event PropertyChangedEventHandler? PropertyChanged;

        public int HealthPoints
        {
            get { return healthPoints; }
            set
            {
                if (healthPoints != value)
                {
                    healthPoints = value;
                    NotifyPropertyChanged("HealthPoints");
                }
            }
        }

        public Opponent(string Name)
        {
            this.Name = Name;
            healthPoints = 100;
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
