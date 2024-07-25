using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace DiagnPortal.API.Patient
{
    public class PatientHelper
    {
        public static IActionResult GetPatientCode(ClaimsPrincipal user, out long patCode)
        {
            patCode = 0;
            var claim = user.Claims.FirstOrDefault(c => c.Type == "PATCODE");

            if (claim == null)
            {
                return new NotFoundObjectResult(new { status = "failure", message = "Claim missing" });
            }

            if (!long.TryParse(claim.Value, out patCode))
            {
                return new BadRequestObjectResult(new { status = "failure", message = "Invalid claim data." });
            }

            return null; // No error
        }
        public static bool TryGetPatientCode(ClaimsPrincipal user, out long patCode)
        {
            patCode = 0;
            var claim = user.Claims.FirstOrDefault(c => c.Type == "PATCODE");
            if (claim == null)
            {
                return false;
            }

            if (!long.TryParse(claim.Value, out patCode))
            {
                return false;
            }

            return true;
        }
    }
}
