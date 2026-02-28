namespace FinanceTracker.Api.Common.Extensions
{
    using System;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Mvc;
    using FinanceTracker.Api.Common.Models;
    using FinanceTracker.Api.Common.Responses;

    public static class ControllerBaseExtensions
    {
        public static IActionResult CreateResponse<T>(this ControllerBase controller, T value)
            where T : WebResponse
        {
            var result = controller.StatusCode((int)value.StatusCode, value);
            return result;
        }

        public static UserWebModel GetCurrentUser(this ControllerBase controller)
        {
            var result = new UserWebModel();
            var user = controller.User;

            if (controller.User != default(ClaimsPrincipal) && user.HasClaim(c => c.Type == ClaimTypes.NameIdentifier))
            {
                result.UserId = new Guid(user.FindFirstValue(ClaimTypes.NameIdentifier));
                result.FirstName = user.FindFirstValue(ClaimTypes.GivenName);
                result.LastName = user.FindFirstValue(ClaimTypes.Surname);
                result.UserName = user.FindFirstValue(ClaimTypes.Name);
                result.Email = user.FindFirstValue(ClaimTypes.Email);
                result.RoleName = user.FindFirstValue(ClaimTypes.Role);
            }

            return result;
        }
    }
}
