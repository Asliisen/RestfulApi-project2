using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace week2_assignment
{
    // Attribute class used for customized authorization.
    public class CustomAuthorizeAttribute : TypeFilterAttribute
    {
        // Enables the use of this attribute with a specific role requirement.
        public CustomAuthorizeAttribute(string role) : base(typeof(CustomAuthorizeFilter))
        {
            Arguments = new object[] { role };
        }
    }
}
