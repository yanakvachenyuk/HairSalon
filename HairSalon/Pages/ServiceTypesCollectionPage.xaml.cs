using HairSalon.Entities;

namespace HairSalon.Pages;

public partial class ServiceTypesCollectionPage : ContentPage
{
	MyHairSalon _hairSalon;
	public ServiceTypesCollectionPage(MyHairSalon hairSalon)
	{
		InitializeComponent();
		_hairSalon = hairSalon;
        BindingContext = this;
        serviceTypesCollectionView.ItemsSource = _hairSalon.GetServiceTypes();
	}

    private async void ServiceTypeFrame_Tapped(object sender, EventArgs e)
    {
       
        var selectedServiceType = (ServiceType)((TappedEventArgs)e).Parameter;

        int selectedServiceTypeId = selectedServiceType.Id;

        await Navigation.PushAsync(new ServicesCollectionPage(_hairSalon, selectedServiceTypeId));
       
    }

}