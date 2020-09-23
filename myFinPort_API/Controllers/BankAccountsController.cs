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
    /// Controller for BankAccount model
    /// </summary>
    public class BankAccountsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        /// <summary>
        /// Provides data for all Bank Accounts
        /// </summary>
        /// <returns>A list of Bank Accounts and their data</returns>
        [Route("GetAllBankData")]
        public async Task<List<BankAccount>> GetAllBankData()
        {
            return await db.GetAllBankData();
        }

        /// <summary>
        /// Provides data for all Bank Accounts in Json
        /// </summary>
        /// <returns>A list of all Bank Accounts and their data in Json</returns>
        [Route("GetAllBankData/json")]
        public async Task<IHttpActionResult> GetAllBankDataAsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAllBankData());
            return Ok(json);
        }

        /// <summary>
        /// Provides data for a single bank
        /// </summary>
        /// <param name="id">The primary key for the Bank you wish to see</param>
        /// <returns>The Data for a single bank</returns>
        [Route("GetDataForSingleBank")]
        public async Task<BankAccount> GetBankDataById(int id)
        {
            return await db.GetBankDataById(id);
        }

        /// <summary>
        /// Provides data for a single bank in Json
        /// </summary>
        /// <param name="id">The primary key for the Bank you wish to see</param>
        /// <returns>The Data for a single bank</returns>
        [Route("GetDataForSingleBank/json")]
        public async Task<IHttpActionResult> GetBankDataByIdAsJson(int id)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetBankDataById(id)));
        }

        /// <summary>
        /// Adds a new Bank account to the database.
        /// </summary>
        /// <param name="hhId">Household Id</param>
        /// <param name="ownerId">Owner Id</param>
        /// <param name="accountName">Bank Account Name</param>
        /// <param name="created">Date account was created</param>
        /// <param name="startingBalance">Balance of account at creation</param>
        /// <param name="currentBalance">Current balance in account</param>
        /// <param name="warningBalance">Balance at which a warning should be sent</param>
        /// <param name="isDeleted">Is this account deleted (true/false)</param>
        /// <param name="accountType">Account Type</param>
        /// <returns></returns>
        [Route("AddBankAccount")]
        public async Task<int> AddBankAccount
            (
                int hhId,
                string ownerId,
                string accountName,
                DateTime created,
                decimal startingBalance,
                decimal currentBalance,
                decimal warningBalance,
                bool isDeleted,
                AccountType accountType)
        {
            return await db.AddBankAccount(hhId, ownerId, accountName, created, startingBalance, currentBalance, warningBalance, isDeleted, accountType);
        }

        [Route("UpdateBankById")]
        public async Task<int> UpdateBankById
    (
        int bankId,
        int hhId,
        string ownerId,
        string accountName,
        DateTime created,
        decimal startingBalance,
        decimal currentBalance,
        decimal warningBalance,
        bool isDeleted,
        AccountType accountType)
        {
            return await db.UpdateBankById(bankId, hhId, ownerId, accountName, created, startingBalance, currentBalance, warningBalance, isDeleted, accountType);
        }
    }
}
