using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Transactions.ViewModels
{
    // ToDo: Add Other Transaction Fields [Only Added Three For The Sake Of Time]

    [QueryProperty(nameof(TransactionId), nameof(TransactionId))]
    public class TransactionDetailViewModel : BaseViewModel
    {
        private string transactionId;
        private string name;
        private string bank_name;
        public string Id { get; set; }

        /// <summary>
        /// Transaction Name
        /// </summary>
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        /// <summary>
        /// Transaction Bank Name
        /// </summary>
        public string BankName
        {
            get => bank_name;
            set => SetProperty(ref bank_name, value);
        }

        /// <summary>
        /// Transaction ID
        /// </summary>
        public string TransactionId
        {
            get
            {
                return transactionId;
            }
            set
            {
                transactionId = value;
                LoadTransactionId(value);
            }
        }

        /// <summary>
        /// Load Transaction By ID
        /// </summary>
        /// <param name="transactionId"></param>
        public async void LoadTransactionId(string transactionId)
        {
            try
            {
                var transaction = await Services.TransactionAPI.GetTransactionAsync(transactionId);
                Id = transaction.ID;
                Name = transaction.Name;
                BankName = transaction.BankName;
                Title = "Transaction Details";

            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to get Transaction");
            }
        }


    }
}
