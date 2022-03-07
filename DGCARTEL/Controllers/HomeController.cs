using DGCARTEL.DAL;
using DGCARTEL.Models;
using DGCARTEL.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DGCARTEL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["USERNAME"] == null)
            {
                return RedirectToAction("login", "login");
            }
            DGCARTELContext db = new DGCARTELContext();
            //var USER_DETAILS_data = db.USER_DETAILS.Where(a => a.AUTOUSERID == USERID).FirstOrDefault();
            var pageMetaDetail = db.PageMetaDetail.FirstOrDefault(a => a.PageUrl == "Home/Index");
            if (pageMetaDetail != null)
            {
                ViewBag.metadescription = pageMetaDetail.MetaDescription;
                ViewBag.metakeywords = pageMetaDetail.MetaKeywords;
            }

            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(FormCollection FC)
        {
            string name = "", email = "", mobile = "", message = "";
            if (FC.AllKeys.Contains("name"))
            {
                name = FC["name"].ToString();
            }
            if (FC.AllKeys.Contains("email"))
            {
                email = FC["email"].ToString();
            }
            if (FC.AllKeys.Contains("mobile"))
            {
                mobile = FC["mobile"].ToString();
            }
            if (FC.AllKeys.Contains("message"))
            {
                message = FC["message"].ToString();
            }
            Connection Cn = new Connection();
            StringBuilder sb = new StringBuilder();
            sb.Append("<p><b>Name:</b> " + name + "<br/>");
            sb.Append("<b>Email:</b> " + email + "<br/>");
            sb.Append("<p><b>Mobile:</b> " + mobile + "<br/><br/>");
            sb.Append("<b>Message:</b> " + message + "<p><br/>");
            if (Cn.SendEmail("dgcartel.contact@gmail.com", "Contact Us", sb.ToString(), null) == "p")
            {
                ViewData["successmessage"] = "<script>alert('Email sent Successfully to dgcartel.contact@gmail.com');</script>";
                return View();
            }
            else
            {
                var ty = Cn.SendEmail("dgcartel.contact@gmail.com", "Contact Us", sb.ToString(), null);
                ViewData["successmessage"] = "<script>alert('" + ty + "');</script>";

            }
            return View();
        }
        //public ActionResult OpenUpdateProfile(LoginScreen VM)
        //{
        //    try
        //    {
        //        var USERID = (decimal)Session["USERID"];
        //        DGCARTELContext db = new DGCARTELContext();
        //        var USER_DETAILS_data = db.USER_DETAILS.Where(a => a.AUTOUSERID == USERID).FirstOrDefault();
        //        LoginScreen ls = new LoginScreen();
        //        ls.USER_DETAILS = USER_DETAILS_data;
        //        ModelState.Clear();
        //        return PartialView("_UpdateProfile", ls);
        //    }
        //    catch (Exception e)
        //    {
        //        return Content(e.ToString());
        //    }
        //}

        //public ActionResult SaveUpdateProfile(LoginScreen VM, FormCollection FC)
        //{
        //    try
        //    {
        //        var USERID = (decimal)Session["USERID"];
        //        DGCARTELContext db = new DGCARTELContext();
        //        var USER_DETAILS_data = db.tb.Where(a => a.AUTOUSERID == USERID).FirstOrDefault();
        //        DGCARTELContext db1 = new DGCARTELContext();
        //        USER_DETAILS1 udt = new USER_DETAILS1();
        //        udt.AUTOUSERID = USERID;
        //        udt.PASSWORD = USER_DETAILS_data.PASSWORD;
        //        udt.USEREMAIL = VM.USER_DETAILS.USEREMAIL.ToUpper();
        //        udt.FULLNAME = VM.USER_DETAILS.FULLNAME.ToUpper();
        //        udt.MOBILE = VM.USER_DETAILS.MOBILE;
        //        udt.DOB = VM.USER_DETAILS.DOB;
        //        udt.ADDRESS = VM.USER_DETAILS.ADDRESS.ToUpper();
        //        udt.GENDER = VM.USER_DETAILS.GENDER.ToUpper();
        //        db1.Entry(udt).State = System.Data.Entity.EntityState.Modified;
        //        db1.SaveChanges();
        //        return Content("updated");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Content(ex.Message);
        //    }

        //}
        public ActionResult GetAdvertisement()
        {
            try
            {
                DGCARTELContext db = new DGCARTELContext();
                var ty = db.Advertisements.ToList();
                var rndGen = new Random();
                int random = rndGen.Next(0, ty.Count);
                var tyy = ty.ElementAt(random);
                return Content(tyy.Description);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}