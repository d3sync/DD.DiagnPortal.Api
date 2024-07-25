using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace DiagnPortal.API.Affiliate
{
    public static class AffiliateHelper
    {
        public static IActionResult GetParapCode(ClaimsPrincipal user, out int dcode)
        {
            dcode = 0;
            var claim = user.Claims.FirstOrDefault(c => c.Type == "DCODE");

            if (claim == null)
            {
                return new NotFoundObjectResult(new { status = "failure", message = "Claim missing" });
            }

            if (!int.TryParse(claim.Value, out dcode))
            {
                return new BadRequestObjectResult(new { status = "failure", message = "Invalid claim data." });
            }

            return null; // No error
        }
        public static IActionResult GetTamCode(ClaimsPrincipal user, out short tamCode)
        {
            tamCode = 0;
            var claim = user.Claims.FirstOrDefault(c => c.Type == "TAMCODE");

            if (claim == null)
            {
                return new NotFoundObjectResult(new { status = "failure", message = "Claim missing" });
            }

            if (!short.TryParse(claim.Value, out tamCode))
            {
                return new BadRequestObjectResult(new { status = "failure", message = "Invalid claim data." });
            }

            return null; // No error
        }

        public static bool TryGetTamCode(ClaimsPrincipal user, out short affiliateCode)
        {
            affiliateCode = 0;
            var claim = user.Claims.FirstOrDefault(c => c.Type == "TAMCODE");
            if (claim == null)
            {
                return false;
            }

            if (!short.TryParse(claim.Value, out affiliateCode))
            {
                return false;
            }

            return true;
        }
        public static bool TryGetParapCode(ClaimsPrincipal user, out int dcode)
        {
            dcode = 0;
            var claim = user.Claims.FirstOrDefault(c => c.Type == "DCODE");
            if (claim == null)
            {
                return false;
            }

            if (!int.TryParse(claim.Value, out dcode))
            {
                return false;
            }

            return true;
        }
    }
}
