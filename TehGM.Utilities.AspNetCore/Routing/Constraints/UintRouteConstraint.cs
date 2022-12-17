using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace TehGM.Utilities.AspNetCore.Routing.Constraints
{
    /// <summary>Constrains a route parameter to represent only unsigned 32-bit integer values.</summary>
    public class UintRouteConstraint : IRouteConstraint
    {
        /// <inheritdoc/>
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.TryGetValue(routeKey, out object routeValue))
                return false;

            return uint.TryParse(routeValue.ToString(), out _);
        }
    }
}
