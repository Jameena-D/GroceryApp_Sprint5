using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grocery.App.ViewModels
{
    [QueryProperty(nameof(GroceryListId), nameof(GroceryListId))]
    [QueryProperty(nameof(ItemsParam), nameof(ItemsParam))]
    public partial class CheckoutViewModel : ObservableObject
    {
        [ObservableProperty]
        private int groceryListId;

        public ObservableCollection<GroceryListItem> Items { get; } = new();

        private IList<GroceryListItem> _itemsParam;
        public IList<GroceryListItem> ItemsParam
        {
            get => _itemsParam;
            set
            {
                _itemsParam = value;
                Items.Clear();
                if (_itemsParam != null)
                {
                    foreach (var it in _itemsParam)
                        Items.Add(it);
                }
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public decimal TotalPrice => Items.Sum(i => i.TotalLinePrice);

        [RelayCommand]
        private async Task ConfirmPayment()
        {
            await App.Current.MainPage.DisplayAlert(
                "Bestelling",
                $"Totaal: € {TotalPrice:F2}\n(Bevestiging - demo)",
                "OK");
        }
    }
}


