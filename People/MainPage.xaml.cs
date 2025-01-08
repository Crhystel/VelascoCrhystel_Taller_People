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

    

}

