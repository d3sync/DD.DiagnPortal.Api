using DD.Shared.DTOs;
using DD.Shared.Models;

namespace DiagnPortal.API.Patient
{
    public class PatvisitDetailDTO
    {
        public Pat1fileDTO? Pat1file => Patvisits.Any() ? Patvisits.First().Pat1file : null;
        public IEnumerable<PatvisitDTO> Patvisits { get; set; }
        public List<PatexetResult>? Patexes { get; set; }
    }
}
