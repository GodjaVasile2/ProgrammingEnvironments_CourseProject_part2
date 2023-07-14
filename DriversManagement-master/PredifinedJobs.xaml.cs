using DriversManagement.Models;

namespace DriversManagement;

public partial class PredifinedJobs : ContentPage
{
    ListaJobe lo;
    public PredifinedJobs(ListaJobe olista)
    {
        InitializeComponent();
        lo = olista;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var obiectiv = (Job)BindingContext;
        await App.Database.SaveProductAsync(obiectiv);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var obiectiv = (Job)BindingContext;
        await App.Database.DeleteProductAsync(obiectiv);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Job o;
        if (listView.SelectedItem != null)
        {
            o = listView.SelectedItem as Job;
            var lp = new JobList()
            {
                ListaJobeID = lo.ID,
                JobID = o.ID
            };
            await App.Database.SaveListProductAsync(lp);
            o.JobList = new List<JobList> { lp };
            await Navigation.PopAsync();
        }
    }
}