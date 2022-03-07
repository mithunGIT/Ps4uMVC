namespace DGCARTEL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PAYUMONEY_DATA
    {
        [Key]
        [StringLength(8)]
        public string AUTONOPAY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AUTOUSERID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MIHPAYID { get; set; }

        [StringLength(2)]
        public string MODE { get; set; }

        [Required]
        [StringLength(7)]
        public string STATUS { get; set; }

        [StringLength(20)]
        public string UNMAPPEDSTATUS { get; set; }

        [StringLength(9)]
        public string MARCHENT_KEY { get; set; }

        [Required]
        [StringLength(30)]
        public string TXNID { get; set; }

        [StringLength(30)]
        public string AMOUNT { get; set; }

        public DateTime? ADDEDON { get; set; }

        [StringLength(100)]
        public string PRODUCTINFO { get; set; }

        [StringLength(20)]
        public string FIRSTNAME { get; set; }

        [StringLength(20)]
        public string LASTNAME { get; set; }

        [StringLength(100)]
        public string ADDRESS1 { get; set; }

        [StringLength(100)]
        public string ADDRESS2 { get; set; }

        [StringLength(30)]
        public string CITY { get; set; }

        [StringLength(30)]
        public string STATE { get; set; }

        [StringLength(30)]
        public string COUNTRY { get; set; }

        [StringLength(6)]
        public string ZIPCODE { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        [StringLength(11)]
        public string PHONE { get; set; }

        [StringLength(100)]
        public string UDF1 { get; set; }

        [StringLength(100)]
        public string UDF2 { get; set; }

        [StringLength(100)]
        public string UDF3 { get; set; }

        [StringLength(100)]
        public string UDF4 { get; set; }

        [StringLength(100)]
        public string UDF5 { get; set; }

        [StringLength(100)]
        public string UDF6 { get; set; }

        [StringLength(100)]
        public string UDF7 { get; set; }

        [StringLength(100)]
        public string UDF8 { get; set; }

        [StringLength(100)]
        public string UDF9 { get; set; }

        [StringLength(100)]
        public string UDF10 { get; set; }

        [Required]
        [StringLength(128)]
        public string HASH { get; set; }

        [StringLength(150)]
        public string FIELD1 { get; set; }

        [StringLength(150)]
        public string FIELD2 { get; set; }

        [StringLength(150)]
        public string FIELD3 { get; set; }

        [StringLength(150)]
        public string FIELD4 { get; set; }

        [StringLength(150)]
        public string FIELD5 { get; set; }

        [StringLength(150)]
        public string FIELD6 { get; set; }

        [StringLength(150)]
        public string FIELD7 { get; set; }

        [StringLength(150)]
        public string FIELD8 { get; set; }

        [StringLength(150)]
        public string FIELD9 { get; set; }

        [StringLength(20)]
        public string PG_TYPE { get; set; }

        [StringLength(100)]
        public string ENCRYPTEDPAYMENTID { get; set; }

        [StringLength(20)]
        public string BANK_REF_NUM { get; set; }

        [StringLength(20)]
        public string BANKCODE { get; set; }

        [StringLength(200)]
        public string ERROR { get; set; }

        [StringLength(200)]
        public string ERROR_MESSAGE { get; set; }

        [StringLength(40)]
        public string NAME_ON_CARD { get; set; }

        [StringLength(20)]
        public string CARDNUM { get; set; }

        [StringLength(100)]
        public string CARDHASH { get; set; }

        [StringLength(100)]
        public string AMOUNT_SPLIT { get; set; }

        [StringLength(20)]
        public string PAYUMONEYID { get; set; }

        [StringLength(20)]
        public string DISCOUNT { get; set; }

        [StringLength(20)]
        public string NET_AMOUNT_DEBIT { get; set; }
    }
}
