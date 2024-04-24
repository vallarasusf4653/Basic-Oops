using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    
    public enum AdmissionStatus{Select,Admitted,Cancelled}
    public class AdmissionDetails
    {
        /*
        Properties:
            a.	AdmissionID – (Auto Increment ID - AID1001)
            b.	StudentID
            c.	DepartmentID
            d.	AdmissionDate
            e.	AdmissionStatus – Enum- (Select, Admitted, Cancelled)

        */

        // Field
        private static int s_admissionID=1001;

        // Property
        public string AdmissionID { get; }
        public string StudentID { get; set; }
        public string DepartmentID { get; set; }
        public DateTime AdmissionDate { get; set; }
        public AdmissionStatus AdmissionStatus { get; set; }

        //Constructor
        public AdmissionDetails(string studentID,string departmentID,DateTime admissionDate,AdmissionStatus admissionStatus)
        {
            AdmissionID="AID"+s_admissionID;
            StudentID=studentID;
            DepartmentID=departmentID;
            AdmissionDate=admissionDate;
            AdmissionStatus=admissionStatus;
            //Auto Incrementation
            s_admissionID++;

        }
    }
}