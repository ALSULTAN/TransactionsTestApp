using Transactions.Views;
using Xamarin.Forms;

namespace Transactions
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TransactionDetailsPage), typeof(TransactionDetailsPage));
        }


    }
}
