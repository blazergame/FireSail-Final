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
        public AttackView display = new AttackView(); 
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

            surrenderButton.Clicked += async (s, e) =>
            {
                displayAlertSurrender();
                
            };
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

            //Get total health of all characters
            for (int k = 0; k < 4; k++)
            {
                var temp = c[k];

                totalHP += temp.Health;
                
            }

            System.Diagnostics.Debug.WriteLine(totalHP);


            while (totalHP > 0)
            {


                var m1 = m[i];
                var c1 = c[i];


                //Check bounds of character index
                if (i+1 <= c.Count) {
                    m1 = m[i];
                    c1 = c[i];
                    i++;
                }

               //Reset index once out of bound
                if (i >= c.Count)
                    i = 0;

                //[0] holds monster's damage to character
                //[1] holds character's damage to monster
                damageList = ge.battlefield.attack(ref m1, ref c1);
                healthMonster = damageList[0];
                characterHealth = damageList[1];

                m1.DamangeReceived = damageList[0];
                c1.DamangeReceived = damageList[1];


                m1.DmgHolder = display.Concat(m1,c1, damageList[0]);
                c1.DmgHolder = display.Concat(c1, m1, damageList[1]);
				

                healths.Add(healthMonster);
                healths.Add(characterHealth);

                //Update character health after each turn
                //If health is below 0, set it to 0
                if ((c1.Health - characterHealth) > 0)
                    await App.Database.UpdateCharacter(c1);
                else
                {
                    c1.Health = 0;
                    await App.Database.UpdateCharacter(c1);
                }

                //Update monster health after each turn
                //If health is below 0, set it to 0
                if ((m1.Health - healthMonster) > 0)
					await App.Database.InsertMonster(m1);
				else
				{
					m1.Health = 0;
					await App.Database.InsertMonster(m1);
				}

                MonsterDoingDamageView.ItemsSource = await App.Database.RetrieveMonsters();
                CharacterDoingDamageView.ItemsSource = await App.Database.RetrieveCharacters();
                //  System.Threading.Thread.Sleep(100);
                System.Diagnostics.Debug.WriteLine(totalHP);
                totalHP -= c1.DamangeReceived;
            }

             //Need to do level up once monster has died
             //Get exp value from monster, add to c1.xp
             //Call c1.didLevelUp(). If return true, it has leveled up
             //c1.didLevelUp will automatically add random values to the level up stats
             
            displayAlertWin();

        }

        async void displayAlertWin()
        {
            var answer = await DisplayAlert("Congrats!!","You have won","Ok","Cancel");
            System.Diagnostics.Debug.WriteLine("Answer: " + answer);

            if(answer == true)
            {
                //Push items drop page gained from battle page
                //From that page, after clicking okay, should return to main menu
                resetBattleFieldMonster();
                resetBattleFieldCharacter();
                await Navigation.PopAsync();
            }

            
        }

        async void displayAlertSurrender()
        {
            var answer = await DisplayAlert("Surrendered!", "You have lost", "Ok", "Cancel");
            System.Diagnostics.Debug.WriteLine("Answer: " + answer);

            if(answer == true)
            {
                resetBattleFieldMonster();
                resetBattleFieldCharacter();
                await Navigation.PopAsync();
            }
        }

        async void displayAlertLost()
        {
            var answer = await DisplayAlert("Better Luck Next Time", "You have lost", "Ok", "Cancel");
            System.Diagnostics.Debug.WriteLine("Answer: " + answer);

            if (answer == true)
            {
                resetBattleFieldMonster();
                resetBattleFieldCharacter();
                await Navigation.PopAsync();
            }
        }

        async void resetBattleFieldMonster()
        {

            var monsterHPReset = await App.Database.RetrieveMonsters();

            for (var i = 0; i < monsterHPReset.Count; i++) {
                monsterHPReset[i].Health = 100;
                await App.Database.UpdateMonster(monsterHPReset[i]);
            }

        }

        async void resetBattleFieldCharacter()
        {

            var characterHPReset = await App.Database.RetrieveCharacters();

            for (var i = 0; i < characterHPReset.Count; i++)
            {
                characterHPReset[i].Health = 100;
                await App.Database.UpdateCharacter(characterHPReset[i]);
            }

        }

        private void equipItem()
        {
            var listOfItem = App.Database.RetrieveItems();


            System.Diagnostics.Debug.WriteLine(listOfItem);
        }
    }
}
