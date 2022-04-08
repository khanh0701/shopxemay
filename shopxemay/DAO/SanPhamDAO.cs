using shopxemay.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace shopxemay.DAO
{
    public class SanPhamDAO
    {

        private MyDBcontext db = new MyDBcontext();
        //trả về ds các mục tin
        public List<SanPham> Getlist(string TrangThai = "All")
        {
            List<SanPham> list = null;
            switch (TrangThai)
            {
                case "Index":
                    {
                        list = db.SanPhams.Where(m => m.TrangThai != true).ToList();
                        break;
                    }
                case "Trash":
                    {
                        list = db.SanPhams.Where(m => m.TrangThai == false).ToList();
                        break;

                    }
                default:
                    {
                        list = db.SanPhams.ToList();
                        break;

                    }
            }
            return list;
        }
        //trả về 1 mục tin
        public SanPham getRow(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.SanPhams.Find(id);
            }
        }

        //thêm Mẫu tin
        public int Insert(SanPham row)
        {
            db.SanPhams.Add(row);
            return db.SaveChanges();
        }
        //cập nhật Mẫu tin
        public int Update(SanPham row)
        {
            db.Entry(row).State = EntityState.Modified;
           
            return db.SaveChanges();

           
        }

        //xóa Mẫu tin
        public int Delete(SanPham row)
        {
            db.SanPhams.Remove(row);
            return db.SaveChanges();

        }

    }
}
 


