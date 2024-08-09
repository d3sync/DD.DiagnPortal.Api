using DD.Shared.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DiagnPortal.API.Patient;

public class PatvisitDTO
{
    public virtual Pat1fileDTO? Pat1file { get; set; } 
    public long PATCODE { get; set; }

    [Column(TypeName = "datetime")] public DateTime PATDATE { get; set; }

    [Column(TypeName = "datetime")] public DateTime PATTIME { get; set; }

    public short? PATASFAL { get; set; }

    [StringLength(15)] public string ASFALAM { get; set; }

    public int? ROWTAM { get; set; }

    public int? CNCODE { get; set; }

    public int? PARAP1 { get; set; }

    public int? PARAP2 { get; set; }

    public short? USERCODE { get; set; }

    public short? PATASFAL2 { get; set; }

    public bool? ForeignPat { get; set; }

    public bool? FOREIGNRESPRINT { get; set; }

    public string EXTRAEMAILS { get; set; }

}