
using System;

using ClassLibrary284;

using Microsoft.AspNetCore.Mvc;

namespace Listify.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListifyController : ControllerBase
    {
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
                return NotFound($"index {index} outside of {low}-{high}");
            }
        }
    }
}
