using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test1.Models;


namespace Test1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        Database1Entities db = new Database1Entities();
        public ActionResult Index()
        {
            BaiHatList strBH = new BaiHatList();
            List<BaiHat> obj = strBH.getBaiHat(string.Empty);
            return View(obj);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(BaiHat strBH)
        {
            if (ModelState.IsValid)
            {

                BaiHatList BH = new BaiHatList();
                BH.ADDBH(strBH);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(string id = "")
        {
            BaiHatList BH = new BaiHatList();
            List<BaiHat> obj = BH.getBaiHat(id);
            return View(obj.FirstOrDefault());
        }
        [HttpPost]

        public ActionResult Edit(BaiHat strBH)
        {
            BaiHatList BH = new BaiHatList();
            BH.EDITBH(strBH);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id = "")
        {
            BaiHatList BH = new BaiHatList();
            List<BaiHat> obj = BH.getBaiHat(id);
            return View(obj.FirstOrDefault());
        }
        [HttpPost]

        public ActionResult Delete(BaiHat strBH)
        {
            BaiHatList BH = new BaiHatList();
            BH.DeleteBH(strBH);
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id = "")
        {
            BaiHatList BH = new BaiHatList();
            List<BaiHat> obj = BH.getBaiHat(id);
            return View(obj.FirstOrDefault());
        }
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Signup(Taikhoan tk)
        {
            if (db.Taikhoan.Any(x => x.UserNameUS == tk.UserNameUS))
            {
                ViewBag.Notification = "Tài khoản đã tồn tại!";
                return View();
            }
            else
            {
                db.Taikhoan.Add(tk);
                db.SaveChanges();

                Session["IdUS"] = tk.Id.ToString();
                Session["UserNameUSS"] = tk.UserNameUS.ToString();
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(Taikhoan tk)
        {
            var checkLogin = db.Taikhoan.Where(x => x.UserNameUS.Equals(tk.UserNameUS) && x.Password.Equals(tk.Password)).FirstOrDefault();
            if (checkLogin != null)
            {
                Session["IdUS"] = tk.Id.ToString();
                Session["UserNameUSS"] = tk.UserNameUS.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Sai tên tài khoản hoặc mật khẩu!";
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }

    }
}