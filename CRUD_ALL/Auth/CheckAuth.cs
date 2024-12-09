using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_ALL.Auth
{
    public class CheckAuth : ActionFilterAttribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (string.IsNullOrEmpty(context.HttpContext.Session.GetString("Emp_ID")))
            {
                context.HttpContext.Session.Clear();
                context.Result = new RedirectResult("~/Employee/Login");
            }
        }


        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            filterContext.HttpContext.Response.Headers["Expires"] = "-1";
            filterContext.HttpContext.Response.Headers["Pragma"] = "no-cache";
            base.OnResultExecuting(filterContext);
        }
    }
}
