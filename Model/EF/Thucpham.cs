namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Thucpham")]
    public partial class Thucpham
    {
        [Key]
        public long ID_thucpham { get; set; }

        [StringLength(250)]
        public string Ten_thucpham { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(250)]
        public string Image_thucpham { get; set; }

        [Column(TypeName = "ntext")]
        public string Mota { get; set; }

        public decimal? Calories { get; set; }

        public decimal? Total_Fat { get; set; }

        public decimal? Cholesterol { get; set; }

        public decimal? Sodium { get; set; }

        public decimal? Total_Carbohydrate { get; set; }

        public decimal? Total_Sugar { get; set; }

        public decimal? Protein { get; set; }

        [StringLength(500)]
        public string Tags { get; set; }

        public int? ID_loaithucpham { get; set; }
    }
}
