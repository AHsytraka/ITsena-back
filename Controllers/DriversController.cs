using ITsena_back.Data;
using ITsena_back.Models;
using ITsena_back.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITsena_back.Controllers;

[ApiController]
[Route("[Controller]")]
public class DriversController: ControllerBase
{
    private readonly ILogger<DriversController> _logger;
    private readonly ICacheService _cacheService;
    private readonly AppDbContext _dbContext;
    public DriversController(ILogger<DriversController> logger, ICacheService cacheService, AppDbContext dbContext)
    {
        _logger = logger;
        _cacheService = cacheService;
        _dbContext = dbContext;
    }

    [HttpGet("/Drivers")]
    public async Task<IActionResult> GetDrivers()
    {
        // check cache data
        var cacheData = _cacheService.GetData<IEnumerable<Driver>>("drivers");
        if (cacheData!= null && cacheData.Count()>0)
            return Ok(cacheData);
        cacheData = await _dbContext.Drivers.ToListAsync();
    
        // Set expiry time
        var expiryTime = DateTimeOffset.Now.AddSeconds(30);
        _cacheService.SetData<IEnumerable<Driver>>("drivers", cacheData, expiryTime);
        return Ok (cacheData);
    }

    [HttpPost("/AddDriver")]
    public async Task<IActionResult> PostDrivers(Driver value)
    {
        var AddedObj = await _dbContext.Drivers.AddAsync(value);
        var expiryTime = DateTimeOffset.Now.AddSeconds(30);
        _cacheService.SetData<Driver>($"driver{value.Id}", AddedObj.Entity, expiryTime);

        await _dbContext.SaveChangesAsync();
        
        return Ok(AddedObj.Entity);
    }

    [HttpDelete("/RemoveDriver")]
    public async Task<IActionResult> RemoveDrivers(int id)
    {
        var exist = await _dbContext.Drivers.FirstOrDefaultAsync(x => x.Id == id);
        if (exist!=null)
        {
            _dbContext.Remove(exist);
            _cacheService.RemoveData($"driver{id}");
            await _dbContext.SaveChangesAsync();
            return NoContent(); 
        }
        return NotFound();
    }
}
