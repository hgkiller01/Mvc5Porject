namespace Mvc5Porject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Gift")]
    public partial class Gift
    {
        [StringLength(10)]
        public string GiftID { get; set; }

        [StringLength(50)]
        public string GiftName { get; set; }

        public int? GiftPrice { get; set; }

        public int? PieCount { get; set; }

        public int? CakeCount { get; set; }

        public int? CookieCount { get; set; }

        [StringLength(50)]
        public string GiftImage { get; set; }

        public bool? IsOnSales { get; set; }

    }
}
