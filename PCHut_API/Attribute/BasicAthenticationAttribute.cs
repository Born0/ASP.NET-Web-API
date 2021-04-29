using PCHut_API.Models;
using PCHut_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PCHut_API.Attribute
{
    public class BasicAthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
            if(actionContext.Request.Headers.Authorization==null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {

                //string encode = actionContext.Request.Headers.Authorization.Parameter;
                string encode = actionContext.Request.Headers.Authorization.ToString();
                string decode = Encoding.UTF8.GetString(Convert.FromBase64String(encode));
                string[] splitedText=decode.Split(new char[] {':'});

                string  userId = splitedText[0];
                string password = splitedText[1];
                /////////// This section is hardCoded        -------->   
                ///remove these lines to check authentication      
                //userId = 1;
                //password = "123";
                
                if (userId == "adm" && password=="12")
                {
                   Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userId), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                }
                ///////////////////    <---------------------------------------

                /// Remove Comment from bellow to check authentication Logically-------------------------->
                /// 
                /* CredentialRepository credentialRepository = new CredentialRepository();
                 Credential credential = credentialRepository.Get(userId);
                 if(credential.UserId==userId && credential.Password== password)
                 {
                     Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userId.ToString()), null);
                 }
                 else
                 {
                     actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                 }*/
                //////  <---------------------------------------
            }
        }
    }
}