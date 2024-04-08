using HairSalon.Entities;
using System.Diagnostics;

namespace HairSalon.Pages;

public partial class ServicesCollectionPage : ContentPage
{
	MyHairSalon _hairSalon;
    Service selectedService;
    int _selectedServiceTypeId;
	public ServicesCollectionPage(MyHairSalon hairSalon,int selectedServiceTypeId)
	{
        InitializeComponent();
		_hairSalon = hairSalon;
        BindingContext = this;
        _selectedServiceTypeId = selectedServiceTypeId;
        ServicesCollectionView.ItemsSource = _hairSalon.GetServices(selectedServiceTypeId);
        
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
       
        ServicesCollectionView.ItemsSource = _hairSalon.GetServices(_selectedServiceTypeId);
        selectedService = null;
        
    }
    private async void OnAddServiceButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddServicePage(_hairSalon, _selectedServiceTypeId));
    }
    private async void OnServiceFrame_Tapped(object sender, EventArgs e)
    {
        selectedService = (Service)((TappedEventArgs)e).Parameter;
        Debug.WriteLine(selectedService.Name);

    }
    private async void OnDeleteServiceButton_Clicked(object sender, EventArgs e)
    {
        if (selectedService != null)
        {
            
            bool answer = await DisplayAlert("Confirm", "Are you sure you want to delete this service?", "Yes", "No");
            if (answer)
            {
               
                _hairSalon.DeleteService(selectedService.Id);
               
                ServicesCollectionView.ItemsSource = _hairSalon.GetServices(_selectedServiceTypeId);
                selectedService = null;
            }
        }
        else
        {
            await DisplayAlert("Error", "Please select a service to delete.", "OK");
        }
    }
}