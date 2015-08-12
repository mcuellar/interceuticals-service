﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;
using System.Net;
using System.Diagnostics;

namespace InterceuticalsService.Extenders
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Debug.WriteLine("Request Type: " + actionContext.Request.Method.Method.ToString());

            // Only check Model State if Request is a POST
            if(actionContext.Request.Method.Method.ToString() == "POST")
            {
                if (actionContext.ModelState.IsValid == false) 
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(
                        HttpStatusCode.BadRequest, actionContext.ModelState);
                }

            }

        }
    }
}