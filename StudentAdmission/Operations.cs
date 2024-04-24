using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    // Static class
    public static class Operations
    {
        //Local / Global Object Creation
        static StudentDetails currentLoggedStudent;
        // static list for StudentDetails
        static List<StudentDetails> studentList = new List<StudentDetails>();
         // static list for DepartmentDetails
        static List<DepartmentDetails> departmentList = new  List<DepartmentDetails>();
         // static list for AdmissiontDetails
        static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();
        
        //Main Menu
        public static void MainMenu()
        {
            Console.WriteLine("*************Welcome to Syncfusion College*************");
            string mainChoice="yes";
            do
            {
                // Need to show the main menu option
                Console.WriteLine("MainMenu\n\t1.Registration\n\t2.Login\n\t3.DepartmentWise Seat Availability\n\t4.Exit");
                // Need to get an input from user and validate
                Console.Write("Select an option: ");
                int mainOption = int.Parse(Console.ReadLine());
                // To create a MainMenu structure
                switch (mainOption)
                {

                    case 1:
                        {
                            Console.WriteLine("*************Student Registration*************");
                            StudentRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("*************Login*************");
                            StudentLogin();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("*************DepartmentWise Seat Availability*************");
                            DepartmentWiseSeatAvailability();
                            break;
                        }
                    case 4:
                        {
                            
                            Console.WriteLine("Application Exited Successfully");
                            mainChoice="no";
                            break;
                        }
                }
                // Need to iterate untill the option is exit  
            } while(mainChoice=="yes");
            
        }// End of Main Menu

        // Student Registration
        public static void StudentRegistration()
        {
          //Need to get Required details
          Console.Write("Enter your name : ");
          string studentName=Console.ReadLine();
          Console.Write("Enter your Father name : ");
          string fatherName = Console.ReadLine();
          Console.Write("Enter your Date Of Birth (dd/MM/yyyy) :");
          DateTime dob =  DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
          Console.Write("Enter your gender (Male/Female) : ");
          Gender gender = Enum.Parse<Gender>(Console.ReadLine(),true);
          Console.Write("Enter your Physics mark : ");
          int physcis = int.Parse(Console.ReadLine());
          Console.Write("Enter your Chemistry mark : ");
          int chemistry = int.Parse(Console.ReadLine());
          Console.Write("Enter your Maths mark : ");
          int maths = int.Parse(Console.ReadLine());
          //Need to create an object
          StudentDetails student = new StudentDetails(studentName,fatherName,dob,gender,physcis,chemistry,maths);
          //Need to add in list
          studentList.Add(student);
          //Need to display confirmation message and ID
          Console.WriteLine($"Registration Successfully . Student ID : {student.StudentID}");
        }// Student Registration Ends
         // Student Login
        public static void StudentLogin()
        {
            // Need to get ID input
            Console.Write("Enter your student ID : ");
            string loginID = Console.ReadLine().ToUpper();
            //Validate by its presence int the list
            bool flag = true;
            foreach (StudentDetails  student in studentList)
            {
                if(student.StudentID.Equals(loginID))
                {
                  flag=false;
                  //Assigning current user to global variable
                  currentLoggedStudent=student;
                  Console.WriteLine("Login Successfully");
                  Submenu();
                  break;
                  //Need to call sub Menu
                }
            }
            if(flag==true)
            {
                Console.WriteLine("Invalid ID or ID is not present");
            }
            //if not : invalid ID
        }

        //Submenu
        public static void Submenu()
        {
              string subChoice="yes";
              do
              {
                    Console.WriteLine("***************Sub Menu***************");
                    //Need to show sub menu option
                    Console.WriteLine("Sub Menu : \n\t1.Check Eligibility\n\t2.Show Details\n\t3.Take Admission\n\t4.Cancel Admission\n\t5.Show Admission Details\n\t6.Exit");
                    //Geting user option
                    Console.Write("Enter your option ");
                    int subOption = int.Parse(Console.ReadLine());
                    switch(subOption)
                    {
                        case 1:
                        {
                            Console.WriteLine("****************Check Eligibility****************");
                            CheckEligibility();
                            break;
                        }
                        case 2:
                        {
                             Console.WriteLine("****************Show Details****************");
                             ShowDetails();
                            break;
                        }
                        case 3:
                        {
                             Console.WriteLine("****************Tale Admission****************");
                             TakeAdmission();
                            break;
                        }
                        case 4:
                        {
                             Console.WriteLine("****************Cancel Admission****************");
                             CancelAdmission();
                            break;
                        }
                        case 5:
                        {
                             Console.WriteLine("****************Show Admission Details****************");
                             ShowAdmissionDetails();
                            break;
                        }
                        case 6:
                        {
                             Console.WriteLine("Taking back to Main Menu");
                            subChoice="no";
                            break;
                        }
                    }
                    //Iterate till the option is exit
              }
              while(subChoice=="yes");
        }// end of sub Menu
        //Check Eligibility
        public static void CheckEligibility()
        {
              // Get cutoff value from user
              Console.Write("Enter the cutoff value :");
              double cutOff = double.Parse(Console.ReadLine());
              // check eligible or not
              if(currentLoggedStudent.CheckEligibility(cutOff))
              {
                Console.WriteLine("Student is eligible.");
              }
              else
              {
                Console.WriteLine("Student is not eligible");
              }
        }
        //Show Details
        public static void ShowDetails()
        {
             // Need to show the current studnet's details
               Console.WriteLine("|Student ID|Student Name|Father Name|DOB|Gender|Physics Marks|Chemistry Marks|Maths Marks");
               Console.WriteLine($"|{currentLoggedStudent.StudentID}|{ currentLoggedStudent.StudentName}|{ currentLoggedStudent.FatherName}|{ currentLoggedStudent.DOB}|{ currentLoggedStudent.Gender}|{ currentLoggedStudent.Physics}|{ currentLoggedStudent.Chemistry}|{ currentLoggedStudent.Maths}|");
             
        }
        //Take Admission
        public static void TakeAdmission()
        {
            //Need to show available deparments
             DepartmentWiseSeatAvailability();
            // Need to ask department id from user
            Console.Write("Select department ID : ");
            string departmentID=Console.ReadLine().ToUpper();
             //check id is present or not
             bool flag=true;
             foreach (DepartmentDetails department in departmentList)
             {
                if(department.DepartmentID.Equals(departmentID))
                {
                    flag=false;
                    // check student is eligible or not
                    
                    if( currentLoggedStudent.CheckEligibility(75.0))
                    {
                         // check seat availability or not
                         if(department.NumberOfSeats>0)
                         {
                            int count=0;
                            //check student already have admission or not
                            foreach (AdmissionDetails admission in admissionList)
                            {
                                if(currentLoggedStudent.StudentID.Equals(admission.StudentID)&& admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                                {
                                   count++;
                                }
                            }
                            if(count==0)
                            {
                                //if not create object for AdmissionDetails 
                                AdmissionDetails newAdmission = new AdmissionDetails(currentLoggedStudent.StudentID,department.DepartmentID,DateTime.Now,AdmissionStatus.Admitted);
                                department.NumberOfSeats--;
                                //add to admission list
                                admissionList.Add(newAdmission);
                                //show message admission successfully with admission id
                               Console.WriteLine($"Admission took Successfully . Admission ID : {newAdmission.AdmissionID}");
                            }
                            else
                            {
                                Console.WriteLine("You have already taken an admission");
                            }
                           
                         }
                         else
                         {
                            Console.WriteLine("Seats are Not Available");
                         }
                        
                    }
                    else
                    {
                         Console.WriteLine("Your are not eligible due to lwo cutoff");
                    }
                   
                    break;
                }
             }
             if(flag)
             {
                Console.WriteLine("Invalid Department ID or ID is not present");
             }
             
             //
        }
        //Cancel Admission
        public static void CancelAdmission()
        {
           //Need student is taken any admission and display it.
           bool flag=true;
           foreach (AdmissionDetails admission in admissionList )
           {
                if (admission.StudentID.Equals(currentLoggedStudent.StudentID) && admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                {
                    flag = false;
                    //cance the found admission
                    admission.AdmissionStatus = AdmissionStatus.Cancelled;
                    //return the seat to department
                    foreach (DepartmentDetails department in departmentList)
                    {
                        if (admission.DepartmentID.Equals(department.DepartmentID))
                        {
                            department.NumberOfSeats++;
                            Console.WriteLine("Successfully Cancelled");
                            break;
                        }
                    }
                    Console.WriteLine("");
                    break;
                }

            }
           if(flag)
           {
            Console.WriteLine("You have no admission to cancel");
           }
          
        }
        //Show Admission Details
        public static void ShowAdmissionDetails()
        {
            Console.WriteLine("|Admission ID|Student ID|Department ID|Admistion Date|Admission Status");
            // Need to show currentloged student Admission details
            foreach (AdmissionDetails admission in admissionList)
            {
                if (currentLoggedStudent.StudentID.Equals(admission.StudentID))
                {
                    Console.WriteLine($"|{admission.AdmissionID}|{admission.StudentID}|{admission.DepartmentID}|{admission.AdmissionDate}|{admission.AdmissionStatus}");
                }
            }
        }
         // DepartmentWise Seat Availability
        public static void DepartmentWiseSeatAvailability()
        {
            //if(departmentList.count>0)
            //Need to show all department details
            Console.WriteLine("DepartmentID  DepartmentName  NumberOfSeats");
            foreach (DepartmentDetails department in departmentList)
            {
                Console.WriteLine($"|{department.DepartmentID}|{department.DepartmentName}|{department.NumberOfSeats}");
            }
        }
        // Adding Default Data
        public static void DefaultData()
        {
           //Create object for StudentDetails to assign default values 
           StudentDetails student1 = new StudentDetails("Ravichandran","Ettapparajan",new DateTime(1999,11,11),Gender.Male,95,95,95); 
           StudentDetails student2 = new StudentDetails("Baskaran","Sethurajan",new DateTime(1999,11,11),Gender.Male,95,95,95); 
           //Adding object to studentList
           studentList.AddRange(new List<StudentDetails>(){student1,student2});

           //Create object for DepartmentDetails to assign default values 
           DepartmentDetails department1=new DepartmentDetails("EEE",29);
           DepartmentDetails department2=new DepartmentDetails("CSE",29);
           DepartmentDetails department3=new DepartmentDetails("MECH",30);
           DepartmentDetails department4=new DepartmentDetails("ECE",30);
           //Adding object to departmentList
           departmentList.AddRange(new List<DepartmentDetails>(){department1,department2,department3,department4});

           //Create object for AdmissiontDetails to assign default values 
           AdmissionDetails admision1 = new AdmissionDetails(student1.StudentID,department1.DepartmentID,new DateTime(2022,05,11),AdmissionStatus.Admitted);
           AdmissionDetails admision2 = new AdmissionDetails(student2.StudentID,department2.DepartmentID,new DateTime(2022,05,11),AdmissionStatus.Admitted);
           //Adding object to admissionList
           admissionList.AddRange(new List<AdmissionDetails>(){admision1,admision2});

           // Printing the Data
          
           Console.WriteLine();
          
           Console.WriteLine();
           
         
        }// Default data ending
    
       
    }
}