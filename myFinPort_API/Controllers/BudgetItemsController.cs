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
    /// Controller for BudgetItem model
    /// </summary>
    public class BudgetItemsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        /// <summary>
        /// Provides data for all Budget Items
        /// </summary>
        /// <returns>A list of Budget Items and their data</returns>
        [Route("GetAllBudgetItemData")]
        public async Task<List<BudgetItem>> GetAllBudgetItemData()
        {
            return await db.GetAllBudgetItemData();
        }

        /// <summary>
        /// Provides data for all Budget Items in Json
        /// </summary>
        /// <returns>A list of all Budget Items and their data in Json</returns>
        [Route("GetAllBudgetItemData/json")]
        public async Task<IHttpActionResult> GetAllBudgetItemDataAsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAllBudgetItemData());
            return Ok(json);
        }

        /// <summary>
        /// Provides data for a single Budget Item
        /// </summary>
        /// <param name="id">The primary key for the Budget Item you wish to see</param>
        /// <returns>The Data for a single budget item</returns>
        [Route("GetDataForSingleBudgetItem")]
        public async Task<BudgetItem> GetBudgetItemDataById(int id)
        {
            return await db.GetBudgetItemDataById(id);
        }

        /// <summary>
        /// Provides data for a single budget item in Json
        /// </summary>
        /// <param name="id">The primary key for the Budget Item you wish to see</param>
        /// <returns>The Data for a single budget item</returns>
        [Route("GetDataForSingleBudgetItem/json")]
        public async Task<IHttpActionResult> GetBudgetItemDataByIdAsJson(int id)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetBudgetItemDataById(id)));
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
        [Route("AddBudgetItem")]
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
            return await db.AddBudgetItem
            (
            budgetId,
            created,
            itemName,
            targetAmount,
            currentAmount,
            isDeleted
            );
        }
    }
}
