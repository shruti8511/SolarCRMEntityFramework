using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarCRM.Entity.Models.CompanyModule
{
    public class ContactNotesEntity
    {
        public long ContNoteID { get; set; }
        public long ContactID { get; set; }
        public long EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public long NoteSetBy { get; set; }
        public string NoteSetName { get; set; }
        public DateTime ContNoteDate { get; set; }
        public int ContNoteTypeID { get; set; }
        public string ContNote { get; set; }
        public bool ContNoteDone { get; set; }
        public string ContNoteSubject { get; set; }
    }
}
