using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolarCRM.Common
{
    public class Pagging
    {
        public static List<int> GetPaggingdata(long RowCount, int CurrentPage, int PageSize)
        {
            int PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(RowCount) / PageSize));
            int FirstPage = 0;
            int LastPage = 0;
            if (CurrentPage <= 3)
                FirstPage = 1;
            else
                FirstPage = CurrentPage - 2;

            if ((PageCount - 2) <= CurrentPage)
            {
                LastPage = PageCount;
                if ((PageCount - 4) > 0)
                {
                    FirstPage = PageCount - 4;
                }
            }
            else
            {
                if (CurrentPage <= 3 && PageCount >= (CurrentPage + 2))
                {
                    // LastPage = 5;
                    //    LastPage =Convert.ToInt32( RowCount / PageSize);

                    if (RowCount <= 50)
                    {
                        LastPage = 3;
                    }
                    else if (RowCount <= 100)
                    {
                        LastPage = 5;
                    }
                    else
                    {
                        LastPage = 5;
                    }
                }

                else
                    LastPage = (CurrentPage + 2) < PageCount ? (CurrentPage + 2) : PageCount;
            }
            List<int> lstPage = new List<int>();
            for (int i = FirstPage; i <= LastPage; i++)
            {
                lstPage.Add(i);
            }
            return lstPage;
        }

       
    }
    public enum MyEnum : int
    {
        installer = 11
    }
}