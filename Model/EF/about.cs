namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("about")]
    public partial class about
    {
        public int ID { get; set; }

        [StringLength(500)]
        public string Ten { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(250)]
        public string Images { get; set; }

        [Column(TypeName = "ntext")]
        public string Mota { get; set; }

        public bool Trangthai { get; set; }
    }
}
