using System;
using System.Web.Mvc;

using reg_claim4.Models;
using reg_claim4.Controllers;

namespace reg_claim4.filters
{
    public  class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            logs log = new logs()
            {
                dataTime = DateTime.Now,
                events = "зашел на эту страницу",
                UserName = "fff",
                pc_ip = PC.GetIPAddress(),
                pc_name = System.Net.Dns.GetHostName(),
                Url = request.RawUrl
            };

            using (userdbContext db = new userdbContext())
            {
                db.logs.Add(log);
                db.SaveChanges();
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
