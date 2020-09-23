using myFinPort_API.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace myFinPort_API.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext()
        : base("ApiConnection")
        {
        }

        // here is where I add code to call my stored procedures

        //
        // Start of Household related methods
        //
        /// <summary>
        /// Returns data for all Households
        /// </summary>
        /// <returns>A list of all Households</returns>
        public async Task<List<Household>> GetAllHouseholdData()
        {
            return await Database.SqlQuery<Household>("GetAllHouseholdData").ToListAsync();
        }

        /// <summary>
        /// Returns data for a single Household
        /// </summary>
        /// <param name="hhId">The Primary Key of the Household you want to see</param>
        /// <returns>The data for the a single Household</returns>
        public async Task<Household> GetHouseholdDataById(int hhId)
        {
            return await Database.SqlQuery<Household>("GetHouseholdDataById @Id",
                new SqlParameter("Id", hhId)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Add a new household to the database
        /// </summary>
        /// <param name="householdName">The name of the household</param>
        /// <param name="greeting">A greeting that will be presented to household members</param>
        /// <param name="created">The date the household was created</param>
        /// <param name="isDeleted">Specifies whether this household is deleted or not</param>
        /// <returns></returns>
        public async Task<int> AddHousehold
        (
            string householdName,
            string greeting,
            DateTime created,
            bool isDeleted
        )
        {
            return await Database.ExecuteSqlCommandAsync
            (
                "AddHousehold @householdName," +
                "@greeting," +
                "@created," +
                "@isDeleted",
                new SqlParameter("householdName", householdName),
                new SqlParameter("greeting", greeting),
                new SqlParameter("created", created),
                new SqlParameter("isDeleted", isDeleted)
            );
        }

        //
        // Start of Bank related methods
        //

        /// <summary>
        /// Provide data for all Bank Accounts
        /// </summary>
        /// <returns>A list data for all Bank Accounts</returns>
        public async Task<List<BankAccount>> GetAllBankData()
        {
            return await Database.SqlQuery<BankAccount>("GetAllBankData").ToListAsync();
        }

        /// <summary>
        /// Provides the data for a single Back Account
        /// </summary>
        /// <param name="Id">Primary Key for the Bank Account you want to see</param>
        /// <returns>Data for a single Bank Account</returns>
        public async Task<BankAccount> GetBankDataById(int Id)
        {
            return await Database.SqlQuery<BankAccount>("GetBankDataById @Id",
                new SqlParameter("Id", Id)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Creates a new BankAccount with the data provided by user.
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
                AccountType accountType
            )
        {
            return await Database.ExecuteSqlCommandAsync
            (
                "AddBankAccount @hhId," +
                "@ownerId," +
                "@accountName," +
                "@created," +
                "@startingBalance," +
                "@currentBalance," +
                "@warningBalance," +
                "@isDeleted," +
                "@accountType ",
                new SqlParameter("hhId", hhId),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("accountName", accountName),
                new SqlParameter("created", created),
                new SqlParameter("startingBalance", startingBalance),
                new SqlParameter("currentBalance", currentBalance),
                new SqlParameter("warningBalance", warningBalance),
                new SqlParameter("isDeleted", isDeleted),
                new SqlParameter("accountType", accountType)
            );
        }

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
        AccountType accountType
    )
        {
            return await Database.ExecuteSqlCommandAsync
            (
                "UpdateBankById @bankId," +
                "@hhId," +
                "@ownerId," +
                "@accountName," +
                "@created," +
                "@startingBalance," +
                "@currentBalance," +
                "@warningBalance," +
                "@isDeleted," +
                "@accountType ",
                new SqlParameter("bankId", bankId),
                new SqlParameter("hhId", hhId),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("accountName", accountName),
                new SqlParameter("created", created),
                new SqlParameter("startingBalance", startingBalance),
                new SqlParameter("currentBalance", currentBalance),
                new SqlParameter("warningBalance", warningBalance),
                new SqlParameter("isDeleted", isDeleted),
                new SqlParameter("accountType", accountType)
            );
        }

        //
        // Start of Budget related methods
        //

        /// <summary>
        /// Provides data for all Budgets
        /// </summary>
        /// <returns>A list of data for all Budgets</returns>
        public async Task<List<Budget>> GetAllBudgetData()
        {
            return await Database.SqlQuery<Budget>("GetAllBudgetData").ToListAsync();
        }

        /// <summary>
        /// Provides data for a single Budget
        /// </summary>
        /// <param name="Id">The Primary Key for the Budget you want to see</param>
        /// <returns>The data for a single Budget</returns>
        public async Task<Budget> GetBudgetDataById(int Id)
        {
            return await Database.SqlQuery<Budget>("GetBudgetDataById @Id",
                new SqlParameter("Id", Id)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Adds a new Budget to the database
        /// </summary>
        /// <param name="hhId">Household Id</param>
        /// <param name="ownerId">Owner Id</param>
        /// <param name="created">Date Budget was created</param>
        /// <param name="budgetName">Name of the new Budget</param>
        /// <param name="currentAmount">The Budget's current balance</param>
        /// <returns></returns>
        public async Task<int> AddBudget
        (
            int hhId,
            string ownerId,
            DateTime created,
            string budgetName,
            decimal currentAmount
        )
        {
            return await Database.ExecuteSqlCommandAsync
            (
                "AddBudget @hhId," +
                "@ownerId," +
                "@created," +
                "@budgetName," +
                "@currentAmount",
                new SqlParameter("hhId", hhId),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("created", created),
                new SqlParameter("budgetName", budgetName),
                new SqlParameter("currentAmount", currentAmount)
            );
        }

        //
        // Start of BudgetItem related methods
        //

        /// <summary>
        ///  Provides data for all BudgetItems
        /// </summary>
        /// <returns>A list of data for all Budgets</returns>
        public async Task<List<BudgetItem>> GetAllBudgetItemData()
        {
            return await Database.SqlQuery<BudgetItem>("GetAllBudgetItemData").ToListAsync();
        }

        /// <summary>
        /// Provides the data for a single Budget Item
        /// </summary>
        /// <param name="Id">The Primary Key for the Budget Item you want to see</param>
        /// <returns>The data for a single Budget Item</returns>
        public async Task<BudgetItem> GetBudgetItemDataById(int Id)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetDataById @Id",
                new SqlParameter("Id", Id)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Add a new BudgetItem record to the database
        /// </summary>
        /// <param name="budgetId">The FK to the parent Budget</param>
        /// <param name="created">The date the BudgetItem was created</param>
        /// <param name="itemName">The name of the BudgetItem</param>
        /// <param name="targetAmount">The target amount for the BudgetItem</param>
        /// <param name="currentAmount">The current amount for the BudgetItem</param>
        /// <param name="isDeleted">Specifies whether or not the BudgetItem is deleted</param>
        /// <returns>Success (-1) or failure (0)</returns>
        public async Task<int> AddBudgetItem
        (
            int budgetId,
            DateTime created,
            string itemName,
            decimal targetAmount,
            decimal currentAmount,
            bool isDeleted
        )
        {
            return await Database.ExecuteSqlCommandAsync
            (
                "AddBudgetItem @budgetId," +
                "@created," +
                "@itemName," +
                "@targetAmount," +
                "@currentAmount," +
                "@isDeleted",
                new SqlParameter("budgetId", budgetId),
                new SqlParameter("created", created),
                new SqlParameter("itemName", itemName),
                new SqlParameter("targetAmount", targetAmount),
                new SqlParameter("currentAmount", currentAmount),
                new SqlParameter("isDeleted", isDeleted)
            );
        }

        //
        // Start of Transaction related methods
        //

        /// <summary>
        /// Provides all data for all Transactions
        /// </summary>
        /// <returns>A list of data for all Transactions</returns>
        public async Task<List<Transaction>> GetAllTransactionData()
        {
            return await Database.SqlQuery<Transaction>("GetAllTransactionData").ToListAsync();
        }

        /// <summary>
        /// Provides the data for a single Transaction
        /// </summary>
        /// <param name="Id">The Primary Key for the Transaction you want to see</param>
        /// <returns>The data for a single Transaction</returns>
        public async Task<Transaction> GetTransactionDataById(int Id)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionDataById @Id",
                new SqlParameter("Id", Id)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Add a new Transaction to the database
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
            return await Database.ExecuteSqlCommandAsync
            (
                "AddTransaction @accountId," +
                "@budgetItemId," +
                "@ownerId," +
                "@transactionType," +
                "@created," +
                "@amount," +
                "@memo," +
                "@isDeleted",
                new SqlParameter("accountId", accountId),
                new SqlParameter("budgetItemId", budgetItemId),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("transactionType", transactionType),
                new SqlParameter("created", created),
                new SqlParameter("amount", amount),
                new SqlParameter("memo", memo),
                new SqlParameter("isDeleted", isDeleted)
            );
        }

        /// <summary>
        /// Deletes the specified Transaction from the database
        /// </summary>
        /// <param name="id">The PK of the transaction being deleted</param>
        /// <returns></returns>
        public async Task<int> DeleteTransactionDataById(int id)
        {
            return await Database.ExecuteSqlCommandAsync
            (
                "DeleteTransactionDataById @id",
                new SqlParameter("id", id)
            );
        }
    }
}