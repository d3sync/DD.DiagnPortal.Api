using DD.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DD.Shared.Attributes;
using DD.Shared.Enums;

namespace DiagnPortal.API.Patient;

public class Pat1fileDTO
{
    public long PATCODE { get; set; }

    [StringLength(25)]
    [Censor(Policy.CanViewName)]
    public string PATLAST { get; set; }

    [StringLength(15)]
    [Censor(Policy.CanViewName)]
    public string PATFIRST { get; set; }

    [StringLength(30)]
    [Censor(Policy.CanViewName)]
    public string PATLATIN { get; set; }

    [Column(TypeName = "datetime")]
    [Censor(Policy.CanViewCharacteristics)]
    public DateTime? PATBIRTH { get; set; }

    [StringLength(1)]
    [Censor(Policy.CanViewCharacteristics)]
    public string PATSEX { get; set; }

    [StringLength(100)]
    [Censor(Policy.CanViewName)]
    public string PATPROFF { get; set; }

    [StringLength(30)]
    [Censor(Policy.CanViewAddress)]
    public string PATADDR { get; set; }

    [StringLength(5)]
    [Censor(Policy.CanViewAddress)]
    public string PATZIP { get; set; }

    [StringLength(50)]
    [Censor(Policy.CanViewAddress)]
    public string PATTOWN { get; set; }

    [StringLength(35)]
    [Censor(Policy.CanViewContact)]
    public string PATPHON { get; set; }
    [Censor(Policy.CanViewContact)]
    public int? PATFAX { get; set; }

    [StringLength(100)]
    [Censor(Policy.CanViewContact)]
    public string PATEMAIL { get; set; }

    [Censor(Policy.CanViewCharacteristics)]
    public bool? PATCIGAR { get; set; }

    [StringLength(20)]
    [Censor(Policy.CanViewCharacteristics)]
    public string CIGARNUM { get; set; }

    [StringLength(15)]
    [Censor(Policy.CanViewCharacteristics)]
    public string PATFKIND { get; set; }
    [Censor(Policy.CanViewCharacteristics)]
    public string PATOPER { get; set; }
    [Censor(Policy.CanViewCharacteristics)]
    public string PATSICK { get; set; }
    [Censor(Policy.CanViewCharacteristics)]
    public string PATINHER { get; set; }
    [Censor(Policy.CanViewCharacteristics)]
    public string PATATHL { get; set; }

    public short? PATEKPT { get; set; }

    public bool? SENSENT { get; set; }
    [Censor(Policy.CanViewCharacteristics)]
    public string PATALLERGY { get; set; }
    [Censor(Policy.CanViewCharacteristics)]
    public short? PATANAEMIAID { get; set; }
[Censor(Policy.CanViewCharacteristics)]
    public short? PATDISEASEID { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    [Censor(Policy.CanViewCharacteristics)]
    public string PATBLTYPE { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string PATRHES { get; set; }
    [Censor(Policy.CanViewName)]
    public int? DOYCODE { get; set; }

    public bool? WEB { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WEBDATE { get; set; }

    [StringLength(10)]
    public string WEBPASS { get; set; }

    [StringLength(20)]
    [Censor(Policy.CanViewName)]
    public string AMKA { get; set; }
    [Censor(Policy.CanViewAddress)]
    public int? TOWNCODE { get; set; }

    [StringLength(2)]
    [Censor(Policy.CanViewAddress)]
    public string CTRCODE { get; set; }

    [StringLength(2)]
    [Censor(Policy.CanViewAddress)]
    public string CTRCODE_ST { get; set; }

    [StringLength(10)]
    public string PATPASS { get; set; }

    [StringLength(14)]
    [Censor(Policy.CanViewContact)]
    public string PATMOBILE { get; set; }

    [StringLength(4)]
    [Censor(Policy.CanViewName)]
    public string PROFFCODE { get; set; }

    public int? TAMCODE1 { get; set; }

    public int? TAMCODE2 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LASTHISTDT { get; set; }

    public short? TAMCODE { get; set; }

    [StringLength(50)]
    [Censor(Policy.CanViewName)]
    public string PATLAST_FULL { get; set; }

    [StringLength(50)]
    [Censor(Policy.CanViewName)]
    public string PATFIRST_FULL { get; set; }

    public bool? ForeignPat { get; set; }

    //[InverseProperty("PATCODENavigation")]
    //public virtual ICollection<PATVISIT> PATVISIT { get; set; } = new List<PATVISIT>();
}