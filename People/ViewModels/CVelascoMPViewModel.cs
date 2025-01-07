using People.Interfaces;
using People.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace People.ViewModels
{
    internal class CVelascoMPViewModel : INotifyPropertyChanged
    {
        private string _cvAlerta;
        private CVPerson _cvPerson;
        private List<CVPerson> _cvPersons;
        private readonly ICVPersonRepository _cvPersonRepository;
        public ICommand ComandoAgregar { get; }
        public ICommand ComandoMostrar { get; }
        
        public CVPerson cvPerson
        {
            get => _cvPerson;
            set
            {
                if (_cvPerson != value)
                {
                    _cvPerson = value;
                    OnPropertyChanged();
                }
            }
        }
        public List<CVPerson> cvPersons
        {
            get => _cvPersons;
            set
            {
                if (_cvPersons != value)
                {
                    _cvPersons = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Alerta
        {
            get => _cvAlerta;
            set
            {
                if (_cvAlerta != value)
                {
                    _cvAlerta = value;
                    OnPropertyChanged();
                }
            }
        }
        public CVelascoMPViewModel(PersonRepository personRepository)
        {
            
        }

        public async Task AgregarPersona()
        {
            if (await _cvPersonRepository.AgregarPersonAsync(cvPerson))
            {
                await MostrarPerson(); 
            }
        }
        private async Task MostrarPerson()
        {
            cvPersons=await _cvPersonRepository.GetAllPersonAsync();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
