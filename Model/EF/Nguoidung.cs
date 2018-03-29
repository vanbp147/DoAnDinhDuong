namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nguoidung")]
    public partial class Nguoidung
    {
        [Key]
        public int ID_Nguoidung { get; set; }

        [StringLength(100)]
        public string Taikhoan { get; set; }

        [StringLength(100)]
        public string Ten_ND { get; set; }

        public int? Tuoi { get; set; }

        [StringLength(10)]
        public string Gioitinh { get; set; }

        public decimal? Chieucao { get; set; }

        public decimal? Cannang { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(500)]
        public string Matkhau { get; set; }

        [StringLength(500)]
        public string Matkhauxacnhan { get; set; }

        public decimal? CaloriesTrongngay { get; set; }

        public int? ID_MuctieuNguoidung { get; set; }

        public bool Status { get; set; }

        public int? ID_Kieunguoi { get; set; }
    }
}
