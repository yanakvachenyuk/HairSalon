using HairSalon.Entities;

namespace HairSalon.Pages;

public partial class AdminsCollectionPage : ContentPage
{
	MyHairSalon _hairSalon;
	public AdminsCollectionPage(MyHairSalon hairSalon)
	{
		InitializeComponent();
		_hairSalon = hairSalon;
        BindingContext = this;
        adminsCollectionView.ItemsSource = _hairSalon.GetAdmins();
	}
}