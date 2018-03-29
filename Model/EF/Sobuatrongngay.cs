namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sobuatrongngay")]
    public partial class Sobuatrongngay
    {
        [Key]
        public int ID_sobuatrongngay { get; set; }

        [StringLength(500)]
        public string Ten_bua { get; set; }
    }
}
