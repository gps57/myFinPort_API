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
    /// Controller for Budget model
    /// </summary>
    public class BudgetsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        /// <summary>
        /// Provides data for all Budgets
        /// </summary>
        /// <returns>A list of Budgets and their data</returns>
        [Route("GetAllBudgetData")]
        public async Task<List<Budget>> GetAllBudgetData()
        {
            return await db.GetAllBudgetData();
        }

        /// <summary>
        /// Provides data for all Budgets in Json
        /// </summary>
        /// <returns>A list of all Budgets and their data in Json</returns>
        [Route("GetAllBudgetData/json")]
        public async Task<IHttpActionResult> GetAllBudgetDataAsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAllBudgetData());
            return Ok(json);
        }

        /// <summary>
        /// Provides data for a single Budget
        /// </summary>
        /// <param name="id">The primary key for the Budget you wish to see</param>
        /// <returns>The Data for a single budget</returns>
        [Route("GetDataForSingleBudget")]
        public async Task<Budget> GetBudgetDataById(int id)
        {
            return await db.GetBudgetDataById(id);
        }

        /// <summary>
        /// Provides data for a single budget in Json
        /// </summary>
        /// <param name="id">The primary key for the Budget you wish to see</param>
        /// <returns>The Data for a single budget</returns>
        [Route("GetDataForSingleBudget/json")]
        public async Task<IHttpActionResult> GetBudgetDataByIdAsJson(int id)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetBudgetDataById(id)));
        }

        /// <summary>
        /// Creates a new Budget in the database
        /// </summary>
        /// <param name="hhId">Household Id</param>
        /// <param name="ownerId">Owner Id</param>
        /// <param name="created">Date new Budget was created</param>
        /// <param name="budgetName">The new Budget's name</param>
        /// <param name="currentAmount">The new Budget's current balance</param>
        /// <returns></returns>
        [Route("AddBudget")]
        public async Task<int> AddBudget
        (
            int hhId,
            string ownerId,
            DateTime created,
            string budgetName,
            decimal currentAmount
        )
        {
            return await db.AddBudget
            (
                hhId, 
                ownerId,
                created,
                budgetName,
                currentAmount
            );
        }
    }
}
