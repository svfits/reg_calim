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
        userdbContext db = new userdbContext();
        public ActionResult Index()
        {
            var value = Session["logNotLog"];
            if (value == null)
            {
                Session["logNotLog"] = "true";                
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

        public ActionResult fromUser()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult onUser()
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
          
            ViewBag.Message = "Если у Вас не правильно отображается ФИО  ";

            AD.getUser(User.Identity.Name, out Name, out Surname, out SecondName);
            AD.getGrups("afanasievdv", "SCSM Группа поддержки пользователей");               

            ViewBag.Name = Name;
            ViewBag.Surname = Surname;
            ViewBag.SecondName = SecondName;
            ViewBag.Text = Request.UserHostName + "  444 " + PC.GetIPAddress();
            AD.FromADtoBD();

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
            IEnumerable<logs> log = db.logs;
            ViewBag.Message = log;
            return View();
        }

        [HttpGet]
        public ActionResult AddClaim()
        {
           // ViewBag.ClaimId = id;
            return View();
        }
        [HttpPost]
        public string AddClaim(string UserNameFrom, string UserNameWhom,string GroupWhom,string evants,string ClaimeName,string parents,string category, string claimBody)
        {        

            try
            {
                db.ClaimeName.Add(new claim()
                {
                    UserNameFrom = User.Identity.Name,
                    ClaimeName = "Заявка",
                    UserNameWhom = "",
                    claimBody = claimBody,
                    dataTimeOpen = DateTime.Now,
                    dataTimeEnd = DateTime.Now,
                    evants = evants,
                    parents = parents,
                    category = category
                });
              
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            
            return "Ваша Заявка Зарегистрирована" ;
        }
    }
}