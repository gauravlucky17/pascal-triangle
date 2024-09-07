using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace pascal_triangle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemoveDuplicateArrayController : ControllerBase
    {
        [HttpPost("removeduplicates")]
        public IActionResult RemoveDuplicates([FromBody] int[] array)
        {
            if (array == null || array.Length == 0)
            { return BadRequest("Array cannot be null or empty."); }
            int[] arrayWithoutDuplicates = RemoveDuplicatesFromArray(array);
            return Ok(arrayWithoutDuplicates);
        }
        private int[] RemoveDuplicatesFromArray(int[] array)
        {
            int[] tempArray = new int[array.Length];
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                bool isDuplicate = false;
                for (int j = 0; j < count; j++)
                {
                    if (array[i] == tempArray[j])
                    {
                        isDuplicate = true;
                        break;
                    }
                }
                if (!isDuplicate)
                {
                    tempArray[count] = array[i];
                    count++;
                }
            }
            int[] resultArray = new int[count];
            Array.Copy(tempArray, resultArray, count);
            return resultArray;

        }
    }
}
