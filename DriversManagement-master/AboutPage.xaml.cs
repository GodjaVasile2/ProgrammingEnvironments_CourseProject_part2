using System.Diagnostics;

namespace DriversManagement;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}
    private void OnContactUsClicked(object sender, EventArgs e)
    {
        var email = "mailto:vasie.godja8@@gmail.com";
        var process = new Process
        {
            StartInfo = new ProcessStartInfo(email)
            {
                UseShellExecute = true
            }
        };
        process.Start();
    }
    private void OnFacebookClicked(object sender, EventArgs e)
    {
        var url = "https://www.facebook.com/groups/249609853770889";
        var process = new Process
        {
            StartInfo = new ProcessStartInfo(url)
            {
                UseShellExecute = true
            }
        };
        process.Start();
    }

}