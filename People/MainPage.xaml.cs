using People.Models;
using System.Collections.Generic;

namespace People;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    public void OnNewButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        App.CVPersonRepo.AddNewPerson(newPerson.Text);
        statusMessage.Text = App.CVPersonRepo.StatusMessage;
    }

    public void OnGetButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        List<CVPerson> people = App.CVPersonRepo.GetAllPeople();
        peopleList.ItemsSource = people;
    }

}

