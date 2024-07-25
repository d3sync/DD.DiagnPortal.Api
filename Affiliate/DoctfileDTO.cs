using DD.Shared.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DiagnPortal.API.Affiliate
{
    public class DoctfileDTO
{
    [Key]
    public int DCODE { get; set; }

    [StringLength(25)]
    public string? DLAST { get; set; }

    [StringLength(15)]
    public string? DFIRST { get; set; }

    [StringLength(254)]
    public string? DRSLTNAME { get; set; }

    [StringLength(1)]
    public string? DSEX { get; set; }

    [StringLength(30)]
    public string? DADDR { get; set; }

    [StringLength(20)]
    public string? DTOWN { get; set; }

    [StringLength(30)]
    public string? DNOMOS { get; set; }

    public int? DZIP { get; set; }

    [StringLength(20)]
    public string? DAREA { get; set; }

    [StringLength(25)]
    public string? DPHONE1 { get; set; }

    [StringLength(25)]
    public string? DPHONE2 { get; set; }

    [StringLength(25)]
    public string? DPHONE3 { get; set; }

    public long? DFAX { get; set; }

    [StringLength(100)]
    public string? DEMAIL { get; set; }

    [StringLength(40)]
    public string? DPROFF { get; set; }

    [StringLength(10)]
    public string? DAFM { get; set; }

    [StringLength(20)]
    public string? DDOY { get; set; }

    public bool? DPARAP { get; set; }

    public bool? DDIAGN { get; set; }

    public bool? DTHERAP { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DDATE { get; set; }

    [StringLength(10)]
    public string? DUSER1 { get; set; }

    public short? DUSER { get; set; }

    public bool? OLD { get; set; }

    public int? TSAYNUM { get; set; }

    /// <summary>
    /// HΜΕΡΟΜΗΝΙΑ ΕΝΗΜΕΡΩΣΗΣ
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime? USERDATE { get; set; }


    [StringLength(20)]
    public string? AMKA { get; set; }

    public int? DOCKINDID { get; set; }

    [StringLength(200)]
    public string? SIGNATURE { get; set; }

    public byte[]? SIGNATUREFILE { get; set; }

    public bool? EMAIL_LOCK { get; set; }

}
}
