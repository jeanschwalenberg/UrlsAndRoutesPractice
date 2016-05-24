using System.Web.Mvc;
using System.Web.Routing;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes {
    public class RouteConfig {

        public static void RegisterRoutes(RouteCollection routes) {
            routes.MapMvcAttributeRoutes();

            routes.Add(new Route("SayHello", new CustomRouteHandler()));

            routes.Add(new LegacyRoute(
                    "~/articles/Windows_3_1_Overview_html",
                    "~/old/_NET_1_0_Class_Library"));

            routes.MapRoute("MyRoute", "{controller}/{action}");
            routes.MapRoute("MyOtherRoute", "App/{action}", new { controller = "Home" });

            /*  OLD ROUTES
            //constraint in Chrome
            routes.MapRoute("ChromeRoute", "{*catchall}",
                new { controller = "Home", action = "Index" },
                new { customConstraint = new UserAgentConstraint("Chrome") },
                new[] { "UrlsAndRoutes.AdditionalControllers" });
            
            routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new {
                    controller = "^H.*", action = "Index|About",
                    httpMethod = new HttpMethodConstraint("GET"),
                    id = new CompoundRouteConstraint(new IRouteConstraint[] {
                         new AlphaRouteConstraint(),
                         //new MinLengthRouteConstraint(6)
                    })
                },
                new[] { "UrlsAndRoutes.Controllers" });

            /*
            //constrained by HTTP method
            routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new {
                    controller = "^H.*", action = "Index|About",
                    httpMethod = new HttpMethodConstraint("GET")
                },
                new[] { "UrlsAndRoutes.Controllers" });
            */

            /*
            //constraining a route to a specific set of vallues
            routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new { controller = "^H.*", action = "^Index$|^About$" },
                new[] { "UrlsAndRoutes.Controllers" });
            */

            /*
            //constraining routes using a regular expression [for first letter "H"]
            routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new { controller = "^H.*" },
                new[] { "UrlsAndRoutes.Controllers" });
            */

            /*
            //disabling namespace fallbacks

            Route myRoute = routes.MapRoute("AddControllerRoute", 
                    "Home/{action}/{id}/{*catchall}",
                new { controller = "Home", action = "Index",
                    id = UrlParameter.Optional },
                new[] { "UrlsAndRoutes.AdditionalControllers" });

            myRoute.DataTokens["UseNamespaceFallback"] = false;
            */
        }
    }
}
