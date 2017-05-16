﻿using System;
using System.Collections.Generic;
using DandD.Models.Game_Files;
using Xamarin.Forms;

namespace DandD.Views
{
    public partial class AttackView : ContentPage
    {
        public string damageView;
        public AttackView()
        {
            InitializeComponent();
        }

        public string Concat(Monster m1, Character c1, int val)
        {
           return damageView = m1.Name + " Attacked " + c1.Name + " for " + val;
        }

        public string Concat(Character c1, Monster m1, int val)
        {
            return damageView = c1.Name + " Attacked " + c1.Name + " for " + val;

        }
    }
}

