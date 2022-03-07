namespace DGCARTEL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PageMetaDetail")]
    public partial class PageMetaDetail
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string PageUrl { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(100)]
        public string MetaKeywords { get; set; }

        [StringLength(100)]
        public string MetaDescription { get; set; }
    }
}
