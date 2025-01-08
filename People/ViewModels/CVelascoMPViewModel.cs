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
    public class CVelascoMPViewModel : INotifyPropertyChanged
    {
        private string _cvAlerta;
        private CVPerson _cvPerson;
        private List<CVPerson> _cvPersons;
        private CVPerson _personSeleccionada;
        private readonly ICVPersonRepository _cvPersonRepository;
        public ICommand ComandoAgregar { get; }
        public ICommand ComandoMostrar { get; }
        public ICommand ComandoEliminar { get; }

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
        public CVPerson PersonSeleccionada
        {
            get => _personSeleccionada;
            set
            {
                if (_personSeleccionada != value)
                {
                    _personSeleccionada = value;
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
        public CVelascoMPViewModel()
        {
            _cvPersonRepository = new PersonRepository("VelascoCrhystelpeople.db3");
            cvPerson = new CVPerson();
            ComandoAgregar = new Command(async () => await AgregarPersona());
            ComandoMostrar = new Command(async () => await MostrarPerson());
            ComandoEliminar = new Command<CVPerson>(async (person) => await EliminarPersona(person));
        }
        public CVelascoMPViewModel(PersonRepository personRepository)
        {
            _cvPersonRepository = personRepository;
            cvPerson = new CVPerson();
            ComandoAgregar = new Command(async () => await AgregarPersona());
            ComandoMostrar = new Command(async () => await MostrarPerson());
            ComandoEliminar = new Command<CVPerson>(async (person) => await EliminarPersona(person));
        }

        public async Task AgregarPersona()
        {
            await _cvPersonRepository.AgregarPersonAsync(cvPerson);
        }
        private async Task MostrarPerson()
        {
            cvPersons = await _cvPersonRepository.GetAllPersonAsync();
        }
        private async Task EliminarPersona(CVPerson person)
        {
            if (person != null)
            {
                bool eliminado = await _cvPersonRepository.EliminarPersonAsync(person.Id);
                if (eliminado)
                {
                    Alerta = $"Crhystel Velasco acaba de eliminar a esta persona: {person.Name}";
                    await MostrarPerson();  
                }
                else
                {
                    Alerta = "Error al eliminar la persona.";
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
