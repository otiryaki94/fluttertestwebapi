using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace FlutterTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public JsonResult KullaniciListesi()
        {
            using (flutter_model Context = new flutter_model())
            {
                var kullaniciList = Context.Kullanici.ToList();

                JavaScriptSerializer js = new JavaScriptSerializer();
                string jsonData = js.Serialize(kullaniciList);

                return Json(kullaniciList, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult KullaniciKayit(KullaniciDTO kullanici)
        {
            using (flutter_model Context = new flutter_model())
            {
                Kullanici kullaniciModel = new Kullanici();
                kullaniciModel.Ad = kullanici.Ad;
                kullaniciModel.Soyad = kullanici.Soyad;
                kullaniciModel.Telefon = kullanici.Telefon;
                kullaniciModel.Ulke = kullanici.Ulke;
                kullaniciModel.Sehir = kullanici.Sehir;
                kullaniciModel.SilindiMi = false;

                Context.Entry(kullaniciModel);
                Context.SaveChanges();

                return Json(true, JsonRequestBehavior.AllowGet);
            }

        }
    }
}
