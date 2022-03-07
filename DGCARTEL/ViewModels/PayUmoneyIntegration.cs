using DGCARTEL;
using DGCARTEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DGCARTEL.ViewModels
{
    public class PayUmoneyIntegration
    {
        public PAYUMONEY_DATA PAYUMONEY_DATA { get; set; }
        public PAYUMONEY_FAIL_DATA PAYUMONEY_FAIL_DATA { get; set; }
        public string txnid { get; set; }
        public string key { get; set; }
        public string hash { get; set; }
        public string amount { get; set; }
        public string firstname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string productinfo { get; set; }
        public string surl { get; set; }
        public string furl { get; set; }
        public string lastname { get; set; }
        public string curl { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string zipcode { get; set; }
        public string udf1 { get; set; }
        public string udf2 { get; set; }
        public string udf3 { get; set; }
        public string udf4 { get; set; }
        public string udf5 { get; set; }
        public string pg { get; set; }
        public string service_provider { get; set; }
    }
}