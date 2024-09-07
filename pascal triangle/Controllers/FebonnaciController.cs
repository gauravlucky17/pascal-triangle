using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace pascal_triangle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FebonnaciController : ControllerBase
    {
        [HttpGet("series")]
        public IActionResult GetFibonacciSeries([FromQuery] int terms)
        {
            if (terms <= 0)
            { return BadRequest("Number of terms must be a positive integer."); }
            var series = GenerateFibonacciSeries(terms);
            return Ok(series);
        }
        private List<int> GenerateFibonacciSeries(int terms)
        {
            var series = new List<int>();
            if (terms >= 1)
            { series.Add(0); }
            if (terms >= 2)
            { series.Add(1); }
            int first = 0, second = 1, next;
            for (int i = 2; i < terms; i++)
            {
                next = first + second;
                series.Add(next);
                first = second;
                second = next;
            }
            return series;
        }

    }
}
