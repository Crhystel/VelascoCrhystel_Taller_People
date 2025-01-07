using People.Models;
using System.Collections.Generic;

namespace People;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    public async void OnNewButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        await App.CVPersonRepo.AddNewPerson(newPerson.Text);
        statusMessage.Text = App.CVPersonRepo.StatusMessage;
    }

    public async void OnGetButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        List<CVPerson> people = await App.CVPersonRepo.GetAllPeople();
        peopleList.ItemsSource = people;
    }

}

