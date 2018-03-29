namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MuctieuNguoidung")]
    public partial class MuctieuNguoidung
    {
        [Key]
        public int ID_MuctieuNguoidung { get; set; }

        [StringLength(100)]
        public string TenMuctieu { get; set; }

        public decimal? Fat_tp { get; set; }

        public decimal? Protein_tp { get; set; }

        public decimal? Carb_tp { get; set; }
    }
}
