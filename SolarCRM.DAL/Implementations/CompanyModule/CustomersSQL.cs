using SolarCRM.Entity.Models.Common;
using SolarCRM.Entity.Models.CompanyModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.DAL.Implementations.CompanyModule
{
    public class CustomersSQL : BaseSqlManager
    {
        #region  Company Insert Call Method

        public virtual long tblCustomers_Insert(CustomersEntity CustEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblCustomers_Insert";
            cmdAdd.Parameters.AddWithValue("@EmployeeID", CustEntity.EmployeeID);
            cmdAdd.Parameters.AddWithValue("@CustTypeID", CustEntity.CustTypeID);
            cmdAdd.Parameters.AddWithValue("@CustSourceID", CustEntity.CustSourceID);
            cmdAdd.Parameters.AddWithValue("@CustSourceSubID", CustEntity.CustSourceSubID);
            cmdAdd.Parameters.AddWithValue("@ProjectTypeID", CustEntity.ProjectTypeID);
            cmdAdd.Parameters.AddWithValue("@CustEnteredBy", CustEntity.CustEnteredBy);
            cmdAdd.Parameters.AddWithValue("@CustEntered", CustEntity.CustEntered);
            cmdAdd.Parameters.AddWithValue("@CustMr", CustEntity.CustMr);
            cmdAdd.Parameters.AddWithValue("@CustFirst", CustEntity.CustFirst);
            cmdAdd.Parameters.AddWithValue("@CustLast", CustEntity.CustLast);
            cmdAdd.Parameters.AddWithValue("@Customer", CustEntity.Customer);
            cmdAdd.Parameters.AddWithValue("@StreetAddress", CustEntity.StreetAddress);
            cmdAdd.Parameters.AddWithValue("@StreetArea", CustEntity.StreetArea);
            cmdAdd.Parameters.AddWithValue("@StreetCity", CustEntity.StreetCity);
            cmdAdd.Parameters.AddWithValue("@StreetState", CustEntity.StreetState);
            cmdAdd.Parameters.AddWithValue("@StreetPostCode", CustEntity.StreetPostCode);
            cmdAdd.Parameters.AddWithValue("@PostalAddress", CustEntity.PostalAddress);
            cmdAdd.Parameters.AddWithValue("@PostalArea", CustEntity.PostalArea);
            cmdAdd.Parameters.AddWithValue("@PostalCity", CustEntity.PostalCity);
            cmdAdd.Parameters.AddWithValue("@PostalState", CustEntity.PostalState);
            cmdAdd.Parameters.AddWithValue("@PostalPostCode", CustEntity.PostalPostCode);
            cmdAdd.Parameters.AddWithValue("@Country", CustEntity.Country);
            cmdAdd.Parameters.AddWithValue("@CustEmail", CustEntity.CustEmail);
            cmdAdd.Parameters.AddWithValue("@CustMobile", CustEntity.CustMobile);
            cmdAdd.Parameters.AddWithValue("@CustPhone", CustEntity.CustPhone);
            cmdAdd.Parameters.AddWithValue("@CustAltPhone", CustEntity.CustAltPhone);
            cmdAdd.Parameters.AddWithValue("@CustFax", CustEntity.CustFax);
            cmdAdd.Parameters.AddWithValue("@CustNotes", CustEntity.CustNotes);
            cmdAdd.Parameters.AddWithValue("@CustWebSite", CustEntity.CustWebSite);
            cmdAdd.Parameters.AddWithValue("@BranchLocation", CustEntity.BranchLocation);
            cmdAdd.Parameters.AddWithValue("@Area", CustEntity.Area);
            cmdAdd.Parameters.AddWithValue("@CustRating", CustEntity.CustRating);
            cmdAdd.Parameters.AddWithValue("@CompanyType", CustEntity.CompanyType);
            cmdAdd.Parameters.AddWithValue("@CompanyLocationID", CustEntity.CompanyLocationID);
            cmdAdd.Parameters.AddWithValue("@ZoneID", CustEntity.ZoneID);
            

            long CustomerID = Convert.ToInt64(ExecuteScalar(cmdAdd));
            //long CustomerID = ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();
            return CustomerID;
        }

        public virtual long tblCustomers_InsertContacts(long CustomerID, string ContMr, string ContFirst, string ContLast, string ContMobile, string ContEmail, long EmployeeID, long ContactEnteredBy)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblCustomers_InsertContacts";
            cmdAdd.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdAdd.Parameters.AddWithValue("@ContMr", ContMr);
            cmdAdd.Parameters.AddWithValue("@ContFirst", ContFirst);
            cmdAdd.Parameters.AddWithValue("@ContLast", ContLast);
            cmdAdd.Parameters.AddWithValue("@ContMobile", ContMobile);
            cmdAdd.Parameters.AddWithValue("@ContEmail", ContEmail);
            cmdAdd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            cmdAdd.Parameters.AddWithValue("@ContactEntered", DateTime.UtcNow);
            cmdAdd.Parameters.AddWithValue("@ContactEnteredBy", ContactEnteredBy);

            long ContactsID = Convert.ToInt64(ExecuteScalar(cmdAdd));
            //long ContactID = ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();
            return ContactsID;
        }

        public virtual long tblCompanyNumber_Insert(long CustomerID)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblCompanyNumber_Insert";
            cmdAdd.Parameters.AddWithValue("@CustomerID", CustomerID);
            
            long CompanyNumber = ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();
            return CompanyNumber;
        }

        public virtual long tblCompanyNumber_Select(long CustomerID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCompanyNumber_Select";
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            long CompanyNumber = 0;
            while (dr.Read())
            {
                CompanyNumber = GetInt64(dr, "CompanyNumberID");
            }
            dr.Close();
            ForceCloseConnection();
            return CompanyNumber;
        }

        public virtual void tblCustomers_UpdateCompanyNumber(long CustomerID, long CompanyNumber)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblCustomers_UpdateCompanyNumber";
            cmdAdd.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdAdd.Parameters.AddWithValue("@CompanyNumber", CompanyNumber);
           
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        public virtual long tblCustDup_Insert(long CustEnteredBy, DateTime CustEntered, string DupName, string DupMobile, string DupEmail, string Customer, string ContEmail, string ContMobile, long CustomerID, long CompanyNumber)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblCustDup_Insert";
            cmdAdd.Parameters.AddWithValue("@CustEnteredBy", CustEnteredBy);
            cmdAdd.Parameters.AddWithValue("@CustEntered", CustEntered);
            cmdAdd.Parameters.AddWithValue("@DupName", DupName);
            cmdAdd.Parameters.AddWithValue("@DupMobile", DupMobile);
            cmdAdd.Parameters.AddWithValue("@DupEmail", DupEmail);
            cmdAdd.Parameters.AddWithValue("@Customer", Customer);
            cmdAdd.Parameters.AddWithValue("@ContEmail", ContEmail);
            cmdAdd.Parameters.AddWithValue("@ContMobile", ContMobile);
            cmdAdd.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdAdd.Parameters.AddWithValue("@CompanyNumber", CompanyNumber);
            long CusDup = ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();
            return CusDup;
        }

        public virtual long tblCustLogReport_Insert(long CustomerID)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblCustLogReport_Insert";
            cmdAdd.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdAdd.Parameters.AddWithValue("@CreateDate", DateTime.UtcNow);
           
            long CompanyNumber = ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();
            return CompanyNumber;
        }

        public virtual long tblContacts_ExistName(string Contact)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblContacts_ExistName";
            cmdAdd.Parameters.AddWithValue("@Contact", Contact);
           
            long Con = ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();
            return Con;
        }

        public virtual long tblContacts_ExistMobile(string Mobile)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblContacts_ExistMobile";
            cmdAdd.Parameters.AddWithValue("@Mobile", Mobile);
           
            long Con = ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();
            return Con;
        }

        public virtual long tblContacts_ExistEmail(string Email)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblContacts_ExistEmail";
            cmdAdd.Parameters.AddWithValue("@Email", Email);
            long Con = ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();
            return Con;
        }

        public virtual long tblCustomers_ExistPhone(string Phone)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblCustomers_ExistPhone";
            cmdAdd.Parameters.AddWithValue("@Phone", Phone);
           
            long Con = ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();
            return Con;
        }

        public virtual void ap_form_element_execute(string LogReport)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "ap_form_element_execute";
            cmdAdd.Parameters.AddWithValue("@LogReport", LogReport);
          
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

        }

        #endregion


        #region Duplicate Entry Select

        public virtual List<CustomerExistEntity> tblContacts_ExistSelect(string Contact)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblContacts_ExistSelect";
            cmdGet.Parameters.AddWithValue("@Contact", Contact);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<CustomerExistEntity> lstContacts = new List<CustomerExistEntity>();
            while (dr.Read())
            {
                CustomerExistEntity ObjEntity = new CustomerExistEntity();
                ObjEntity.Contacts = GetTextValue(dr, "Contacts");
                ObjEntity.Locations = GetTextValue(dr, "Locations");
                ObjEntity.ContMobile = GetTextValue(dr, "ContMobile");
                ObjEntity.ContEmail = GetTextValue(dr, "ContEmail");
                ObjEntity.AssignedTo = GetTextValue(dr, "AssignedTo");

                lstContacts.Add(ObjEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstContacts;
        }

        public virtual List<CustomerExistEntity> tblContacts_ExistSelectMobile(string Mobile)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblContacts_ExistSelectMobile";
            cmdGet.Parameters.AddWithValue("@Mobile", Mobile);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<CustomerExistEntity> lstContacts = new List<CustomerExistEntity>();
            while (dr.Read())
            {
                CustomerExistEntity ObjEntity = new CustomerExistEntity();
                ObjEntity.Contacts = GetTextValue(dr, "Contacts");
                ObjEntity.Locations = GetTextValue(dr, "Locations");
                ObjEntity.ContMobile = GetTextValue(dr, "ContMobile");
                ObjEntity.ContEmail = GetTextValue(dr, "ContEmail");
               
                lstContacts.Add(ObjEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstContacts;
        }

        public virtual List<CustomerExistEntity> tblContacts_ExistSelectEmail(string Email)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblContacts_ExistSelectEmail";
            cmdGet.Parameters.AddWithValue("@Email", Email);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<CustomerExistEntity> lstContacts = new List<CustomerExistEntity>();
            while (dr.Read())
            {
                CustomerExistEntity ObjEntity = new CustomerExistEntity();
                ObjEntity.Contacts = GetTextValue(dr, "Contacts");
                ObjEntity.Locations = GetTextValue(dr, "Locations");
                ObjEntity.ContMobile = GetTextValue(dr, "ContMobile");
                ObjEntity.ContEmail = GetTextValue(dr, "ContEmail");

                lstContacts.Add(ObjEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstContacts;
        }

        public virtual List<CustomerExistEntity> tblContacts_ExistSelectPhone(string Phone)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblContacts_ExistSelectPhone";
            cmdGet.Parameters.AddWithValue("@Phone", Phone);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            List<CustomerExistEntity> lstContacts = new List<CustomerExistEntity>();
            while (dr.Read())
            {
                CustomerExistEntity ObjEntity = new CustomerExistEntity();
                ObjEntity.Contacts = GetTextValue(dr, "Contacts");
                ObjEntity.Locations = GetTextValue(dr, "Locations");
                ObjEntity.ContMobile = GetTextValue(dr, "ContMobile");
                ObjEntity.ContEmail = GetTextValue(dr, "ContEmail");

                lstContacts.Add(ObjEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstContacts;
        }
        #endregion


        #region Bind Customer list
        public virtual List<CustomersEntity> tblCustomers_SelectRoleWise(PagingEntity CommonEntity, out int Count)
        {
            
            List<CustomersEntity> lstCustomers = new List<CustomersEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCustomers_SelectRoleWise";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                CustomersEntity objEntity = new CustomersEntity();
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.EmployeeID = GetInt64(dr, "EmployeeID");
                objEntity.CompanyNumber = GetInt64(dr, "CompanyNumber");     
                objEntity.Customer = GetTextValue(dr, "Customer");
                objEntity.Location = GetTextValue(dr, "Location");
                objEntity.CustMobile = GetTextValue(dr, "CustMobile");
                objEntity.ProjectTypeID = GetInt32(dr, "ProjectTypeID");
                if (objEntity.ProjectTypeID == 1)
                {
                    objEntity.ProjectType = "Residentail";
                }
                else
                {
                    objEntity.ProjectType = "Commercial";
                }
                objEntity.AssignedTo = GetTextValue(dr, "AssignedTo");
                objEntity.StreetAddress = GetTextValue(dr, "StreetAddress");
                objEntity.CustTypeID = GetInt32(dr, "CustTypeID");
                objEntity.CustType = GetTextValue(dr, "CustType");
                


                lstCustomers.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstCustomers;
        }


        public virtual CustomersEntity tblCustomers_SelectByCustomerID(long CustomerID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCustomers_SelectByCustomerID";
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
           
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            CustomersEntity objEntity = new CustomersEntity();
            while (dr.Read())
            {
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.EmployeeID = GetInt64(dr, "EmployeeID");

               // objEntity.ContactID = GetInt64(dr, "ContactID");

                objEntity.CompanyNumber = GetInt64(dr, "CompanyNumber");
                objEntity.Customer = GetTextValue(dr, "Customer");
                objEntity.FullName = GetTextValue(dr, "CustMr") + " " + GetTextValue(dr, "CustFirst") + " " + GetTextValue(dr, "CustLast");
                objEntity.CustMobile = GetTextValue(dr, "CustMobile");
                objEntity.CustPhone = GetTextValue(dr, "CustPhone");
                objEntity.CustAltPhone = GetTextValue(dr, "CustAltPhone");
                objEntity.CustEmail = GetTextValue(dr, "CustEmail");
                objEntity.CustType = GetTextValue(dr, "CustType");
                objEntity.CustSource = GetTextValue(dr, "CompanySource");
                objEntity.CustSourceSub = GetTextValue(dr, "CompanySourceSub");
                objEntity.CustNotes = GetTextValue(dr, "CustNotes");

                objEntity.StreetAddress = GetTextValue(dr, "StreetAddress");
                objEntity.StreetArea = GetTextValue(dr, "StreetArea");
                objEntity.StreetCity = GetTextValue(dr, "StreetCity");
                objEntity.StreetState = GetTextValue(dr, "StreetState");
                objEntity.StreetPostCode = GetTextValue(dr, "StreetPostCode");

                objEntity.PostalAddress = GetTextValue(dr, "PostalAddress");
                objEntity.PostalArea = GetTextValue(dr, "PostalArea");
                objEntity.PostalCity = GetTextValue(dr, "PostalCity");
                objEntity.PostalState = GetTextValue(dr, "PostalState");
                objEntity.PostalPostCode = GetTextValue(dr, "PostalPostCode");

                objEntity.Area = GetInt32(dr, "Area");
                if (objEntity.Area == 1)
                {
                    objEntity.AreaName = "Metro";
                }
                else
                {
                    objEntity.AreaName = "Regional";
                }

                objEntity.Country = GetTextValue(dr, "Country");
                objEntity.CustWebSite = GetTextValue(dr, "CustWebSite");
                objEntity.CustFax = GetTextValue(dr, "CustFax");
                objEntity.CustRating = GetTextValue(dr, "CustRating");

                objEntity.ProjectTypeID = GetInt32(dr, "ProjectTypeID");
               // objEntity.ProjectType = GetTextValue(dr, "ProjectType");

                //if (objEntity.ProjectTypeID == 1)
                //{
                //    objEntity.ProjectType = "Residentail";
                //}
                //else
                //{
                //    objEntity.ProjectType = "Commercial";
                //}
                objEntity.AssignedTo = GetTextValue(dr, "AssignedTo");
                objEntity.CompanyTypeName = GetTextValue(dr, "CompanyTypeName");
                objEntity.CompanyLocationID = GetInt32(dr, "CompanyLocationID");

            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual List<ContactsEntity> tblContacts_SelectByCustomerID(long CustomerID)
        {
            List<ContactsEntity> lstcontacts = new List<ContactsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblContacts_SelectByCustomerID";
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ContactsEntity objEntity = new ContactsEntity();

                objEntity.ContactID = GetInt64(dr, "ContactID");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.EmployeeID = GetInt64(dr, "EmployeeID");
                objEntity.Customer = GetTextValue(dr, "Customer");
                objEntity.FullName = GetTextValue(dr, "ContMr") + " " + GetTextValue(dr, "ContFirst") + " " + GetTextValue(dr, "ContLast");
                objEntity.ContMobile = GetTextValue(dr, "ContMobile");
                objEntity.ContPhone = GetTextValue(dr, "ContPhone");
                objEntity.ContEmail = GetTextValue(dr, "ContEmail");
              
                lstcontacts.Add(objEntity);

            }
            dr.Close();
            ForceCloseConnection();
            return lstcontacts;
        }


        public virtual ContactsEntity tblContacts_SelectByContactID(long ContactID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblContacts_SelectByContactID";
            cmdGet.Parameters.AddWithValue("@ContactID", ContactID);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ContactsEntity objEntity = new ContactsEntity();
            while (dr.Read())
            {
                objEntity.ContactID = GetInt64(dr, "ContactID");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.ContMr = GetTextValue(dr, "ContMr");
                objEntity.ContFirst = GetTextValue(dr, "ContFirst");
                objEntity.ContLast = GetTextValue(dr, "ContLast");
                objEntity.FullName = objEntity.ContFirst + " " + objEntity.ContLast;
                objEntity.ContEmail = GetTextValue(dr, "ContEmail");
                objEntity.ContMobile = GetTextValue(dr, "ContMobile");
                objEntity.ContPhone = GetTextValue(dr, "ContPhone");
                objEntity.ContHomePhone = GetTextValue(dr, "ContHomePhone");
                objEntity.ContFax = GetTextValue(dr, "ContFax");
                objEntity.ContactEntered = GetDateTime(dr, "ContactEntered");
                objEntity.ContactEnteredBy = GetInt64(dr, "ContactEnteredBy");
                objEntity.StreetAddress = GetTextValue(dr, "StreetAddress");
                objEntity.StreetArea = GetTextValue(dr, "StreetArea");
                objEntity.StreetCity = GetTextValue(dr, "StreetCity");
                objEntity.StreetState = GetTextValue(dr, "StreetState");
                objEntity.StreetPostCode = GetTextValue(dr, "StreetPostCode");

                objEntity.EmployeeID = GetInt64(dr, "EmployeeID");
                objEntity.ContLeadStatusID = GetInt32(dr, "ContLeadStatusID");
                objEntity.SendEmail = GetBoolean(dr, "SendEmail");
                objEntity.SendSMS = GetBoolean(dr, "SendSMS");
                objEntity.ActiveTag = GetBoolean(dr, "ActiveTag");

            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }


        public virtual List<ContactsEntity> tblContLeadStatus_SelectActive()
        {
            List<ContactsEntity> lstLocation = new List<ContactsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblContLeadStatus_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ContactsEntity objEntity = new ContactsEntity();
                objEntity.ContLeadStatusID = GetInt32(dr, "ContLeadStatusID");
                objEntity.ContLeadStatus = GetTextValue(dr, "ContLeadStatus");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<ContactsEntity> tblContLeadCancelReason_SelectActive()
        {
            List<ContactsEntity> lstLocation = new List<ContactsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblContLeadCancelReason_SelectActive";

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ContactsEntity objEntity = new ContactsEntity();
                objEntity.ContLeadCancelReasonID = GetInt32(dr, "ContLeadCancelReasonID");
                objEntity.ContLeadCancelReason = GetTextValue(dr, "ContLeadCancelReason");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual void tblContacts_UpdateDetail(ContactsEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblContacts_UpdateDetail";
            cmdAdd.Parameters.AddWithValue("@ContactID", ObjEntity.ContactID);
            cmdAdd.Parameters.AddWithValue("@ContMr", ObjEntity.ContMr);
            cmdAdd.Parameters.AddWithValue("@ContFirst", ObjEntity.ContFirst);
            cmdAdd.Parameters.AddWithValue("@ContLast", ObjEntity.ContLast);
            cmdAdd.Parameters.AddWithValue("@ContMobile", ObjEntity.ContMobile);
            cmdAdd.Parameters.AddWithValue("@ContEmail", ObjEntity.ContEmail);
            cmdAdd.Parameters.AddWithValue("@ContPhone", ObjEntity.ContPhone);
            cmdAdd.Parameters.AddWithValue("@ContHomePhone", ObjEntity.ContHomePhone);
            cmdAdd.Parameters.AddWithValue("@ContFax", ObjEntity.ContFax);
            cmdAdd.Parameters.AddWithValue("@EmployeeID", ObjEntity.EmployeeID);
            cmdAdd.Parameters.AddWithValue("@ContLeadStatusID", ObjEntity.ContLeadStatusID);
            cmdAdd.Parameters.AddWithValue("@ContLeadCancelReasonID", ObjEntity.ContLeadCancelReasonID);
            cmdAdd.Parameters.AddWithValue("@ActiveTag", ObjEntity.ActiveTag);
            cmdAdd.Parameters.AddWithValue("@SendEmail", ObjEntity.SendEmail);
            cmdAdd.Parameters.AddWithValue("@SendSMS", ObjEntity.SendSMS);
            
            //long ContactsID = Convert.ToInt64(ExecuteScalar(cmdAdd));
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();
            //return ContactsID;
        }

        #endregion


        #region  ContactNotes Insert & Get for bind

        public virtual void tblContNotes_Insert(ContactNotesEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblContNotes_Insert";
            cmdAdd.Parameters.AddWithValue("@EmployeeID", ObjEntity.EmployeeID);
            cmdAdd.Parameters.AddWithValue("@ContactID", ObjEntity.ContactID);
            cmdAdd.Parameters.AddWithValue("@NoteSetBy", ObjEntity.NoteSetBy);
            cmdAdd.Parameters.AddWithValue("@ContNoteDate", ObjEntity.ContNoteDate);
            cmdAdd.Parameters.AddWithValue("@ContNote", ObjEntity.ContNote);

            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();
        }


        public virtual List<ContactNotesEntity> tblContNotes_SelectByContactID(long ContactID)
        {
            List<ContactNotesEntity> lstContactNotes = new List<ContactNotesEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblContNotes_SelectByContactID";
            cmdGet.Parameters.AddWithValue("@ContactID", ContactID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ContactNotesEntity objEntity = new ContactNotesEntity();

                objEntity.ContNoteID = GetInt64(dr, "ContNoteID");
                objEntity.EmployeeName = GetTextValue(dr, "EmployeeName");
                objEntity.NoteSetName = GetTextValue(dr, "NoteSetName");
                objEntity.ContNoteDate = GetDateTime(dr, "ContNoteDate");
                objEntity.ContNote = GetTextValue(dr, "ContNote");

                lstContactNotes.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstContactNotes;
        }

        #endregion


        public virtual void tblCustomers_UpdateCustType(int CustTypeID, long CustomerID)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblCustomers_UpdateCustType";
            cmdAdd.Parameters.AddWithValue("@CustTypeID", CustTypeID);
            cmdAdd.Parameters.AddWithValue("@CustomerID", CustomerID);

            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();
        }

        public virtual void tblContacts_UpdateContLeadStatus(int ContLeadStatusID, long ContactID)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblContacts_UpdateContLeadStatus";
            cmdAdd.Parameters.AddWithValue("@ContLeadStatusID", ContLeadStatusID);
            cmdAdd.Parameters.AddWithValue("@ContactID", ContactID);

            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();
        }

        public virtual long tblCustomers_SelectContactID(string CustomerName)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCustomers_SelectContactID";
            cmdGet.Parameters.AddWithValue("@CustomerName", CustomerName);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            long ContactID = 0;
            while (dr.Read())
            {
                ContactID = GetInt64(dr, "ContactID");
            }
            dr.Close();
            ForceCloseConnection();
            return ContactID;
        }

        public virtual void tblCustomers_UpdateReferral(long CustomerID, long ContactID)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblCustomers_UpdateReferral";
            cmdAdd.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdAdd.Parameters.AddWithValue("@ContactID", ContactID);

            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();
        }

        public virtual CustomersEntity tblCustomer_ForEdit(int CustomerID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCustomer_ForEdit";
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            CustomersEntity objEntity = new CustomersEntity();
            while (dr.Read())
            {
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.EmployeeID = GetInt64(dr, "EmployeeID");
                objEntity.CompanyNumber = GetInt64(dr, "CompanyNumber");
                objEntity.Customer = GetTextValue(dr, "Customer");
                objEntity.CustMr = GetTextValue(dr, "CustMr");
                objEntity.CustFirst = GetTextValue(dr, "CustFirst");
                objEntity.CustLast = GetTextValue(dr, "CustLast");
                objEntity.FullName = GetTextValue(dr, "CustMr") + " " + GetTextValue(dr, "CustFirst") + " " + GetTextValue(dr, "CustLast");
                objEntity.CustMobile = GetTextValue(dr, "CustMobile");
                objEntity.CustPhone = GetTextValue(dr, "CustPhone");
                objEntity.CustAltPhone = GetTextValue(dr, "CustAltPhone");
                objEntity.CustEmail = GetTextValue(dr, "CustEmail");
                objEntity.CustTypeID = GetInt32(dr, "CustTypeID");
                objEntity.CustSourceID = GetInt32(dr, "CustSourceID");
                objEntity.CustSourceSubID = GetInt32(dr, "CustSourceSubID");
                objEntity.CustNotes = GetTextValue(dr, "CustNotes");

                objEntity.StreetAddress = GetTextValue(dr, "StreetAddress");
                objEntity.StreetArea = GetTextValue(dr, "StreetArea");
                objEntity.StreetCity = GetTextValue(dr, "StreetCity");
                objEntity.StreetState = GetTextValue(dr, "StreetState");
                objEntity.StreetPostCode = GetTextValue(dr, "StreetPostCode");

                objEntity.PostalAddress = GetTextValue(dr, "PostalAddress");
                objEntity.PostalArea = GetTextValue(dr, "PostalArea");
                objEntity.PostalCity = GetTextValue(dr, "PostalCity");
                objEntity.PostalState = GetTextValue(dr, "PostalState");
                objEntity.PostalPostCode = GetTextValue(dr, "PostalPostCode");

                objEntity.Area = GetInt32(dr, "Area");
                if (objEntity.Area == 1)
                {
                    objEntity.AreaName = "Metro";
                }
                else
                {
                    objEntity.AreaName = "Regional";
                }

                objEntity.CompanyType = GetInt32(dr, "CompanyType");


                objEntity.Country = GetTextValue(dr, "Country");
                objEntity.CustWebSite = GetTextValue(dr, "CustWebSite");
                objEntity.CustFax = GetTextValue(dr, "CustFax");
                objEntity.CustRating = GetTextValue(dr, "CustRating");

                objEntity.ProjectTypeID = GetInt32(dr, "ProjectTypeID");
                if (objEntity.ProjectTypeID == 1)
                {
                    objEntity.ProjectType = "Residentail";
                }
                else
                {
                    objEntity.ProjectType = "Commercial";
                }
                objEntity.AssignedTo = GetTextValue(dr, "AssignedTo");
                objEntity.CompanyTypeName = GetTextValue(dr, "CompanyTypeName");
                objEntity.CompanyLocationID = GetInt32(dr, "CompanyLocationID");
                objEntity.ZoneID = GetInt32(dr, "ZoneID");
                
                
            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }

        public virtual void tblCustomers_Update(CustomersEntity ObjEntity)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblCustomers_Update";
            cmdAdd.Parameters.AddWithValue("@CustomerID", ObjEntity.CustomerID);       
            cmdAdd.Parameters.AddWithValue("@EmployeeID", ObjEntity.EmployeeID);
            cmdAdd.Parameters.AddWithValue("@CustTypeID", ObjEntity.CustTypeID);
            cmdAdd.Parameters.AddWithValue("@CustSourceID", ObjEntity.CustSourceID);
            cmdAdd.Parameters.AddWithValue("@CustSourceSubID", ObjEntity.CustSourceSubID);
            cmdAdd.Parameters.AddWithValue("@ProjectTypeID", ObjEntity.ProjectTypeID);
            cmdAdd.Parameters.AddWithValue("@CustEnteredBy", ObjEntity.CustEnteredBy);
            cmdAdd.Parameters.AddWithValue("@CustEntered", ObjEntity.CustEntered);
            cmdAdd.Parameters.AddWithValue("@CustMr", ObjEntity.CustMr);
            cmdAdd.Parameters.AddWithValue("@CustFirst", ObjEntity.CustFirst);
            cmdAdd.Parameters.AddWithValue("@CustLast", ObjEntity.CustLast);
            cmdAdd.Parameters.AddWithValue("@Customer", ObjEntity.Customer);
            cmdAdd.Parameters.AddWithValue("@StreetAddress", ObjEntity.StreetAddress);
            cmdAdd.Parameters.AddWithValue("@StreetArea", ObjEntity.StreetArea);
            cmdAdd.Parameters.AddWithValue("@StreetCity", ObjEntity.StreetCity);
            cmdAdd.Parameters.AddWithValue("@StreetState", ObjEntity.StreetState);
            cmdAdd.Parameters.AddWithValue("@StreetPostCode", ObjEntity.StreetPostCode);
            cmdAdd.Parameters.AddWithValue("@PostalAddress", ObjEntity.PostalAddress);
            cmdAdd.Parameters.AddWithValue("@PostalArea", ObjEntity.PostalArea);
            cmdAdd.Parameters.AddWithValue("@PostalCity", ObjEntity.PostalCity);
            cmdAdd.Parameters.AddWithValue("@PostalState", ObjEntity.PostalState);
            cmdAdd.Parameters.AddWithValue("@PostalPostCode", ObjEntity.PostalPostCode);
            cmdAdd.Parameters.AddWithValue("@Country", ObjEntity.Country);
            cmdAdd.Parameters.AddWithValue("@CustEmail", ObjEntity.CustEmail);
            cmdAdd.Parameters.AddWithValue("@CustMobile", ObjEntity.CustMobile);
            cmdAdd.Parameters.AddWithValue("@CustPhone", ObjEntity.CustPhone);
            cmdAdd.Parameters.AddWithValue("@CustAltPhone", ObjEntity.CustAltPhone);
            cmdAdd.Parameters.AddWithValue("@CustFax", ObjEntity.CustFax);
            cmdAdd.Parameters.AddWithValue("@CustNotes", ObjEntity.CustNotes);
            cmdAdd.Parameters.AddWithValue("@CustWebSite", ObjEntity.CustWebSite);
            cmdAdd.Parameters.AddWithValue("@BranchLocation", ObjEntity.BranchLocation);
            cmdAdd.Parameters.AddWithValue("@Area", ObjEntity.Area);
            cmdAdd.Parameters.AddWithValue("@CustRating", ObjEntity.CustRating);
            cmdAdd.Parameters.AddWithValue("@CompanyType", ObjEntity.CompanyType);
            cmdAdd.Parameters.AddWithValue("@ZoneID", ObjEntity.ZoneID);
            
         //   cmdAdd.Parameters.AddWithValue("@CompanyLocationID", ObjEntity.CompanyLocationID);

            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();

           
          
        }

        public virtual List<ContactsEntity> tblContacts_SelectByCustId(long CustomerID)
        {
            List<ContactsEntity> lstLocation = new List<ContactsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblContacts_SelectByCustId";
            cmdGet.Parameters.AddWithValue("@CustomerID", CustomerID);
          
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ContactsEntity objEntity = new ContactsEntity();
                objEntity.ContactID = GetInt32(dr, "ContactID");
                objEntity.FullName = GetTextValue(dr, "Contact");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<CustomersEntity> tblCustomers_SelectForLeadTracker(PagingEntity CommonEntity, out int Count)
        {
            List<CustomersEntity> lstprojects = new List<CustomersEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCustomers_SelectForLeadTracker";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                CustomersEntity objEntity = new CustomersEntity();
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.Customer = GetTextValue(dr, "Customer");
                objEntity.Address = GetTextValue(dr, "Address");               
                objEntity.StreetCity = GetTextValue(dr, "StreetCity");
                objEntity.StreetState = GetTextValue(dr, "StreetState");
                objEntity.CustMobile = GetTextValue(dr, "CustMobile");
                objEntity.CustNotes = GetTextValue(dr, "CustNotes");
                objEntity.CompanySource = GetTextValue(dr, "CompanySource");
                objEntity.CustEntered = GetDateTime(dr, "CustEntered");
                objEntity.EmployeeName = GetTextValue(dr, "EmployeeName");
                lstprojects.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstprojects;
        }

        public virtual List<CustomersEntity> tblCustomers_SelectForContact(PagingEntity CommonEntity, out int Count)
        {
            List<CustomersEntity> lstprojects = new List<CustomersEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCustomers_SelectForContact";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                CustomersEntity objEntity = new CustomersEntity();
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.Customer = GetTextValue(dr, "Customer");
                objEntity.Address = GetTextValue(dr, "Address");
                objEntity.CustMobile = GetTextValue(dr, "CustMobile");
                objEntity.EmployeeName = GetTextValue(dr, "EmployeeName");
                objEntity.StreetPostCode = GetTextValue(dr, "StreetPostCode");
                objEntity.CustType = GetTextValue(dr, "CustType");
                //objEntity.ProjectStatus = GetTextValue(dr, "ProjectStatus");
                objEntity.QuoteSent = GetDateTime(dr, "QuoteSent");
                objEntity.LeadFollowUp = GetDateTime(dr, "LeadFollowUp");             
                lstprojects.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstprojects;
        }

        public virtual List<ContactsEntity> tblContacts_SelectAvailInstaller(string date1, string date2, string InstallState, int isactive, string ContactID)
        {
            List<ContactsEntity> lstLocation = new List<ContactsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblContacts_SelectAvailInstaller";
            cmdGet.Parameters.AddWithValue("@date1", date1);
            cmdGet.Parameters.AddWithValue("@date12", date2);
            cmdGet.Parameters.AddWithValue("@InstallState", InstallState);
            cmdGet.Parameters.AddWithValue("@isactive", isactive);
            cmdGet.Parameters.AddWithValue("@ContactID", ContactID);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ContactsEntity objEntity = new ContactsEntity();
                objEntity.ContactID = GetInt32(dr, "ContactID");
                objEntity.Contact = GetTextValue(dr, "Contact");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<ContactsEntity> tblContacts_SelectInstallerByState(string InstallState)
        {
            List<ContactsEntity> lstLocation = new List<ContactsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblContacts_SelectInstallerByState";
            cmdGet.Parameters.AddWithValue("@InstallState", InstallState);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ContactsEntity objEntity = new ContactsEntity();
                objEntity.ContactID = GetInt32(dr, "ContactID");
                objEntity.Contact = GetTextValue(dr, "Contact");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<ContactsEntity> tblContacts_SelectMeterElectrician(int isactive, string ContactID)
        {
            List<ContactsEntity> lstLocation = new List<ContactsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblContacts_SelectMeterElectrician";
            cmdGet.Parameters.AddWithValue("@isactive", isactive);
            cmdGet.Parameters.AddWithValue("@ContactID", ContactID);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ContactsEntity objEntity = new ContactsEntity();
                objEntity.ContactID = GetInt32(dr, "ContactID");
                objEntity.Contact = GetTextValue(dr, "Contact");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<ContactsEntity> tblContacts_SelectDesigner(int isactive, string ContactID)
        {
            List<ContactsEntity> lstLocation = new List<ContactsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblContacts_SelectDesigner";
            cmdGet.Parameters.AddWithValue("@isactive", isactive);
            cmdGet.Parameters.AddWithValue("@ContactID", ContactID);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ContactsEntity objEntity = new ContactsEntity();
                objEntity.ContactID = GetInt32(dr, "ContactID");
                objEntity.Contact = GetTextValue(dr, "Contact");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }
        public virtual List<ContactsEntity> tblContacts_SelectElectrician(int isactive, string ContactID)
        {
            List<ContactsEntity> lstLocation = new List<ContactsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblContacts_SelectElectrician";
            cmdGet.Parameters.AddWithValue("@isactive", isactive);
            cmdGet.Parameters.AddWithValue("@ContactID", ContactID);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                ContactsEntity objEntity = new ContactsEntity();
                objEntity.ContactID = GetInt32(dr, "ContactID");
                objEntity.Contact = GetTextValue(dr, "Contact");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }
        public virtual List<ContactsEntity> tblContacts_SelectDesignerByContactID(long ContactID)
        {
            List<ContactsEntity> lstLocation = new List<ContactsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblContacts_SelectDesignerByContactID";
            cmdGet.Parameters.AddWithValue("@ContactID", ContactID);

            SqlDataReader dr = ExecuteDataReader(cmdGet);

            while (dr.Read())
            {
                ContactsEntity objEntity = new ContactsEntity();
                objEntity.ContactID = GetInt32(dr, "ContactID");
                objEntity.FullName = GetTextValue(dr, "Contact");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }
        public virtual List<ContactsEntity> tblContacts_SelectElectricianByContactID(long ContactID)
        {
            List<ContactsEntity> lstLocation = new List<ContactsEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblContacts_SelectElectricianByContactID";
            cmdGet.Parameters.AddWithValue("@ContactID", ContactID);

            SqlDataReader dr = ExecuteDataReader(cmdGet);

            while (dr.Read())
            {
                ContactsEntity objEntity = new ContactsEntity();
                objEntity.ContactID = GetInt32(dr, "ContactID");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual ContactsEntity tblCustomers_SelectByCustType(long CustTypeID)
        {
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCustomers_SelectByCustType";
            cmdGet.Parameters.AddWithValue("@CustTypeID", CustTypeID);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            ContactsEntity objEntity = new ContactsEntity();
            while (dr.Read())
            {
                objEntity.ContactID = GetInt64(dr, "ContactID");
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.ContMr = GetTextValue(dr, "ContMr");
                objEntity.ContFirst = GetTextValue(dr, "ContFirst");
                objEntity.ContLast = GetTextValue(dr, "ContLast");
                objEntity.FullName = objEntity.ContFirst + " " + objEntity.ContLast;
                objEntity.ContEmail = GetTextValue(dr, "ContEmail");
                objEntity.ContMobile = GetTextValue(dr, "ContMobile");
                objEntity.ContPhone = GetTextValue(dr, "ContPhone");
                objEntity.ContHomePhone = GetTextValue(dr, "ContHomePhone");
                objEntity.ContFax = GetTextValue(dr, "ContFax");
                objEntity.ContactEntered = GetDateTime(dr, "ContactEntered");
                objEntity.ContactEnteredBy = GetInt64(dr, "ContactEnteredBy");
                objEntity.StreetAddress = GetTextValue(dr, "StreetAddress");
                objEntity.StreetArea = GetTextValue(dr, "StreetArea");
                objEntity.StreetCity = GetTextValue(dr, "StreetCity");
                objEntity.StreetState = GetTextValue(dr, "StreetState");
                objEntity.StreetPostCode = GetTextValue(dr, "StreetPostCode");

                objEntity.EmployeeID = GetInt64(dr, "EmployeeID");
                objEntity.ContLeadStatusID = GetInt32(dr, "ContLeadStatusID");
                objEntity.SendEmail = GetBoolean(dr, "SendEmail");
                objEntity.SendSMS = GetBoolean(dr, "SendSMS");
                objEntity.ActiveTag = GetBoolean(dr, "ActiveTag");

            }
            dr.Close();
            ForceCloseConnection();
            return objEntity;
        }




        public virtual void tblCustomers_UpdateCustTypeID( int CustomerID,int CustTypeID)
        {
            SqlCommand cmdAdd = new SqlCommand();
            cmdAdd.CommandType = CommandType.StoredProcedure;
            cmdAdd.CommandText = "tblCustomers_UpdateCustTypeID";
            cmdAdd.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmdAdd.Parameters.AddWithValue("@CustTypeID", CustTypeID);           
            ExecuteNonQuery(cmdAdd);
            ForceCloseConnection();
        }


        public virtual List<CustomersEntity> tblCustomer_SelectByCustomerTypeID(int CustomerTypeID)
        {
            List<CustomersEntity> lstLocation = new List<CustomersEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCustomer_SelectByCustomerTypeID";
            cmdGet.Parameters.AddWithValue("@CustomerTypeID", CustomerTypeID);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                CustomersEntity objEntity = new CustomersEntity();
                objEntity.CustomerID = GetInt32(dr, "CustomerID");
                objEntity.Customer = GetTextValue(dr, "Customer");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }
        public virtual List<CustomersEntity> tblCustomer_SelectForLeadDashboard(string CustType, string userid)
        {
            List<CustomersEntity> lstLocation = new List<CustomersEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCustomer_SelectForLeadDashboard";
            cmdGet.Parameters.AddWithValue("@CustType", CustType);
            cmdGet.Parameters.AddWithValue("@UserID",userid);

            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                CustomersEntity objEntity = new CustomersEntity();
                objEntity.CustomerID = GetInt32(dr, "CustomerID");
                objEntity.CompanyNumber = GetInt64(dr, "CompanyNumber");
                objEntity.Customer = GetTextValue(dr, "Customer");
                objEntity.CustMobile = GetTextValue(dr, "CustMobile");
                objEntity.StreetPostCode = GetTextValue(dr, "StreetPostCode");
                objEntity.CustType = GetTextValue(dr, "CustType");
                objEntity.CustRating = GetTextValue(dr, "CustRating");
                lstLocation.Add(objEntity);
            }
            dr.Close();
            ForceCloseConnection();
            return lstLocation;
        }

        public virtual List<CustomersEntity> tblCustomer_SelectForReport(DateTime FromDate, DateTime ToDate, String UserID)
        {
            
            List<CustomersEntity> lstCustomers = new List<CustomersEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCustomer_SelectForReport";
           // cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
          //  cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            cmdGet.Parameters.AddWithValue("@fromdate", FromDate);
            cmdGet.Parameters.AddWithValue("@todate", ToDate);
            cmdGet.Parameters.AddWithValue("@UserID",UserID);
          //  SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
          //  p.Direction = ParameterDirection.Output;
          //  cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                CustomersEntity objEntity = new CustomersEntity();
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.EmployeeID = GetInt64(dr, "EmployeeID");
                objEntity.CompanyNumber = GetInt64(dr, "CompanyNumber");     
                objEntity.Customer = GetTextValue(dr, "Customer");
                objEntity.Location = GetTextValue(dr, "Location");
                objEntity.CustMobile = GetTextValue(dr, "CustMobile");
                objEntity.ProjectTypeID = GetInt32(dr, "ProjectTypeID");
                if (objEntity.ProjectTypeID == 1)
                {
                    objEntity.ProjectType = "Residentail";
                }
                else
                {
                    objEntity.ProjectType = "Commercial";
                }
                objEntity.AssignedTo = GetTextValue(dr, "AssignedTo");
                objEntity.StreetAddress = GetTextValue(dr, "StreetAddress");
                objEntity.CustTypeID = GetInt32(dr, "CustTypeID");
                objEntity.CustType = GetTextValue(dr, "CustType");
                


                lstCustomers.Add(objEntity);
            }
            dr.Close();
         //   Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstCustomers;
        }
        public virtual List<CustomersEntity> tblCustomer_SelectForReportAll(String UserID)
        {

            List<CustomersEntity> lstCustomers = new List<CustomersEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCustomer_SelectForReportAll";
          //  cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
           // cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            cmdGet.Parameters.AddWithValue("@UserID", UserID);
            //SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            //p.Direction = ParameterDirection.Output;
            //cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                CustomersEntity objEntity = new CustomersEntity();
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.EmployeeID = GetInt64(dr, "EmployeeID");
                objEntity.CompanyNumber = GetInt64(dr, "CompanyNumber");
                objEntity.Customer = GetTextValue(dr, "Customer");
                objEntity.Location = GetTextValue(dr, "Location");
                objEntity.CustMobile = GetTextValue(dr, "CustMobile");
                objEntity.ProjectTypeID = GetInt32(dr, "ProjectTypeID");
                if (objEntity.ProjectTypeID == 1)
                {
                    objEntity.ProjectType = "Residentail";
                }
                else
                {
                    objEntity.ProjectType = "Commercial";
                }
                objEntity.AssignedTo = GetTextValue(dr, "AssignedTo");
                objEntity.StreetAddress = GetTextValue(dr, "StreetAddress");
                objEntity.CustTypeID = GetInt32(dr, "CustTypeID");
                objEntity.CustType = GetTextValue(dr, "CustType");



                lstCustomers.Add(objEntity);
            }
            dr.Close();
           // Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstCustomers;
        }

        public virtual List<CustomersEntity> tblCustomer_SelectSearchForReport(DateTime FromDate, DateTime ToDate, String UserID, string SearchKeyword, PagingEntity CommonEntity, out int Count)
        {
            
            List<CustomersEntity> lstCustomers = new List<CustomersEntity>();
            SqlCommand cmdGet = new SqlCommand();
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.CommandText = "tblCustomer_SelectSearchForReport";
            cmdGet.Parameters.AddWithValue("@PageNo", CommonEntity.PageNo);
            cmdGet.Parameters.AddWithValue("@PageSize", CommonEntity.PageSize);
            cmdGet.Parameters.AddWithValue("@fromdate", FromDate);
            cmdGet.Parameters.AddWithValue("@todate", ToDate);
            cmdGet.Parameters.AddWithValue("@UserID",UserID);
            cmdGet.Parameters.AddWithValue("@searchkeyword", SearchKeyword);
            SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmdGet.Parameters.Add(p);
            SqlDataReader dr = ExecuteDataReader(cmdGet);
            while (dr.Read())
            {
                CustomersEntity objEntity = new CustomersEntity();
                objEntity.CustomerID = GetInt64(dr, "CustomerID");
                objEntity.EmployeeID = GetInt64(dr, "EmployeeID");
                objEntity.CompanyNumber = GetInt64(dr, "CompanyNumber");     
                objEntity.Customer = GetTextValue(dr, "Customer");
                objEntity.Location = GetTextValue(dr, "Location");
                objEntity.CustMobile = GetTextValue(dr, "CustMobile");
                objEntity.ProjectTypeID = GetInt32(dr, "ProjectTypeID");
                if (objEntity.ProjectTypeID == 1)
                {
                    objEntity.ProjectType = "Residentail";
                }
                else
                {
                    objEntity.ProjectType = "Commercial";
                }
                objEntity.AssignedTo = GetTextValue(dr, "AssignedTo");
                objEntity.StreetAddress = GetTextValue(dr, "StreetAddress");
                objEntity.CustTypeID = GetInt32(dr, "CustTypeID");
                objEntity.CustType = GetTextValue(dr, "CustType");
                


                lstCustomers.Add(objEntity);
            }
            dr.Close();
            Count = Convert.ToInt32(cmdGet.Parameters["@TotalCount"].Value.ToString());
            ForceCloseConnection();
            return lstCustomers;
        }

    }
}
