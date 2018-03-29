namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SystemConfig")]
    public partial class SystemConfig
    {
        [StringLength(250)]
        public string ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Type { get; set; }

        [StringLength(250)]
        public string Value { get; set; }

        public bool? Trangthai { get; set; }
    }
}
