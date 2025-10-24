using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Microsoft.Maui.Controls;

namespace Grocery.App.ViewModels
{
    public partial class CheckoutViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private int groceryListId;

        public ObservableCollection<GroceryListItem> Items { get; } = new();

        // This method is called when navigating to this ViewModel with query parameters. Avoids type conversion errors.
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("GroceryListId", out var idObj) && idObj is int id)
                GroceryListId = id;

            if (query.TryGetValue("ItemsParam", out var itemsObj) &&
                itemsObj is IEnumerable<GroceryListItem> list)
            {
                Items.Clear();
                foreach (var it in list) Items.Add(it);
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public decimal TotalPrice => Items.Sum(i => i.TotalLinePrice);

        [RelayCommand]
        private async Task ConfirmPayment()
        {
            // To test the payment screen. No real payment integration yet.
            await App.Current.MainPage.DisplayAlert(
                "Bestelling",
                $"Totaal: € {TotalPrice:F2}\n(Bevestiging - test)",
                "OK");
        }
    }
}


