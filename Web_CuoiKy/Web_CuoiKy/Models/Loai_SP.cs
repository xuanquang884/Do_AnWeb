namespace Web_CuoiKy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Loai_SP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Loai_SP()
        {
            San_Pham = new HashSet<San_Pham>();
        }

        [Key]
        [Required]
        [StringLength(50)]
        [DisplayName("Mã loại")]
        public string MALOAI { get; set; }

        [StringLength(255)]
        [DisplayName("Tên loại")]
        public string TENLOAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<San_Pham> San_Pham { get; set; }
    }
}
