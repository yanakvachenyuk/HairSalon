using HairSalon.Entities;
using System.Diagnostics;
namespace HairSalon.Pages;

public partial class AdminProfilePage : ContentPage
{
    private MyHairSalon _hairSalon;
    private string name;
    public string Name
    {
        get => name;
        set
        {
            if (name == value) return;
            name = value;
            OnPropertyChanged();
        }
    }
    public AdminProfilePage(MyHairSalon hairSalon)
	{
		InitializeComponent();
        NavigationPage.SetHasBackButton(this, false);
        _hairSalon = hairSalon;
        BindingContext = this;
    }


    protected override bool OnBackButtonPressed()
    {
       
        return true;
    }


    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        if (Navigation.NavigationStack.Count > 1)
        {
            var previousPage = Navigation.NavigationStack[Navigation.NavigationStack.Count - 2];
            Navigation.RemovePage(previousPage);
        }
    }

    private void OnFrameTapped(object sender, EventArgs e)
    {
        
    }

    void ProfilePage_Loaded(object sender, EventArgs e)
    {
        var user = _hairSalon.accountsSystem.currentUser;
        //Debug.WriteLine(user.GetType());
        //Debug.WriteLine(typeof(Client));
        if (user.GetType() == typeof(Admin))
        {
            Name = user.FirstName + " " + user.LastName;
        }
       
    }

    private async void OnLogoutFrame_Tapped(object sender, TappedEventArgs e)
    {
        _hairSalon.accountsSystem.Logout();
        Application.Current.MainPage = new AppShell();
        await Shell.Current.GoToAsync("//LogIn");
        await Shell.Current.CurrentItem.Navigation.PushAsync(new NavigationPage(new LogInPage(_hairSalon)));
        //await Shell.Current.GoToAsync("//LogIn");
    }
}