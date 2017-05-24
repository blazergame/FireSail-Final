using System;

using Xamarin.Forms;

namespace DandD.Views
{
    public class BattleEffects : ContentPage
    {
        public BattleEffects()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

