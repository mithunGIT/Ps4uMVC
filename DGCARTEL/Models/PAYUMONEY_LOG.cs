namespace DGCARTEL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PAYUMONEY_LOG
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal AUTONO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AUTOUSERID { get; set; }

        public DateTime SUBMIT_TIME { get; set; }

        [Required]
        [StringLength(30)]
        public string TXNID { get; set; }

        [Required]
        [StringLength(20)]
        public string FIRSTNAME { get; set; }

        [Required]
        [StringLength(30)]
        public string AMOUNT { get; set; }

        [StringLength(10)]
        public string STATUS { get; set; }
    }
}
