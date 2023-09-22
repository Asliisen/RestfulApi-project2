using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using System;
 


namespace week2_assignment
{
    // Action filter class used for customized authorization
    public class CustomAuthorizeFilter : IAuthorizationFilter
    {
        private readonly string _role;

        public CustomAuthorizeFilter(string role)
        {
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;


            // If the user is not logged in, authorization is denied and HTTP 401 (Unauthorized) is returned.
            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            // If the specified role requirement is present and the user does not have this role, authorization is rejected and HTTP 403 (Forbidden) is returned.
            if (!string.IsNullOrEmpty(_role) && !user.IsInRole(_role))
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }
}
