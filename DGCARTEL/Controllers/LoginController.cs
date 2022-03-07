using DGCARTEL.DAL;
using DGCARTEL.Models;
using DGCARTEL.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data;
using System.Text;
using Newtonsoft.Json.Linq;

namespace DGCARTEL.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            LoginScreen VM = new LoginScreen();
            //tblUser1 rEGISTER = new tblUser1();
            //if (Request.Cookies["Userid"] != null)
            //    rEGISTER.USEREMAIL = Request.Cookies["Userid"].Value;
            //if (Request.Cookies["Password"] != null)
            //    rEGISTER.PASSWORD = Request.Cookies["Password"].Value;
            //if (Request.Cookies["Userid"] != null && Request.Cookies["Password"] != null)
            //    VM.REMEMBERME = true;
            //VM.tblUser = rEGISTER;
            return View(VM);
        }
        [HttpPost]
        public ActionResult Login(LoginScreen VM)
        {
            DGCARTELContext db = new DGCARTELContext();
            string USEREMAIL = VM.USER_DETAILS.USEREMAIL;
            string PASSWORD = VM.USER_DETAILS.PASSWORD ;
            var tblUser_data = db.tblUser.Where(a => a.UserId == USEREMAIL && a.Password == PASSWORD).FirstOrDefault();
          
            if (tblUser_data != null)
            {
                Session["USEREMAIL"] = USEREMAIL;
                //Session["USERID"] = tblUser_data.AUTOUSERID;
                //Session["USERNAME"] = tblUser_data.FULLNAME;
                if (VM.REMEMBERME == true)
                {
                    //Response.Cookies["USEREMAIL"].Value = VM.tblUser.USEREMAIL;
                    //Response.Cookies["PASSWORD"].Value = VM.tblUser.PASSWORD;
                    Response.Cookies["USEREMAIL"].Expires = DateTime.Now.AddDays(15);
                    Response.Cookies["PASSWORD"].Expires = DateTime.Now.AddDays(15);
                }
                else
                {
                    Response.Cookies["USEREMAIL"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                }
                ModelState.Clear();
            }
            else
            {
                ModelState.Clear();
                ModelState.AddModelError("USEREMAIL", "Wrong Username or Password Entired.");
            }
            if (!ModelState.IsValid)
            {
                return View(VM);
            }
            else
            {
                ModelState.Clear();
                return RedirectToAction("Index", "HOME");
            }
        }

        public ActionResult Registration()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Registration(LoginScreen VM)
        //    {
        //    if (VM.REMEMBERME == true)
        //    {
        //        Response.Cookies["Userid"].Value = VM.tblUser.USEREMAIL;
        //        Response.Cookies["Password"].Value = VM.tblUser.PASSWORD;
        //        Response.Cookies["Userid"].Expires = DateTime.Now.AddDays(15);
        //        Response.Cookies["Password"].Expires = DateTime.Now.AddDays(15);
        //    }
        //    else
        //    {
        //        Response.Cookies["Userid"].Expires = DateTime.Now.AddDays(-1);
        //        Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
        //    }
        //    if (VM.tblUser.PASSWORD != VM.CPASSWORD)
        //    {
        //        ModelState.AddModelError("pass","Password Not Match");
        //        return View(VM);
        //    }
        //    try
        //    {
        //        using (DGCARTELContext entities = new DGCARTELContext())
        //        {
        //           var USEREMAILchk = entities.tblUser.Where(a => a.USEREMAIL == VM.tblUser.USEREMAIL).ToList();
        //            if (USEREMAILchk.Any())
        //            {
        //                ModelState.AddModelError("Email", "This Email Id allready Exist.");
        //                return View(VM);
        //            }
        //            int datacnt = entities.tblUser.Where(a => a.AUTOUSERID != 0).Count();
        //            decimal MAXUSERID = 0;
        //            if (datacnt != 0)
        //            {
        //                MAXUSERID = entities.tblUser.Max(a => a.AUTOUSERID);
        //            }
        //            else
        //            {
        //                MAXUSERID = 0;
        //            }
        //            VM.tblUser.AUTOUSERID = MAXUSERID + 1;
        //            entities.tblUser.Add(VM.tblUser);
        //            entities.SaveChanges();
        //        }
        //        return RedirectToAction("Login", "Login");
        //    }
        //    catch (Exception e)
        //    {
        //        return Content(e.ToString());
        //    }            
        //}
        public ActionResult Logout()
        {
            Session.RemoveAll();
            ModelState.Clear();
            TempData["MSG"] = "Logout Successfully.";
            return RedirectToAction("Index", "HOME");
        }
        public ActionResult ForgotPassword()
        {
            LoginScreen VM = new LoginScreen();         
            return View(VM);
        }
        //[HttpPost]
        //public ActionResult ForgotPassword(LoginScreen VM,FormCollection FC)
        //{
        //    DGCARTELContext db = new DGCARTELContext();
        //    string USEREMAIL = VM.ForgotPassword.USEREMAIL.ToUpper();
        //    var tblUser_data = db.tblUser.Where(a => a.USEREMAIL == USEREMAIL).FirstOrDefault();
        //    if (tblUser_data != null)
        //    {
        //        string GENERATEDOTP = TempData["GENERATEDOTP"].ToString();
        //        TempData.Keep();                
        //        if(VM.ForgotPassword.OTP== GENERATEDOTP)
        //        {
        //            tblUser1 udt = new tblUser1();
        //            udt = tblUser_data;
        //            udt.PASSWORD = VM.ForgotPassword.NEWPASSWORD;
        //            db.Entry(udt).State = System.Data.Entity.EntityState.Modified;
        //            db.SaveChanges();
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("otp", "Wrong OTP Entired.");
        //        }
        //    }
        //    else
        //    {
        //        ModelState.Clear();
        //        ModelState.AddModelError("USEREMAIL", "Wrong Username/Email Entired.");
        //    }
        //    if (!ModelState.IsValid)
        //    {
        //        return View(VM);
        //    }
        //    else
        //    {
        //        ModelState.Clear();
        //       TempData["MSG"] = "Password has been Reset.";
        //        return RedirectToAction("Login", "Login");
        //    }
        //}
        //public ActionResult GetOtp(LoginScreen VM)
        //{
        //    try
        //    {
        //        DGCARTELContext db = new DGCARTELContext();
        //        Connection Cn = new Connection();
        //        ForgotPassword JSONobj = new ForgotPassword();
        //        var USEREMAILchk = db.tblUser.Where(a => a.USEREMAIL == VM.ForgotPassword.USEREMAIL).ToList();
        //        if (USEREMAILchk.Any())
        //        {
        //            tblUser1 userdata = USEREMAILchk.FirstOrDefault();
        //            string otp = Cn.GenerateOTP(false, 4);
        //            string GETOTPWITH = VM.ForgotPassword.GETOTPWITH;
        //            if (GETOTPWITH == "E")
        //            {
        //                StringBuilder forgormailbody = new StringBuilder();
        //                forgormailbody.Append("Dear " + userdata.FULLNAME + "<br /> <br /><br />");
        //                forgormailbody.Append("<p>");
        //                forgormailbody.Append("You have requested <u><b> forgot password </u></b> in our website.We have generated a One - Time Password  for You, this will verify that you have requested access.");
        //                forgormailbody.Append("This One time Password is time sensitive for a single use.");
        //                forgormailbody.Append("One subsequent logins you will not nees to enter this One Time Password code.");
        //                forgormailbody.Append("</p ><br /><br />");
        //                forgormailbody.Append("Your one Time Password  is <b>&nbsp;&nbsp; " + otp + "&nbsp;</b> <br /><br />");
        //                forgormailbody.Append("Please enter this OTP into that you have accessed and thank you for utlizing our services.<br /><br /><br /><br /><br />");
        //                forgormailbody.Append("For any queries you can replay this mail. <br />");
        //                forgormailbody.Append("Regards <br />");
        //                forgormailbody.Append("DGCARTEL <br />");
        //                forgormailbody.Append("9932659585<br />");
        //                bool status = false;//  Cn.SendEmail(VM.ForgotPassword.USEREMAIL, "Forgot Password", forgormailbody.ToString(), null);
        //                if (!status)
        //                {
        //                    JSONobj.MSG = " Email not sent.";
        //                    return Json(JSONobj);
        //                }
        //            }
        //            else if (GETOTPWITH == "M")
        //            {
        //                string forgotmsg = otp + " is your One Time Password for Forgot Password in DGCARTEL. Don't share with anyone.";
        //                string result=  Cn.sendSMS(userdata.MOBILE, forgotmsg);
        //                JObject jObject = JObject.Parse(result.Trim());
        //                string status = (string)jObject.SelectToken("status");
        //                if (status == "success")
        //                {
        //                    string recipient = (string)jObject.SelectToken("messages[0].recipient");
        //                    JSONobj.MSG = "Message sent successfully to this "+ recipient + ".";
        //                    return Json(JSONobj);
        //                }

        //                if (status== "failure")
        //                {
        //                    string message = (string)jObject.SelectToken("warnings[0].message");
        //                    JSONobj.MSG = "Message not sent due to : " + message + ".";
        //                    return Json(JSONobj);
        //                }
        //            }
        //            JSONobj.MSG = "SUCCESS";
        //            JSONobj.USEREMAIL = userdata.USEREMAIL;
        //            JSONobj.MOBILE = userdata.MOBILE;
        //            JSONobj.GETOTPWITH = GETOTPWITH;
        //            TempData["GENERATEDOTP"] = otp;
        //            return Json(JSONobj, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            JSONobj.MSG = "Entired Email/User Id does not exist in DGCartel.";
        //            return Json(JSONobj);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }                       
        //}
    }
}