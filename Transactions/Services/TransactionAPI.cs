using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Transactions.Models;
using Transactions.Shared;

namespace Transactions.Services
{
    /// <summary>
    /// Transaction Rest APIs
    /// </summary>
    public class TransactionAPI
    {
        /// <summary>
        /// Get All Transactions
        /// </summary>
        /// <returns>List Of Transaction</returns>
        public static async Task<List<Transaction>> GetTransactionsAsync()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(Constants.TransactionsService);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var Json = await response.Content.ReadAsStringAsync();
                var Transactions = JsonConvert.DeserializeObject<List<Transaction>>(Json);
                return Transactions;
            }
            return new List<Transaction>();
        }
        /// <summary>
        /// Get Transaction Details Using Its ID
        /// </summary>
        /// <param name="ID">Transaction ID</param>
        /// <returns>Transaction</returns>
        public static async Task<Transaction> GetTransactionAsync(string ID)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(Constants.TransactionsService + ID);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var Json = await response.Content.ReadAsStringAsync();
                var Transaction = JsonConvert.DeserializeObject<Transaction>(Json);
                return Transaction;
            }
            return new Transaction();
        }
    }
}
