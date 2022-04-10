using PagedList;
using shopxemay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopxemay.Controllers
{
    public class ShopXeController : Controller
    {
         MyDBcontext data = new MyDBcontext();
        // GET: ShopXe
        public ActionResult Index()
        {
            //if (page == null) page = 1;
            //var all_sach = (from s in data.SanPhams select s).OrderBy(m => m.MaSP);
            //int pageSize = 4;
            //int pageNum = page ?? 1;
            //return View(all_sach.ToPagedList(pageNum, pageSize));
            var all_sach = from ss in data.SanPhams select ss;
            return View(all_sach);

        }


    }
}