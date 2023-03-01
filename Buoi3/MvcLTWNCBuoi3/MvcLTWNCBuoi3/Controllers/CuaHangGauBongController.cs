using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLTWNCBuoi3.Controllers
{
    public class CuaHangGauBongController : Controller
    {
        // GET: CuaHangGauBong
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DanhSachSanPham()
        {
            return View();
        }

        public ActionResult SanPhamGauBong()
        {
            return View();
        }
    }
}