using HairSalon.Entities;

namespace HairSalon.Pages;

public partial class EmployeeServiceTypesCollectionPage : ContentPage
{
	MyHairSalon _hairSalon;
	public EmployeeServiceTypesCollectionPage(MyHairSalon hairSalon,int id)
	{
		InitializeComponent();
		_hairSalon = hairSalon;
        BindingContext = this;
        EmployeeServiceTypesCollectionView.ItemsSource = _hairSalon.GetEmployeeServiceTypes(id);
	}
}
