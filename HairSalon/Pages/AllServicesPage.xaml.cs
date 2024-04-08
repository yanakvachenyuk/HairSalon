
using HairSalon.Entities;
using Microsoft.VisualBasic;

namespace HairSalon.Pages;

public partial class AllServicesPage : ContentPage
{
	MyHairSalon _hairSalon;
	public AllServicesPage(MyHairSalon hairSalon)
	{
		InitializeComponent();
		_hairSalon = hairSalon;
        BindingContext = this;
        LoadServices();
	}

    private void LoadServices()
    {
        var serviceTypes = _hairSalon.GetServiceTypes().ToList(); 

        List<GroupedServiceType> groupedServiceTypes = new List<GroupedServiceType>();

        foreach (var serviceType in serviceTypes)
        {
            var services = _hairSalon.GetServices(serviceType.Id).ToList();      
            groupedServiceTypes.Add(new GroupedServiceType(serviceType, services));
        }

        collectionView.ItemsSource = groupedServiceTypes;
    }
}