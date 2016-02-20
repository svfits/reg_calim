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
                var user = db.Ad_users;

                var userName = user
                        .Where(c => c.UserName.StartsWith(term))
                        .Select(c => c.UserName)
                        .AsEnumerable()
                        .Distinct()
                        .Take(10)
                        .ToList();

                if (userName.Count >= 0)
                {
                    return Json(userName, JsonRequestBehavior.AllowGet);
                }

                //foreach (var item in user)
                //{
                //    // System.Diagnostics.Debug.WriteLine(item.Email.ToString());
                //    // System.Diagnostics.Debug.WriteLine(item.UserName.ToString());
                //    System.Diagnostics.Debug.WriteLine(item.DisplayName.ToString());
                //}

                var user2 = db.Ad_users;

                var DisplayName = user2
                      .Where(c => c.DisplayName.StartsWith(term))
                      .Select(c => c.DisplayName)
                      .AsEnumerable()
                      .Distinct()
                      .Take(10)
                      .ToList();

                if (DisplayName.Count >= 0)
                {
                    return Json(DisplayName, JsonRequestBehavior.AllowGet);
                }
                return Json("пользователь не найден", JsonRequestBehavior.AllowGet);
            }

            //    try
            //    {
            //        //var user = db.Ad_users
            //    .Where(c => c.UserName.StartsWith(term))
            //    .Select(c => c.UserName)
            //    .AsEnumerable()
            //    .Distinct()
            //    .Take(10)
            //    .ToList();

           

            //System.Diagnostics.Debug.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

            //if (user.Count <= 0)
            //{
            //    //System.Diagnostics.Debug.WriteLine("не найден пользователь!!!!!!!!!!!!!!!!!!!");
            //    //  user = db.Ad_users
            // .Where(c => c.DisplayName.StartsWith(term))
            // .AsEnumerable()
            // .Take(10)
            // .ToList();

            //  foreach (var item in user)
            //  {
            //     // System.Diagnostics.Debug.WriteLine(item.Email.ToString());
            //     // System.Diagnostics.Debug.WriteLine(item.UserName.ToString());
            //      System.Diagnostics.Debug.WriteLine(item.DisplayName.ToString());


            //  }

            //        return Json(user, JsonRequestBehavior.AllowGet);
            //    }
            //    else
            //    {
            //        return Json(user, JsonRequestBehavior.AllowGet);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine(ex.ToString());
            //    System.Diagnostics.Debug.WriteLine("ошибка пользователь не найден ");
            //    return Json("что то пошло не так тут", JsonRequestBehavior.AllowGet);
            //}

        }
      
    }
}