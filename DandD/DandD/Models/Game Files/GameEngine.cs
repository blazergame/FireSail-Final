using System.Collections.Generic;
using DandD.Models.Game_Files;
using DandD.Services;

namespace DandD.Models.GameFiles
{
	public class GameEngine
	{
	    public List<Monster> Monsters;
	    public List<Character> Characters;
		public BattlefieldController battlefield;
        public bool Dead; 
        public bool GameOver;
	    public int TurnCounter;

        public GameEngine()
        {
            //Monsters = new List<Monster>();
            //Characters = new List<Character>();
            battlefield = new BattlefieldController();
            Dead = false;
            GameOver = false; 
            TurnCounter = 0; 
        }

        public void AddCharacter(Character character)
        {
            //if (character.IsValid() && Characters.Count < 4)
            //    Characters.Add(character);

        }

        public void AddMonster(Monster monster)
        {
            //if (monster.isValid() && Monsters.Count < 4)
            //    Monsters.Add(monster);
        }

        public void PlayGame()
        {
			//while(!GameOver)
   //             TakeTurn(Characters, Monsters);
            ResetGame();
        }

        public void ResetGame()
        {
            //Characters.Clear();
            //Monsters.Clear();
            TurnCounter = 0;
            GameOver = false;
        }


        //public void TakeTurn(List<Character> Characters, List<Monster> Monsters)
        //{
        //    CheckIfGameOver(Characters, Monsters);
        //    if (GameOver)
        //        return; 

        //    for (int i = 0; i < Characters.Count; i++)
        //    {
        //        battlefield.attack(Monsters[i], Characters[i]);
        //        Dead = battlefield.isDead(Monsters[i]);
        //        if (Dead == true)
        //        {
        //            RemoveCharcterFromListIfDead(Characters[i]);
        //        }
        //        Dead = battlefield.isDead(Characters[i]);
        //        if (Dead == true)
        //        {
        //            RemoveMonsterFromListIfDead(Monsters[i]);
        //        }
        //    }
        //    TurnCounter++;
        //}
    
        //public void RemoveCharcterFromListIfDead(Character character)
        //{
        //    //Characters.Remove(character);

        //}

        //public void RemoveMonsterFromListIfDead(Monster monster)
        //{
        //    //Monsters.Remove(monster);
        //}


        //public void CheckIfGameOver(List<Character> Characters, List<Monster> Monsters)
        //{
        //    if (Characters.Count == 0 || Monsters.Count == 0)
        //        EndGame(); 
        //}
       
        //public void EndGame()
        //{
        //    GameOver = true; 
        //}

    }
}
