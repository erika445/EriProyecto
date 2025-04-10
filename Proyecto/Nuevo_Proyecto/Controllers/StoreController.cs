using Microsoft.AspNetCore.Mvc;
using Nuevo_Proyecto.Interface;
using Nuevo_Proyecto.Model;

namespace Nuevo_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : Controller
    {
        private readonly IStoreRepository _storeRepository;

        public StoreController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Store>> GetStoreById(int id)
        {
            var store = await _storeRepository.GetStoreByIdAsync(id);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Store>>> GetStores()
        {
            var stores = await _storeRepository.GetStoresAsync();
            return Ok(stores);
        }

        [HttpPost]
        public async Task<ActionResult<Store>> CreateStore(Store store)
        {
            var createdStore = await _storeRepository.CreateStoreAsync(store);
            return CreatedAtAction(nameof(GetStoreById), new { id = createdStore.BusinessEntityID }, createdStore);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStore(int id, Store store)
        {
            if (id != store.BusinessEntityID)
            {
                return BadRequest();
            }

            var result = await _storeRepository.UpdateStoreAsync(store);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(int id)
        {
            var result = await _storeRepository.DeleteStoreByIdAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
