using reg_claim4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace reg_claim4.Controllers
{
    public  class AddClaimController : Controller
    {
        userdbContext db = new userdbContext();
        /// <summary>
        /// для заведения Заявок вывод запросов из БД во время заведения
        /// </summary>              

        public  ActionResult WhomUserClaimFromAD(string term)
        {              
                var DisplayName1 = db.Ad_users
                    .Where(c => c.DisplayName.StartsWith(term))
                    .Select(c => c.DisplayName)
                    .AsEnumerable()
                    .Distinct()
                    .Take(10)
                    .ToList();

                if (DisplayName1.Count > 0)
                {
                System.Diagnostics.Debug.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>       " + DisplayName1.Count);
                return Json(DisplayName1, JsonRequestBehavior.AllowGet);
                }
                
                var userName1 = db.Ad_users
                     .Where(c => c.UserName.StartsWith(term))
                        .Select(c => c.UserName)
                        .AsEnumerable()
                        .Distinct()
                        .Take(10)
                        .ToList();

                if (userName1.Count > 0)
                {
                    return Json(userName1, JsonRequestBehavior.AllowGet);
                }
                       
            return Json("пользователь не найден", JsonRequestBehavior.AllowGet);
            
        }
      
    }
}