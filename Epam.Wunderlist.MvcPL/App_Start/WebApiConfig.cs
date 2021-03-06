﻿using System.Web.Http;

namespace Epam.Wunderlist.MvcPL
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "GetManyTodoTaskApi",
                routeTemplate: "api/todolists/{todoListId}/{controller}",
                defaults: new { todoListId = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "GetManyTodoSubtaskApi",
                routeTemplate: "api/todotask/{todoTaskId}/{controller}",
                defaults: new { todoTaskId = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultWithActionApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            

            
        }
    }
}
