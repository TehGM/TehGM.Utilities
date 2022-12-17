using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace TehGM.Utilities.AspNetCore.Routing.Constraints
{
    /// <summary>Constrains a route parameter to represent only 16-bit integer values.</summary>
    public class ShortRouteConstraint : IRouteConstraint
    {
        /// <inheritdoc/>
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.TryGetValue(routeKey, out object routeValue))
                return false;

            return short.TryParse(routeValue.ToString(), out _);
        }
    }
}
