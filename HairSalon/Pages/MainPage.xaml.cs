using HairSalon.Entities;
using HairSalon.Pages;

namespace HairSalon;

public partial class MainPage : ContentPage
{
    MyHairSalon _hairSalon;

    public MainPage(MyHairSalon hairSalon)
    {
        InitializeComponent();
        _hairSalon = hairSalon;
        employeesCollectionView.ItemsSource = _hairSalon.GetEmployees();
    }

    private async void OnAllServicesFrame_Tapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AllServicesPage(_hairSalon));
    }

}