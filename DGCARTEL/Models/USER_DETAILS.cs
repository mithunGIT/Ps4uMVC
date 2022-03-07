namespace DGCARTEL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USER_DETAILS1
    {

        public string USERID { get; set; }

        [Required]
        [StringLength(50)]
        public string USEREMAIL { get; set; }

        [Required]
        [StringLength(20)]
        public string PASSWORD { get; set; }

        [Required]
        [StringLength(50)]
        public string FULLNAME { get; set; }

        [Required]
        [StringLength(20)]
        public string MOBILE { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(1)]
        public string GENDER { get; set; }

        [Required]
        [StringLength(100)]
        public string ADDRESS { get; set; }
    }
}
