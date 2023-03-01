using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLTWNCBuoi3.Controllers
{
    public class LienHeController : Controller
    {
        // GET: LienHe
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KetQua(string chude, string title, string noidung, string hovaten, string email, string sdt)
        {
            ViewBag.kq = "Chủ đề: " + chude
                            + ",\t Tiêu đề: " + title
                            + ",\t Nội dung: " + noidung
                            + ",\t Họ và tên: " + hovaten
                            + ",\t Email: " + email
                            + ",\t Số điện thoại: " + sdt;
            return View();
        }
    }
}