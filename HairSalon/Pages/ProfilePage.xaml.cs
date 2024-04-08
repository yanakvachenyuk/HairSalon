using HairSalon.Entities;
using System.Diagnostics;

namespace HairSalon.Pages;

public partial class ProfilePage : ContentPage
{
    MyHairSalon _hairSalon;
    private string name;
    private string email;
	public ProfilePage(MyHairSalon hairSalon)
	{
		InitializeComponent();
        BindingContext = this;
        NavigationPage.SetHasBackButton(this, false);
        _hairSalon = hairSalon;

    }

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

    public string Email
    {
        get => email;
        set
        {
            if (email == value) return;
            email = value;
            OnPropertyChanged();
        }
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
        Debug.WriteLine(user.GetType());
        Debug.WriteLine(typeof(Client));
        if (user.GetType() == typeof(Client))
        {
            Name = user.FirstName + " " + user.LastName;
            Email = user.Email;
            Debug.WriteLine(Name);
        }
        
    }

    private async void OnLogoutFrame_Tapped(object sender, EventArgs e)
    {
        _hairSalon.accountsSystem.Logout();
        await Navigation.PushAsync(new NavigationPage(new LogInPage(_hairSalon)));

    }

}