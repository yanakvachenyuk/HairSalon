using HairSalon.Entities;
using System.Diagnostics;

namespace HairSalon.Pages;

public partial class AdminMainPage : ContentPage
{
    MyHairSalon _hairSalon;
	public AdminMainPage(MyHairSalon hairSalon)
	{
		InitializeComponent();
        _hairSalon = hairSalon;
	}

    private async void MainFrame_Tapped(object sender, EventArgs e)
    {
        Frame selectedFrame = (Frame)sender; 
        Label selectedLabel = (Label)selectedFrame.Content; 
        string labelText = selectedLabel.Text; 

        if (labelText == "Clients")
        {
            
            await Navigation.PushAsync(new ClientsCollectionPage(_hairSalon));
        }
        else if(labelText == "ServiceTypes")
        {
            await Navigation.PushAsync(new ServiceTypesCollectionPage(_hairSalon));
        }
        else if(labelText =="Admins")
        {
            await Navigation.PushAsync(new AdminsCollectionPage(_hairSalon));
        }
        else if (labelText == "Employees")
        {
            await Navigation.PushAsync(new EmployeesCollectionPage(_hairSalon));
        }
        

    }

}