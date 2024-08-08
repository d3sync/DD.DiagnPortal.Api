using System.Dynamic;
using DD.Shared.DTOs;
using DD.Shared.Models;
using DiagnPortal.API.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DiagnPortal.API.Patient
{
    public class PatvisitDetail
    {
        public Pat1fileDTO PatInfo { get; set; }
        public List<PatvisitDTO> Visits { get; set; }
    }
    public static class PatientDataAccess
    {
        public static async Task<List<PATVISIT>> GetVisitDataList(ReadDbContext context,
            Func<PATVISIT, bool> predicate)
        {
            return await context.PATVISIT
                .AsNoTracking()
                .Include(x => x.PATCODENavigation)
                .Where(predicate)
                .AsQueryable()
                .ToListAsync();
        }

        public static async Task<PatvisitDetail> GetVisitsByPatcodeAsList(ReadDbContext context, long patcode,
            int? affiliate)
        {
            Expression<Func<PATVISIT, bool>> predicate = patvisit => patvisit.PATCODE == patcode;
            if (affiliate.HasValue)
            {
                predicate = patvisit => patvisit.PATCODE == patcode && patvisit.PARAP1 == affiliate;
            }

            var retData = await context.PATVISIT.AsNoTracking()
                .Where<PATVISIT>(predicate)
                .Include(x=>x.PATCODENavigation)
                .ToListAsync();
            return new PatvisitDetail
            {
                PatInfo = retData.First().PATCODENavigation.ToDTO(), 
                Visits = retData.Select(x => new PatvisitDTO
                {
                    PATCODE = x.PATCODE,
                    PATDATE = x.PATDATE,
                    PATTIME = x.PATTIME,
                    PATASFAL = x.PATASFAL,
                    ASFALAM = x.ASFALAM,
                    ROWTAM = x.ROWTAM,
                    CNCODE = x.CNCODE,
                    PARAP1 = x.PARAP1,
                    PARAP2 = x.PARAP2,
                    USERCODE = x.USERCODE,
                    PATASFAL2 = x.PATASFAL2,
                    ForeignPat = x.ForeignPat,
                    FOREIGNRESPRINT = x.FOREIGNRESPRINT,
                    EXTRAEMAILS = x.EXTRAEMAILS
                }).ToList()
            };
        }
        public static async Task<List<PatvisitDTO>> GetVisitsByAffiliateAsList(ReadDbContext context, int dcode,
            DateTime fromDate, DateTime toDate)
        {
            return await context.PATVISIT.AsNoTracking()
                .Where(x => x.PARAP1 == dcode && x.PATDATE >= fromDate && x.PATDATE <= toDate)
                .Include(x=>x.PATCODENavigation)
                .Select(x=> new PatvisitDTO
                {
                    Pat1file = x.PATCODENavigation.ToDTO(),
                    PATCODE = x.PATCODE,
                    PATDATE = x.PATDATE,
                    PATTIME = x.PATTIME,
                    PATASFAL = x.PATASFAL,
                    ASFALAM = x.ASFALAM,
                    ROWTAM = x.ROWTAM,
                    CNCODE = x.CNCODE,
                    PARAP1 = x.PARAP1,
                    PARAP2 = x.PARAP2,
                    USERCODE = x.USERCODE,
                    PATASFAL2 = x.PATASFAL2,
                    ForeignPat = x.ForeignPat,
                    FOREIGNRESPRINT = x.FOREIGNRESPRINT,
                    EXTRAEMAILS = x.EXTRAEMAILS
                }).ToListAsync();
        }

        public static async Task<List<PatvisitDTO>> GetVisitsByPatcodeAsList(ReadDbContext context, long patcode, DateTime fromDate, DateTime toDate)
        {
            return await context.PATVISIT.AsNoTracking()
                .Where(x => x.PATCODE == patcode && x.PATDATE >= fromDate && x.PATDATE <= toDate)
                .Include(x=>x.PATCODENavigation)
                .Select(x=> new PatvisitDTO
                {
                    Pat1file = x.PATCODENavigation.ToDTO(),
                    PATCODE = x.PATCODE,
                    PATDATE = x.PATDATE,
                    PATTIME = x.PATTIME,
                    PATASFAL = x.PATASFAL,
                    ASFALAM = x.ASFALAM,
                    ROWTAM = x.ROWTAM,
                    CNCODE = x.CNCODE,
                    PARAP1 = x.PARAP1,
                    PARAP2 = x.PARAP2,
                    USERCODE = x.USERCODE,
                    PATASFAL2 = x.PATASFAL2,
                    ForeignPat = x.ForeignPat,
                    FOREIGNRESPRINT = x.FOREIGNRESPRINT,
                    EXTRAEMAILS = x.EXTRAEMAILS
                }).ToListAsync();
        }
        public static async Task<List<PatexetResult>> GetVisitExamsList(ReadDbContext context,
            long patcode, DateTime patdate, DateTime? pattime)
        {
            string sqlQuery;
            List<object> param =
            [
                new SqlParameter("@PATCODE", patcode),
                new SqlParameter("@PATDATE", patdate)
            ];
            if (pattime is null)
            {
                sqlQuery = CustomSqlQueries.GetSqlQueryPatcodePatdate;
            }
            else
            {
                sqlQuery = CustomSqlQueries.GetSqlQueryPatcodePatdatePattime;
                param.Add(new SqlParameter("@PATTIME", pattime));
            }

            var data = await context.Set<PatexetResult>().FromSqlRaw(sqlQuery, param.ToArray()).ToListAsync();
            return data;
        }

        public static async Task<List<ExpandoObject>> GetVisitsByAffiliateLastAsList(ReadDbContext context, int dcode, int take)
        {
            return await context.PATVISIT.AsNoTracking()
                .Where(x => x.PARAP1 == dcode)
                .OrderByDescending(x => x.PATDATE)
                .Select(x => new
                {
                    Pat1file = x.PATCODENavigation.ToDTO(),
                    x.PATCODE,
                    x.PATDATE,
                    x.PATTIME
                })
                .Take(take)
                .ToListAsync()
                .ContinueWith(t => t.Result.Select(item =>
                {
                    dynamic expando = new ExpandoObject();
                    expando.PATNAME = $"{item.Pat1file.PATFIRST} {item.Pat1file.PATLAST}";
                    expando.PATCODE = item.PATCODE;
                    expando.PATDATE = item.PATDATE;
                    expando.PATTIME = item.PATTIME;
                    return (ExpandoObject)expando;
                }).ToList());
        }
    }
}
