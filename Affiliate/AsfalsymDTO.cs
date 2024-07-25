using DD.Shared.Models;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DiagnPortal.API.Affiliate
{
public class AsfalsymDTO
{
    public short TAMCODE { get; set; }

    public int ROWTAM { get; set; }

    [StringLength(20)]
    public string SYMNAME { get; set; }

    public bool? ENERG { get; set; }

    public short? RELATION { get; set; }

    public short? USERCODE { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? USERDATE { get; set; }

    public bool? SENDRESEMAIL { get; set; }

    [StringLength(60)]
    public string SYMEMAIL { get; set; }

}
}
