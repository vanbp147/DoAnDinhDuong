namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kieunguoi")]
    public partial class Kieunguoi
    {
        [Key]
        public int ID_Kieunguoi { get; set; }

        [StringLength(500)]
        public string Loai { get; set; }

        public decimal? chiso { get; set; }
    }
}
