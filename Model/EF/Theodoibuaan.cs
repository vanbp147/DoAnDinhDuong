namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Theodoibuaan")]
    public partial class Theodoibuaan
    {
        [Key]
        public int ID_theodoi { get; set; }

        public int? ID_Nguoidung { get; set; }

        public int? ID_sobuatrongngay { get; set; }

        public DateTime? Ngaythang { get; set; }

        public decimal? Fat_ba { get; set; }

        public decimal? Protein_ba { get; set; }

        public decimal? Carb_ba { get; set; }

        public decimal? Total_calos { get; set; }
    }
}
