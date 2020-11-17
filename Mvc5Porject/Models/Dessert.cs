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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dessert()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
