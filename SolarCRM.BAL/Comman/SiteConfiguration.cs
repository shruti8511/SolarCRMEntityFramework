using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;






namespace SolarCRM.BAL.Comman
{
    public class SiteConfiguration
    {
        public static string ChangeCurrency(string Price)
        {
            //StSiteConfiguration st = ClsAdminSiteConfiguration.AdminSiteConfigurationGetDataStructById("1");
            int Currencydigit = Convert.ToInt32(2);

            //string Currency = st.Symbol;

            //Price = string.Format("{0:0.000 Rs}", Convert.ToDecimal(Price));
            Price =  Convert.ToString(Math.Round(Convert.ToDecimal(Price), Currencydigit));
            return Price;
        }






        public static bool UploadPDFFile(string foldername, string filename)
        {
            GC.Collect();
            string username = ConfigurationManager.AppSettings["ClaudUsername"];
            string api_key = ConfigurationManager.AppSettings["ClaudKey"];
            string chosenContainer = ConfigurationManager.AppSettings["ClaudContainer"];
            string filePath = HttpContext.Current.Request.PhysicalApplicationPath + "/" + foldername;
            var cloudIdentity = new CloudIdentity() { APIKey = api_key, Username = username };
            var cloudFilesProvider = new CloudFilesProvider(cloudIdentity);
            //ObjectStore createContainerResponse = cloudFilesProvider.CreateContainer(chosenContainer);
            try
            {
                using (FileStream stream = System.IO.File.OpenRead(HttpContext.Current.Request.PhysicalApplicationPath + "/userfiles/" + foldername + "/" + filename))
                {
                    if (foldername != "")
                    {
                        chosenContainer = Path.Combine(chosenContainer, foldername);
                    }
                    cloudFilesProvider.CreateObject(chosenContainer, stream, filename);
                    stream.Flush();
                    stream.Close();
                }
            }
            catch
            {
            }

            return true;
        }





    }
}
