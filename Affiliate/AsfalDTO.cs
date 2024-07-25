using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DiagnPortal.API.Affiliate
{
    public class AsfalDTO
    {
        [Key]
    public short TAMCODE { get; set; }

    [StringLength(50)]
    public string TAMNAME { get; set; }

    [StringLength(50)]
    public string TAMADDR { get; set; }

    [StringLength(15)]
    public string TAMPROF { get; set; }

    [StringLength(35)]
    public string TAMTEL { get; set; }

    [StringLength(20)]
    public string TAMAFM { get; set; }

    [StringLength(15)]
    public string TAMDOY { get; set; }

    /// <summary>
    /// 1=ΑΣΦ.ΦΟΡΕΑΣ 2=ΕΤΑΙΡΕΙΑ
    /// </summary>
    public short? TAMKAT { get; set; }

    public bool? TAMENERG { get; set; }

    public short? USERCODE { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? USERDATE { get; set; }

    public byte? CLKAT { get; set; }

    public bool? ABROAD { get; set; }

    public int? DOYCODE { get; set; }

    public bool? WEB { get; set; }

    [StringLength(100)]
    public string TAMEMAIL { get; set; }

    [StringLength(10)]
    public string TAMZIP { get; set; }

    [StringLength(50)]
    public string TAMTOWN { get; set; }

    public int? TAMCTRID { get; set; }
    
    public int? DCODE { get; set; }

    [StringLength(100)]
    public string TAMALTERNAME { get; set; }

    public bool? EMAIL_LOCK { get; set; }

    
    }
}
