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
        Random rand = new Random(); 
		public CharacterPage ()
		{
			InitializeComponent();
		}

        public async void Save_Clicked(object sender, System.EventArgs e)
        {
            var createCharacter = (Character)BindingContext;
            createCharacter.Str = Randomize();
			System.Threading.Thread.Sleep(10);
            createCharacter.Dex = Randomize();
            System.Threading.Thread.Sleep(10);
            createCharacter.Speed = Randomize();
            createCharacter.Health = 100;
            createCharacter.Level = 1;

            await App.Database.InsertCharacter(createCharacter);
            await Navigation.PopAsync();
        }

		//async void Cancel_Clicked(object sender, System.EventArgs e)
		//{
		//    await Navigation.PopAsync();
		//}

		private int Randomize()
		{
			Random rand = new Random();
			return rand.Next(5, 12);
		}

		private string PopulateAndReturnNames()
		{

			var words = new[] { "Leroy Jenkins", "Warlock", "Qui-gone-drank-the-gin","The_Chosen_One", "Anakin", "Frank", "Jake from Statefarm", "Flo", "Donald Drumpf",
			"Father Sunborg", "Mitt Romney", "Barrack Yo-Momma The 3rd", "Carl", "O_O", "THE_MARINERS_SUCK_AT_BASEBALL" };
			return words[rand.Next(0, words.Length)];
		}
    }
}
