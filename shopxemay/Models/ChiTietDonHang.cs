namespace shopxemay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonHang")]
    public partial class ChiTietDonHang
    {
        [Key]
        public int MaCTDH { get; set; }

        public int? MaDH { get; set; }

        public int? MaSP { get; set; }

        public int? GiamGia { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(10)]
        public string NgayGiao { get; set; }

        [StringLength(10)]
        public string TongTien { get; set; }

        public virtual DonHang DonHang { get; set; }
    }
}
