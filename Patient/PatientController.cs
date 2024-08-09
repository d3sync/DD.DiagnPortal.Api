using DD.Shared.Models;
using DD.Shared.Services;
using DiagnPortal.API.Affiliate;
using DiagnPortal.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiagnPortal.API.Patient;

[Route("patient")]
[ApiController]
[Authorize(Roles="Affiliate,Guest")]
public class PatientController : ControllerBase
{
    private readonly ReadDbContext _context;
    private readonly CensorService _censorService;
    public PatientController(ReadDbContext context, CensorService censorService)
    {
        _context = context;
        _censorService = censorService;
    }
    //GET PATVISITSbyPATCODE -- ENDPOINT -- RETURNS a list of PATVISITDTO
    [HttpGet("visitsbypatcode/{patcode}")]
    public async Task<IActionResult> GetVisitsByPatcode(long patcode)
    {
        PatvisitDetail retData = null;
        if (AffiliateHelper.TryGetParapCode(User, out int affCode))
        {
             retData = await PatientDataAccess.GetVisitsByPatcodeAsList(_context, patcode, affCode);
        }
        else if (PatientHelper.TryGetPatientCode(User, out long patientCode))
        {
            if (patientCode != patcode)
                return BadRequest(new { status="failure", message="Invalid patient code"});
retData = await PatientDataAccess.GetVisitsByPatcodeAsList(_context, patcode, null);
        }
        
        
        if (retData != null)
            return Ok(new { status ="success", data = retData});
        return NoContent();

    }
    //GET PATVISITSbyAFFILIATE -- ENDPOINT -- RETURNS a list of PATVISITDTO
    [HttpGet("visitsbyaffiliate/{fromDate}/{toDate?}")]
    public async Task<IActionResult> GetVisitsByAffiliate(DateTime fromDate, DateTime? toDate)
    {
        var errorResult = AffiliateHelper.GetParapCode(User, out int dCode);
        
        if (errorResult != null)
        {
            return errorResult;
        }

        toDate ??= DateTime.Now;
        var retData = await PatientDataAccess.GetVisitsByAffiliateAsList(_context, dCode, fromDate, (DateTime)toDate);
        if (retData.Count > 0)
            return Ok(new { status ="success", data = retData});
        return NoContent();
    }
    [HttpGet("lastvisitsbyaffiliate/{take?}")]
    public async Task<IActionResult> GetVisitsByAffiliateLast(int? take)
    {
        if (take is <= 0 or null)
            take = 20;
        var errorResult = AffiliateHelper.GetParapCode(User, out int dCode);
        
        if (errorResult != null)
        {
            return errorResult;
        }
        var retData = await PatientDataAccess.GetVisitsByAffiliateLastAsList(_context,dCode, (int)take);
        if (retData.Count > 0)
            return Ok(new { status ="success", data = retData});
        return NoContent();
    }
    //GET PATVISITSbyUSERMAIL -- ENDPOINT -- RETURNS a list of PATVISITDTO
    [HttpGet("visitsbypatcode/{fromDate}/{toDate?}")]
    public async Task<IActionResult> GetVisitsByPatcode(DateTime fromDate, DateTime? toDate)
    {
        var errorResult = PatientHelper.GetPatientCode(User, out long patCode);
        if (errorResult != null)
        {
            return errorResult;
        }
        toDate ??= DateTime.Now;
        var retData = await PatientDataAccess.GetVisitsByPatcodeAsList(_context, patCode, fromDate, (DateTime)toDate);
        if (retData.Count > 0)
            return Ok(new { status ="success", data = retData});
        return NoContent();
    }
    //GET PATVISIT -- ENDPOINT -- RETURNS PATVISITDTO
    [HttpGet("visit/{patcode}/{patdate}/{pattime?}")]
    public async Task<IActionResult> GetVisitPatcodePatdatePattime(long patcode, DateTime patdate, DateTime? pattime)
    {
        Expression<Func<PATVISIT, bool>> predicate = patvisit => patvisit.PATCODE == patcode && patvisit.PATDATE == patdate;
        if (pattime.HasValue)
            predicate = patvisit => patvisit.PATCODE == patcode && patvisit.PATDATE == patdate && patvisit.PATTIME == pattime;

        var pat1file = await PatientDataAccess.GetPat1file(_context, patcode);
        var visitData = await PatientDataAccess.GetVisitDataList(_context, predicate);
        var exams = await PatientDataAccess.GetVisitExamsList(_context, patcode, patdate, pattime);

        if (visitData.Count > 0)
        {
            return Ok(new
            {
                status = "success",
                data = new PatvisitDetailDTO
                {
                    //Pat1file = _censorService.Censor(pat1file.ToDTO(), User),
                    //Patvisits = _censorService.Censor(visitData.Select(x => x.ToDTO()), User),
                    Pat1file = pat1file.ToDTO(),
                    Patvisits = visitData.Select(x => x.ToDTO()),
                    Patexes = exams
                }
            }
        );
        }

        return NoContent();
    }
    //GET ExamsByPATCODEandPATVISIT

}