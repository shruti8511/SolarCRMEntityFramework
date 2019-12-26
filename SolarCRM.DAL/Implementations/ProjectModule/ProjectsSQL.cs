

namespace SolarCRM.DAL.Implementations.ProjectModule
{
    using SolarCRM.Entity.Models.Common;
    using SolarCRM.Entity.Models.ProjectModule;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class ProjectsSQL : BaseSqlManager
    {
        public virtual long tblProjects_Insert(ProjectsEntity ProEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProjects_Insert";
            cmdAdd.Parameters.AddWithValue("@CustomerID", ProEntity.CustomerID);
            cmdAdd.Parameters.AddWithValue("@ContactID", ProEntity.ContactID);
            cmdAdd.Parameters.AddWithValue("@EmployeeID", ProEntity.EmployeeID);
            cmdAdd.Parameters.AddWithValue("@SalesRep", ProEntity.SalesRep);
            cmdAdd.Parameters.AddWithValue("@ProjectTypeID", ProEntity.ProjectTypeID);
            cmdAdd.Parameters.AddWithValue("@OldProjectNumber", ProEntity.OldProjectNumber);
            cmdAdd.Parameters.AddWithValue("@ManualQuoteNumber", ProEntity.ManualQuoteNumber);
            cmdAdd.Parameters.AddWithValue("@ProjectOpened", ProEntity.ProjectOpened);
            cmdAdd.Parameters.AddWithValue("@Project", ProEntity.Project);
            cmdAdd.Parameters.AddWithValue("@InstallAddress", ProEntity.InstallAddress);
            cmdAdd.Parameters.AddWithValue("@InstallArea", ProEntity.InstallArea);
            cmdAdd.Parameters.AddWithValue("@InstallCity", ProEntity.InstallCity);
            cmdAdd.Parameters.AddWithValue("@InstallState", ProEntity.InstallState);
            cmdAdd.Parameters.AddWithValue("@InstallPostCode", ProEntity.InstallPostCode);
            cmdAdd.Parameters.AddWithValue("@ProjectNotes", ProEntity.ProjectNotes);
            cmdAdd.Parameters.AddWithValue("@InstallerNotes", ProEntity.InstallerNotes);
            cmdAdd.Parameters.AddWithValue("@MeterInstallerNotes", ProEntity.MeterInstallerNotes);
            cmdAdd.Parameters.AddWithValue("@ProjectStatusID", ProEntity.ProjectStatusID);

            cmdAdd.Parameters.AddWithValue("@ProjectMgr", ProEntity.ProjectMgr);
            cmdAdd.Parameters.AddWithValue("@CompanyLocationID", ProEntity.CompanyLocationID);
            cmdAdd.Parameters.AddWithValue("@ProjectEnteredBy", ProEntity.ProjectEnteredBy);
            cmdAdd.Parameters.AddWithValue("@UpdateDate", ProEntity.UpdateDate);
            cmdAdd.Parameters.AddWithValue("@UpdateBy", ProEntity.UpdateBy);


            long ProjectID = Convert.ToInt64(ExecuteScalar(cmdAdd));
            //long CustomerID = ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();
            return ProjectID;
        }

        public virtual void tblTrackProjStatus_Insert(int ProjectStatusID, long ProjectID, long EmpID, int NumberPanels)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblTrackProjStatus_Insert";
            cmdAdd.Parameters.AddWithValue("@ProjectStatusID", ProjectStatusID);
            cmdAdd.Parameters.AddWithValue("@ProjectID", ProjectID);
            cmdAdd.Parameters.AddWithValue("@EmployeeID", EmpID);
            cmdAdd.Parameters.AddWithValue("@NumberPanels", NumberPanels);

            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();
        }

        public virtual List<ProjectsEntity> tblProjects_SelectByCustomerID(PagingEntity CommonEntity,long CustomerID, out int Count)
        {
            List<ProjectsEntity> lstCustomers = new List<ProjectsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjects_SelectByCustomerID";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ProjectsEntity objEntity = new ProjectsEntity();
                objEntity.ProjectID = GetInt64(dr, "ProjectID");
                objEntity.ProjectNumber = GetInt64(dr, "ProjectNumber");
                objEntity.ProjectAddress = GetTextValue(dr, "ProjectAddress");
                objEntity.ProjectStatus = GetTextValue(dr, "ProjectStatus");
                objEntity.ProjectType = GetTextValue(dr, "ProjectType");
                objEntity.EmployeeName = GetTextValue(dr, "EmployeeName");
                objEntity.UpdateName = GetTextValue(dr, "UpdateName");
                

                lstCustomers.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstCustomers;
        }

        public virtual ProjectsEntity tblProjects_SelectReferral(long ProjectNumber)
        {
            ProjectsEntity lstCustomers = new ProjectsEntity();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjects_SelectReferral";
            cmdGet.Parameters.AddWithValue("@ProjectNumber", ProjectNumber);
           
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ProjectsEntity objEntity = new ProjectsEntity();
            while (dr.Read())
            {
               
                objEntity.ProjectID = GetInt64(dr, "ProjectID");
                objEntity.ProjectNumber = GetInt64(dr, "ProjectNumber");
                
            }
            dr.Close();
            ForceCloseConnection();
            return lstCustomers;
        }

        public virtual void tblProjects_UpdateFormsSolar(long ProjectID)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProjects_UpdateFormsSolar";
            cmdAdd.Parameters.AddWithValue("@ProjectID", ProjectID);
           
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();
            
        }

        public virtual void tblProjects_UpdateFormsSolarUG(long ProjectID)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProjects_UpdateFormsSolarUG";
            cmdAdd.Parameters.AddWithValue("@ProjectID", ProjectID);

            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();
        }

        public virtual ProjectsEntity tblProjects_SelectByProjectID(long ProjectID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjects_SelectByProjectID";
            cmdGet.Parameters.AddWithValue("@ProjectID", ProjectID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ProjectsEntity details = new ProjectsEntity();
            while (dr.Read())
            {
                details.ProjectID = GetInt64(dr, "ProjectID");
                details.EmployeeID = GetInt32(dr, "EmployeeID");
                details.ProjectMgr = GetInt64(dr, "ProjectMgr");
                details.ContactID = GetInt64(dr, "ContactID");
                details.SalesRep = GetInt64(dr, "SalesRep");
                details.CustomerID = GetInt64(dr, "CustomerID");
                details.ProjectStatusID = GetInt32(dr, "ProjectStatusID");
                details.ProjectNumber = GetInt64(dr, "ProjectNumber");
                details.ProjectTypeID = GetInt32(dr, "ProjectTypeID");
                details.BasicSystemCost = GetDecimal(dr, "BasicSystemCost");
                details.TotalQuotePrice = GetDecimal(dr, "TotalQuotePrice");
                details.InstallState = GetTextValue(dr, "InstallState");
              
               
            }
            dr.Close();
            ForceCloseConnection();
            return details;
        }

        public virtual void tblProjectsSalesInput_Insert(ProjectsEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProjectsSalesInput_Insert";
            cmdAdd.Parameters.AddWithValue("@ProjectID", ObjEntity.ProjectID);
            cmdAdd.Parameters.AddWithValue("@ProjectManegerID", ObjEntity.ProjectManegerID);
            cmdAdd.Parameters.AddWithValue("@CustomerID", ObjEntity.CustomerID);         
            cmdAdd.Parameters.AddWithValue("@EmployeeID", ObjEntity.EmployeeID);
            cmdAdd.Parameters.AddWithValue("@FollowUpDate", ObjEntity.FollowUpDate);
            cmdAdd.Parameters.AddWithValue("@ContactID", ObjEntity.ContactID);
            cmdAdd.Parameters.AddWithValue("@ManualQuoteNumber", ObjEntity.ManualQuoteNumber);
            cmdAdd.Parameters.AddWithValue("@FollowUpNote", ObjEntity.FollowUpNote);
            cmdAdd.Parameters.AddWithValue("@PanelBrandID", ObjEntity.PanelBrandID);
            cmdAdd.Parameters.AddWithValue("@NumberPanels", ObjEntity.NumberPanels);
            cmdAdd.Parameters.AddWithValue("@InverterDetailsID", ObjEntity.InverterDetailsID);
            cmdAdd.Parameters.AddWithValue("@SecondInverterDetailsID", ObjEntity.SecondInverterDetailsID);
            cmdAdd.Parameters.AddWithValue("@InverterModel", ObjEntity.InverterModel);
            cmdAdd.Parameters.AddWithValue("@InverterCert", ObjEntity.InverterCert);
            cmdAdd.Parameters.AddWithValue("@SystemCapKW", ObjEntity.SystemCapKW);
            cmdAdd.Parameters.AddWithValue("@PerKWCost", ObjEntity.PerKWCost);
            cmdAdd.Parameters.AddWithValue("@BasicSystemCost", ObjEntity.BasicSystemCost);
            cmdAdd.Parameters.AddWithValue("@OtherCost", ObjEntity.OtherCost);
            cmdAdd.Parameters.AddWithValue("@SpecialDiscount", ObjEntity.SpecialDiscount);
            cmdAdd.Parameters.AddWithValue("@CGST", ObjEntity.CGST);
            cmdAdd.Parameters.AddWithValue("@SGST", ObjEntity.SGST);
            cmdAdd.Parameters.AddWithValue("@IGST", ObjEntity.IGST);
            cmdAdd.Parameters.AddWithValue("@TotalQuotePrice", ObjEntity.TotalQuotePrice);
            cmdAdd.Parameters.AddWithValue("@DepositRequired", ObjEntity.DepositRequired);
            cmdAdd.Parameters.AddWithValue("@HouseTypeID", ObjEntity.HouseTypeID);
            cmdAdd.Parameters.AddWithValue("@VarHouseType", ObjEntity.VarHouseType);
            cmdAdd.Parameters.AddWithValue("@RoofTypeID", ObjEntity.RoofTypeID);
            cmdAdd.Parameters.AddWithValue("@VarRoofType", ObjEntity.VarRoofType);
            cmdAdd.Parameters.AddWithValue("@RoofAngleID", ObjEntity.RoofAngleID);
            cmdAdd.Parameters.AddWithValue("@VarRoofAngle", ObjEntity.VarRoofAngle);
            cmdAdd.Parameters.AddWithValue("@MeterInstallation", ObjEntity.MeterInstallation);
            cmdAdd.Parameters.AddWithValue("@VarMeterInstallation", ObjEntity.VarMeterInstallation);
            cmdAdd.Parameters.AddWithValue("@MeterPhase", ObjEntity.MeterPhase);
            cmdAdd.Parameters.AddWithValue("@MeterNumber", ObjEntity.MeterNumber);
            cmdAdd.Parameters.AddWithValue("@OffPeak", ObjEntity.OffPeak);
            cmdAdd.Parameters.AddWithValue("@ElecDistributorID", ObjEntity.ElecDistributorID);
            cmdAdd.Parameters.AddWithValue("@MeterEnoughSpace", ObjEntity.MeterEnoughSpace);
            cmdAdd.Parameters.AddWithValue("@ElecRetailerID", ObjEntity.ElecRetailerID);
            cmdAdd.Parameters.AddWithValue("@STCNumber", ObjEntity.STCNumber);
            cmdAdd.Parameters.AddWithValue("@PeakMeterNumber", ObjEntity.PeakMeterNumber);
            cmdAdd.Parameters.AddWithValue("@QuoteAccepted", ObjEntity.QuoteAccepted);
            cmdAdd.Parameters.AddWithValue("@SignedQuote", ObjEntity.SignedQuote);
            cmdAdd.Parameters.AddWithValue("@QuoteSent", ObjEntity.QuoteSent);
            cmdAdd.Parameters.AddWithValue("@QuotationNotes", ObjEntity.QuotationNotes);
            cmdAdd.Parameters.AddWithValue("@ProjectNotes", ObjEntity.ProjectNotes);
            cmdAdd.Parameters.AddWithValue("@MeterBoxPhotosSaved", ObjEntity.MeterBoxPhotosSaved);
            cmdAdd.Parameters.AddWithValue("@ElecBillSaved", ObjEntity.ElecBillSaved);
            cmdAdd.Parameters.AddWithValue("@SiteMap", ObjEntity.SiteMap);
            cmdAdd.Parameters.AddWithValue("@PaymentReceipt", ObjEntity.PaymentReceipt);
            cmdAdd.Parameters.AddWithValue("@MeterApproval", ObjEntity.MeterApproval); 
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblProjectsSalesInput_ProjectIDExists(long ProjectID)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectsSalesInput_ProjectIDExists";
            cmdGet.Parameters.AddWithValue("@ProjectID", ProjectID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "ProjectID");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual List<ProjectsEntity> tblProjects_Select(PagingEntity CommonEntity, out int Count)
        {
            List<ProjectsEntity> lstprojects = new List<ProjectsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjects_Select";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ProjectsEntity objEntity = new ProjectsEntity();
                objEntity.ProjectID = GetInt64(dr, "ProjectID");
                objEntity.ProjectNumber = GetInt64(dr, "ProjectNumber");
                objEntity.ManualQuoteNumber = GetTextValue(dr, "ManualQuoteNumber");
                objEntity.ProjectType = GetTextValue(dr, "ProjectType");
                objEntity.ProjectStatus = GetTextValue(dr, "ProjectStatus");
                objEntity.CustomerName = GetTextValue(dr, "CustomerName");
                objEntity.ContactNO = GetTextValue(dr, "ContPhone");
                objEntity.ProjectOpened = GetDateTime(dr, "ProjectOpened");
                objEntity.Location = GetTextValue(dr, "BranchLocation");
                objEntity.InstallArea = GetTextValue(dr, "InstallArea");
                objEntity.InstallCity = GetTextValue(dr, "InstallCity");
                objEntity.InstallState = GetTextValue(dr, "InstallState");
                objEntity.InstallerNotes = GetTextValue(dr, "InstallerNotes");
                objEntity.UpdateBy = GetInt32(dr, "UpdateBy");

                lstprojects.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstprojects;
        }

        public virtual List<ProjectsEntity> tblProjects_SelectSearch(PagingEntity CommonEntity, string Searchkeyword, out int Count)
        {
            List<ProjectsEntity> lstprojects = new List<ProjectsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjects_SelectSearch";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            cmdGet.Parameters.AddWithValue("@searchkeyword", Searchkeyword);

            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ProjectsEntity objEntity = new ProjectsEntity();
                objEntity.ProjectID = GetInt64(dr, "ProjectID");
                objEntity.ProjectNumber = GetInt64(dr, "ProjectNumber");
                objEntity.ManualQuoteNumber = GetTextValue(dr, "ManualQuoteNumber");
                objEntity.ProjectType = GetTextValue(dr, "ProjectType");
                objEntity.ProjectStatus = GetTextValue(dr, "ProjectStatus");
                objEntity.CustomerName = GetTextValue(dr, "CustomerName");
                objEntity.ContactNO = GetTextValue(dr, "ContPhone");
                objEntity.ProjectOpened = GetDateTime(dr, "ProjectOpened");
                objEntity.Location = GetTextValue(dr, "BranchLocation");
                objEntity.InstallArea = GetTextValue(dr, "InstallArea");
                objEntity.InstallCity = GetTextValue(dr, "InstallCity");
                objEntity.InstallState = GetTextValue(dr, "InstallState");
                objEntity.InstallerNotes = GetTextValue(dr, "InstallerNotes");
                objEntity.UpdateBy = GetInt32(dr, "UpdateBy");

                lstprojects.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstprojects;
        }

        public virtual long tblProjectQuotes_Insert(long ProjectID, long ProjectNumber, long EmployeeID, decimal BasicSystemCost, decimal TotalQuotePrice )
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProjectQuotes_Insert";
            cmdAdd.Parameters.AddWithValue("@ProjectID", ProjectID);
            cmdAdd.Parameters.AddWithValue("@ProjectNumber", ProjectNumber);
            cmdAdd.Parameters.AddWithValue("@EmployeeID", EmployeeID);  
            cmdAdd.Parameters.AddWithValue("@BasicSystemCost",BasicSystemCost);
            cmdAdd.Parameters.AddWithValue("@TotalQuotePrice",TotalQuotePrice);
          
            long ID = Convert.ToInt64(ExecuteScalar(cmdAdd));          
            ForceCloseConnection();
            return ID;
        }

        public virtual long tblProjectsInstallationDocuments_Insert(long ProjectID, long ProjectNumber, string DocumentType)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProjectsInstallationDocuments_Insert";
            cmdAdd.Parameters.AddWithValue("@ProjectID", ProjectID);
            cmdAdd.Parameters.AddWithValue("@ProjectNumber", ProjectNumber);
            cmdAdd.Parameters.AddWithValue("@DocumentType", DocumentType);  
          
            long ID = Convert.ToInt64(ExecuteScalar(cmdAdd));          
            ForceCloseConnection();
            return ID;
        }

        public virtual long tblProjectQuotes_UpdateProjectQuoteDoc(long ProjectQuoteID, string QuoteDoc)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProjectQuotes_UpdateProjectQuoteDoc";
            cmdAdd.Parameters.AddWithValue("@ProjectQuoteID", ProjectQuoteID);
            cmdAdd.Parameters.AddWithValue("@QuoteDoc", QuoteDoc);           
            //long ID = Convert.ToInt64(ExecuteScalar(cmdAdd));
            //ForceCloseConnection();
            //return ID;


            int result = -1;
            result = ExecuteNonQuery(cmdAdd);
            try
            {
            }
            catch
            {
            }
            return (Convert.ToInt64( result != -1));
        }
        public virtual long tblProjectsInstallationDocuments_Update(long ProjectInstallationLetterID, string QuoteDoc)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProjectsInstallationDocuments_Update";
            cmdAdd.Parameters.AddWithValue("@ProjectInstallationLetterID", ProjectInstallationLetterID);
            cmdAdd.Parameters.AddWithValue("@QuoteDoc", QuoteDoc);           
        


            int result = -1;
            result = ExecuteNonQuery(cmdAdd);
            try
            {
            }
            catch
            {
            }
            return (Convert.ToInt64( result != -1));
        }
        
        public virtual List<ProjectsEntity> tblProjectQuotes_SelectByProjectID(long ProjectID)
        {
            List<ProjectsEntity> lstLocation = new List<ProjectsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectQuotes_SelectByProjectID";
            cmdGet.Parameters.AddWithValue("@ProjectID", ProjectID);     
            SqlDataReader dr = ExecuteDataReader(cmdGet);
           
            while (dr.Read())
            {
                ProjectsEntity objEntity = new ProjectsEntity();
                objEntity.ProjectQuoteID = GetInt32(dr, "ProjectQuoteID");
                objEntity.ProjectID = GetInt64(dr, "ProjectID");
                objEntity.ProjectNumber = GetInt32(dr, "ProjectNumber");
                objEntity.ProjectQuoteDate = GetDateTime(dr, "ProjectQuoteDate");
                objEntity.ProjectQuoteDoc = GetInt32(dr, "ProjectQuoteDoc");
                objEntity.TotalQuotePrice = GetInt64(dr, "TotalQuotePrice");                  
                lstLocation.Add(objEntity);
            }
            dr.Close();         
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual ProjectsEntity tblProjectsSalesInput_SelectByProjectID(long ProjectID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectsSalesInput_SelectByProjectID";
            cmdGet.Parameters.AddWithValue("@ProjectID", ProjectID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ProjectsEntity details = new ProjectsEntity();
            while (dr.Read())
            {
                details.ProjectID = GetInt64(dr, "ProjectID");
                details.EmployeeID = GetInt32(dr, "EmployeeID");               
                details.ContactID = GetInt64(dr, "ContactID");            
                details.SystemCapKW = GetDecimal(dr, "SystemCapKW");
                details.PerKWCost = GetDecimal(dr, "PerKWCost");
                details.CGST = GetDecimal(dr, "CGST");
                details.SGST = GetDecimal(dr, "SGST");
                details.IGST = GetDecimal(dr, "IGST");
                details.BasicSystemCost = GetDecimal(dr, "BasicSystemCost");
                

            }
            dr.Close();
            ForceCloseConnection();
            return details;
        }


        public virtual void tblProjectsSalesInput_Update(ProjectsEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProjectsSalesInput_Update";
            cmdAdd.Parameters.AddWithValue("@ProjectID", ObjEntity.ProjectID);
            cmdAdd.Parameters.AddWithValue("@ProjectManegerID", ObjEntity.ProjectManegerID);
            cmdAdd.Parameters.AddWithValue("@CustomerID", ObjEntity.CustomerID); 
            cmdAdd.Parameters.AddWithValue("@EmployeeID", ObjEntity.EmployeeID);
            cmdAdd.Parameters.AddWithValue("@FollowUpDate", ObjEntity.FollowUpDate);
            cmdAdd.Parameters.AddWithValue("@ContactID", ObjEntity.ContactID);
            cmdAdd.Parameters.AddWithValue("@ManualQuoteNumber", ObjEntity.ManualQuoteNumber);
            cmdAdd.Parameters.AddWithValue("@FollowUpNote", ObjEntity.FollowUpNote);
            cmdAdd.Parameters.AddWithValue("@PanelBrandID", ObjEntity.PanelBrandID);
            cmdAdd.Parameters.AddWithValue("@NumberPanels", ObjEntity.NumberPanels);
            cmdAdd.Parameters.AddWithValue("@InverterDetailsID", ObjEntity.InverterDetailsID);
            cmdAdd.Parameters.AddWithValue("@SecondInverterDetailsID", ObjEntity.SecondInverterDetailsID);
            cmdAdd.Parameters.AddWithValue("@InverterModel", ObjEntity.InverterModel);
            cmdAdd.Parameters.AddWithValue("@InverterCert", ObjEntity.InverterCert);
            cmdAdd.Parameters.AddWithValue("@SystemCapKW", ObjEntity.SystemCapKW);
            cmdAdd.Parameters.AddWithValue("@PerKWCost", ObjEntity.PerKWCost);
            cmdAdd.Parameters.AddWithValue("@BasicSystemCost", ObjEntity.BasicSystemCost);
            cmdAdd.Parameters.AddWithValue("@OtherCost", ObjEntity.OtherCost);
            cmdAdd.Parameters.AddWithValue("@SpecialDiscount", ObjEntity.SpecialDiscount);
            cmdAdd.Parameters.AddWithValue("@CGST", ObjEntity.CGST);
            cmdAdd.Parameters.AddWithValue("@SGST", ObjEntity.SGST);
            cmdAdd.Parameters.AddWithValue("@IGST", ObjEntity.IGST);
            cmdAdd.Parameters.AddWithValue("@TotalQuotePrice", ObjEntity.TotalQuotePrice);
            cmdAdd.Parameters.AddWithValue("@DepositRequired", ObjEntity.DepositRequired);
            cmdAdd.Parameters.AddWithValue("@HouseTypeID", ObjEntity.HouseTypeID);
            cmdAdd.Parameters.AddWithValue("@VarHouseType", ObjEntity.VarHouseType);
            cmdAdd.Parameters.AddWithValue("@RoofTypeID", ObjEntity.RoofTypeID);
            cmdAdd.Parameters.AddWithValue("@VarRoofType", ObjEntity.VarRoofType);
            cmdAdd.Parameters.AddWithValue("@RoofAngleID", ObjEntity.RoofAngleID);
            cmdAdd.Parameters.AddWithValue("@VarRoofAngle", ObjEntity.VarRoofAngle);
            cmdAdd.Parameters.AddWithValue("@MeterInstallation", ObjEntity.MeterInstallation);
            cmdAdd.Parameters.AddWithValue("@VarMeterInstallation", ObjEntity.VarMeterInstallation);
            cmdAdd.Parameters.AddWithValue("@MeterPhase", ObjEntity.MeterPhase);
            cmdAdd.Parameters.AddWithValue("@MeterNumber", ObjEntity.MeterNumber);
            cmdAdd.Parameters.AddWithValue("@OffPeak", ObjEntity.OffPeak);
            cmdAdd.Parameters.AddWithValue("@ElecDistributorID", ObjEntity.ElecDistributorID);
            cmdAdd.Parameters.AddWithValue("@MeterEnoughSpace", ObjEntity.MeterEnoughSpace);
            cmdAdd.Parameters.AddWithValue("@ElecRetailerID", ObjEntity.ElecRetailerID);
            cmdAdd.Parameters.AddWithValue("@STCNumber", ObjEntity.STCNumber);
            cmdAdd.Parameters.AddWithValue("@PeakMeterNumber", ObjEntity.PeakMeterNumber);
            cmdAdd.Parameters.AddWithValue("@QuoteAccepted", ObjEntity.QuoteAccepted);
            cmdAdd.Parameters.AddWithValue("@SignedQuote", ObjEntity.SignedQuote);
            cmdAdd.Parameters.AddWithValue("@QuoteSent", ObjEntity.QuoteSent);
            cmdAdd.Parameters.AddWithValue("@QuotationNotes", ObjEntity.QuotationNotes);
            cmdAdd.Parameters.AddWithValue("@ProjectNotes", ObjEntity.ProjectNotes);
            cmdAdd.Parameters.AddWithValue("@MeterBoxPhotosSaved", ObjEntity.MeterBoxPhotosSaved);
            cmdAdd.Parameters.AddWithValue("@ElecBillSaved", ObjEntity.ElecBillSaved);
            cmdAdd.Parameters.AddWithValue("@SiteMap", ObjEntity.SiteMap);
            cmdAdd.Parameters.AddWithValue("@PaymentReceipt", ObjEntity.PaymentReceipt);
            cmdAdd.Parameters.AddWithValue("@MeterApproval", ObjEntity.MeterApproval);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual ProjectsEntity tblProjectsSalesInputByProjectID(long ProjectID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectsSalesInputByProjectID";
            cmdGet.Parameters.AddWithValue("@ProjectID", ProjectID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ProjectsEntity details = new ProjectsEntity();
            while (dr.Read())
            {
                details.ProjectSalesInputID = GetInt32(dr, "ProjectSalesInputID");
                details.ProjectID = GetInt32(dr, "ProjectID");
                details.ProjectManegerID = GetInt32(dr, "ProjectManegerID");
                details.EmployeeID = GetInt32(dr, "EmployeeID");
                details.FollowUpDate = Convert.ToDateTime(GetTextValue(dr, "FollowUpDate"));
                details.ContactID = GetInt32(dr, "ContactID");
                details.ManualQuoteNumber = GetTextValue(dr, "ManualQuoteNumber");
                details.PanelBrandID = GetInt32(dr, "PanelBrandID");
                details.NumberPanels = GetInt32(dr, "NumberPanels");
                details.InverterDetailsID = GetInt32(dr, "InverterDetailsID");
                details.SecondInverterDetailsID = GetInt32(dr, "SecondInverterDetailsID");
                details.InverterModel = GetTextValue(dr, "InverterModel");
                details.InverterCert = GetTextValue(dr, "InverterCert");
                details.SystemCapKW = Convert.ToDecimal(GetTextValue(dr, "SystemCapKW"));
                details.PerKWCost = Convert.ToDecimal(GetTextValue(dr, "PerKWCost"));
                details.BasicSystemCost = GetInt32(dr, "BasicSystemCost");
                details.CGST = Convert.ToDecimal(GetTextValue(dr, "CGST"));
                details.IGST = Convert.ToDecimal(GetTextValue(dr, "IGST"));
                details.OtherCost = Convert.ToDecimal(GetTextValue(dr, "OtherCost"));
                details.SpecialDiscount = Convert.ToDecimal(GetTextValue(dr, "SpecialDiscount"));
                details.TotalQuotePrice = GetInt32(dr, "TotalQuotePrice");
                details.DepositRequired = Convert.ToDecimal(GetTextValue(dr, "DepositRequired"));
                details.HouseTypeID = GetInt32(dr, "HouseTypeID");
                details.VarHouseType = Convert.ToDecimal(GetTextValue(dr, "VarHouseType"));
                details.RoofTypeID = GetInt32(dr, "RoofTypeID");
                details.VarRoofType = Convert.ToDecimal(GetInt32(dr, "VarRoofType"));
                details.RoofAngleID = GetInt32(dr, "RoofAngleID");
                details.VarRoofAngle = Convert.ToDecimal(GetTextValue(dr, "VarRoofAngle"));
                details.MeterInstallation = GetInt32(dr, "MeterInstallation");
                details.VarMeterInstallation = Convert.ToDecimal(GetTextValue(dr, "VarMeterInstallation"));
                details.MeterPhase = GetInt32(dr, "MeterPhase");
                details.MeterNumber = GetTextValue(dr, "MeterNumber");
                details.OffPeak = GetBoolean(dr, "OffPeak");
                details.ElecDistributorID = GetInt32(dr, "ElecDistributorID");
                details.MeterEnoughSpace = GetBoolean(dr, "MeterEnoughSpace");
                details.ElecRetailerID = GetInt32(dr, "ElecRetailerID");
                details.STCNumber = GetTextValue(dr, "STCNumber");
                details.PeakMeterNumber = GetTextValue(dr, "PeakMeterNumber");
                details.QuoteAccepted = Convert.ToDateTime(GetTextValue(dr, "QuoteAccepted"));
                details.SignedQuote = GetBoolean(dr, "SignedQuote");
                details.QuoteSent = Convert.ToDateTime(GetTextValue(dr, "QuoteSent"));
                details.QuotationNotes = GetTextValue(dr, "QuotationNotes");
                details.ProjectNotes = GetTextValue(dr, "ProjectNotes");
                details.MeterBoxPhotosSaved = GetBoolean(dr, "MeterBoxPhotosSaved");
                details.ElecBillSaved = GetBoolean(dr, "ElecBillSaved");
                details.SiteMap = GetBoolean(dr, "SiteMap");
                details.PaymentReceipt = GetBoolean(dr, "PaymentReceipt");
                details.MeterApproval = GetBoolean(dr, "MeterApproval");
                details.InvoiceNumber = GetInt32(dr, "InvoiceNumber");
                details.InvoiceDoc = GetInt32(dr, "InvoiceDoc");
                details.ProjectOpened = GetDateTime(dr, "ProjectOpened");
            }
            dr.Close();
            ForceCloseConnection();
            return details;
        }

        public virtual ProjectsEntity tblProjectQuotes_SelectByProjectQuoteID(int ProjectQuoteID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectQuotes_SelectByProjectQuoteID";
            cmdGet.Parameters.AddWithValue("@ProjectQuoteID", ProjectQuoteID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ProjectsEntity details = new ProjectsEntity();
            while (dr.Read())
            {
                details.ProjectQuoteID = GetInt32(dr, "ProjectQuoteID");
                details.ProjectID = GetInt64(dr, "ProjectID");
                details.ProjectNumber = GetInt32(dr, "ProjectNumber");
                details.ProjectQuoteDate = GetDateTime(dr, "ProjectQuoteDate");
                details.ProjectQuoteDoc = GetInt32(dr, "ProjectQuoteDoc");
                details.EmployeeID = GetInt32(dr, "EmployeeID");
                details.QuoteDoc = GetTextValue(dr, "QuoteDoc");
                details.TotalQuotePrice = GetInt64(dr,"TotalQuotePrice");
                details.BasicSystemCost = GetInt64(dr, "BasicSystemCost");

            }
            dr.Close();
            ForceCloseConnection();
            return details;
        }




        public virtual bool tblProjects_UpdateInvoiceDoc(long ProjectID, long ProjectNumber)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProjects_UpdateInvoiceDoc";
            cmdAdd.Parameters.AddWithValue("@ProjectID", ProjectID);
            cmdAdd.Parameters.AddWithValue("@ProjectNumber", ProjectNumber);
            cmdAdd.Parameters.AddWithValue("@InvoiceSent", DateTime.Now);
          
            int result = -1;
            result = ExecuteNonQuery(cmdAdd);
            try
            {
            }
            catch
            {
            }
            return (Convert.ToBoolean(result != -1));
        }

        public virtual ProjectsEntity GetRoleIDByUserID(string userid)
        {
            ProjectsEntity details = new ProjectsEntity();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "GetRoleIDByUserID";
            cmdGet.Parameters.AddWithValue("@userid", userid);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                details.UserId = GetTextValue(dr, "UserId");
                details.RoleId = GetTextValue(dr, "RoleId");
                details.RoleName = GetTextValue(dr, "RoleName");
            }
            dr.Close();
            ForceCloseConnection();
            return details;

        }
        public virtual void tblProjectsInstallation_Insert(ProjectsEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProjectsInstallation_Insert";
            cmdAdd.Parameters.AddWithValue("@ProjectID", ObjEntity.ProjectID);
            cmdAdd.Parameters.AddWithValue("@MeterAppliedDate", ObjEntity.MeterAppliedDate);
            cmdAdd.Parameters.AddWithValue("@MeterApplyRef", ObjEntity.MeterApplyRef);
            cmdAdd.Parameters.AddWithValue("@MeterApprovalDate", ObjEntity.MeterApprovalDate);
            cmdAdd.Parameters.AddWithValue("@MeterApprovalRef", ObjEntity.MeterApprovalRef);
            cmdAdd.Parameters.AddWithValue("@RexAppliedDate", ObjEntity.RexAppliedDate);
            cmdAdd.Parameters.AddWithValue("@RexAppliedRef", ObjEntity.RexAppliedRef);
            cmdAdd.Parameters.AddWithValue("@RexStatusID", ObjEntity.RexStatusID);
            cmdAdd.Parameters.AddWithValue("@CustomerNotifiedMeter", ObjEntity.CustomerNotifiedMeter);
            cmdAdd.Parameters.AddWithValue("@InitialInstallDate", ObjEntity.InitialInstallDate);
            cmdAdd.Parameters.AddWithValue("@InstallBookingDate", ObjEntity.InstallBookingDate);
            cmdAdd.Parameters.AddWithValue("@ElectricianID", ObjEntity.ElectricianIDs);
            cmdAdd.Parameters.AddWithValue("@InstallerID", ObjEntity.InstallerIDs);
            cmdAdd.Parameters.AddWithValue("@DesignerID", ObjEntity.DesignerIDs);
            cmdAdd.Parameters.AddWithValue("@InstallerNotifiedDate", ObjEntity.InstallerNotifiedDate);
            cmdAdd.Parameters.AddWithValue("@InstallationIssueID", ObjEntity.InstallationIssueID);
            cmdAdd.Parameters.AddWithValue("@StockAllocationStoreID", ObjEntity.StockAllocationStoreID);
            cmdAdd.Parameters.AddWithValue("@SpecialPurposeID", ObjEntity.SpecialPurposeID);
            cmdAdd.Parameters.AddWithValue("@InstallationCompletionDate", ObjEntity.InstallationCompletionDate);
            cmdAdd.Parameters.AddWithValue("@InstallationVerifiedBy", ObjEntity.InstallationVerifiedBy);
            cmdAdd.Parameters.AddWithValue("@InstallDocsRec", ObjEntity.InstallDocsRec);
            cmdAdd.Parameters.AddWithValue("@InstallationConfirmed", ObjEntity.InstallationConfirmed);
            cmdAdd.Parameters.AddWithValue("@STCChecked", ObjEntity.STCChecked);
            cmdAdd.Parameters.AddWithValue("@STCCheckedByID", ObjEntity.STCCheckedByID);
            cmdAdd.Parameters.AddWithValue("@CertificateIssuedDate", ObjEntity.CertificateIssuedDate);
            cmdAdd.Parameters.AddWithValue("@INVSerialNo", ObjEntity.INVSerialNo);
            cmdAdd.Parameters.AddWithValue("@INVSerialNo2", ObjEntity.INVSerialNo2);
            cmdAdd.Parameters.AddWithValue("@MeterElecID", ObjEntity.MeterElecID);
            cmdAdd.Parameters.AddWithValue("@MeterInstallationDocSent", ObjEntity.MeterInstallationDocSent);
            cmdAdd.Parameters.AddWithValue("@MeterJobBooked", ObjEntity.MeterJobBooked);
            cmdAdd.Parameters.AddWithValue("@MeterCompleted", ObjEntity.MeterCompleted);
            cmdAdd.Parameters.AddWithValue("@CCEW", ObjEntity.CCEW);
            cmdAdd.Parameters.AddWithValue("@STCFormSaved", ObjEntity.STCFormSaved);
            cmdAdd.Parameters.AddWithValue("@CertificateSaved", ObjEntity.CertificateSaved);
            cmdAdd.Parameters.AddWithValue("@AdditionalSystem", ObjEntity.AdditionalSystem);
            cmdAdd.Parameters.AddWithValue("@OwnerGSTReg", ObjEntity.OwnerGSTReg);
            cmdAdd.Parameters.AddWithValue("@CompanyABNName", ObjEntity.CompanyABNName);
            cmdAdd.Parameters.AddWithValue("@NewModelPanel", ObjEntity.NewModelPanel);
            cmdAdd.Parameters.AddWithValue("@NewModelINV", ObjEntity.NewModelINV);
            cmdAdd.Parameters.AddWithValue("@STCAppliedDate", ObjEntity.STCAppliedDate);
            cmdAdd.Parameters.AddWithValue("@STCUploadNumber", ObjEntity.STCUploadNumber);
            cmdAdd.Parameters.AddWithValue("@PVDNumber", ObjEntity.PVDNumber);
            cmdAdd.Parameters.AddWithValue("@PVDStatusID", ObjEntity.PVDStatusID);
            cmdAdd.Parameters.AddWithValue("@STCAppliedByID", ObjEntity.STCAppliedByID);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }
        public virtual void tblProjectsInstallation_Update(ProjectsEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProjectsInstallation_Update";
            cmdAdd.Parameters.AddWithValue("@ProjectID", ObjEntity.ProjectID);
            cmdAdd.Parameters.AddWithValue("@MeterAppliedDate", ObjEntity.MeterAppliedDate);
            cmdAdd.Parameters.AddWithValue("@MeterApplyRef", ObjEntity.MeterApplyRef);
            cmdAdd.Parameters.AddWithValue("@MeterApprovalDate", ObjEntity.MeterApprovalDate);
            cmdAdd.Parameters.AddWithValue("@MeterApprovalRef", ObjEntity.MeterApprovalRef);
            cmdAdd.Parameters.AddWithValue("@RexAppliedDate", ObjEntity.RexAppliedDate);
            cmdAdd.Parameters.AddWithValue("@RexAppliedRef", ObjEntity.RexAppliedRef);
            cmdAdd.Parameters.AddWithValue("@RexStatusID", ObjEntity.RexStatusID);
            cmdAdd.Parameters.AddWithValue("@CustomerNotifiedMeter", ObjEntity.CustomerNotifiedMeter);
            cmdAdd.Parameters.AddWithValue("@InitialInstallDate", ObjEntity.InitialInstallDate);
            cmdAdd.Parameters.AddWithValue("@InstallBookingDate", ObjEntity.InstallBookingDate);
            cmdAdd.Parameters.AddWithValue("@ElectricianID", ObjEntity.ElectricianIDs);
            cmdAdd.Parameters.AddWithValue("@InstallerID", ObjEntity.InstallerIDs);
            cmdAdd.Parameters.AddWithValue("@DesignerID", ObjEntity.DesignerIDs);
            cmdAdd.Parameters.AddWithValue("@InstallerNotifiedDate", ObjEntity.InstallerNotifiedDate);
            cmdAdd.Parameters.AddWithValue("@InstallationIssueID", ObjEntity.InstallationIssueID);
            cmdAdd.Parameters.AddWithValue("@StockAllocationStoreID", ObjEntity.StockAllocationStoreID);
            cmdAdd.Parameters.AddWithValue("@SpecialPurposeID", ObjEntity.SpecialPurposeID);
            cmdAdd.Parameters.AddWithValue("@InstallationCompletionDate", ObjEntity.InstallationCompletionDate);
            cmdAdd.Parameters.AddWithValue("@InstallationVerifiedBy", ObjEntity.InstallationVerifiedBy);
            cmdAdd.Parameters.AddWithValue("@InstallDocsRec", ObjEntity.InstallDocsRec);
            cmdAdd.Parameters.AddWithValue("@InstallationConfirmed", ObjEntity.InstallationConfirmed);
            cmdAdd.Parameters.AddWithValue("@STCChecked", ObjEntity.STCChecked);
            cmdAdd.Parameters.AddWithValue("@STCCheckedByID", ObjEntity.STCCheckedByID);
            cmdAdd.Parameters.AddWithValue("@CertificateIssuedDate", ObjEntity.CertificateIssuedDate);
            cmdAdd.Parameters.AddWithValue("@INVSerialNo", ObjEntity.INVSerialNo);
            cmdAdd.Parameters.AddWithValue("@INVSerialNo2", ObjEntity.INVSerialNo2);
            cmdAdd.Parameters.AddWithValue("@MeterElecID", ObjEntity.MeterElecID);
            cmdAdd.Parameters.AddWithValue("@MeterInstallationDocSent", ObjEntity.MeterInstallationDocSent);
            cmdAdd.Parameters.AddWithValue("@MeterJobBooked", ObjEntity.MeterJobBooked);
            cmdAdd.Parameters.AddWithValue("@MeterCompleted", ObjEntity.MeterCompleted);
            cmdAdd.Parameters.AddWithValue("@CCEW", ObjEntity.CCEW);
            cmdAdd.Parameters.AddWithValue("@STCFormSaved", ObjEntity.STCFormSaved);
            cmdAdd.Parameters.AddWithValue("@CertificateSaved", ObjEntity.CertificateSaved);
            cmdAdd.Parameters.AddWithValue("@AdditionalSystem", ObjEntity.AdditionalSystem);
            cmdAdd.Parameters.AddWithValue("@OwnerGSTReg", ObjEntity.OwnerGSTReg);
            cmdAdd.Parameters.AddWithValue("@CompanyABNName", ObjEntity.CompanyABNName);
            cmdAdd.Parameters.AddWithValue("@NewModelPanel", ObjEntity.NewModelPanel);
            cmdAdd.Parameters.AddWithValue("@NewModelINV", ObjEntity.NewModelINV);
            cmdAdd.Parameters.AddWithValue("@STCAppliedDate", ObjEntity.STCAppliedDate);
            cmdAdd.Parameters.AddWithValue("@STCUploadNumber", ObjEntity.STCUploadNumber);
            cmdAdd.Parameters.AddWithValue("@PVDNumber", ObjEntity.PVDNumber);
            cmdAdd.Parameters.AddWithValue("@PVDStatusID", ObjEntity.PVDStatusID);
            cmdAdd.Parameters.AddWithValue("@STCAppliedByID", ObjEntity.STCAppliedByID);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }
        public virtual int tblProjectsInstallation_ProjectIDExists(long ProjectID)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectsInstallationProjectIDExists";
            cmdGet.Parameters.AddWithValue("@ProjectID", ProjectID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "ProjectID");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }

        public virtual void tblProjectsNewInstallation_Insert(ProjectsEntityInstallation ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProjectsNewInstallation_Insert";



            cmdAdd.Parameters.AddWithValue("@ProjectID", ObjEntity.ProjectID);
            cmdAdd.Parameters.AddWithValue("@GedaAppliedDate", ObjEntity.GedaAppliedDate);
            cmdAdd.Parameters.AddWithValue("@GedaAppliedRef", ObjEntity.GedaAppliedRef);
            cmdAdd.Parameters.AddWithValue("@GedaApprovalDate", ObjEntity.GedaApprovalDate);
            cmdAdd.Parameters.AddWithValue("@GedaApprovalRef", ObjEntity.GedaApprovalRef);
            cmdAdd.Parameters.AddWithValue("@ElectricityBoardID", ObjEntity.ElectricityBoardID);
            cmdAdd.Parameters.AddWithValue("@GedaStatusID", ObjEntity.GedaStatusID);
            cmdAdd.Parameters.AddWithValue("@GedaDepositID", ObjEntity.GedaDepositID);
            cmdAdd.Parameters.AddWithValue("@ApprovalLetter", ObjEntity.ApprovalLetter);
            cmdAdd.Parameters.AddWithValue("@RegistrationForm", ObjEntity.RegistrationForm);
            cmdAdd.Parameters.AddWithValue("@CeigAppliedDate", ObjEntity.CeigAppliedDate);
            cmdAdd.Parameters.AddWithValue("@CeigAppliedRef", ObjEntity.CeigAppliedRef);
            cmdAdd.Parameters.AddWithValue("@CeigApprovalDate", ObjEntity.CeigApprovalDate);
            cmdAdd.Parameters.AddWithValue("@CeigApprovalRef", ObjEntity.CeigApprovalRef);
            cmdAdd.Parameters.AddWithValue("@NetMeterDepositID", ObjEntity.NetMeterDepositID);
            cmdAdd.Parameters.AddWithValue("@CeigStatusID", ObjEntity.CeigStatusID);
            cmdAdd.Parameters.AddWithValue("@CustNotifiedMeter", ObjEntity.CustNotifiedMeter);
            cmdAdd.Parameters.AddWithValue("@Drawing", ObjEntity.Drawing);

            cmdAdd.Parameters.AddWithValue("@ApprovalLetterCEIG", ObjEntity.ApprovalLetterCEIG);
            cmdAdd.Parameters.AddWithValue("@CoveringLetterCeig", ObjEntity.CoveringLetterCeig);
            cmdAdd.Parameters.AddWithValue("@MaterialDispatchedDate", ObjEntity.MaterialDispatchedDate);
            cmdAdd.Parameters.AddWithValue("@NOCDispatched", ObjEntity.NOCDispatched);
            cmdAdd.Parameters.AddWithValue("@InstallationStartDate", ObjEntity.InstallationStartDate);
            cmdAdd.Parameters.AddWithValue("@InstallerNotifiedDate", ObjEntity.InstallerNotifiedDate);
            cmdAdd.Parameters.AddWithValue("@InstallerID", ObjEntity.InstallerID);
            cmdAdd.Parameters.AddWithValue("@InstallationIssueID", ObjEntity.InstallationIssueID);
            cmdAdd.Parameters.AddWithValue("@StoreAllocationID", ObjEntity.StoreAllocationID);
            cmdAdd.Parameters.AddWithValue("@NocDispatchedLetter", ObjEntity.NocDispatchedLetter);
            cmdAdd.Parameters.AddWithValue("@am1", ObjEntity.am1);
            cmdAdd.Parameters.AddWithValue("@am2", ObjEntity.am2);
            cmdAdd.Parameters.AddWithValue("@pm1", ObjEntity.pm1);
            cmdAdd.Parameters.AddWithValue("@pm2", ObjEntity.pm2);
            cmdAdd.Parameters.AddWithValue("@days", ObjEntity.days);
            cmdAdd.Parameters.AddWithValue("@CustNotifiedInstallDate", ObjEntity.CustNotifiedInstallDate);
            cmdAdd.Parameters.AddWithValue("@InstallCompleteDate", ObjEntity.InstallCompleteDate);

            cmdAdd.Parameters.AddWithValue("@InstallVerifyBy", ObjEntity.InstallVerifyBy);
            cmdAdd.Parameters.AddWithValue("@MtrSentForTestDate", ObjEntity.MtrSentForTestDate);
            cmdAdd.Parameters.AddWithValue("@MeterJobBookedDate", ObjEntity.MeterJobBookedDate);
            cmdAdd.Parameters.AddWithValue("@CoveringLetterPostInstallation", ObjEntity.CoveringLetterPostInstallation);
            cmdAdd.Parameters.AddWithValue("@InvSrno", ObjEntity.InvSrno);
            cmdAdd.Parameters.AddWithValue("@InvSrno2", ObjEntity.InvSrno2);
            cmdAdd.Parameters.AddWithValue("@MeterCompletedDate", ObjEntity.MeterCompletedDate);
            cmdAdd.Parameters.AddWithValue("@DiscomAppliedDate", ObjEntity.DiscomAppliedDate);
            cmdAdd.Parameters.AddWithValue("@AgreementDate", ObjEntity.AgreementDate);
            cmdAdd.Parameters.AddWithValue("@DiscomAppliedForm", ObjEntity.DiscomAppliedForm);
            cmdAdd.Parameters.AddWithValue("@TechnicalFeasibleReport", ObjEntity.TechnicalFeasibleReport);
            cmdAdd.Parameters.AddWithValue("@AgreementDoc", ObjEntity.AgreementDoc);
            cmdAdd.Parameters.AddWithValue("@SignedAgreementDoc", ObjEntity.SignedAgreementDoc);
            cmdAdd.Parameters.AddWithValue("@ConnectivityPaymentDate", ObjEntity.ConnectivityPaymentDate);

             cmdAdd.Parameters.AddWithValue("@CCPaidByID", ObjEntity.CCPaidByID);
            cmdAdd.Parameters.AddWithValue("@EstimateReport", ObjEntity.EstimateReport);
            cmdAdd.Parameters.AddWithValue("@ConfirmPaymentReceipt", ObjEntity.ConfirmPaymentReceipt);
            cmdAdd.Parameters.AddWithValue("@ConnectivityCharges", ObjEntity.ConnectivityCharges);
            cmdAdd.Parameters.AddWithValue("@DisComElectricityBoardID", ObjEntity.DisComElectricityBoardID);
            cmdAdd.Parameters.AddWithValue("@MnreAppliedDate", ObjEntity.MnreAppliedDate);
            cmdAdd.Parameters.AddWithValue("@MnreApprovalDate", ObjEntity.MnreApprovalDate);
            cmdAdd.Parameters.AddWithValue("@AppliedAmount", ObjEntity.AppliedAmount);
            cmdAdd.Parameters.AddWithValue("@AppliedStatusID", ObjEntity.AppliedStatusID);
            cmdAdd.Parameters.AddWithValue("@MnreFormB", ObjEntity.MnreFormB);
            cmdAdd.Parameters.AddWithValue("@MnreFormc", ObjEntity.MnreFormc);
            cmdAdd.Parameters.AddWithValue("@CACertificate", ObjEntity.CACertificate);
            cmdAdd.Parameters.AddWithValue("@SencationLetter", ObjEntity.SencationLetter);
            cmdAdd.Parameters.AddWithValue("@Affidavit", ObjEntity.Affidavit);
            cmdAdd.Parameters.AddWithValue("@GedaCommissioningDate", ObjEntity.GedaCommissioningDate);

            cmdAdd.Parameters.AddWithValue("@GedaCommissioningApprovalDate", ObjEntity.GedaCommissioningApprovalDate);
            cmdAdd.Parameters.AddWithValue("@GedaCommissioningCertificateNumber", ObjEntity.GedaCommissioningCertificateNumber);
            cmdAdd.Parameters.AddWithValue("@GedaPostStatusID", ObjEntity.GedaPostStatusID);
            cmdAdd.Parameters.AddWithValue("@GedaSubsidyStatusID", ObjEntity.GedaSubsidyStatusID);
            cmdAdd.Parameters.AddWithValue("@GedaAppliedbyID", ObjEntity.GedaAppliedbyID);
            cmdAdd.Parameters.AddWithValue("@GedaSubsidyAppliedDate", ObjEntity.GedaSubsidyAppliedDate);
            cmdAdd.Parameters.AddWithValue("@GedaAppliedAmount", ObjEntity.GedaAppliedAmount);
            cmdAdd.Parameters.AddWithValue("@GedaSubsidyRecieved", ObjEntity.GedaSubsidyRecieved);
            cmdAdd.Parameters.AddWithValue("@CommissioningCerti", ObjEntity.CommissioningCerti);
            cmdAdd.Parameters.AddWithValue("@MDU", ObjEntity.MDU);
            cmdAdd.Parameters.AddWithValue("@PanelInverterSrno", ObjEntity.PanelInverterSrno);
            cmdAdd.Parameters.AddWithValue("@MeterCallingReport", ObjEntity.MeterCallingReport);
            cmdAdd.Parameters.AddWithValue("@PlantPhoto", ObjEntity.PlantPhoto);
            cmdAdd.Parameters.AddWithValue("@Invoice", ObjEntity.Invoice);
            cmdAdd.Parameters.AddWithValue("@GedaSubsidyRecieveLetter", ObjEntity.GedaSubsidyRecieveLetter);
            cmdAdd.Parameters.AddWithValue("@GedaChecklist", ObjEntity.GedaChecklist);
            cmdAdd.Parameters.AddWithValue("@BeneficiaryPhoto", ObjEntity.BeneficiaryPhoto);
             cmdAdd.Parameters.AddWithValue("@CeigPostAppliedDate", ObjEntity.CeigPostAppliedDate);
            cmdAdd.Parameters.AddWithValue("@CeigPostAppliedRef", ObjEntity.CeigPostAppliedRef);
            cmdAdd.Parameters.AddWithValue("@CeigPostApprovalDate", ObjEntity.CeigPostApprovalDate);
            cmdAdd.Parameters.AddWithValue("@CeigPostApprovalRef", ObjEntity.CeigPostApprovalRef);
            cmdAdd.Parameters.AddWithValue("@CeigPostStatusID", ObjEntity.CeigPostStatusID);
             cmdAdd.Parameters.AddWithValue("@CustPostMeterNotifiedDate", ObjEntity.CustPostMeterNotifiedDate);
            cmdAdd.Parameters.AddWithValue("@TestReport", ObjEntity.TestReport);
            cmdAdd.Parameters.AddWithValue("@ChargingNocForm", ObjEntity.ChargingNocForm);


            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }
        public virtual void tblProjectsNewInstallation_Update(ProjectsEntityInstallation ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblProjectsNewInstallation_Update";
            cmdAdd.Parameters.AddWithValue("@ProjectID", ObjEntity.ProjectID);
            cmdAdd.Parameters.AddWithValue("@GedaAppliedDate", ObjEntity.GedaAppliedDate);
            cmdAdd.Parameters.AddWithValue("@GedaAppliedRef", ObjEntity.GedaAppliedRef);
            cmdAdd.Parameters.AddWithValue("@GedaApprovalDate", ObjEntity.GedaApprovalDate);
            cmdAdd.Parameters.AddWithValue("@GedaApprovalRef", ObjEntity.GedaApprovalRef);
            cmdAdd.Parameters.AddWithValue("@ElectricityBoardID", ObjEntity.ElectricityBoardID);
            cmdAdd.Parameters.AddWithValue("@GedaStatusID", ObjEntity.GedaStatusID);
            cmdAdd.Parameters.AddWithValue("@GedaDepositID", ObjEntity.GedaDepositID);
            cmdAdd.Parameters.AddWithValue("@ApprovalLetter", ObjEntity.ApprovalLetter);
            cmdAdd.Parameters.AddWithValue("@RegistrationForm", ObjEntity.RegistrationForm);
            cmdAdd.Parameters.AddWithValue("@CeigAppliedDate", ObjEntity.CeigAppliedDate);
            cmdAdd.Parameters.AddWithValue("@CeigAppliedRef", ObjEntity.CeigAppliedRef);
            cmdAdd.Parameters.AddWithValue("@CeigApprovalDate", ObjEntity.CeigApprovalDate);
            cmdAdd.Parameters.AddWithValue("@CeigApprovalRef", ObjEntity.CeigApprovalRef);

            cmdAdd.Parameters.AddWithValue("@NetMeterDepositID", ObjEntity.NetMeterDepositID);
            cmdAdd.Parameters.AddWithValue("@CeigStatusID", ObjEntity.CeigStatusID);
            cmdAdd.Parameters.AddWithValue("@CustNotifiedMeter", ObjEntity.CustNotifiedMeter);
            cmdAdd.Parameters.AddWithValue("@ApprovalLetterCEIG", ObjEntity.ApprovalLetterCEIG);
            cmdAdd.Parameters.AddWithValue("@CoveringLetterCeig", ObjEntity.CoveringLetterCeig);
            cmdAdd.Parameters.AddWithValue("@MaterialDispatchedDate", ObjEntity.MaterialDispatchedDate);
            cmdAdd.Parameters.AddWithValue("@Drawing", ObjEntity.Drawing);
            cmdAdd.Parameters.AddWithValue("@NOCDispatched", ObjEntity.NOCDispatched);
            cmdAdd.Parameters.AddWithValue("@InstallationStartDate", ObjEntity.InstallationStartDate);
            cmdAdd.Parameters.AddWithValue("@InstallerNotifiedDate", ObjEntity.InstallerNotifiedDate);
            cmdAdd.Parameters.AddWithValue("@InstallerID", ObjEntity.InstallerID);
            cmdAdd.Parameters.AddWithValue("@InstallationIssueID", ObjEntity.InstallationIssueID);
            cmdAdd.Parameters.AddWithValue("@StoreAllocationID", ObjEntity.StoreAllocationID);
            cmdAdd.Parameters.AddWithValue("@NocDispatchedLetter", ObjEntity.NocDispatchedLetter);
            cmdAdd.Parameters.AddWithValue("@am1", ObjEntity.am1);
            cmdAdd.Parameters.AddWithValue("@am2", ObjEntity.am2);
            cmdAdd.Parameters.AddWithValue("@pm1", ObjEntity.pm1);
            cmdAdd.Parameters.AddWithValue("@pm2", ObjEntity.pm2);
            cmdAdd.Parameters.AddWithValue("@days", ObjEntity.days);
            cmdAdd.Parameters.AddWithValue("@CustNotifiedInstallDate", ObjEntity.CustNotifiedInstallDate);
            cmdAdd.Parameters.AddWithValue("@InstallCompleteDate", ObjEntity.InstallCompleteDate);
            cmdAdd.Parameters.AddWithValue("@InstallVerifyBy", ObjEntity.InstallVerifyBy);
            cmdAdd.Parameters.AddWithValue("@MtrSentForTestDate", ObjEntity.MtrSentForTestDate);
            cmdAdd.Parameters.AddWithValue("@MeterJobBookedDate", ObjEntity.MeterJobBookedDate);
            cmdAdd.Parameters.AddWithValue("@CoveringLetterPostInstallation", ObjEntity.CoveringLetterPostInstallation);
            cmdAdd.Parameters.AddWithValue("@InvSrno", ObjEntity.InvSrno);
            cmdAdd.Parameters.AddWithValue("@InvSrno2", ObjEntity.InvSrno2);
            cmdAdd.Parameters.AddWithValue("@MeterCompletedDate", ObjEntity.MeterCompletedDate);
            cmdAdd.Parameters.AddWithValue("@DiscomAppliedDate", ObjEntity.DiscomAppliedDate);
            cmdAdd.Parameters.AddWithValue("@AgreementDate", ObjEntity.AgreementDate);
            cmdAdd.Parameters.AddWithValue("@DiscomAppliedForm", ObjEntity.DiscomAppliedForm);
            cmdAdd.Parameters.AddWithValue("@TechnicalFeasibleReport", ObjEntity.TechnicalFeasibleReport);
            cmdAdd.Parameters.AddWithValue("@AgreementDoc", ObjEntity.AgreementDoc);
            cmdAdd.Parameters.AddWithValue("@SignedAgreementDoc", ObjEntity.SignedAgreementDoc);
            cmdAdd.Parameters.AddWithValue("@ConnectivityPaymentDate", ObjEntity.ConnectivityPaymentDate);
            cmdAdd.Parameters.AddWithValue("@CCPaidByID", ObjEntity.CCPaidByID);
            cmdAdd.Parameters.AddWithValue("@EstimateReport", ObjEntity.EstimateReport);
            cmdAdd.Parameters.AddWithValue("@ConfirmPaymentReceipt", ObjEntity.ConfirmPaymentReceipt);
            cmdAdd.Parameters.AddWithValue("@ConnectivityCharges", ObjEntity.ConnectivityCharges);
            cmdAdd.Parameters.AddWithValue("@DisComElectricityBoardID", ObjEntity.DisComElectricityBoardID);
            cmdAdd.Parameters.AddWithValue("@MnreAppliedDate", ObjEntity.MnreAppliedDate);
            cmdAdd.Parameters.AddWithValue("@MnreApprovalDate", ObjEntity.MnreApprovalDate);
            cmdAdd.Parameters.AddWithValue("@AppliedAmount", ObjEntity.AppliedAmount);
            cmdAdd.Parameters.AddWithValue("@AppliedStatusID", ObjEntity.AppliedStatusID);
            cmdAdd.Parameters.AddWithValue("@MnreFormB", ObjEntity.MnreFormB);
            cmdAdd.Parameters.AddWithValue("@MnreFormc", ObjEntity.MnreFormc);
            cmdAdd.Parameters.AddWithValue("@CACertificate", ObjEntity.CACertificate);
            cmdAdd.Parameters.AddWithValue("@SencationLetter", ObjEntity.SencationLetter);
            cmdAdd.Parameters.AddWithValue("@Affidavit", ObjEntity.Affidavit);
            cmdAdd.Parameters.AddWithValue("@GedaCommissioningDate", ObjEntity.GedaCommissioningDate);
            cmdAdd.Parameters.AddWithValue("@GedaCommissioningApprovalDate", ObjEntity.GedaCommissioningApprovalDate);
            cmdAdd.Parameters.AddWithValue("@GedaCommissioningCertificateNumber", ObjEntity.GedaCommissioningCertificateNumber);
            cmdAdd.Parameters.AddWithValue("@GedaPostStatusID", ObjEntity.GedaPostStatusID);
            cmdAdd.Parameters.AddWithValue("@GedaSubsidyStatusID", ObjEntity.GedaSubsidyStatusID);
            cmdAdd.Parameters.AddWithValue("@GedaAppliedbyID", ObjEntity.GedaAppliedbyID);
            cmdAdd.Parameters.AddWithValue("@GedaSubsidyAppliedDate", ObjEntity.GedaSubsidyAppliedDate);
            cmdAdd.Parameters.AddWithValue("@GedaAppliedAmount", ObjEntity.GedaAppliedAmount);
            cmdAdd.Parameters.AddWithValue("@GedaSubsidyRecieved", ObjEntity.GedaSubsidyRecieved);
            cmdAdd.Parameters.AddWithValue("@CommissioningCerti", ObjEntity.CommissioningCerti);
            cmdAdd.Parameters.AddWithValue("@MDU", ObjEntity.MDU);
            cmdAdd.Parameters.AddWithValue("@PanelInverterSrno", ObjEntity.PanelInverterSrno);
            cmdAdd.Parameters.AddWithValue("@MeterCallingReport", ObjEntity.MeterCallingReport);
            cmdAdd.Parameters.AddWithValue("@PlantPhoto", ObjEntity.PlantPhoto);
            cmdAdd.Parameters.AddWithValue("@Invoice", ObjEntity.Invoice);
            cmdAdd.Parameters.AddWithValue("@GedaSubsidyRecieveLetter", ObjEntity.GedaSubsidyRecieveLetter);
            cmdAdd.Parameters.AddWithValue("@GedaChecklist", ObjEntity.GedaChecklist);
            cmdAdd.Parameters.AddWithValue("@BeneficiaryPhoto", ObjEntity.BeneficiaryPhoto);
            cmdAdd.Parameters.AddWithValue("@CeigPostAppliedDate", ObjEntity.CeigPostAppliedDate);
            cmdAdd.Parameters.AddWithValue("@CeigPostAppliedRef", ObjEntity.CeigPostAppliedRef);
            cmdAdd.Parameters.AddWithValue("@CeigPostApprovalDate", ObjEntity.CeigPostApprovalDate);
            cmdAdd.Parameters.AddWithValue("@CeigPostApprovalRef", ObjEntity.CeigPostApprovalRef);
            cmdAdd.Parameters.AddWithValue("@CeigPostStatusID", ObjEntity.CeigPostStatusID);
            cmdAdd.Parameters.AddWithValue("@CustPostMeterNotifiedDate", ObjEntity.CustPostMeterNotifiedDate);
            cmdAdd.Parameters.AddWithValue("@TestReport", ObjEntity.TestReport);
            cmdAdd.Parameters.AddWithValue("@ChargingNocForm", ObjEntity.ChargingNocForm);
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual int tblProjectsNewInstallation_ProjectIDExists(long ProjectID)
        {
            int ID = 0;
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectsNewInstallation_ProjectIDExists";
            cmdGet.Parameters.AddWithValue("@ProjectID", ProjectID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ID = GetInt32(dr, "ProjectID");
            }
            dr.Close();
            ForceCloseConnection();
            return ID;

        }
        public virtual ProjectsEntity tblProjectsInstallationByProjectID(long ProjectID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectsInstallationByProjectID";
            cmdGet.Parameters.AddWithValue("@ProjectID", ProjectID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ProjectsEntity details = new ProjectsEntity();
            while (dr.Read())
            {
                details.ProjectInstallationID = GetInt32(dr, "ProjectInstallationID");
                details.ProjectID = GetInt32(dr, "ProjectID");
                details.MeterAppliedDate = Convert.ToDateTime(GetTextValue(dr, "MeterAppliedDate"));
                details.MeterApplyRef = GetTextValue(dr, "MeterApplyRef");
                details.MeterApprovalDate = Convert.ToDateTime(GetTextValue(dr, "MeterApprovalDate"));
                details.MeterApprovalRef = GetTextValue(dr, "MeterApprovalRef");
                details.RexAppliedDate = Convert.ToDateTime(GetTextValue(dr, "RexAppliedDate"));
                details.RexAppliedRef = GetTextValue(dr, "RexAppliedRef");
                details.RexStatusID = GetInt32(dr, "RexStatusID");
                details.CustomerNotifiedMeter = GetBoolean(dr, "CustomerNotifiedMeter");
                details.InitialInstallDate = Convert.ToDateTime(GetTextValue(dr, "InitialInstallDate"));
                details.InstallBookingDate = Convert.ToDateTime(GetTextValue(dr, "InstallBookingDate"));
                //details.ElectricianID = GetInt32(dr, "ElectricianID");
                //details.InstallerID = GetInt32(dr, "InstallerID");
                //details.DesignerID = GetInt32(dr, "DesignerID");
                details.InstallerNotifiedDate = Convert.ToDateTime(GetTextValue(dr, "InstallerNotifiedDate"));
                details.InstallationIssueID = GetInt32(dr, "InstallationIssueID");
                details.StockAllocationStoreID = GetInt32(dr, "StockAllocationStoreID");
                details.SpecialPurposeID = GetInt32(dr, "SpecialPurposeID");
                details.InstallationCompletionDate = Convert.ToDateTime(GetTextValue(dr, "InstallationCompletionDate"));
                details.InstallationVerifiedBy = GetTextValue(dr, "InstallationVerifiedBy");
                details.InstallDocsRec = Convert.ToDateTime(GetTextValue(dr, "InstallDocsRec"));
                details.InstallationConfirmed = GetBoolean(dr, "InstallationConfirmed");
                details.STCChecked = GetBoolean(dr, "STCChecked");
                details.STCCheckedByID = GetInt32(dr, "STCCheckedByID");
                details.CertificateIssuedDate = Convert.ToDateTime(GetTextValue(dr, "CertificateIssuedDate"));
                details.INVSerialNo = GetTextValue(dr, "INVSerialNo");
                details.INVSerialNo2 = GetTextValue(dr, "INVSerialNo2");
                details.MeterElecID = GetInt32(dr, "MeterElecID");
                details.MeterInstallationDocSent = Convert.ToDateTime(GetTextValue(dr, "MeterInstallationDocSent"));
                details.MeterJobBooked = Convert.ToDateTime(GetTextValue(dr, "MeterJobBooked"));
                details.MeterCompleted = Convert.ToDateTime(GetTextValue(dr, "MeterCompleted"));
                details.CCEW = GetBoolean(dr, "CCEW");
                details.CertificateSaved = GetBoolean(dr, "CertificateSaved");
                details.AdditionalSystem = GetBoolean(dr, "AdditionalSystem");
                details.OwnerGSTReg = GetBoolean(dr, "OwnerGSTReg");
                details.CompanyABNName = GetTextValue(dr, "CompanyABNName");
                details.NewModelPanel = GetBoolean(dr, "NewModelPanel");
                details.NewModelINV = GetBoolean(dr, "NewModelINV");
                details.STCAppliedDate = Convert.ToDateTime(GetTextValue(dr, "STCAppliedDate"));
                details.STCUploadNumber = GetTextValue(dr, "STCUploadNumber");
                details.PVDNumber = GetTextValue(dr, "PVDNumber");
                details.PVDStatusID = GetInt32(dr, "PVDStatusID");
                details.STCAppliedByID = GetInt32(dr, "STCAppliedByID");
            }
            dr.Close();
            ForceCloseConnection();
            return details;
        }

        public virtual ProjectsEntityInstallation tblProjectsNewInstallationByProjectID(long ProjectID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjectsNewInstallationByProjectID";
            cmdGet.Parameters.AddWithValue("@ProjectID", ProjectID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);



            ProjectsEntityInstallation details = new ProjectsEntityInstallation();
            while (dr.Read())
            {
                details.ProjectInstallationID = GetInt32(dr, "ProjectInstallationID");
                details.ProjectID = GetInt32(dr, "ProjectID");
                details.GedaAppliedDate = Convert.ToDateTime(GetTextValue(dr, "GedaAppliedDate"));
                details.GedaAppliedRef = GetTextValue(dr, "GedaAppliedRef");
                details.GedaApprovalDate = Convert.ToDateTime(GetTextValue(dr, "GedaApprovalDate"));
                details.GedaApprovalRef = GetTextValue(dr, "GedaApprovalRef");
                details.ElectricityBoardID =  GetInt32(dr, "ElectricityBoardID");
                details.GedaStatusID = GetInt32(dr, "GedaStatusID");
                details.GedaDepositID = GetInt32(dr, "GedaDepositID");
                details.ApprovalLetter = GetTextValue(dr, "ApprovalLetter");
                details.RegistrationForm = GetTextValue(dr, "RegistrationForm");
                details.CeigAppliedDate = Convert.ToDateTime(GetTextValue(dr, "CeigAppliedDate"));
                details.CeigAppliedRef = GetTextValue(dr, "CeigAppliedRef");
                details.CeigApprovalDate = Convert.ToDateTime(GetTextValue(dr, "CeigApprovalDate"));
                details.CeigApprovalRef = GetTextValue(dr, "CeigApprovalRef");
                details.NetMeterDepositID = GetInt32(dr, "NetMeterDepositID");
                details.CeigStatusID = GetInt32(dr,"CeigStatusID");
                details.CustNotifiedMeter = GetBoolean(dr, "CustNotifiedMeter");
                details.Drawing = GetTextValue(dr, "Drawing");
                details.ApprovalLetterCEIG = GetTextValue(dr,"ApprovalLetterCEIG");
                details.CoveringLetterCeig = GetTextValue(dr,"CoveringLetterCeig");
                details.MaterialDispatchedDate = Convert.ToDateTime(GetTextValue(dr, "MaterialDispatchedDate"));
                details.InstallationStartDate = Convert.ToDateTime(GetTextValue(dr, "InstallationStartDate"));
                details.InstallerNotifiedDate = Convert.ToDateTime(GetTextValue(dr, "InstallerNotifiedDate"));
                details.InstallerID = GetTextValue(dr,"InstallerID");
                details.InstallationIssueID = GetInt32(dr,"InstallationIssueID");
                details.StoreAllocationID = GetInt32(dr,"StoreAllocationID");
                details.NocDispatchedLetter = GetTextValue(dr,"NocDispatchedLetter");
                details.am1 = GetBoolean(dr,"am1");
                details.am2 = GetBoolean(dr,"am2");
                details.pm1 = GetBoolean(dr,"pm1");
                details.pm2 = GetBoolean(dr,"pm2");
                details.days = GetTextValue(dr,"days");
                details.CustNotifiedInstallDate= GetBoolean(dr,"CustNotifiedInstallDate");
                details.InstallCompleteDate = Convert.ToDateTime(GetTextValue(dr, "InstallCompleteDate"));
               // details.InstallVerifyBy = Convert.ToInt32(dr, "InstallVerifyBy");
                details.MtrSentForTestDate = Convert.ToDateTime(GetTextValue(dr, "MtrSentForTestDate"));
                details.MeterJobBookedDate = Convert.ToDateTime(GetTextValue(dr, "MeterJobBookedDate"));
                details.CoveringLetterPostInstallation = GetTextValue(dr, "CoveringLetterPostInstallation");
                details.InvSrno = GetTextValue(dr, "InvSrno");
                details.InvSrno2 = GetTextValue(dr, "InvSrno2");
                details.MeterCompletedDate = Convert.ToDateTime(GetTextValue(dr, "MeterCompletedDate"));
                details.DiscomAppliedDate = Convert.ToDateTime(GetTextValue(dr, "DiscomAppliedDate"));
                details.AgreementDate = Convert.ToDateTime(GetTextValue(dr, "AgreementDate"));
                details.DiscomAppliedForm = GetTextValue(dr, "DiscomAppliedForm");
                details.TechnicalFeasibleReport = GetTextValue(dr, "TechnicalFeasibleReport");
                details.AgreementDoc = GetTextValue(dr, "AgreementDoc");
                details.SignedAgreementDoc = GetTextValue(dr, "SignedAgreementDoc");
                details.ConnectivityPaymentDate = Convert.ToDateTime(GetTextValue(dr, "ConnectivityPaymentDate"));
                details.CCPaidByID = GetInt32(dr, "CCPaidByID");
                details.EstimateReport = GetTextValue(dr, "EstimateReport");
                details.ConfirmPaymentReceipt = GetTextValue(dr, "ConfirmPaymentReceipt");
                details.ConnectivityCharges = GetTextValue(dr, "ConnectivityCharges");
                details.DisComElectricityBoardID = GetInt32(dr, "DisComElectricityBoardID");
                details.MnreAppliedDate = Convert.ToDateTime(GetTextValue(dr, "MnreAppliedDate"));
                details.AppliedAmount = GetTextValue(dr, "AppliedAmount");
                details.AppliedStatusID = GetInt32(dr, "AppliedStatusID");
                details.MnreApprovalDate = Convert.ToDateTime(GetTextValue(dr, "MnreApprovalDate"));
                details.MnreFormB = GetTextValue(dr, "MnreFormB");
                details.MnreFormc = GetTextValue(dr, "MnreFormc");
                details.CACertificate = GetTextValue(dr, "CACertificate");
                details.SencationLetter = GetTextValue(dr, "SencationLetter");
                details.Affidavit = GetTextValue(dr, "Affidavit");
                details.GedaCommissioningDate = Convert.ToDateTime(GetTextValue(dr, "GedaCommissioningDate"));
                details.GedaCommissioningApprovalDate = Convert.ToDateTime(GetTextValue(dr, "GedaCommissioningApprovalDate"));

                details.GedaCommissioningCertificateNumber = GetTextValue(dr, "GedaCommissioningCertificateNumber");
                details.GedaPostStatusID = GetInt32(dr, "GedaPostStatusID");
                details.GedaSubsidyStatusID = GetInt32(dr, "GedaSubsidyStatusID");
                details.GedaAppliedbyID = GetInt32(dr, "GedaAppliedbyID");
                details.GedaSubsidyAppliedDate = Convert.ToDateTime(GetTextValue(dr, "GedaSubsidyAppliedDate"));
                details.GedaAppliedAmount = GetTextValue(dr, "GedaAppliedAmount");
                details.GedaSubsidyRecieved = GetTextValue(dr, "GedaSubsidyRecieved");
                details.CommissioningCerti = GetTextValue(dr, "CommissioningCerti");
                details.MDU = GetTextValue(dr, "MDU");
                details.PanelInverterSrno = GetTextValue(dr, "PanelInverterSrno");
                 details.MeterCallingReport = GetTextValue(dr, "MeterCallingReport");
                details.Invoice = GetTextValue(dr, "Invoice");
                details.PlantPhoto = GetTextValue(dr, "PlantPhoto");
                details.GedaSubsidyRecieveLetter = GetTextValue(dr, "GedaSubsidyRecieveLetter");
                details.GedaChecklist = GetTextValue(dr, "GedaChecklist");
                details.BeneficiaryPhoto = GetTextValue(dr, "BeneficiaryPhoto");
                details.CeigPostAppliedDate = Convert.ToDateTime(GetTextValue(dr, "CeigPostAppliedDate"));
                details.CeigPostAppliedRef = GetTextValue(dr, "CeigPostAppliedRef");
                details.CeigPostApprovalDate = Convert.ToDateTime(GetTextValue(dr,  "CeigPostApprovalDate"));
                details.CeigPostApprovalRef = GetTextValue(dr, "CeigPostApprovalRef");
                details.CeigPostStatusID = GetInt32(dr, "CeigPostStatusID");
                details.CustPostMeterNotifiedDate = GetBoolean(dr, "CustPostMeterNotifiedDate");
                details.TestReport = GetTextValue(dr, "TestReport");
                details.ChargingNocForm = GetTextValue(dr, "ChargingNocForm");
            }
            


           dr.Close();
            ForceCloseConnection();
            return details;
        }
        public virtual List<ProjectsEntity> tblProjects_SelectInstallerProjects(PagingEntity CommonEntity, out int Count, string UserID)
        {
            List<ProjectsEntity> lstprojects = new List<ProjectsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjects_SelectInstallerProjects";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            cmdGet.Parameters.AddWithValue("@UserID", UserID);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ProjectsEntity objEntity = new ProjectsEntity();
                objEntity.ProjectID = GetInt64(dr, "ProjectID");
                objEntity.ProjectNumber = GetInt64(dr, "ProjectNumber");
                objEntity.ManualQuoteNumber = GetTextValue(dr, "ManualQuoteNumber");
                objEntity.ProjectType = GetTextValue(dr, "ProjectType");
                objEntity.ProjectStatus = GetTextValue(dr, "ProjectStatus");
                objEntity.CustomerName = GetTextValue(dr, "CustomerName");
                objEntity.ContactNO = GetTextValue(dr, "ContPhone");
                objEntity.ProjectOpened = GetDateTime(dr, "ProjectOpened");
                objEntity.Location = GetTextValue(dr, "BranchLocation");
                objEntity.InstallArea = GetTextValue(dr, "InstallArea");
                objEntity.InstallCity = GetTextValue(dr, "InstallCity");
                objEntity.InstallState = GetTextValue(dr, "InstallState");
                objEntity.InstallerNotes = GetTextValue(dr, "InstallerNotes");
                objEntity.UpdateBy = GetInt32(dr, "UpdateBy");

                lstprojects.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstprojects;
        }

        public virtual List<ProjectsEntity> tblProjects_SelectSearchInstallerProjects(PagingEntity CommonEntity, string Searchkeyword,string UserID, out int Count)
        {
            List<ProjectsEntity> lstprojects = new List<ProjectsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjects_SelectSearchInstallerProjects";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            cmdGet.Parameters.AddWithValue("@searchkeyword", Searchkeyword);
            cmdGet.Parameters.AddWithValue("@UserID", UserID);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ProjectsEntity objEntity = new ProjectsEntity();
                objEntity.ProjectID = GetInt64(dr, "ProjectID");
                objEntity.ProjectNumber = GetInt64(dr, "ProjectNumber");
                objEntity.ManualQuoteNumber = GetTextValue(dr, "ManualQuoteNumber");
                objEntity.ProjectType = GetTextValue(dr, "ProjectType");
                objEntity.ProjectStatus = GetTextValue(dr, "ProjectStatus");
                objEntity.CustomerName = GetTextValue(dr, "CustomerName");
                objEntity.ContactNO = GetTextValue(dr, "ContPhone");
                objEntity.ProjectOpened = GetDateTime(dr, "ProjectOpened");
                objEntity.Location = GetTextValue(dr, "BranchLocation");
                objEntity.InstallArea = GetTextValue(dr, "InstallArea");
                objEntity.InstallCity = GetTextValue(dr, "InstallCity");
                objEntity.InstallState = GetTextValue(dr, "InstallState");
                objEntity.InstallerNotes = GetTextValue(dr, "InstallerNotes");
                objEntity.UpdateBy = GetInt32(dr, "UpdateBy");

                lstprojects.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstprojects;
        }

        public virtual List<ProjectsEntity> tblProjects_SelectAll(string userid)
        {
            List<ProjectsEntity> lstLocation = new List<ProjectsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjects_SelectAll";
            cmdGet.Parameters.AddWithValue("@UserID", userid);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ProjectsEntity objEntity = new ProjectsEntity();


                objEntity.ProjectID = GetInt32(dr, "ProjectID");
                objEntity.EmployeeName = GetTextValue(dr, "EmployeeName");
                objEntity.CustomerName = GetTextValue(dr, "CustomerName");
                objEntity.InstallAddress = GetTextValue(dr, "InstallAddress");
                objEntity.InstallArea = GetTextValue(dr, "InstallArea");
                objEntity.InstallCity = GetTextValue(dr, "InstallCity");
                objEntity.InstallState = GetTextValue(dr, "InstallState");
                objEntity.InstallerNotes = GetTextValue(dr, "InstallerNotes");
                objEntity.ProjectType = GetTextValue(dr, "ProjectType");
                objEntity.Task = GetTextValue(dr,"Task");

                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }
        public virtual List<ProjectsEntity> tblProjects_SelectByProjectStatus(string UserID, string ProjectStatus)
        {
            List<ProjectsEntity> lstprojects = new List<ProjectsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjects_SelectByProjectStatus";
           // cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            //cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            cmdGet.Parameters.AddWithValue("@UserID", UserID);
            cmdGet.Parameters.AddWithValue("@ProjectStatus", ProjectStatus);
           // SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            //p.Direction = ParameterDirection.Output;
            //cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ProjectsEntity objEntity = new ProjectsEntity();
                objEntity.ProjectID = GetInt64(dr, "ProjectID");
                objEntity.ProjectNumber = GetInt64(dr, "ProjectNumber");
                objEntity.ManualQuoteNumber = GetTextValue(dr, "ManualQuoteNumber");
                objEntity.ProjectType = GetTextValue(dr, "ProjectType");
                objEntity.ProjectStatus = GetTextValue(dr, "ProjectStatus");
                objEntity.CustomerName = GetTextValue(dr, "CustomerName");
                objEntity.ContactNO = GetTextValue(dr, "ContPhone");
                objEntity.ProjectOpened = GetDateTime(dr, "ProjectOpened");
                objEntity.Location = GetTextValue(dr, "BranchLocation");
                objEntity.InstallArea = GetTextValue(dr, "InstallArea");
                objEntity.InstallCity = GetTextValue(dr, "InstallCity");
                objEntity.InstallState = GetTextValue(dr, "InstallState");
                objEntity.InstallerNotes = GetTextValue(dr, "InstallerNotes");
                objEntity.UpdateBy = GetInt32(dr, "UpdateBy");

                lstprojects.Add(objEntity);
            }
            dr.Close();
          //  Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstprojects;
        }
        public virtual List<ProjectsEntity> tblProjects_SelectSearchByProjectStatus(string UserID, string ProjectStatus,string SearchKeyword, PagingEntity CommonEntity, out int Count)
        {
            List<ProjectsEntity> lstprojects = new List<ProjectsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjects_SelectSearchByProjectStatus";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            cmdGet.Parameters.AddWithValue("@UserID", UserID);
            cmdGet.Parameters.AddWithValue("@searchkeyword", SearchKeyword);
            cmdGet.Parameters.AddWithValue("@ProjectStatus", ProjectStatus);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ProjectsEntity objEntity = new ProjectsEntity();
                objEntity.ProjectID = GetInt64(dr, "ProjectID");
                objEntity.ProjectNumber = GetInt64(dr, "ProjectNumber");
                objEntity.ManualQuoteNumber = GetTextValue(dr, "ManualQuoteNumber");
                objEntity.ProjectType = GetTextValue(dr, "ProjectType");
                objEntity.ProjectStatus = GetTextValue(dr, "ProjectStatus");
                objEntity.CustomerName = GetTextValue(dr, "CustomerName");
                objEntity.ContactNO = GetTextValue(dr, "ContPhone");
                objEntity.ProjectOpened = GetDateTime(dr, "ProjectOpened");
                objEntity.Location = GetTextValue(dr, "BranchLocation");
                objEntity.InstallArea = GetTextValue(dr, "InstallArea");
                objEntity.InstallCity = GetTextValue(dr, "InstallCity");
                objEntity.InstallState = GetTextValue(dr, "InstallState");
                objEntity.InstallerNotes = GetTextValue(dr, "InstallerNotes");
                objEntity.UpdateBy = GetInt32(dr, "UpdateBy");

                lstprojects.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstprojects;
        }

        public virtual List<ProjectsEntity> tblProjects_SelectByProjectStatusForDropdown(string ProjectStatus, string userid)
        {
            List<ProjectsEntity> lstLocation = new List<ProjectsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjects_SelectByProjectStatusForDropdown";
            cmdGet.Parameters.AddWithValue("@ProjectStatus", ProjectStatus);
            cmdGet.Parameters.AddWithValue("@UserID", userid);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ProjectsEntity objEntity = new ProjectsEntity();
                objEntity.ProjectID = GetInt32(dr, "ProjectID");
                objEntity.ProjectNumber = GetInt64(dr, "ProjectNumber");
                objEntity.CustomerName = GetTextValue(dr, "CustomerName");

                objEntity.ProjectDetail = objEntity.ProjectNumber +" ("+ objEntity.CustomerName + ")";
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }
        public virtual List<ProjectsEntity> tblProjects_SelectByProjectIDForQuote(long ProjectID)
        {
            List<ProjectsEntity> lstLocation = new List<ProjectsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjects_SelectByProjectIDForQuote";
            cmdGet.Parameters.AddWithValue("@ProjectID", ProjectID);
      
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ProjectsEntity details = new ProjectsEntity();
                details.ProjectID = GetInt64(dr, "ProjectID");
                details.EmployeeID = GetInt32(dr, "EmployeeID");
                details.ProjectMgr = GetInt64(dr, "ProjectMgr");
                details.ContactID = GetInt64(dr, "ContactID");
                details.SalesRep = GetInt64(dr, "SalesRep");
                details.CustomerID = GetInt64(dr, "CustomerID");
                details.ProjectStatusID = GetInt32(dr, "ProjectStatusID");
                details.ProjectNumber = GetInt64(dr, "ProjectNumber");
                details.ProjectTypeID = GetInt32(dr, "ProjectTypeID");
                details.CustomerName = GetTextValue(dr, "CustomerName");
                details.ProjectType = GetTextValue(dr, "ProjectType");
                details.InstallAddress = GetTextValue(dr, "InstallAddress");
                details.InstallArea = GetTextValue(dr, "InstallArea");
                details.InstallState = GetTextValue(dr, "InstallState");
                details.InstallCity = GetTextValue(dr, "InstallCity");
                details.PanelBrand = GetTextValue(dr, "PanelBrand");
                details.InverterDetails = GetTextValue(dr, "InverterDetails");
                details.SecondInverterDetails = GetTextValue(dr, "SecondInverterDetails");
                details.NumberPanelsst = GetTextValue(dr, "NumberPanels");
                details.SystemCapKWst = GetTextValue(dr, "SystemCapKW");
                lstLocation.Add(details);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual ProjectsEntity tblProjects_SelectCustLogin(long ProjectNumber)
        {
            ProjectsEntity details = new ProjectsEntity();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjects_SelectCustLogin";
            cmdGet.Parameters.AddWithValue("@ProjectNumber", ProjectNumber);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                details.CustomerName = GetTextValue(dr, "Customer");
                details.InstallPostCode = GetTextValue(dr, "PCode");
                details.CustSourceID = GetInt32(dr, "CustSource");
                details.ProjectID = GetInt32(dr, "ProjectID");
            }
            dr.Close();
            ForceCloseConnection();
            return details;

        }
        public virtual ProjectsEntity tblProjects_SelectByProjectNumberCust(long ProjectNumber)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblProjects_SelectByProjectNumberCust";
            cmdGet.Parameters.AddWithValue("@ProjectNumber", ProjectNumber);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ProjectsEntity details = new ProjectsEntity();
            while (dr.Read())
            {
                details.CustomerName = GetTextValue(dr, "Contact");
                details.ContactNO = GetTextValue(dr, "ContactNumber");
                details.InvoiceStatus = GetBoolean(dr, "InvoiceStatus");
                details.SalesRepName = GetTextValue(dr, "SalesRepName");
                details.CustomerName = GetTextValue(dr, "Customer");
                details.InstallPostCode = GetTextValue(dr, "PCode");


            }
            dr.Close();
            ForceCloseConnection();
            return details;
        }



    }
}
