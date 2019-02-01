using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabysitterKata.App.Filters
{
    public class ValidateModelStateActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if(!filterContext.ModelState.IsValid)
            {
                if(filterContext.HttpContext.Request.Method is "GET")
                {
                    var result = new BadRequestResult();

                    filterContext.Result = result;
                }
                else
                {
                    var serializerSettings = new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    };

                    var content = JsonConvert.SerializeObject(filterContext.ModelState, serializerSettings);

                    var result = new ContentResult()
                    {
                        Content = content,
                        ContentType = "application/json"
                    };

                    filterContext.HttpContext.Response.StatusCode = 400;

                    filterContext.Result = result;
                }
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
    }
}
