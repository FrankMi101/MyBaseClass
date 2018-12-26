using System;
using System.Configuration;
using System.Net.Mail;

namespace MyCommon
{
    public class EmailNotice
    {
     
        public string EmailType { get; set; }
        public string EmailTo { get; set; }
        public string EmailCC { get; set; }
        public string EmailBcc { get; set; }
        public string EmailFrom { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
        public string EmailFormat { get; set; }
        public string Attachment1 { get; set; }
        public string Attachment2 { get; set; }
        public string Attachment3 { get; set; }

    }
    public class SMTPMail
    {
//        public static void SendMail(string Mail_Server, string Mail_Body, string Mail_To, string Mail_CC, string Mail_BCC, string Mail_From, string Mail_Subject, string Mail_Format)
//        {
//            try
//            {

//                System.Net.Mail.MailMessage Mailmsg = new System.Net.Mail.MailMessage();
//                Mailmsg.To.Clear();

//                if (Mail_To.IndexOf("@") > 0)
//                {
//                    if (Mail_To.IndexOf(";") > 0)
//                    {
//                        foreach (string cAddress in Mail_To.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
//                        {
//                            MailAddress myToAddress = new MailAddress(cAddress, "Custom display name");
//                            Mailmsg.To.Add(myToAddress);
//                        }
//                    }
//                    else
//                    {
//                        Mailmsg.To.Add(new System.Net.Mail.MailAddress(Mail_To));
//                    }
//                }

//                if (Mail_CC.IndexOf("@") > 0)
//                {

//                    foreach (string cAddress in Mail_CC.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
//                    {
//                        MailAddress myCCAddress = new MailAddress(cAddress, "Custom display name");
//                        Mailmsg.CC.Add(myCCAddress);
//                    }

//                }
//                if (Mail_BCC.IndexOf("@") > 0)
//                {

//                    foreach (string cAddress in Mail_BCC.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
//                    {
//                        MailAddress myCCAddress = new MailAddress(cAddress, "Custom display name");
//                        Mailmsg.Bcc.Add(myCCAddress);
//                    }

//                }
//                if (Mail_From.IndexOf("@") > 0)
//                {
//                    MailAddress myFromAddress = new MailAddress(Mail_From);  //, "Custom display name");
//                    Mailmsg.Bcc.Add(myFromAddress);
//                }

//                Mailmsg.Subject = Mail_Subject;
//                Mailmsg.Priority = MailPriority.High;
//                if (Mail_Format == "HTML")
//                {
//                    Mailmsg.IsBodyHtml = true;
//                }
//                Mailmsg.Body = Mail_Body;
//                try
//                {
//                    System.Net.Mail.SmtpClient myMail = new System.Net.Mail.SmtpClient();
//                    myMail.Host = Mail_Server;
//                    myMail.Send(Mailmsg);
//                }
//#pragma warning disable CS0168 // The variable 'ex' is declared but never used
//                catch (Exception ex)
//#pragma warning restore CS0168 // The variable 'ex' is declared but never used
//                {
                    
//                }
//                finally
//                {
//                    Mailmsg.Dispose();
//                }

//            }

//#pragma warning disable CS0168 // The variable 'ex' is declared but never used
//            catch (Exception ex)
//#pragma warning restore CS0168 // The variable 'ex' is declared but never used
//            {
                
//            }
          
//        }

//        public static void SendMail(string Mail_Server, string Mail_Body, string Mail_To, string Mail_CC, string Mail_BCC, string Mail_From, string Mail_Subject, string Mail_Format ,  string Mail_attachement)
//        {
//            try
//            {
//                System.Net.Mail.MailMessage Mailmsg = new System.Net.Mail.MailMessage();
//                Mailmsg.To.Clear();

//                if (Mail_To.IndexOf("@") > 0)
//                {
//                    if (Mail_To.IndexOf(";") > 0)
//                    {
//                        foreach (string cAddress in Mail_To.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
//                        {
//                            MailAddress myToAddress = new MailAddress(cAddress, "Custom display name");
//                            Mailmsg.To.Add(myToAddress);
//                        }
//                    }
//                    else
//                    {
//                        Mailmsg.To.Add(new System.Net.Mail.MailAddress(Mail_To));
//                    }
//                }

//                if (Mail_CC.IndexOf("@") > 0)
//                {

//                    foreach (string cAddress in Mail_CC.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
//                    {
//                        MailAddress myCCAddress = new MailAddress(cAddress, "Custom display name");
//                        Mailmsg.CC.Add(myCCAddress);
//                    }

//                }
//                if (Mail_BCC.IndexOf("@") > 0)
//                {

//                    foreach (string cAddress in Mail_BCC.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
//                    {
//                        MailAddress myCCAddress = new MailAddress(cAddress, "Custom display name");
//                        Mailmsg.Bcc.Add(myCCAddress);
//                    }

//                }
//                if (Mail_From.IndexOf("@") > 0)
//                {
//                    MailAddress myFromAddress = new MailAddress(Mail_From);  //, "Custom display name");
//                    Mailmsg.Bcc.Add(myFromAddress);
//                }


//                Mailmsg.Subject = Mail_Subject;
//                Mailmsg.Priority = MailPriority.High;
//                if (Mail_Format == "HTML")
//                {
//                    Mailmsg.IsBodyHtml = true;
//                }

//                Mailmsg.Body = Mail_Body;

//                System.Net.Mail.Attachment myAttachment =  new System.Net.Mail.Attachment(Mail_attachement);

//                Mailmsg.Attachments.Add(myAttachment);


//                try
//                {
//                    System.Net.Mail.SmtpClient myMail = new System.Net.Mail.SmtpClient();
//                    myMail.Host = Mail_Server;

//                    myMail.Send(Mailmsg);
//                }
//#pragma warning disable CS0168 // The variable 'ex' is declared but never used
//                catch (Exception ex)
//#pragma warning restore CS0168 // The variable 'ex' is declared but never used
//                {
                    
//                }
//                finally
//                {
//                    Mailmsg.Dispose();
//                }

//            }

//#pragma warning disable CS0168 // The variable 'ex' is declared but never used
//            catch (Exception ex)
//#pragma warning restore CS0168 // The variable 'ex' is declared but never used
//            {
               
//            }

//        }


        public static string SendEmail(EmailNotice mailItems)
        {
            string result = "Failed";

          

            System.Net.Mail.SmtpClient myMail = new System.Net.Mail.SmtpClient();
            myMail.Host = ConfigurationManager.AppSettings["SMTPServer"];

            System.Net.Mail.MailMessage Mailmsg = new System.Net.Mail.MailMessage();
            try
            {

                Mailmsg = GetEmailMsg(mailItems);

                myMail.Send(Mailmsg);
                result = "Successfully";
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return "Failed";
            }
            Mailmsg.Dispose();
            return result;
    

        }
        private static System.Net.Mail.MailMessage GetEmailMsg(EmailNotice mailItems)
        {

            try
            {
                System.Net.Mail.MailMessage Mailmsg = new System.Net.Mail.MailMessage();
                Mailmsg.To.Clear();
                LoopAddress("mailTo", mailItems.EmailTo, ref Mailmsg);
                LoopAddress("mailCC", mailItems.EmailCC, ref Mailmsg);
                LoopAddress("mailBCC", mailItems.EmailBcc, ref Mailmsg);
                LoopAddress("mailFrom", mailItems.EmailFrom, ref Mailmsg);


                Mailmsg.Subject = mailItems.EmailSubject;
                Mailmsg.Priority = MailPriority.High;
                if (mailItems.EmailFormat == "HTML")
                { Mailmsg.IsBodyHtml = true; }
                Mailmsg.Body =  mailItems.EmailBody;
                if (mailItems.Attachment1 != "")
                {
                    System.Net.Mail.Attachment myAttachment1 = new System.Net.Mail.Attachment(mailItems.Attachment1);
                    Mailmsg.Attachments.Add(myAttachment1);
                }
                if (mailItems.Attachment2 != "")
                {
                    System.Net.Mail.Attachment myAttachment2 = new System.Net.Mail.Attachment(mailItems.Attachment2);
                    Mailmsg.Attachments.Add(myAttachment2);
                }
                if (mailItems.Attachment3 != "")
                {
                    System.Net.Mail.Attachment myAttachment3 = new System.Net.Mail.Attachment(mailItems.Attachment3);
                    Mailmsg.Attachments.Add(myAttachment3);
                }
                return Mailmsg;

            }
            catch
            {
                return null;
            }

        }


        private static void LoopAddress(string Type, string eMailADD, ref System.Net.Mail.MailMessage Mailmsg)
        {
            if (eMailADD.IndexOf("@") > 0)
            {
                string[] myArray = eMailADD.Split(';');
                for (int x = 0; x < myArray.Length; x++)
                {
                    try
                    {
                        AddAddress(Type, myArray[x], ref Mailmsg);
                    }
                    catch
                    { }
                }
            }
            else
            { }
        }
        private static void AddAddress(string addType, string eMailADD, ref System.Net.Mail.MailMessage Mailmsg)
        {
            try
            {
                if (eMailADD.IndexOf("@") > 0)
                {

                    switch (addType)
                    {
                        case "mailTo":
                            Mailmsg.To.Add(new System.Net.Mail.MailAddress(eMailADD));
                            break;
                        case "mailCC":
                            Mailmsg.CC.Add(new System.Net.Mail.MailAddress(eMailADD));
                            break;
                        case "mailBcc":
                            Mailmsg.Bcc.Add(new System.Net.Mail.MailAddress(eMailADD));
                            break;
                        default:
                            Mailmsg.From = new System.Net.Mail.MailAddress(eMailADD);
                            break;
                    }
                }

            }
            catch { }

        }

    }
}
