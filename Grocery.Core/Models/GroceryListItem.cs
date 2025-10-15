using CommunityToolkit.Mvvm.ComponentModel;

namespace Grocery.Core.Models
{
    public partial class GroceryListItem : Model
    {
        public int GroceryListId { get; set; }
        public int ProductId { get; set; }
        [ObservableProperty]
        public int amount;

        public decimal TotalLinePrice => (Product?.Price ?? 0m) * Amount;
        public GroceryListItem(int id, int groceryListId, int productId, int amount) : base(id, "")
        {
            GroceryListId = groceryListId;
            ProductId = productId;
            Amount = amount;
        }

        public Product Product { get; set; } = new(0, "None", 0);

        partial void OnAmountChanged(int oldValue, int newValue)
        {
            OnPropertyChanged(nameof(TotalLinePrice));
        }
    }
}
