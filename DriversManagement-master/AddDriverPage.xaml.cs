using DriversManagement.Models;
namespace DriversManagement;

public partial class AddDriverPage : ContentPage
{
	public AddDriverPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        VizualizareJob.ItemsSource = await App.Database.GetShopsAsync();
    }
    async void OnShopAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DriverPage
        {
            BindingContext = new Driver()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null) { await Navigation.PushAsync(new DriverPage { BindingContext = e.SelectedItem as Driver }); }
    }
}