namespace StoreDataLayer.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SalePos
    {
        public int SalePosId { get; set; }

        public int? GoodId { get; set; }

        public int? SaleId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal SalePosSum { get; set; }

        public virtual Good Good { get; set; }

        public virtual Sale Sale { get; set; }
    }
}
