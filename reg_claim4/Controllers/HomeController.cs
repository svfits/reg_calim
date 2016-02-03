using reg_claim4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace reg_claim4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var value = Session["logNotLog"];
            if (value == null)
            {
                Session["logNotLog"] = "true";
                userdbContext db = new userdbContext();
                try {
                    db.logs.Add(new logs()
                    {
                        dataTime = DateTime.Now,
                        events = "зашел на эту страницу",
                        UserName = User.Identity.Name,
                        pc_ip = PC.GetIPAddress(),
                        pc_name = System.Net.Dns.GetHostName()
                    });
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
            }
            else
            {
                Session["logNotLog"] = DateTime.Now;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Questions_To_Program()
        {
            ViewBag.Message = "Вопросы разработчикам.";

            return View();
        }

        public ActionResult My_Name_IS()
        {

            string Name;
            string Surname;
            string SecondName;

            userdbContext db = new userdbContext();
            ViewBag.Message = "Если у Вас не правильно отображается ФИО  ";

            AD.getUser(User.Identity.Name, out Name, out Surname, out SecondName);
            AD.getGrups("afanasievdv", "SCSM Группа поддержки пользователей");

            /* для заведения заявок
            try
            {
               
                // db.ClaimeName.Add(new claim()) { UserName = "test" , ClaimeName = "dfdsfd" , claimBody = "sdfsdfsdf" });
                db.ClaimeName.Add(new claim()
                {
                    UserNameFrom = User.Identity.Name,
                    ClaimeName = "Заявка",
                    claimBody = "тут тело завки",
                    dataTimeOpen = DateTime.Now,                    
                });
                db.logs.Add(new logs()
                {
                    dataTime = DateTime.Now,
                    events = "зашел на эту страницу",
                    UserName = User.Identity.Name,
                    pc_ip = PC.GetIPAddress(),
                    pc_name = System.Net.Dns.GetHostName()
                });
                db.SaveChanges();                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            */

            ViewBag.Name = Name;
            ViewBag.Surname = Surname;
            ViewBag.SecondName = SecondName;
            ViewBag.Text = Request.UserHostName + "  444 " + PC.GetIPAddress();

            try {
                var log = db.logs
                    .Where(c => c.UserName == User.Identity.Name)
                    .AsEnumerable()
                    .Reverse()
                    .Take(10)
                    .Reverse();

                ViewBag.LOGS = log;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            return View();
        }

       // logs db = new logs();

        public ActionResult ViewPage1()
        {
            userdbContext db = new userdbContext();                        
            IEnumerable<logs> log = db.logs;
            ViewBag.Message = log;
            return View();
        }
    }
}