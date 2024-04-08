using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HairSalon.Entities;
namespace HairSalon.Pages;

public partial class RegistrationPage : ContentPage
{
    MyHairSalon _hairSalon;
    public RegistrationPage(MyHairSalon hairSalon)
    {
        InitializeComponent();
        _hairSalon = hairSalon;
    }
    private async void RegisterButton_Clicked(object sender, EventArgs e)
    {
		_hairSalon.RegisterClient(PasswordEntry.Text,NameEntry.Text, SurnameEntry.Text, EmailEntry.Text, PhoneEntry.Text);
        _hairSalon.Login(EmailEntry.Text, PasswordEntry.Text);
        await Navigation.PushAsync(new NavigationPage(new ProfilePage(_hairSalon)));
    }
   
}