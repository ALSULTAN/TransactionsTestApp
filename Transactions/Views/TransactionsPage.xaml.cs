using Transactions.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Transactions.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransactionsPage : ContentPage
    {
        public TransactionsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new TransactionsViewModel();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        TransactionsViewModel _viewModel;

    }
}