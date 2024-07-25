using DD.Shared.Models;

namespace DiagnPortal.API.Affiliate
{
    public static class AffiliateExtensions
    {
        public static AsfalDTO ToDTO(this DD.Shared.Models.ASFAL asfal) => new()
        {
            TAMCODE = asfal.TAMCODE,
            TAMNAME = asfal.TAMNAME,
            TAMADDR = asfal.TAMADDR,
            TAMPROF = asfal.TAMPROF,
            TAMTEL = asfal.TAMTEL,
            TAMAFM = asfal.TAMAFM,
            TAMDOY = asfal.TAMDOY,
            TAMKAT = asfal.TAMKAT,
            TAMENERG = asfal.TAMENERG,
            USERCODE = asfal.USERCODE,
            USERDATE = asfal.USERDATE,
            CLKAT = asfal.CLKAT,
            ABROAD = asfal.ABROAD,
            DOYCODE = asfal.DOYCODE,
            WEB = asfal.WEB,
            TAMEMAIL = asfal.TAMEMAIL,
            TAMZIP = asfal.TAMZIP,
            TAMTOWN = asfal.TAMTOWN,
            TAMCTRID = asfal.TAMCTRID,
            DCODE = asfal.DCODE,
            TAMALTERNAME = asfal.TAMALTERNAME,
            EMAIL_LOCK = asfal.EMAIL_LOCK
        };
        public static DoctfileDTO ToDTO(this DOCTFILE d) => new()
        {
            DCODE = d.DCODE,
            DLAST = d.DLAST,
            DFIRST = d.DFIRST,
            DRSLTNAME = d.DRSLTNAME,
            DSEX = d.DSEX,
            DADDR = d.DADDR,
            DTOWN = d.DTOWN,
            DNOMOS = d.DNOMOS,
            DZIP = d.DZIP,
            DAREA = d.DAREA,
            DPHONE1 = d.DPHONE1,
            DPHONE2 = d.DPHONE2,
            DPHONE3 = d.DPHONE3,
            DFAX = d.DFAX,
            DEMAIL = d.DEMAIL,
            DPROFF = d.DPROFF,
            DAFM = d.DAFM,
            DDOY = d.DDOY,
            DPARAP = d.DPARAP,
            DDIAGN = d.DDIAGN,
            DTHERAP = d.DTHERAP,
            DDATE = d.DDATE,
            DUSER1 = d.DUSER1,
            DUSER = d.DUSER,
            OLD = d.OLD,
            TSAYNUM = d.TSAYNUM,
            USERDATE = d.USERDATE,
            AMKA = d.AMKA,
            DOCKINDID = d.DOCKINDID,
            SIGNATURE = d.SIGNATURE,
            SIGNATUREFILE = d.SIGNATUREFILE,
            EMAIL_LOCK = d.EMAIL_LOCK
        };

        public static AsfalsymDTO ToDTO(this ASFALSYM am) =>
            new()
            {
                TAMCODE = am.TAMCODE,
                ROWTAM = am.ROWTAM,
                SYMNAME = am.SYMNAME,
                ENERG = am.ENERG,
                RELATION = am.RELATION,
                USERCODE = am.USERCODE,
                USERDATE = am.USERDATE,
                SENDRESEMAIL = am.SENDRESEMAIL,
                SYMEMAIL = am.SYMEMAIL
            };

        public static TimokatDTO ToDTO(this TIMOKAT tk) => new()
        {
            TAMCODE = tk.TAMCODE,
            ROWTAM = tk.ROWTAM,
            EXCODE = tk.EXCODE,
            EXNAME = tk.EXCODENavigation.EXNAME,
            PRICE = tk.PRICE,
            IDPRICE = tk.IDPRICE,
            SPECIAL = tk.SPECIAL,
            USERCODE = tk.USERCODE,
            USERDATE = tk.USERDATE,
        };
    }
}
