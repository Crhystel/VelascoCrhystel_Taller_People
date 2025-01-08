using People.Interfaces;
using People.Models;
using People.ViewModels;
using System.Collections.Generic;

namespace People;

public partial class MainPage : ContentPage
{

	public MainPage(CVelascoMPViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnEliminarButtonClicked(object sender, EventArgs e)
    {
        var viewModel = (CVelascoMPViewModel)BindingContext;

        if (viewModel.PersonSeleccionada != null)
        {
            await viewModel.EliminarPersona(viewModel.PersonSeleccionada);

            await DisplayAlert("Eliminado", $"Crhystel Velasco acaba de eliminar a {viewModel.PersonSeleccionada.Name} de la base de datos", "OK");
        }
        else
        {
            await DisplayAlert("Error", "No hay persona seleccionada para eliminar", "OK");
        }
    }
        
    

}

