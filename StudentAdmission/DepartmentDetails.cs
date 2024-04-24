using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public class DepartmentDetails
    {
        /*
        Properties:
            a.	DepartmentID – (AutoIncrement - DID101)
            b.	DepartmentName
            c.	NumberOfSeats

        */

        //Field
        private static int s_departmentID=101;

        //Property
        public String DepartmentID { get; }
        public string DepartmentName { get; set; }
        public int NumberOfSeats { get; set; }

        //Constructor
        public DepartmentDetails(string departmentName,int numberOfSeats)
        {
            DepartmentID="DID"+s_departmentID;
            DepartmentName=departmentName;
            NumberOfSeats=numberOfSeats;
            //Auto Incrementation
            s_departmentID++;

        }
    }
}