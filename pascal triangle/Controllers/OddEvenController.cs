using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace pascal_triangle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OddEvenController : ControllerBase
    {
        [HttpPost("check")]
        public IActionResult CheckOddEven([FromBody] int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            { return BadRequest("Array cannot be null or empty."); }
            var results = new List<string>();
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                { results.Add($"{number} is even"); }
                else
                { results.Add($"{number} is odd"); }
            }
            return Ok(results);
        }

    }
}
