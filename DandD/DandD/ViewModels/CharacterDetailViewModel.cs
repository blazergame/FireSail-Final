using DandD.Models.Game_Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace DandD.ViewModels
{
    class CharacterDetailViewModel
    {
        public Character character { get; set; }
        public CharacterDetailViewModel(Character character = null)
        {
            //Title = item.Text;
            //Item = item;
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            //set { SetProperty(ref quantity, value); }
        }
    }
}
