using DandD.Models.Game_Files;
using DandD.Models.GameFiles;
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
	public partial class CharacterPage : ContentPage
	{  
		public CharacterPage ()
		{
			InitializeComponent();
		}

        public async void Save_Clicked(object sender, System.EventArgs e)
        {
            var createCharacter = (Character)BindingContext;
            createCharacter.Str = 4;
            createCharacter.Dex = 4;
            createCharacter.Health = 100;
            createCharacter.Level = 1;

            await App.Database.InsertCharacter(createCharacter);
            await Navigation.PopAsync();
        }

        //async void Cancel_Clicked(object sender, System.EventArgs e)
        //{
        //    await Navigation.PopAsync();
        //}
    }
}
