using Bokningsystem.API.Models;
using Bokningsystem.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bokningsystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TjanstController : ControllerBase
    {
        private readonly TjanstService _service;

        public TjanstController(TjanstService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Tjanst>> GetAll() => await _service.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<Tjanst> Get(int id) => await _service.GetAsync(id);

        [HttpPost]
        public async Task<Tjanst> Create(Tjanst tjanst) => await _service.CreateAsync(tjanst);

        [HttpPut("{id}")]
        public async Task Update(int id, Tjanst tjanst)
        {
            tjanst.Id = id;
            await _service.UpdateAsync(tjanst);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id) => await _service.DeleteAsync(id);
    }
}
