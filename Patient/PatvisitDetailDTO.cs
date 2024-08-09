using DD.Shared.DTOs;
using DD.Shared.Models;

namespace DiagnPortal.API.Patient
{
    public class PatvisitDetailDTO
    {
        public Pat1fileDTO? Pat1file
        {
            get;
            set;
        }
        public IEnumerable<PatvisitDTO> Patvisits { get; set; }
        public ExaminationDisplayModel? Patexes { get; set; }
    }
}
