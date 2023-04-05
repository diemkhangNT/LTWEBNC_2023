using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoWeb.Models;

namespace DemoWeb.Controllers
{
    public class UsersController : Controller
    {
        private DBSportStoreEntities db = new DBSportStoreEntities();
        // GET: Users
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Customer cust)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(cust.NameCus))
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập không được để trống");
            if (string.IsNullOrEmpty(cust.PassCus))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
            if (string.IsNullOrEmpty(cust.EmailCus))
                    ModelState.AddModelError(string.Empty, "Email không được để trống");
            if (string.IsNullOrEmpty(cust.PhoneCus))
                    ModelState.AddModelError(string.Empty, "Điện thoại không được để trống");
                    
//Kiểm tra xem có người nào đã đăng kí với tên đăng nhập này hay chưa
                    var khachhang = db.Customers.FirstOrDefault(k =>
                    k.NameCus == cust.NameCus);
                if (khachhang != null)
                    ModelState.AddModelError(string.Empty, "Đã có người  đăng kí tên này");
            if (ModelState.IsValid)
                {
                    db.Customers.Add(cust);
                    db.SaveChanges();

                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer cust)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(cust.NameCus))
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập không được để trống");
                if (string.IsNullOrEmpty(cust.PassCus))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (ModelState.IsValid)
                {
                    var khachhang = db.Customers.FirstOrDefault(k => k.NameCus == cust.NameCus && cust.PassCus == k.PassCus);
                    if(khachhang != null)
                    {
                        ViewBag.ThonBao = "Chúc mừng đăng nhập thành công!";
                        Session["TaiKhoan"] = khachhang;
                        return RedirectToAction("TrangChu", "Home");
                    }
                    else
                    {
                        ViewBag.ThonBao = "Tên đăng nhập hoặc mật khẩu không đúng!";
                    }
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            TempData["logout"] = "Đăng xuất thành công!";
            Session["TaiKhoan"] = null;
            return RedirectToAction("TrangChu", "Home");
        }
    }
}