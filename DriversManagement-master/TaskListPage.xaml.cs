using DriversManagement.Models;

namespace DriversManagement;

public partial class TaskListPage : ContentPage
{
	public TaskListPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
       VizualizareJob.ItemsSource = await App.Database.GetShopListsAsync();
    }
    async void OnShopListAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PaginaJobe
        {
            BindingContext = new ListaJobe() 
        }); 
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)

    {
        if (e.SelectedItem != null) 
        {
            await Navigation.PushAsync(new PaginaJobe 
            {
                BindingContext = e.SelectedItem as ListaJobe 
            });
        }
    }
}