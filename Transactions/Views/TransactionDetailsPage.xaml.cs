using Transactions.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Transactions.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransactionDetailsPage : ContentPage
    {
        public TransactionDetailsPage()
        {
            InitializeComponent();
            BindingContext = new TransactionDetailViewModel();
        }
    }
}