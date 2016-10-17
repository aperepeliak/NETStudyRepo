namespace StoreDataLayer.DbLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sale")]
    public partial class Sale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sale()
        {
            SalePos = new HashSet<SalePos>();
        }

        public int SaleId { get; set; }

        public int? UserId { get; set; }

        public DateTime SaleDate { get; set; }

        [Required]
        [StringLength(24)]
        public string SaleNumber { get; set; }

        [Column(TypeName = "money")]
        public decimal SaleAmount { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalePos> SalePos { get; set; }
    }
}
