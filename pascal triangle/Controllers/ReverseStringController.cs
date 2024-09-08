using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace pascal_triangle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReverseStringController : ControllerBase
    {
        [HttpGet("reverse")]
        public IActionResult ReverseString([FromQuery] string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return BadRequest("Input string cannot be null or empty.");
            }

            string reversedString = Reverse(input);
            return Ok(reversedString);
        }

        // Helper method to reverse a string
        private string Reverse(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
