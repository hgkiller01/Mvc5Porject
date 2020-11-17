namespace Mvc5Porject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("member")]
    public partial class member
    {

        [Key]
        [StringLength(12)]
        public string Account { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

        [StringLength(60)]
        public string Adress { get; set; }

        public int? Telphone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string PassWord { get; set; }

        public bool? isAdmin { get; set; }

    }
}
