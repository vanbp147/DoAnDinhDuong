namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Congcu")]
    public partial class Congcu
    {
        [Key]
        public int ID_Congcu { get; set; }

        [StringLength(250)]
        public string Ten_Congcu { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }
    }
}
