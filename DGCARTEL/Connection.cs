using System;
using System.IO;
using System.Net.Mail;
using System.Configuration;
using System.Web;
using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;

namespace DGCARTEL
{
    public class Connection
    {
        public string SendEmail(string to, string subject, string body, Attachment emailattachItem, string cc = "", string bcc = "")
        {
            string p = "";
            try
            {
                MailMessage mailMessage = new MailMessage();
                /// recepientEmail = ConfigurationManager.AppSettings["emailtosenddefault"];
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["emailuserName"]);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                if(emailattachItem!=null)mailMessage.Attachments.Add(emailattachItem);
                mailMessage.IsBodyHtml = true;
                 mailMessage.To.Add(to);
                if (cc != "") mailMessage.CC.Add(cc);
                if (bcc != "") mailMessage.Bcc.Add(bcc);
                SmtpClient smtp = new SmtpClient();
                p = "fl";
                smtp.Host = ConfigurationManager.AppSettings["emailhost"];
                smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["emailenableSsl"]);
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = ConfigurationManager.AppSettings["emailuserName"];
                NetworkCred.Password = ConfigurationManager.AppSettings["emailpassword"];
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["emailport"]);
                 p = "l";
                smtp.Send(mailMessage);
                p = "p";
                smtp.Dispose();
                return p;
            }
            catch (Exception ex)
            {
                return p+ ex.Message;
            }

        }

        public string sendSMS(string sendTO, string messageData)
        {
            // You can send multiple message Use comma as a devider.
            try
            {
                string message = HttpUtility.UrlEncode(messageData);
                using (var wb = new WebClient())
                {
                    byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                {
                {"apikey" , "zXEwVeAdKXI-EHfsgVI2gurPKkMHBUUrKUG9LoyPZp"},
                {"numbers" , sendTO},
                {"message" , message},
                {"sender" , "TXTLCL"}
                });
                    string result = System.Text.Encoding.UTF8.GetString(response);
                    return result;
                }
            }
            catch
            {
                return "failed";
            }
        }
        public void ExtracttxtlocalJson(string jsonString)
        { //{ "warnings":[{"code":3,"message":"Invalid number"}],"errors":[{"code":4,"message":"No recipients specified"}],"status":"failure"}
            string jk = "{\"balance\": 9,";
            jk += " \"batch_id\": 464174314,";
            jk += " \"cost\": 1,";
            jk += " \"num_messages\": 1,";
            jk += " \"message\": {";
            jk += " \"num_parts\": 1,";
            jk += " \"sender\": \"TXTLCL\",";
            jk += " \"content\": \"This is your hook message\"";
            jk += " },";
            jk += "\"receipt_url\": \"\",";
            jk += " \"custom\": \"\",";
            jk += " \"messages\": [";
            jk += " {";
            jk += " \"id\": \"1501664773\",";
            jk += " \"recipient\": 918697997345";
            jk += " }";
            jk += " ,";
            jk += " {";
            jk += "\"id\": \"15016647731\",";
            jk += " \"recipient\": 9186979973451";
            jk += " }";
            jk += " ],";
            jk += " \"status\": \"success\"}";
            JObject jObject = JObject.Parse(jsonString.Trim());
            string status = (string)jObject.SelectToken("status");
            string warnings_msg = (string)jObject.SelectToken("warnings[0].message");
            string value = (string)jObject.SelectToken("signInNames[0].value");

            string status11 = (string)jObject.SelectToken("message.sender");
            string status11w = (string)jObject.SelectToken("message.content");
            JArray signInNames = (JArray)jObject.SelectToken("messages");
            foreach (JToken signInName in signInNames)
            {
                warnings_msg = (string)signInName.SelectToken("id");
                var value1 = (long)signInName.SelectToken("recipient");
            }

        }
        public string GenerateOTP(bool alphabet,int length)
        {
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";
            string characters = numbers;
            if (alphabet)
            {
                characters += alphabets + small_alphabets + numbers;
            }           
            string otp = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }
            return otp;
        }

    }

    public class PaytmKey111
    {
        //public void GenerateInvoice(string TransactionID)
        //{
        //    Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);
        //    MemoryStream PDFData = new MemoryStream();
        //    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, PDFData);

        //    var titleFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
        //    var titleFontBlue = FontFactory.GetFont("Arial", 14, Font.NORMAL, BaseColor.BLUE);
        //    var boldTableFont = FontFactory.GetFont("Arial", 8, Font.BOLD);
        //    var bodyFont = FontFactory.GetFont("Arial", 8, Font.NORMAL);
        //    var EmailFont = FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLUE);
        //    BaseColor TabelHeaderBackGroundColor = WebColors.GetRGBColor("#EEEEEE");

        //    Rectangle pageSize = writer.PageSize;
        //    // Open the Document for writing
        //    pdfDoc.Open();
        //    //Add elements to the document here

        //    #region Top table
        //    // Create the header table 
        //    PdfPTable headertable = new PdfPTable(3);
        //    headertable.HorizontalAlignment = 0;
        //    headertable.WidthPercentage = 100;
        //    headertable.SetWidths(new float[] { 100f, 320f, 100f });  // then set the column's __relative__ widths
        //    headertable.DefaultCell.Border = Rectangle.NO_BORDER;
        //    //headertable.DefaultCell.Border = Rectangle.BOX; //for testing           

        //    Image logo = iTextSharp.text.Image.GetInstance(System.Web.HttpContext.Current.Server.MapPath("~/Images/DGcartel_logo.png"));
        //    logo.ScaleToFit(100, 15);

        //    {
        //        PdfPCell pdfCelllogo = new PdfPCell(logo);
        //        pdfCelllogo.Border = Rectangle.NO_BORDER;
        //        pdfCelllogo.BorderColorBottom = new BaseColor(System.Drawing.Color.Black);
        //        pdfCelllogo.BorderWidthBottom = 1f;
        //        headertable.AddCell(pdfCelllogo);
        //    }

        //    {
        //        PdfPCell middlecell = new PdfPCell();
        //        middlecell.Border = Rectangle.NO_BORDER;
        //        middlecell.BorderColorBottom = new BaseColor(System.Drawing.Color.Black);
        //        middlecell.BorderWidthBottom = 1f;
        //        headertable.AddCell(middlecell);
        //    }

        //    {
        //        PdfPTable nested = new PdfPTable(1);
        //        nested.DefaultCell.Border = Rectangle.NO_BORDER;
        //        PdfPCell nextPostCell1 = new PdfPCell(new Phrase("Company Name cwsc", titleFont));
        //        nextPostCell1.Border = Rectangle.NO_BORDER;
        //        nested.AddCell(nextPostCell1);
        //        PdfPCell nextPostCell2 = new PdfPCell(new Phrase("xxx City Heights, AZ 8xxx4, US,", bodyFont));
        //        nextPostCell2.Border = Rectangle.NO_BORDER;
        //        nested.AddCell(nextPostCell2);
        //        PdfPCell nextPostCell3 = new PdfPCell(new Phrase("(xxx) xxx-xxx", bodyFont));
        //        nextPostCell3.Border = Rectangle.NO_BORDER;
        //        nested.AddCell(nextPostCell3);
        //        PdfPCell nextPostCell4 = new PdfPCell(new Phrase("company@example.com", EmailFont));
        //        nextPostCell4.Border = Rectangle.NO_BORDER;
        //        nested.AddCell(nextPostCell4);
        //        nested.AddCell("");
        //        PdfPCell nesthousing = new PdfPCell(nested);
        //        nesthousing.Border = Rectangle.NO_BORDER;
        //        nesthousing.BorderColorBottom = new BaseColor(System.Drawing.Color.Black);
        //        nesthousing.BorderWidthBottom = 1f;
        //        nesthousing.Rowspan = 5;
        //        nesthousing.PaddingBottom = 10f;
        //        headertable.AddCell(nesthousing);
        //    }


        //    PdfPTable Invoicetable = new PdfPTable(3);
        //    Invoicetable.HorizontalAlignment = 0;
        //    Invoicetable.WidthPercentage = 100;
        //    Invoicetable.SetWidths(new float[] { 100f, 320f, 100f });  // then set the column's __relative__ widths
        //    Invoicetable.DefaultCell.Border = Rectangle.NO_BORDER;

        //    {
        //        PdfPTable nested = new PdfPTable(1);
        //        nested.DefaultCell.Border = Rectangle.NO_BORDER;
        //        PdfPCell nextPostCell1 = new PdfPCell(new Phrase("INVOICE TO:", bodyFont));
        //        nextPostCell1.Border = Rectangle.NO_BORDER;
        //        nested.AddCell(nextPostCell1);
        //        PdfPCell nextPostCell2 = new PdfPCell(new Phrase("Mr. Debendra", titleFont));
        //        nextPostCell2.Border = Rectangle.NO_BORDER;
        //        nested.AddCell(nextPostCell2);
        //        PdfPCell nextPostCell3 = new PdfPCell(new Phrase("xxx Silver City, TX xxxx, US", bodyFont));
        //        nextPostCell3.Border = Rectangle.NO_BORDER;
        //        nested.AddCell(nextPostCell3);
        //        PdfPCell nextPostCell4 = new PdfPCell(new Phrase("hook@example.com", EmailFont));
        //        nextPostCell4.Border = Rectangle.NO_BORDER;
        //        nested.AddCell(nextPostCell4);
        //        nested.AddCell("");
        //        PdfPCell nesthousing = new PdfPCell(nested);
        //        nesthousing.Border = Rectangle.NO_BORDER;
        //        //nesthousing.BorderColorBottom = new BaseColor(System.Drawing.Color.Black);
        //        //nesthousing.BorderWidthBottom = 1f;
        //        nesthousing.Rowspan = 5;
        //        nesthousing.PaddingBottom = 10f;
        //        Invoicetable.AddCell(nesthousing);
        //    }

        //    {
        //        PdfPCell middlecell = new PdfPCell();
        //        middlecell.Border = Rectangle.NO_BORDER;
        //        //middlecell.BorderColorBottom = new BaseColor(System.Drawing.Color.Black);
        //        //middlecell.BorderWidthBottom = 1f;
        //        Invoicetable.AddCell(middlecell);
        //    }


        //    {
        //        PdfPTable nested = new PdfPTable(1);
        //        nested.DefaultCell.Border = Rectangle.NO_BORDER;
        //        PdfPCell nextPostCell1 = new PdfPCell(new Phrase("INVOICE 3-2-1", titleFontBlue));
        //        nextPostCell1.Border = Rectangle.NO_BORDER;
        //        nested.AddCell(nextPostCell1);
        //        PdfPCell nextPostCell2 = new PdfPCell(new Phrase("Date of Invoice: " + DateTime.Now.ToShortDateString(), bodyFont));
        //        nextPostCell2.Border = Rectangle.NO_BORDER;
        //        nested.AddCell(nextPostCell2);
        //        PdfPCell nextPostCell3 = new PdfPCell(new Phrase("Due Date: " + DateTime.Now.AddDays(30).ToShortDateString(), bodyFont));
        //        nextPostCell3.Border = Rectangle.NO_BORDER;
        //        nested.AddCell(nextPostCell3);
        //        nested.AddCell("");
        //        PdfPCell nesthousing = new PdfPCell(nested);
        //        nesthousing.Border = Rectangle.NO_BORDER;
        //        //nesthousing.BorderColorBottom = new BaseColor(System.Drawing.Color.Black);
        //        //nesthousing.BorderWidthBottom = 1f;
        //        nesthousing.Rowspan = 5;
        //        nesthousing.PaddingBottom = 10f;
        //        Invoicetable.AddCell(nesthousing);
        //    }


        //    pdfDoc.Add(headertable);
        //    Invoicetable.PaddingTop = 10f;

        //    pdfDoc.Add(Invoicetable);
        //    #endregion

        //    #region Items Table
        //    //Create body table
        //    PdfPTable itemTable = new PdfPTable(5);

        //    itemTable.HorizontalAlignment = 0;
        //    itemTable.WidthPercentage = 100;
        //    itemTable.SetWidths(new float[] { 5, 40, 10, 20, 25 });  // then set the column's __relative__ widths
        //    itemTable.SpacingAfter = 40;
        //    itemTable.DefaultCell.Border = Rectangle.BOX;
        //    PdfPCell cell1 = new PdfPCell(new Phrase("NO", boldTableFont));
        //    cell1.BackgroundColor = TabelHeaderBackGroundColor;
        //    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
        //    itemTable.AddCell(cell1);
        //    PdfPCell cell2 = new PdfPCell(new Phrase("DESCRIPTION", boldTableFont));
        //    cell2.BackgroundColor = TabelHeaderBackGroundColor;
        //    cell2.HorizontalAlignment = 1;
        //    itemTable.AddCell(cell2);
        //    PdfPCell cell3 = new PdfPCell(new Phrase("QUANTITY", boldTableFont));
        //    cell3.BackgroundColor = TabelHeaderBackGroundColor;
        //    cell3.HorizontalAlignment = Element.ALIGN_CENTER;
        //    itemTable.AddCell(cell3);
        //    PdfPCell cell4 = new PdfPCell(new Phrase("UNIT AMOUNT", boldTableFont));
        //    cell4.BackgroundColor = TabelHeaderBackGroundColor;
        //    cell4.HorizontalAlignment = Element.ALIGN_CENTER;
        //    itemTable.AddCell(cell4);
        //    PdfPCell cell5 = new PdfPCell(new Phrase("TOTAL", boldTableFont));
        //    cell5.BackgroundColor = TabelHeaderBackGroundColor;
        //    cell5.HorizontalAlignment = Element.ALIGN_CENTER;
        //    itemTable.AddCell(cell5);
        //    //foreach (DataRow row in dt.Rows)
        //    {
        //        PdfPCell numberCell = new PdfPCell(new Phrase("1", bodyFont));
        //        numberCell.HorizontalAlignment = 1;
        //        numberCell.PaddingLeft = 10f;
        //        numberCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
        //        itemTable.AddCell(numberCell);

        //        var _phrase = new Phrase();
        //        _phrase.Add(new Chunk("New Signup Subscription Plan\n", EmailFont));
        //        _phrase.Add(new Chunk("Subscription Plan description will add here.", bodyFont));
        //        PdfPCell descCell = new PdfPCell(_phrase);
        //        descCell.HorizontalAlignment = 0;
        //        descCell.PaddingLeft = 10f;
        //        descCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
        //        itemTable.AddCell(descCell);

        //        PdfPCell qtyCell = new PdfPCell(new Phrase("1", bodyFont));
        //        qtyCell.HorizontalAlignment = 1;
        //        qtyCell.PaddingLeft = 10f;
        //        qtyCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
        //        itemTable.AddCell(qtyCell);

        //        PdfPCell amountCell = new PdfPCell(new Phrase("$100", bodyFont));
        //        amountCell.HorizontalAlignment = 1;
        //        amountCell.PaddingLeft = 10f;
        //        amountCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
        //        itemTable.AddCell(amountCell);

        //        PdfPCell totalamtCell = new PdfPCell(new Phrase("$100", bodyFont));
        //        totalamtCell.HorizontalAlignment = 1;
        //        totalamtCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
        //        itemTable.AddCell(totalamtCell);

        //    }
        //    // Table footer
        //    PdfPCell totalAmtCell1 = new PdfPCell(new Phrase(""));
        //    totalAmtCell1.Border = Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER;
        //    itemTable.AddCell(totalAmtCell1);
        //    PdfPCell totalAmtCell2 = new PdfPCell(new Phrase(""));
        //    totalAmtCell2.Border = Rectangle.TOP_BORDER; //Rectangle.NO_BORDER; //Rectangle.TOP_BORDER;
        //    itemTable.AddCell(totalAmtCell2);
        //    PdfPCell totalAmtCell3 = new PdfPCell(new Phrase(""));
        //    totalAmtCell3.Border = Rectangle.TOP_BORDER; //Rectangle.NO_BORDER; //Rectangle.TOP_BORDER;
        //    itemTable.AddCell(totalAmtCell3);
        //    PdfPCell totalAmtStrCell = new PdfPCell(new Phrase("Total Amount", boldTableFont));
        //    totalAmtStrCell.Border = Rectangle.TOP_BORDER;   //Rectangle.NO_BORDER; //Rectangle.TOP_BORDER;
        //    totalAmtStrCell.HorizontalAlignment = 1;
        //    itemTable.AddCell(totalAmtStrCell);
        //    PdfPCell totalAmtCell = new PdfPCell(new Phrase("$100", boldTableFont));
        //    totalAmtCell.HorizontalAlignment = 1;
        //    itemTable.AddCell(totalAmtCell);

        //    PdfPCell cell = new PdfPCell(new Phrase("***NOTICE: A finance charge of 1.5% will be made on unpaid balances after 30 days. ***", bodyFont));
        //    cell.Colspan = 5;
        //    cell.HorizontalAlignment = 1;
        //    itemTable.AddCell(cell);
        //    pdfDoc.Add(itemTable);
        //    #endregion

        //    PdfContentByte cb = new PdfContentByte(writer);


        //    BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
        //    cb = new PdfContentByte(writer);
        //    cb = writer.DirectContent;
        //    cb.BeginText();
        //    cb.SetFontAndSize(bf, 8);
        //    cb.SetTextMatrix(pageSize.GetLeft(120), 20);
        //    cb.ShowText("Invoice was created on a computer and is valid without the signature and seal. ");
        //    cb.EndText();

        //    //Move the pointer and draw line to separate footer section from rest of page
        //    cb.MoveTo(40, pdfDoc.PageSize.GetBottom(50));
        //    cb.LineTo(pdfDoc.PageSize.Width - 40, pdfDoc.PageSize.GetBottom(50));
        //    cb.Stroke();

        //    pdfDoc.Close();
        //    DownloadPDF(PDFData);
        //}


        //#region--Download PDF
        //protected void DownloadPDF(System.IO.MemoryStream PDFData)
        //{
        //    // Clear response content & headers
        //    System.Web.HttpContext.Current.Response.Clear();
        //    System.Web.HttpContext.Current.Response.ClearContent();
        //    System.Web.HttpContext.Current.Response.ClearHeaders();
        //    System.Web.HttpContext.Current.Response.ContentType = "application/pdf";
        //    System.Web.HttpContext.Current.Response.Charset = string.Empty;
        //    System.Web.HttpContext.Current.Response.Cache.SetCacheability(System.Web.HttpCacheability.Public);
        //    System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=Invoice-{0}.pdf", "OrderNo"));
        //    System.Web.HttpContext.Current.Response.OutputStream.Write(PDFData.GetBuffer(), 0, PDFData.GetBuffer().Length);
        //    System.Web.HttpContext.Current.Response.OutputStream.Flush();
        //    System.Web.HttpContext.Current.Response.OutputStream.Close();
        //    System.Web.HttpContext.Current.Response.End();
        //}
        //#endregion
    }
}

