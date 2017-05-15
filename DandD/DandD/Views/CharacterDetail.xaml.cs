using DandD.Models.Game_Files;
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
	public partial class CharacterDetail : ContentPage
	{
		public CharacterDetail ()
		{
			InitializeComponent ();
		}

        async void Save_Clicked(object sender, System.EventArgs e)
        {
            var Char = (Character)BindingContext;
            await App.Database.InsertCharacter(Char);
            await Navigation.PopAsync();
        }

        async void Cancel_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }
}

