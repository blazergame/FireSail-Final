using DandD.Helpers;
using DandD.Models.Game_Files;
using DandD.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DandD.ViewModels
{
    class CharacterViewModel : BaseCharacterModel
    {
        public ObservableRangeCollection<Character> Character { get; set; }
        public Command LoadItemsCommand { get; set; }

        public CharacterViewModel()
        {
            Title = "Browse";
            Character = new ObservableRangeCollection<Character>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Character>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Character;
                Character.Add(_item);
                await DataStore.AddItemAsync(_item);
                
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Character.Clear();
                var character = await DataStore.GetItemsAsync(true);
                Character.ReplaceRange(character);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
