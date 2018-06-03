using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace taqueria
{
	public partial class App : Application
	{
		public App (String idPhone)
		{
			InitializeComponent();
            
            MainPage = new NavigationPage(new MainPage(idPhone));

        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
