namespace Mvc5Porject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {

        [Key]
        [StringLength(50)]
        public string OrderID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? OrderDate { get; set; }

        public int? Orderstat { get; set; }

        [StringLength(50)]
        public string DeliveryAddress { get; set; }

        [StringLength(12)]
        public string Account { get; set; }

        public virtual member member { get; set; }

    }
}
