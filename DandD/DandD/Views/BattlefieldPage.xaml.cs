using DandD.Models.Game_Files;
using DandD.Models.GameFiles;
using SQLite;
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
        public int healthMonster;
        public int characterHealth;
        public List<int> damageList = new List<int>();
        GameEngine ge = new GameEngine();
        List<Character> c;
        List <Monster> m;
        readonly SQLiteAsyncConnection database;

        public BattlefieldPage ()
		{
            this.Title = "Battle";
            InitializeComponent();

        }

        protected async override void OnAppearing()
        {
            //var characters = App.Database.RetrieveCharacters();
            base.OnAppearing();
            //BattleListView.ItemsSource = await App.Database.RetrieveCharacters();

            c = await App.Database.RetrieveCharacters();
            m = await App.Database.RetrieveMonsters();

            for (var i = 0; i < c.Count; i++)
            {
                ge.AddCharacter(c[i]);
            }
            
            for(var i = 0; i < m.Count; i++)
            {
                ge.AddMonster(m[i]);
            }
            playGame();


        }

        public async void playGame()
        {
            var m1 = m[0];
            var c1 = c[0];
      
            damageList = ge.battlefield.attack(ref m1,  ref c1);
            healthMonster = damageList[0];
            characterHealth = damageList[1];

            m1.DamangeReceived = damageList[0];
            c1.DamangeReceived = damageList[1];

            List<int> healths = new List<int>();
            healths.Add(healthMonster);
            healths.Add(characterHealth);
            await App.Database.UpdateCharacter(c1);
            
            BattleListView.ItemsSource = await App.Database.RetrieveCharacters();


        }
    }
}
