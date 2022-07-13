using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Transactions.Models;
using Transactions.Views;
using Xamarin.Forms;

namespace Transactions.ViewModels
{    
    // ToDo: Only Fetch Transaction Data On Refresh View Swipe Not On Navigating Back [Performance Tweak]

    public class TransactionsViewModel : BaseViewModel
    {
        private Transaction _selectedTransaction;

        /// <summary>
        /// Currently Selected Transaction
        /// </summary>
        public Transaction SelectedTransaction
        {
            get => _selectedTransaction;
            set
            {
                SetProperty(ref _selectedTransaction, value);
                OnTransactionSelected(value);
            }
        }

        /// <summary>
        /// List Of Current Transactions
        /// </summary>
        public ObservableCollection<Transaction> Transactions { get; }

        /// <summary>
        /// Load Transaction Command
        /// </summary>
        public Command LoadTransactionsCommand { get; }

        /// <summary>
        /// Called When Tapping A Transaction
        /// </summary>
        public Command<Transaction> TransactionTapped { get; }

        /// <summary>
        /// Transaction View Model
        /// </summary>
        public TransactionsViewModel()
        {
            Title = "Transaction History";
            Transactions = new ObservableCollection<Transaction>();
            LoadTransactionsCommand = new Command(async () => await ExecuteLoadTransactionsCommand());
            TransactionTapped = new Command<Transaction>(OnTransactionSelected);
        }

        /// <summary>
        /// Load Transaction
        /// </summary>
        /// <returns></returns>
        async Task ExecuteLoadTransactionsCommand()
        {
            try
            {
                IsBusy = true;
                Transactions.Clear();
                var items = await Services.TransactionAPI.GetTransactionsAsync();
                foreach (var item in items)
                {
                    Transactions.Add(item);
                }
            }
            catch (Exception Error)
            {
                Debug.WriteLine(Error);
            }
            finally
            {
                IsBusy = false;
            }
        }

        /// <summary>
        /// On Transaction View Apearing
        /// </summary>
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedTransaction = null;
        }

        /// <summary>
        /// Called Upon Transaction Select
        /// </summary>
        /// <param name="transaction"></param>
        async void OnTransactionSelected(Transaction transaction)
        {
            if (transaction == null) return;
            await Shell.Current.GoToAsync($"{nameof(TransactionDetailsPage)}?{nameof(TransactionDetailViewModel.TransactionId)}={transaction.ID}");
        }
    }
}
