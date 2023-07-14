using System;
using DriversManagement.Data;
using System.IO;
namespace DriversManagement;

public partial class App : Application
{
    static JobeDatabase database;
    public static JobeDatabase Database 
	{
		get 
		{
			if (database == null) 
			{ 
				database = new JobeDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Jobe.db3")); 
			}
			return database;
		} 
	}
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
