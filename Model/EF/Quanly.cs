namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Quanly")]
    public partial class Quanly
    {
        [Key]
        public int ID_Quanly { get; set; }

        [StringLength(100)]
        public string Taikhoan { get; set; }

        [StringLength(255)]
        public string Matkhau { get; set; }

        [StringLength(255)]
        public string Matkhauxacnhan { get; set; }

        [StringLength(100)]
        public string Hoten { get; set; }

        [StringLength(500)]
        public string Diachi { get; set; }

        public DateTime? Ngaysinh { get; set; }

        [StringLength(50)]
        public string Gioitinh { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public int? CMND { get; set; }

        public int? SDT { get; set; }

        [StringLength(100)]
        public string Quyen { get; set; }

        [StringLength(250)]
        public string Images { get; set; }

        public bool? Status { get; set; }
    }
}
