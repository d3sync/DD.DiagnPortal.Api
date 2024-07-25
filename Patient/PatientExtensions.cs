using DD.Shared.Models;

namespace DiagnPortal.API.Patient;

public static class PatientExtensions
{
    public static Pat1fileDTO ToDTO(this PAT1FILE x) => new()
    {
        PATCODE = x.PATCODE,
        PATLAST = x.PATLAST,
        PATFIRST = x.PATFIRST,
        PATLATIN = x.PATLATIN,
        PATBIRTH = x.PATBIRTH,
        PATSEX = x.PATSEX,
        PATPROFF = x.PATPROFF,
        PATADDR = x.PATADDR,
        PATZIP = x.PATZIP,
        PATTOWN = x.PATTOWN,
        PATPHON = x.PATPHON,
        PATFAX = x.PATFAX,
        PATEMAIL = x.PATEMAIL,
        PATCIGAR = x.PATCIGAR,
        CIGARNUM = x.CIGARNUM,
        PATFKIND = x.PATFKIND,
        PATOPER = x.PATOPER,
        PATSICK = x.PATSICK,
        PATINHER = x.PATINHER,
        PATATHL = x.PATATHL,
        PATEKPT = x.PATEKPT,
        SENSENT = x.SENSENT,
        PATALLERGY = x.PATALLERGY,
        PATANAEMIAID = x.PATANAEMIAID,
        PATDISEASEID = x.PATDISEASEID,
        PATBLTYPE = x.PATBLTYPE,
        PATRHES = x.PATRHES,
        DOYCODE = x.DOYCODE,
        WEB = x.WEB,
        WEBDATE = x.WEBDATE,
        WEBPASS = x.WEBPASS,
        AMKA = x.AMKA,
        TOWNCODE = x.TOWNCODE,
        CTRCODE = x.CTRCODE,
        CTRCODE_ST = x.CTRCODE_ST,
        PATPASS = x.PATPASS,
        PATMOBILE = x.PATMOBILE,
        PROFFCODE = x.PROFFCODE,
        TAMCODE1 = x.TAMCODE1,
        TAMCODE2 = x.TAMCODE2,
        LASTHISTDT = x.LASTHISTDT,
        TAMCODE = x.TAMCODE,
        PATLAST_FULL = x.PATLAST_FULL,
        PATFIRST_FULL = x.PATFIRST_FULL,
        ForeignPat = x.ForeignPat
    };

    public static PatvisitDTO ToDTO(this PATVISIT x) =>
        new()
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
        };
    
}