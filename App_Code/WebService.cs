using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Net.Mail;


/// <summary>
/// Summary description for WebService
/// </summary>
/// 




[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string HelloWorld()
    {
       List<product> products = new List<product>();

        products.Add(new product()
            {
                id=1,
                pname="pendrive",
            });
        products.Add(new product()
        {
            id = 2,
            pname = "bag",
        });
        products.Add(new product()
        {
            id = 3,
            pname = "laptop",
        });



        DataContractJsonSerializer serializer = new DataContractJsonSerializer(products.GetType());
        MemoryStream ms = new MemoryStream();
        serializer.WriteObject(ms, products);
        string jsonString = Encoding.Default.GetString(ms.ToArray());
        ms.Close();
        return jsonString;

    }
    public class product
    {
        public int id { get; set; }
        public string pname { get; set; }
    }

    [WebMethod]
    public int sum(int a, int b)
    {
        return (a + b);
    }


    [WebMethod]
    public void sendmail(string mailadd,string msgbody,string msgsubject)
    {
         
        MailMessage Msg = new MailMessage();
        // Sender e-mail address.
        Msg.From = new MailAddress("cbhavesh34@gmail.com");
        // Recipient e-mail address.
        Msg.To.Add(mailadd);
        Msg.Subject = msgsubject;
        Msg.Body = msgbody
            ;
        // your remote SMTP server IP.
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
        smtp.Credentials = new System.Net.NetworkCredential("bhavesh.chaudhari@tops-int.com", "bm8128690758");
        smtp.EnableSsl = true;
        smtp.Send(Msg);
        Msg = null;
    }
}
