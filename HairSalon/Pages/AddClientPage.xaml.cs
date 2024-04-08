using HairSalon.Entities;

namespace HairSalon.Pages;

public partial class AddClientPage : ContentPage
{
	MyHairSalon _hairSalon;
	public AddClientPage(MyHairSalon hairSalon)
	{
		InitializeComponent();
		_hairSalon = hairSalon;
	}

    private async void AddClientButton_Clicked(object sender, EventArgs e)
    {
        _hairSalon.RegisterClient(PasswordEntry.Text, NameEntry.Text, SurnameEntry.Text, EmailEntry.Text, PhoneEntry.Text);
		await Navigation.PopAsync();
    }
}