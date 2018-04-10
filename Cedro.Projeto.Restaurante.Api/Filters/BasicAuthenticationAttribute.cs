using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Cedro.Projeto.Restaurante.Api.Filters
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {

            string hash = ConfigurationManager.AppSettings["HashValidacao"];

            try
            {

                if (actionContext.Request.Headers.Authorization == null)
                {

                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, HttpStatusCode.Unauthorized.ToString());
                }
                else
                {
                    string hashValue = actionContext.Request.Headers.Authorization.ToString().Replace(" ", "").Replace("Basic", "");

                    if (hashValue != hash)
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, HttpStatusCode.Unauthorized.ToString());
                    }
                }

                base.OnAuthorization(actionContext);
            }
            catch (Exception ex)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString());
            }
            finally
            {
            }
        }
    }
}