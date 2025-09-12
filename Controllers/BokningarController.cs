using Bokningsystem.API.Models;
using Bokningsystem.API.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BokningarController : ControllerBase
{
    private readonly IBokningService _service;

    public BokningarController(IBokningService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Bokning>> GetAll() => await _service.GetAllAsync(null, null);

    [HttpGet("{id}")]
    public async Task<Bokning> Get(int id) => await _service.GetAsync(id);

    [HttpPost]
    public async Task<Bokning> Create(Bokning bokning) => await _service.CreateAsync(bokning);

    [HttpPut("{id}")]
    public async Task Update(int id, Bokning bokning)
    {
        bokning.Id = id;
        await _service.UpdateAsync(bokning);
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id) => await _service.DeleteAsync(id);
}
