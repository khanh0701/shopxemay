using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using shopxemay.Models;
using shopxemay.Library;

namespace shopxemay.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
      private MyDBcontext db = new MyDBcontext();

        // GET: Admin/SanPham
        public ActionResult Index(string SearchString)
        {
           

           if (SearchString == null)
            {
                var sanPhams = db.SanPhams.ToList();
                 return View(sanPhams);

            }

            else 
            {
                var sanPham1 = db.SanPhams.Where(n => n.TenSP.Contains(SearchString)).ToList();  
                   
                return View(sanPham1);
            }
            
           
        }

        // GET: Admin/SanPham/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: Admin/SanPham/Create
        public ActionResult Create()
        {
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSp");
            ViewBag.MaLoaiSP = new SelectList(db.LoaiSanPhams, "MaLoaiSP", "TenLoaiSP");
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC");
            return View();
        }

        // POST: Admin/SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,MoTa1,MoTa2,GiaBan,NgayCapNhat,Hinh,SolanMua,TrangThai,TonKho,SPMoi,MaLoaiSP,MaNCC")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                //xử lý thêm vào
                if(sanPham.NgayCapNhat==null)
                {
                    sanPham.NgayCapNhat =DateTime.Now;
                }
                if (sanPham.SolanMua == null)
                {
                    sanPham.SolanMua = 0;
                }
                if (sanPham.NgayCapNhat == null)
                {
                    sanPham.NgayCapNhat = DateTime.Now;
                }
                if (sanPham.MoTa2 == null)
                {
                    sanPham.MoTa2 = "đang cập nhật";
                }


                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiSP = new SelectList(db.LoaiSanPhams, "MaLoaiSP", "TenLoaiSP", sanPham.MaLoaiSP);
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", sanPham.MaNCC);
            return View(sanPham);
        }

        // GET: Admin/SanPham/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiSP = new SelectList(db.LoaiSanPhams, "MaLoaiSP", "TenLoaiSP", sanPham.MaLoaiSP);
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", sanPham.MaNCC);
            return View(sanPham);
        }

        // POST: Admin/SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,MoTa1,MoTa2,GiaBan,NgayCapNhat,Hinh,SolanMua,TrangThai,TonKho,SPMoi,MaLoaiSP,MaNCC")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiSP = new SelectList(db.LoaiSanPhams, "MaLoaiSP", "TenLoaiSP", sanPham.MaLoaiSP);
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", sanPham.MaNCC);
            return View(sanPham);
        }

        // GET: Admin/SanPham/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Admin/SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Areas/Admin/AssetsAD/img/" + file.FileName));
            return "/Areas/Admin/AssetsAD/img/" + file.FileName;
        }
        public ActionResult TrangThai(int? id)
        {
            if (id == null)
            {
                
                return RedirectToAction("Index", "SanPam");
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                

                return RedirectToAction("Index", "SanPam");

            }
            if (sanPham == null)
            {
                

                return RedirectToAction("Index", "SanPam");

            }
            sanPham.TrangThai =(sanPham.TrangThai == true) ? false : true;
            sanPham.NgayCapNhat = DateTime.Now;
            db.SanPhams.Add(sanPham);
            db.SaveChanges();       
            return RedirectToAction("Index", "SanPam");
        }


        

        
        
    }
}
