namespace Mvc5Porject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dessert")]
    public partial class Dessert
    {

        [StringLength(10)]
        public string DessertID { get; set; }

        [StringLength(50)]
        public string DessertName { get; set; }

        public int? DessertPrice { get; set; }

        [StringLength(10)]
        public string DessertKind { get; set; }

        public string DessertIntroduction { get; set; }

        [StringLength(50)]
        public string DessertImage { get; set; }

        public bool? IsOnSale { get; set; }
    }
}
