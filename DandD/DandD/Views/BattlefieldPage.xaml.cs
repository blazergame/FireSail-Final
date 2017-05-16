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
            int score = 0;
            Random rand = new Random();

            healths.Clear();

            //Get total health of all characters
            for (int k = 0; k < c.Count; k++)
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
                    c1.Xp += m1.Xp;

                    if (c1.didLevelUp())
                    {
                        System.Diagnostics.Debug.WriteLine("CHARACTER LEVELED UP");
                      
                    }

					await App.Database.InsertMonster(m1);
				}

                MonsterDoingDamageView.ItemsSource = await App.Database.RetrieveMonsters();
                CharacterDoingDamageView.ItemsSource = await App.Database.RetrieveCharacters();

                System.Diagnostics.Debug.WriteLine(totalHP);
                totalHP -= c1.DamangeReceived;

                //Assign score to user
                score+= rand.Next(1,10);
                assignHighScore(c[i], score);


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
                equipItem();
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

        async void assignHighScore(Character character, int _score)
        {
            Random rand = new Random();

            character.HighScore = _score + rand.Next(1, 20);
            await App.Database.UpdateCharacter(character);
        }

        async private void equipItem()
        {
            System.Diagnostics.Debug.WriteLine("Inside equipItem");
            c = await App.Database.RetrieveCharacters();
            m = await App.Database.RetrieveMonsters();

            int totalMonsterHP = 0; //For equipping items when all monsters are dead

            for (int i = 0; i < m.Count; i++)
            {
                totalMonsterHP += m[i].Health;
            }

            if (totalMonsterHP <= 0)
            {
                var items = await App.Database.RetrieveItems(); //Dropping Items LOGIC
                System.Diagnostics.Debug.WriteLine("Inside IF HP <0 loop");

                for (int j = 0; j < c.Count; j++)
                {
                    if (c[j].Health > 0)
                    {
                        //Transfer attributes from items to character : EQUIP ITEM logic
                        for (int i = 0; i < items.Count; i++)
                        {
                            if (items[i].Dex > 0)
                                c[j].Dex += items[i].Dex;

                            if (items[i].Str > 0)
                                c[j].Str += items[i].Str;

                            if (items[i].Speed > 0)
                                c[j].Speed += items[i].Speed;

                            await App.Database.UpdateCharacter(c[j]);
                        }
                    }
                }


            }
            var listOfItem = App.Database.RetrieveItems();
            System.Diagnostics.Debug.WriteLine(listOfItem);
        }
    }
}
