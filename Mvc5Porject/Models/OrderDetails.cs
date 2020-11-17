namespace Mvc5Porject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetails
    {
        [Key]
        [StringLength(50)]
        public string DetailID { get; set; }

        public int? DessertAmount { get; set; }

        [StringLength(50)]
        public string OrderID { get; set; }

        [StringLength(10)]
        public string GiftID { get; set; }

        [StringLength(10)]
        public string DessertID { get; set; }

        public virtual Dessert Dessert { get; set; }

        public virtual Gift Gift { get; set; }

        public virtual Orders Orders { get; set; }
    }
}
