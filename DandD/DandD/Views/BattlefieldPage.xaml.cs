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
	public partial class BattlefieldPage : ContentPage
	{
        GameEngine ge = new GameEngine();
        
        public BattlefieldPage ()
		{
            this.Title = "Battle";
            InitializeComponent();

        }

        protected async override void OnAppearing()
        {
            //var characters = App.Database.RetrieveCharacters();
            base.OnAppearing();
            BattleListView.ItemsSource = await App.Database.RetrieveCharacters();

           
            //  ge.AddCharacter();

        }

    }
}
