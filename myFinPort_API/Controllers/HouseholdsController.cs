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
    /// Controller for Household model
    /// </summary>
    [RoutePrefix("api/Households")]
    public class HouseholdsController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();

        /// <summary>
        /// Endpoint to return data for all Households
        /// </summary>
        /// <returns>List of household models</returns>
        [Route("GetAllHouseholdData")]
        public async Task<List<Household>> GetAllHouseholdData()
        {
            return await db.GetAllHouseholdData();
        }

        /// <summary>
        /// Gives data for all Households in Json form.
        /// </summary>
        /// <returns></returns>
        [Route("GetAllHouseholdData/json")]
        public async Task<IHttpActionResult> GetAllHouseholdDataAsJson()
        {
            var json = JsonConvert.SerializeObject(await db.GetAllHouseholdData());
            return Ok(json);
        }

        /// <summary>
        /// Returns information for a single household
        /// </summary>
        /// <param name="id">The primary key of the household you want to see</param>
        /// <returns>Single household model</returns>
        [Route("GetDataForSingleHousehold")]
        public async Task<Household> GetHouseholdDataById(int id)
        {
            return await db.GetHouseholdDataById(id);
        }

        /// <summary>
        /// Returns information for a single Household in Json form
        /// </summary>
        /// <param name="id">The Primary Key of the household you want to see</param>
        /// <returns></returns>
        [Route("GetDataForSingleHousehold/json")]
        public async Task <IHttpActionResult> GetHouseholdDataByIdAsJson(int id)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetHouseholdDataById(id)));
        }

        /// <summary>
        /// Add a new household to the database
        /// </summary>
        /// <param name="householdName">The name of the new household</param>
        /// <param name="greeting">A greeting that is presented to members of the household</param>
        /// <param name="created">The date the household was created</param>
        /// <param name="isDeleted">Specifies whether the household is deleted or not</param>
        /// <returns></returns>
        [Route("AddHousehold")]
        [HttpPost]
        public async Task<int> AddHousehold
        (
            string householdName,
            string greeting,
            DateTime created,
            bool isDeleted
        )
        {
            return await db.AddHousehold
            (
            householdName,
            greeting,
            created,
            isDeleted
            );
        }
    }
}
