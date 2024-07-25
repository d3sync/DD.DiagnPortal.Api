using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DD.Shared.Models;

namespace DiagnPortal.API.Affiliate
{
    public class TimokatDTO
    {
        public short TAMCODE { get; set; }
        public int ROWTAM { get; set; }
        public string EXCODE { get; set; }
        public string EXNAME { get; set; }
        public float? PRICE { get; set; }
        public float? IDPRICE { get; set; }
        public bool? SPECIAL { get; set; }
        public short? USERCODE { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? USERDATE { get; set; }
    }
}
