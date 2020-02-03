
using System;

using ClassLibrary284;

using Microsoft.AspNetCore.Mvc;

namespace Listify.Controllers
{
    /// <summary>
    /// api controller for accessing a range list
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ListifyController : ControllerBase
    {
        /// <summary>
        /// range list accessor
        /// </summary>
        /// <param name="low">low of range</param>
        /// <param name="high">high or range</param>
        /// <param name="index">0-based accessor index for range: low..high</param>
        /// <returns>corr. ranged list value i.e. low + index</returns>
        [HttpGet("{low:int}/{high:int}/{index:int}")]
        public ActionResult<int> Get(int low, int high, int index)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return new RangeList(low, high)[index];
            }
            catch (IndexOutOfRangeException)
            {
                return NotFound($"index: {index} outside of {low}-{high}");
            }
        }
    }
}
