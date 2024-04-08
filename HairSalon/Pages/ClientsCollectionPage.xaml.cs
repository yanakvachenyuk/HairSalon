
using HairSalon.Entities;
using HairSalon.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace HairSalon.Pages;

public partial class ClientsCollectionPage : ContentPage
{
    MyHairSalon _hairSalon;
    private Client selectedClient;
    //private ObservableCollection<Client> Clients {  get; set; }
    

    public ClientsCollectionPage(MyHairSalon hairSalon)
    {
        InitializeComponent();
        _hairSalon = hairSalon;
        BindingContext = this;
        //Clients = [];
        // _hairSalon.GetClients().ForEach(client => Clients.Add(client));
        // clientsCollectionView.ItemsSource = Clients;
        clientsCollectionView.ItemsSource = _hairSalon.GetClients();
        selectedClient = null;
        
    }

    private async void OnAddClientButton_Clicked(object sender, EventArgs e)
    {
       
        await Navigation.PushAsync(new AddClientPage(_hairSalon));
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        //Clients.Clear();
        // _hairSalon.GetClients().ForEach(client => Clients.Add(client));
        clientsCollectionView.ItemsSource = _hairSalon.GetClients();
        //Debug.WriteLine("appear");
        //foreach (var client in Clients)
        //{
        //    Debug.WriteLine(client.FirstName);
        //}
        //Debug.WriteLine("");
        //foreach (var client in _hairSalon.GetClients())
        //{
        //    Debug.WriteLine(client.FirstName);
        //}
        //foreach (var client in _hairSalon.GetClients().Where(client => !Clients.Contains(client)))
        //{
        //    Clients.Add(client);
        //}
        selectedClient = null;
           
    }

    

    private async void OnClientFrame_Tapped(object sender, EventArgs e)
    {
         selectedClient = (Client)((TappedEventArgs)e).Parameter;

    }

   
    private async void OnDeleteClientButton_Clicked(object sender, EventArgs e)
    {
        if (selectedClient != null)
        {
            
            bool answer = await DisplayAlert("Confirm", "Are you sure you want to delete this client?", "Yes", "No");
            if (answer)
            {
               
                _hairSalon.DeleteClient(selectedClient.Id);
               
                clientsCollectionView.ItemsSource = _hairSalon.GetClients();
                selectedClient = null;
            }
        }
        else
        {
            await DisplayAlert("Error", "Please select a client to delete.", "OK");
        }
    }

    private void DeleteSwipeItem_Clicked(object sender, EventArgs e)
    {
        var menuItem=sender as SwipeItem;

        if(menuItem?.CommandParameter is Client client)
        {
            _hairSalon.DeleteClient(client.Id);
            //Clients.Remove(client);
            clientsCollectionView.ItemsSource = _hairSalon.GetClients();
        }
    }


}