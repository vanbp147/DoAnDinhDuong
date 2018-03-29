namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sex")]
    public partial class Sex
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string Gioitinh { get; set; }
    }
}
