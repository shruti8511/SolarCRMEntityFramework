using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.WebDownloadModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.BAL.Implementations.WebDownload
{
   public class WebDownloadManagement
    {

       public static long tblWebDownload_Insert(string Customer, string First, string Last, string Email, string Phone, string Mobile, string Address, string City, string State, string PostCode, string Source, string System, string Roof, string Angle, string Story, string HouseAge, string Notes, string SubSource)
       {
           return ( new SolarCRM.DAL.Implementations.WebDownload.WebDownloadSQL().tblWebDownload_Insert(Customer, First, Last, Email, Phone, Mobile, Address, City, State, PostCode, Source, System, Roof, Angle, Story, HouseAge, Notes, SubSource));
       }


       public static List<WebDownloadEntity> tblWebDownload_Select(PagingEntity CommonEntity, out int Count)
       {
           return (new SolarCRM.DAL.Implementations.WebDownload.WebDownloadSQL().tblWebDownload_Select(CommonEntity, out Count));
       }

    }
}
