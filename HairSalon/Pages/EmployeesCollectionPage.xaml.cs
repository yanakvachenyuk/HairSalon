using HairSalon.Entities;

namespace HairSalon.Pages;

public partial class EmployeesCollectionPage : ContentPage
{
	MyHairSalon _hairSalon;
	public EmployeesCollectionPage(MyHairSalon hairSalon)
	{
		InitializeComponent();
		_hairSalon = hairSalon;
        BindingContext = this;
        employeesCollectionView.ItemsSource = _hairSalon.GetEmployees();
	}

    private async void EmployeeFrame_Tapped(object sender, TappedEventArgs e)
    {
        var selectedEmployee = (Employee)((TappedEventArgs)e).Parameter;

        int selectedEmployeeId = selectedEmployee.Id;

        await Navigation.PushAsync(new EmployeeServiceTypesCollectionPage(_hairSalon, selectedEmployeeId));
    }
}