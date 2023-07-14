using DriversManagement.Models;
namespace DriversManagement;

public partial class PaginaJobe : ContentPage
{
	public PaginaJobe()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
	{
		var slist = (ListaJobe)BindingContext;
		slist.Date = DateTime.UtcNow;
        Driver selectedDriver = (AlegeDriver.SelectedItem as Driver);
		slist.DriverID = selectedDriver.ID;
        await App.Database.SaveShopListAsync(slist);
		await Navigation.PopAsync(); 
	}
    async void OnDeleteButtonClicked(object sender, EventArgs e) 
	{
		var slist = (ListaJobe)BindingContext;
		await App.Database.DeleteShopListAsync(slist);
		await Navigation.PopAsync();
	}
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PredifinedJobs((ListaJobe)this.BindingContext)
		{ 
			BindingContext = new Job() 
		});
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var items = await App.Database.GetShopsAsync();
		AlegeDriver.ItemsSource = (System.Collections.IList)items;
        AlegeDriver.ItemDisplayBinding = new Binding("DetaliiDriver");
        var shopl = (ListaJobe)BindingContext;
        VizualizareaJobe.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
    }
}