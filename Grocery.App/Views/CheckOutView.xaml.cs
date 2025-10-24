using Grocery.App.ViewModels;
using Grocery.App;

namespace Grocery.App.Views;

public partial class CheckOutView : ContentPage
{
    public CheckOutView()
    {
        InitializeComponent();
        BindingContext = ServiceHelper.GetService<CheckoutViewModel>();
    }
}