using GenericImplementation.Api.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GenericImplementation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T> : ControllerBase where T : class
    {
        private readonly GenericDataService<T> _genericDataService;

        public GenericController(GenericDataService<T> genericDataService)
        {
            _genericDataService = genericDataService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] T value)
        {
            var result = await _genericDataService.AddAsync(value);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] T value)
        {
            var result = await _genericDataService.UpdateAsync(id, value);
            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<T> entity)
        {
            if (!ModelState.IsValid)
            {
                return NoContent();
            }

            var result = await _genericDataService.PatchUpdateAsync(id, entity);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _genericDataService.GetAll();
            if (result == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _genericDataService.GetById(id);
            if (result == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _genericDataService.DeleteAsync(id);
        }
    }
}
