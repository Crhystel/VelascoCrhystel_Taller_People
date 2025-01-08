
using People.ViewModels;

namespace People;

public partial class CVTarjetaPage : ContentPage
{
	public CVTarjetaPage(CVelascoTarjetaViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}