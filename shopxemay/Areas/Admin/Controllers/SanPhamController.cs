using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using shopxemay.Models;
using shopxemay.DAO;

namespace shopxemay.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        SanPhamDAO sanphamDAO = new SanPhamDAO();

        MyDBcontext db = new MyDBcontext();


        // GET: Admin/SanPham
        public ActionResult Index()
        {
           
            return View(sanphamDAO.Getlist("Index"));
        }

        // GET: Admin/SanPham/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = sanphamDAO.getRow(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: Admin/SanPham/Create
        public ActionResult Create()
        {
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
                sanphamDAO.Insert(sanPham);
                
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
            SanPham sanPham = sanphamDAO.getRow(id);

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
                sanphamDAO.Update(sanPham);
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
            SanPham sanPham = sanphamDAO.getRow(id);

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
            SanPham sanPham = sanphamDAO.getRow(id);

            sanphamDAO.Delete(sanPham);
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

        public ActionResult TrangThai(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("Index", "SanPham");
            }
             SanPham sanPham = sanphamDAO.getRow(id);
            if (sanPham == null)
            {
            return RedirectToAction("Index", "SanPham");
            }
            sanPham.TrangThai = (sanPham.TrangThai == true) ? false : true;
            sanphamDAO.Update(sanPham);
            return RedirectToAction("Index", "SanPham");

        }
    }
}
