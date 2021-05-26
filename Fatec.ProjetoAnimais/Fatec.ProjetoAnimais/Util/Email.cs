using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Fatec.ProjetoAnimais.Util
{

    public static class Email
    {
        public static void enviarSenha(string email, string senha)
        {
            try
            {
                System.Web.Mail.MailMessage myMail = new System.Web.Mail.MailMessage();
                myMail.Fields.Add
                    ("http://schemas.microsoft.com/cdo/configuration/smtpserver",
                                  "smtp.gmail.com");
                myMail.Fields.Add
                    ("http://schemas.microsoft.com/cdo/configuration/smtpserverport",
                                  "465");
                myMail.Fields.Add
                    ("http://schemas.microsoft.com/cdo/configuration/sendusing",
                                  "2");
                myMail.Fields.Add
      ("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
                //Use 0 for anonymous
                myMail.Fields.Add
                ("http://schemas.microsoft.com/cdo/configuration/sendusername",
                    "portalaprendendo21@gmail.com");
                myMail.Fields.Add
                ("http://schemas.microsoft.com/cdo/configuration/sendpassword",
                     "Autismo21");
                myMail.Fields.Add
                ("http://schemas.microsoft.com/cdo/configuration/smtpusessl",
                     "true");
                myMail.From = "portalaprendendo21@gmail.com";
                myMail.To = email;
                myMail.Subject = "Senha portal aprendendo";
                myMail.BodyFormat = System.Web.Mail.MailFormat.Html;
                myMail.Body = "Sua senha do portal aprendendo é: "+senha;
                System.Web.Mail.SmtpMail.SmtpServer = "smtp.gmail.com:465";
                System.Web.Mail.SmtpMail.Send(myMail);
             
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
    }
}