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
        
        [HttpPost]
        public  ActionResult WhomUserClaimFromAD(string letters)
        {
            userdbContext db = new userdbContext();
           
            try
            {
                var user = db.Ad_users
                    .Where(c => c.UserName.StartsWith(letters))
                    .AsEnumerable()                    
                    .Take(10)
                    .ToList();

              foreach(var item in user)
                {
                  //  System.Diagnostics.Debug.WriteLine(item.Email.ToString());
                    System.Diagnostics.Debug.WriteLine(item.UserName.ToString());
                  //  System.Diagnostics.Debug.WriteLine(item.DisplayName.ToString());
                }            
              
                //System.Diagnostics.Debug.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                
                if (user.Count<=0)
                {
                  System.Diagnostics.Debug.WriteLine("не найден пользователь!!!!!!!!!!!!!!!!!!!");
                    user = db.Ad_users
                   .Where(c => c.DisplayName.StartsWith(letters))
                   .AsEnumerable()
                   .Take(10)
                   .ToList();
                    
                    foreach (var item in user)
                    {
                       // System.Diagnostics.Debug.WriteLine(item.Email.ToString());
                       // System.Diagnostics.Debug.WriteLine(item.UserName.ToString());
                        System.Diagnostics.Debug.WriteLine(item.DisplayName.ToString());
                    }

                 return   PartialView(User);
                }
                else
                {
                    return PartialView(User);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                System.Diagnostics.Debug.WriteLine("ошибка пользователь не найден ");
                return HttpNotFound();
            }
            return PartialView(User);
        }
      
    }
}