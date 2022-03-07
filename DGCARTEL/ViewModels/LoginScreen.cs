using DGCARTEL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DGCARTEL.ViewModels
{
    public class LoginScreen
    {
        
        public tblUser tblUser { get; set; }
        public USER_DETAILS1 USER_DETAILS { get; set; }
        public List< USER_DETAILS1 > Userdtl { get; set; }
        public ForgotPassword ForgotPassword { get; set; }
        public bool REMEMBERME { get; set; }
        public string CPASSWORD { get; set; }
    }
    public class ForgotPassword
    {       
        public decimal AUTOUSERID { get; set; }

        [Required]
        [StringLength(50)]
        public string USEREMAIL { get; set; }

        [Required]
        [StringLength(20)]
        public string NEWPASSWORD { get; set; }
        
        [StringLength(20)]
        public string MOBILE { get; set; }
        
        [StringLength(1)]
        public string GETOTPWITH { get; set; }
        [Required]
        [StringLength(6)]
        public string OTP { get; set; }
        public string MSG { get; set; }
    }

}