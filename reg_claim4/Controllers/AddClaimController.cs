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
       
        /// <summary>
        /// для заведения Заявок вывод запросов из БД во время заведения
        /// </summary>              

        public  ActionResult WhomUserClaimFromAD(string term)
        {
            using (userdbContext db = new userdbContext())
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

                var groupName = db.Ad_users
                    .Where(c => c.group.Contains(term))
                    .Select(c => c.group)
                    .AsEnumerable()
                    .Distinct()
                    .Take(10)
                    .ToList();

                if (groupName.Count > 0)
                {
                    return Json(groupName, JsonRequestBehavior.AllowGet);
                }
            }           
            return Json("пользователь не найден", JsonRequestBehavior.AllowGet);
            
        }

        //выборка названия заявок заявок и времени закрытия 

        public ActionResult ClaimeName(string term)
        {
            //return Json("тип заявки не найден", JsonRequestBehavior.AllowGet);
            using (userdbContext db = new userdbContext())
            {
                var ClaimName = db.ClaimeName
                    .Where(c => c.claimName.Contains(term))
                    .Select(c => c.claimName)
                    .AsEnumerable()
                    .Distinct()
                    .Take(10)
                    .ToList();

                if (ClaimName.Count > 0)
                {
                    System.Diagnostics.Debug.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>       " + ClaimName.Count);
                    return Json(ClaimName, JsonRequestBehavior.AllowGet);
                }

                return Json("тип заявки не найден", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult DataTimeEnd(string date_end)
        {
            //  dataTimeEnd = "fffff";
            System.Diagnostics.Debug.WriteLine("aaaaaaaaaa     " + date_end);
            using (userdbContext db = new userdbContext())
            {
                var dataTimeEn = db.ClaimeName
                    .Where(c => c.claimName == date_end)
                    .Select(c => c.dataEndClaim)
                    .AsEnumerable()
                    .Distinct()
                    .Take(10)
                    .ToList();

                System.Diagnostics.Debug.WriteLine("rrrrrrrr   " + " " + dataTimeEn    + "   " + dataTimeEn);
                return Json(dataTimeEn, JsonRequestBehavior.AllowGet);
            }
          //  return Json("-------", JsonRequestBehavior.AllowGet);
        }   
    }
}