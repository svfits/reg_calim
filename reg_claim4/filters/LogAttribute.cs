using System;
using System.Web.Mvc;

using reg_claim4.Models;
using reg_claim4.Controllers;

namespace reg_claim4.filters
{
    public  class LogAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// фильтр логов кто куда ходил и когда
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            userdbContext db = new userdbContext();
            var request = filterContext.HttpContext.Request;
            //logs log = new logs()
            //{
            //    dataTime = DateTime.Now,
            //    events = "зашел на эту страницу",
            //    UserName = "fff",
            //    pc_ip = PC.GetIPAddress(),
            //    pc_name = System.Net.Dns.GetHostName(),
            //    Url = request.RawUrl
            //};

            //using (userdbContext db = new userdbContext())
            //{
            //    db.logs.Add(log);
            //    db.SaveChanges();
            //}
          
                try
                {
                    db.logs.Add(new logs()
                    {
                        dataTime = DateTime.Now,
                        events = "зашел на эту страницу",
                        UserName = (request.IsAuthenticated) ? filterContext.HttpContext.User.Identity.Name : "null",
                        pc_ip = PC.GetIPAddress(),
                        pc_name = System.Net.Dns.GetHostName(),
                        Url = request.RawUrl
                    });
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
            }
           
        }
    }

