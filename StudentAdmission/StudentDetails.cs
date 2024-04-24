using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public enum Gender{Male,Female,Transgender}
    public class StudentDetails
    {
        /*
            Properties: 
                a.	StudentID – (AutoGeneration ID – SF3000)
                b.	StudentName
                c.	FatherName
                d.	DOB
                e.	Gender – Enum (Male, Female, Transgender)
                f.	Physics
                g.	Chemistry
                h.	Maths

        */

        //Property
        private static int s_studentID=3000;
        public string StudentID { get;  }
        public string StudentName { get; set; }
        public string  FatherName { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int Maths { get; set; }

        //Constructor
        public StudentDetails(string studentName,string fatherName,DateTime dob,Gender gender,int physics,int chemistry,int maths)
        {
            //Auto Incrementation
            s_studentID++;
            
            StudentID="SF"+s_studentID;
            StudentName=studentName;
            FatherName=fatherName;
            DOB=dob;
            Gender=gender;
            Physics=physics;
            Chemistry=chemistry;
            Maths=maths;
        }

        //Methods
        public double Average()
        {
            int total=Physics+Chemistry+Maths;
            double  average = (double)total/3;
            return average;
        }
        public bool CheckEligibility(double cutoff)
        {
            if(Average()>=cutoff)
            {
                return true;
            }
            return false;
        }
    }
}