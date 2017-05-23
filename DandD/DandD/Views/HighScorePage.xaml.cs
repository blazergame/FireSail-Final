using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DandD.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HighScorePage : ContentPage
	{
		public HighScorePage ()
		{
			InitializeComponent ();
            this.Title = "High Scores";
         
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            HighScoreView.ItemsSource = await App.Database.RetrieveCharacters();
        }

    }
}
