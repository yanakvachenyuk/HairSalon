using HairSalon.Entities;

namespace HairSalon.Pages;

public partial class LogInPage : ContentPage
{
	private MyHairSalon _hairSalon;
	public LogInPage(MyHairSalon hairSalon)
	{
		InitializeComponent();
		_hairSalon = hairSalon;
	}

	private async void LogInButton_Clicked(object sender, EventArgs e)
	{
		_hairSalon.Login(LoginEntry.Text, PasswordEntry.Text);
		if (_hairSalon.accountsSystem.currentUser.GetType() == typeof(Client))
		{
			await Navigation.PushAsync(new NavigationPage(new ProfilePage(_hairSalon)));
		}
		else if (_hairSalon.accountsSystem.currentUser.GetType() == typeof(Admin))
		{
			Application.Current.MainPage = new AdminShell();
            await Shell.Current.GoToAsync("//Profile");
            
            await Shell.Current.CurrentItem.CurrentItem.Navigation.PushAsync(new NavigationPage(new AdminProfilePage(_hairSalon)));
            //await Shell.Current.GoToAsync("//Profile");


        }
       
    }
	private async void RegistrationButton_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.Navigation.PushAsync(new RegistrationPage(_hairSalon));
	}
}