namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Loaithucpham")]
    public partial class Loaithucpham
    {
        [Key]
        public int ID_loaithucpham { get; set; }

        [StringLength(250)]
        public string Ten_loaithucpham { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }
    }
}
