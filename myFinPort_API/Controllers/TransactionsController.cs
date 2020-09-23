using myFinPort_API.Enums;
using myFinPort_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace myFinPort_API.Controllers
{
    /// <summary>
    /// Controller for Transaction model
    /// </summary>
    public class TransactionsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        /// <summary>
        /// Provides data for all Transaction
        /// </summary>
        /// <returns>A list of Transactions and their data</returns>
        [Route("GetAllTransactionData")]
        public async Task<List<Transaction>> GetAllTransactionData()
        {
            return await db.GetAllTransactionData();
        }

        /// <summary>
        /// Provides data for all Transactions in Json
        /// </summary>
        /// <returns>A list of all Transactions and their data in Json</returns>
        [Route("GetAllTransactionData/json")]
        public async Task<IHttpActionResult> GetAllTransactionDataAsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAllTransactionData());
            return Ok(json);
        }

        /// <summary>
        /// Provides data for a single Transaction
        /// </summary>
        /// <param name="id">The primary key for the Transaction you wish to see</param>
        /// <returns>The Data for a single Transaction</returns>
        [Route("GetDataForSingleTransaction")]
        public async Task<Transaction> GetTransactionDataById(int id)
        {
            return await db.GetTransactionDataById(id);
        }

        /// <summary>
        /// Provides data for a single Transaction in Json
        /// </summary>
        /// <param name="id">The primary key for the Transaction you wish to see</param>
        /// <returns>The Data for a single Transaction</returns>
        [Route("GetDataForSingleTransaction/json")]
        public async Task<IHttpActionResult> GetTransactionDataByIdAsJson(int id)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetTransactionDataById(id)));
        }

        /// <summary>
        /// Adds a new Transaction to the database
        /// </summary>
        /// <param name="accountId">Id of bank account which will be charged</param>
        /// <param name="budgetItemId">Id of budget item that will be charged</param>
        /// <param name="ownerId">Id of the owner of the new Transaction</param>
        /// <param name="transactionType">The type of transaction</param>
        /// <param name="created">The date the transaction was created</param>
        /// <param name="amount">The transaction amount</param>
        /// <param name="memo">The transaction memo</param>
        /// <param name="isDeleted">Says whether this transaction is deleted.</param>
        /// <returns></returns>
        [Route("AddTransaction")]
        public async Task<int> AddTransaction
        (
            int accountId,
            int budgetItemId,
            string ownerId,
            TransactionType transactionType,
            DateTime created,
            decimal amount,
            string memo,
            bool isDeleted
        )
        {
            return await db.AddTransaction
            (
                accountId,
                budgetItemId,
                ownerId,
                transactionType,
                created,
                amount,
                memo,
                isDeleted
            );
        }

        /// <summary>
        /// Deletes the specified Transaction from the database
        /// </summary>
        /// <param name="id">The PK of the transaction being deleted</param>
        /// <returns></returns>        [Route("DeleteTransactionDataById")]
        public async Task<int> DeleteTransactionDataById(int id)
        {
            return await db.DeleteTransactionDataById(id);
        }
    }
}
