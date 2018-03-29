namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Thucpham_tag
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID_Thucpham_tag { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(250)]
        public string ID_Tag { get; set; }
    }
}
