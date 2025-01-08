using People.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace People.ViewModels
{
    public class CVelascoTarjetaViewModel:INotifyPropertyChanged
    {
        private CVTarjeta _cvTarjeta;
        public CVTarjeta CVTarjeta
        {
            get => _cvTarjeta;
            set
            {
                if (_cvTarjeta != value)
                {
                    _cvTarjeta = value;
                    OnPropertyChanged();
                }
            }
        }
        public CVelascoTarjetaViewModel()
        {
            CVTarjeta = new CVTarjeta
            {
                Name = "Crhystel Velasco",
                Age = 19,
                ImageUrl = "C:\\Users\\Crhystel\\Source\\Repos\\VelascoCrhystel_Taller_People\\People\\Resources\\Images\\yo.jpeg"
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
