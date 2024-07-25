using DD.Shared.Utilities;
using DiagnPortal.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace DiagnPortal.API.Affiliate;

[Route("affiliate")]
[ApiController]
[Authorize(Roles = "Affiliate")]
public class AffiliateController : ControllerBase
{
    private readonly ReadDbContext _context;


    public AffiliateController(ReadDbContext context)
    {
        _context = context;
    }
/// <summary>
/// 
/// </summary>
/// <returns></returns>
    [HttpGet("info")]
    public async Task<IActionResult> AffiliateInfoById()
    {
        var errorResult = AffiliateHelper.GetTamCode(User, out short affCode);

        if (errorResult != null || !AffiliateHelper.TryGetParapCode(User,out int dCode))
        {
            return errorResult;
        }
        var result = await _context.ASFAL.FirstOrDefaultAsync(x => x.TAMCODE == affCode);
        var result2 = await _context.DOCTFILE.FirstOrDefaultAsync(x => x.DCODE == dCode);
        if (result == null)
        {
            return NotFound(new { status = "failure", message = "No Data" });
        }

        return Ok(new { status = "success", data = new { TAM = result.ToDTO(), DOC = result2.ToDTO() }});
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet("pricelists")]
    public async Task<IActionResult> AffiliatePricelistsById()
    {
        var errorResult = AffiliateHelper.GetTamCode(User, out short affCode);
        if (errorResult != null) 
        {
            return errorResult;
        }
        var result = await _context.ASFALSYM.Where(x => x.TAMCODE == affCode).ToListAsync();
        if (result == null)
        {
            return NotFound(new { status = "failure", message = "No Data" });
        }

        return Ok(new { status = "success", data = result.Select(x => x.ToDTO()) });
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="timokatid"></param>
    /// <returns></returns>
    [HttpGet("pricelist/{timokatid}")]
    public async Task<IActionResult> AffiliatePricelistById(int timokatid)
    {
        var errorResult = AffiliateHelper.GetParapCode(User, out int affCode);
        if (errorResult != null || !AffiliateHelper.TryGetTamCode(User, out var tamCode))
        {
            return errorResult;
        }

        var result = await _context.TIMOKAT
            .Where(x => x.TAMCODE == tamCode && x.ROWTAM == timokatid)
            .Include(x => x.EXCODENavigation)
            .Select(x => x.ToDTO())
            .ToListAsync();

        if (result.Count > 0)
        {
            return Ok(new { status = "success", data = result });
        }
    
        return NotFound(new { status = "failure", message = "No Data" });
    }

    [HttpGet("GetCalendarData")]
    public IActionResult GetEventsPerAffiliateForCalendar()
    {
        var errorResult = AffiliateHelper.GetParapCode(User, out int affCode);
        if (errorResult != null)
        {
            return errorResult;
        }

        var events = _context.PATVISIT.Where(x => x.PARAP1 == affCode).Include(x => x.PATCODENavigation).Select(e =>
            new
            {
                id = string.Concat(e.PATCODE, "|", e.PATDATE.ToBinary(), "|", e.PATTIME.ToBinary()),
                title = string.Concat(e.PATCODENavigation.PATLAST, " ", e.PATCODENavigation.PATFIRST.Truncate(2)),
                start = e.PATDATE,
                end = e.PATDATE,
                description = string.Concat(e.PATCODENavigation.PATFIRST, " ", e.PATCODENavigation.PATLAST),
                allDay = true,
                backgroundColor = "#FFFFFF",
                textColor = "#2471a3",
                //url = e.Url
            }).ToList();
        if (events.Count > 0)
        {
            return Ok(events);
        }

        return NoContent();
    }
}