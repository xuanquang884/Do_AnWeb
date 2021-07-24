namespace Web_CuoiKy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class San_Pham
    {
        [Key]
        public int MASP { get; set; }

        [StringLength(50)]
        [DisplayName("Loại SP")]
        public string MALOAISP { get; set; }

        [StringLength(255)]
        [DisplayName("Tên SP")]
        public string TENSP { get; set; }

        [DisplayName("Mô tả")]
        public string MOTA { get; set; }

        [DisplayName("Giá")]
        public int? GIA { get; set; }

        [DisplayName("Số lượng")]
        public int? SOLUONG { get; set; }

        [DisplayName("Tình trạng")]
        public int? TINHTRANG { get; set; }

        [DisplayName("Lượt xem")]
        public int? LUOTVIEW { get; set; }

        [StringLength(255)]
        [DisplayName("Hình")]
        public string HINH { get; set; }

        [StringLength(255)]
        [DisplayName("Hình 1")]
        public string HINH1 { get; set; }

        [StringLength(255)]
        [DisplayName("Hình 2")]
        public string HINH2 { get; set; }

        [StringLength(255)]
        [DisplayName("Hình 3")]
        public string HINH3 { get; set; }

        [StringLength(255)]
        [DisplayName("Hình 4")]
        public string HINH4 { get; set; }

        public virtual Loai_SP Loai_SP { get; set; }
    }
}
