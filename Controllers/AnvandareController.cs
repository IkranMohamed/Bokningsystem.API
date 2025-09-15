using Bokningsystem.API.Models;
using Bokningsystem.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bokningsystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnvandareController : ControllerBase
    {
        private readonly AnvandareService _service;

        public AnvandareController(AnvandareService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Anvandare>> GetAll() => await _service.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<Anvandare> Get(int id) => await _service.GetAsync(id);

        [HttpPost]
        public async Task<Anvandare> Create(Anvandare anvandare) => await _service.CreateAsync(anvandare);

        [HttpPut("{id}")]
        public async Task Update(int id, Anvandare anvandare)
        {
            anvandare.Id = id;
            await _service.UpdateAsync(anvandare);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id) => await _service.DeleteAsync(id);
    }
}
