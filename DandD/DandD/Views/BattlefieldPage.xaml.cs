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
        List<int> healths = new List<int>();

        public BattlefieldPage ()
		{
            this.Title = "Battle";
            InitializeComponent();


        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            c = await App.Database.RetrieveCharacters();
            m = await App.Database.RetrieveMonsters();

            for (var i = 0; i < c.Count; i++)
            {
                ge.AddCharacter(c[i]);
                System.Diagnostics.Debug.WriteLine(c[i]);
            }
            
            for(var i = 0; i < m.Count; i++)
            {
                ge.AddMonster(m[i]);
                System.Diagnostics.Debug.WriteLine(m[i]);
            }
            playGame();


        }

        public async void playGame()
        {
            int totalHP = 0;
            int i = 0;
            healths.Clear();

            for (int k = 0; k < c.Count; k++)
            {
                var temp = c[i];

                totalHP += temp.Health;
                
            }

            System.Diagnostics.Debug.WriteLine(totalHP);

            while (totalHP > 0)
            {


                var m1 = m[i];
                var c1 = c[i];

                if (i+1 <= c.Count) {
                    m1 = m[i];
                    c1 = c[i];
                    i++;

                }

                if (i >= c.Count)
                    i = 0;

                //[0] holds monster's damage to character
                //[1] holds character's damage to monster
                damageList = ge.battlefield.attack(ref m1, ref c1);
                healthMonster = damageList[0];
                characterHealth = damageList[1];

                m1.DamangeReceived = damageList[0];
                c1.DamangeReceived = damageList[1];

                System.Diagnostics.Debug.WriteLine(m1.Name + " gave " + c1.Name + " " + damageList[0] + " damage");
                System.Diagnostics.Debug.WriteLine(c1.Name + " gave " + m1.Name + " " + damageList[1] + " damage");

                healths.Add(healthMonster);
                healths.Add(characterHealth);

                if ((c1.Health - characterHealth) > 0)
                    await App.Database.UpdateCharacter(c1);
                else
                {
                    c1.Health = 0;
                    await App.Database.UpdateCharacter(c1);
                }

                BattleListView.ItemsSource = await App.Database.RetrieveCharacters();
                System.Diagnostics.Debug.WriteLine("okay");



                totalHP -= 10;
                
            }
            

        }
    }
}
