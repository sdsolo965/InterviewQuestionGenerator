using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace InterviewQuestionGenerator
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "ApiGetByAction",
                "api/{controller}/{action}",
                new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                "ApiGetByActionAndId",
                "api/{controller}/{action}/{id}",
                new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                "ApiUpdateSelectedStudent",
                "api/{controller}/{action}/{id}/{isSelected}",
                new { id = RouteParameter.Optional, isSelected = RouteParameter.Optional }
            );
        }
    }
}
