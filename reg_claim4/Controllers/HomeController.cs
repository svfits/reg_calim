using reg_claim4.filters;
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
        [Log]
        public ActionResult Index()
        {
            //var value = Session["logNotLog"];
            //if (value == null)
            //{
            //    Session["logNotLog"] = "true";
            //    try
            //    {
            //        db.logs.Add(new logs()
            //        {
            //            dataTime = DateTime.Now,
            //            events = "зашел на эту страницу",
            //            UserName = User.Identity.Name,
            //            pc_ip = PC.GetIPAddress(),
            //            pc_name = System.Net.Dns.GetHostName()
            //        });
            //        db.SaveChanges();
            //    }
            //    catch (Exception ex)
            //    {
            //        System.Diagnostics.Debug.WriteLine(ex.ToString());
            //    }
            //}
            //else
            //{
            //    Session["logNotLog"] = DateTime.Now;
            //}
            return View();
        }

        [Log]
        public ActionResult fromUser()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Log]
        public ActionResult onUser()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Log]
        public ActionResult Questions_To_Program()
        {
            ViewBag.Message = "Вопросы разработчикам.";

            return View();
        }

        [Log]
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

           // AD.FromADtoBD();  //добавление пользователей в из АД
           // AddClaimController.WhomUserClaimFromAD("fffff");
           // AddClaimController.WhomUserClaimFromAD("Ковал");

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

        [Log]
        public ActionResult ViewPage1()
        {
            //db.ClaimeName.Add(new ClaimeName()
            //{
            //    claimName = "Сменить пароль студенту",
            //    dataEndClaim = 5
            //});
            //db.SaveChanges();
                                          
            IEnumerable<logs> log = db.logs
                .AsEnumerable()
                .Reverse()
                .Take(10)
                .Reverse();
            ViewBag.Message = log;
            return View();
        }

        [HttpGet]
        [Log]
        public ActionResult AddClaim()
        {
           // ViewBag.ClaimId = id;
            return View();
        }
        [HttpPost]
        [Log]
        public string AddClaim(string UserNameFrom, string UserNameWhom,string GroupWhom,string evants,string ClaimeName,string parents,string category, string claimBody)
        {           
            try
            {
                db.claim.Add(new claim()
                {
                    UserNameFrom = User.Identity.Name,
                    ClaimeName = ClaimeName,
                    UserNameWhom = UserNameWhom,
                    claimBody = claimBody,
                    dataTimeOpen = DateTime.Now,
                    dataTimeEnd = DateTime.Now.AddMinutes(5),
                    evants = "заявка создана",
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