using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace pascal_triangle
{
    [Route("api/[controller]")]
    [ApiController]
    public class PascalTriangle : ControllerBase
    {
        [HttpGet("generate")]
        public IActionResult GeneratePascalTriangle([FromQuery] int rows)
        {
            if (rows <= 0)
            {
                return BadRequest("Number of rows must be a positive integer.");
            }

            var triangle = GenerateTriangle(rows);
            var formattedTriangle = FormatTriangle(triangle);
            return Ok(formattedTriangle);
        }

        private List<List<int>> GenerateTriangle(int rows)
        {
            var triangle = new List<List<int>>();
            for (int i = 0; i < rows; i++)
            {
                var row = new List<int>();
                int value = 1;
                for (int k = 0; k <= i; k++)
                {
                    row.Add(value);
                    value = value * (i - k) / (k + 1);
                }
                triangle.Add(row);
            }
            return triangle;
        }

        private string FormatTriangle(List<List<int>> triangle)
        {
            var sb = new StringBuilder();
            foreach (var row in triangle)
            {
                sb.AppendLine(string.Join(" ", row));
            }
            return sb.ToString();
        }
    }
}
