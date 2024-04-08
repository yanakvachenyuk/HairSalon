using HairSalon.Entities;


namespace HairSalon.Pages;

public partial class AddServicePage : ContentPage
{
	MyHairSalon _hairSalon;
    int _serviceTypeId;

    public AddServicePage(MyHairSalon hairSalon, int serviceTypeId)
	{
		InitializeComponent();
		_hairSalon = hairSalon;
        _serviceTypeId = serviceTypeId;
	}

    private async void AddServiceButton_Clicked(object sender, EventArgs e)
    {
        Service service = new Service(NameEntry.Text, decimal.Parse(PriceEntry.Text), _serviceTypeId);
        _hairSalon.AddService(service);
        await Navigation.PopAsync();
    }
}