namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tag")]
    public partial class Tag
    {
        [Key]
        [StringLength(250)]
        public string ID_Tag { get; set; }

        [StringLength(250)]
        public string Name { get; set; }
    }
}
