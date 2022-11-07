using DERS.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DERS.Controllers
{
    public class Login : Controller
    {

       


        [HttpGet]
        public IActionResult GirisYap(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> GirisYap(Admin pers)
        {//Bir admin giriş değişkeni tanımlayıp Firstordefault methodu ile kullanıcının girmiş olduğu bilgiyle veritabanındakı adı karşılaştırdaktan sonra
         //if şartları arasına yapılacakları belirtiyoruz.  
            Context c = new Context();
            var admingiris = c.Admins.FirstOrDefault(x => x.Kullanici == pers.Kullanici && x.Sifre == pers.Sifre);
            if (admingiris != null)//eğer textler boş gelmez ise
            {
                var claims = new List<Claim> // claim ypaısı oluşuyor
                { new Claim(ClaimTypes.Name,admingiris.Kullanici),
                 new Claim(ClaimTypes.Role, admingiris.Sehir)
                };


                var useridentity = new ClaimsIdentity(claims, "Login");//identitiy tanımı yapıp loginden aldırıyoruz.
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);//burdaki principal sorgu alanım.
                                                                              //ve bu alandan loginden gelenleri sorguluyorum.
                await HttpContext.SignInAsync(principal);//await kullanıp işlem sıramı düzenledim.
               
                if (TempData["returnUrl"] != null)
                {
                    if (Url.IsLocalUrl(TempData["returnUrl"].ToString()))
                    {
                        return Redirect(TempData["returnUrl"].ToString());
                    }
                }
                else
                {
                    return RedirectToAction("Index","Home");
                }

            }
          
            return View();

        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "İstanbul")]
        public IActionResult Security()
        {
            //var value = "Hello admin";
            return View();
        }
    }
}
