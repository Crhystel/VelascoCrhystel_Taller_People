using People.Interfaces;
using People.Models;
using System.Collections.Generic;

namespace People;

public partial class MainPage : ContentPage
{
    public CVPerson cvPerson;

	public MainPage()
	{
		InitializeComponent();
        BindingContext = cvPerson;
    }

    

}

