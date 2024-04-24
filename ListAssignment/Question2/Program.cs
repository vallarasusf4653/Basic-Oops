using System;
using System.Collections.Generic;
namespace Question2;
class Program
{
    static List<Employee> emplist = new List<Employee>();

    public static void Main(string[] args)
    {
        string exit = string.Empty;
        do
        {
            Console.WriteLine();
            Console.WriteLine("*****Welcome to Syncfusion Payroll Portal******");
            Console.WriteLine("\n\tMain Menu : \n\t\t1.Registration\n\t\t2.Login\n\t\t3.Exit");
            Console.Write("Please Mention Your choice : ");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    {
                        Registration();
                        break;
                    }
                case 2:
                    {
                        Login();
                        break;
                    }
                case 3:
                    {
                        Environment.Exit(0);
                        break;
                    }
            }
            Console.Write("Do you want to contiune yes/no :");
            exit = Console.ReadLine();
        } while (exit == "yes");

    }
    public static void Registration()
    {
        Employee emp = new Employee();
        Console.Write("Enter your Name: ");
        emp.Name = Console.ReadLine();
        Console.Write("Enter your Role: ");
        emp.Role = Console.ReadLine();
        Console.Write("Enter your Work Location (Home/Office): ");
        emp.workLocation = Enum.Parse<WorkLocation>(Console.ReadLine(), true);
        Console.Write("Enter your Team Name: ");
        emp.TeamName = Console.ReadLine();
        Console.Write("Enter your Date of Joining (dd/MM/yyyy): ");
        emp.DateOfJoining = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        Console.Write("Enter No of Working Days: ");
        emp.NoOfWorkingDays = int.Parse(Console.ReadLine());
        Console.Write("Enter your No Of Leave: ");
        emp.NoOfLeave = int.Parse(Console.ReadLine());
        Console.Write("Enter your Gender (Male/Female): ");
        emp.Gender = Enum.Parse<Gender>(Console.ReadLine(), true);
        emplist.Add(emp);
        Console.WriteLine("Your are Successfully Registered in Syncfusion Payroll Portal");
        Console.WriteLine($"Employee Id : {emp.EmployeeId}");

    }
    public static void Login()
    {
        Console.WriteLine("Please Enter Your Employee Id: ");
        string empId = Console.ReadLine();
        foreach (Employee emp in emplist)
        {
            if (emp.EmployeeId.Equals(empId))
            {
                //Employee employee = new Employee();
                Console.WriteLine($"Welcome {emp.Name}");
                Console.WriteLine("Sub Menu :");
                Console.WriteLine("\t1.Calculate Salary\n\t2.Display Details\n\t3.Exit");
                Console.Write("Please Mention Choice : ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            double sal = emp.SalaryCalculation(emp.NoOfWorkingDays, emp.NoOfLeave);
                            Console.WriteLine($"Total Salary :{sal}");
                            break;
                        }
                    case 2:
                        {
                            DisplayDetails(empId);
                            break;
                        }
                    case 3:
                        {
                            break;
                        }
                }
            }
            else
            {
                Console.WriteLine("User Invalid ID");
            }
        }
    }

    public static void DisplayDetails(string empId)
    {
        foreach (Employee emp in emplist)
        {
            if (emp.EmployeeId.Equals(empId))
            {
                Console.WriteLine($"Employee Id : {emp.EmployeeId}");
                Console.WriteLine($"Employee Name : {emp.Name}");
                Console.WriteLine($"Employee Gender : {emp.Gender}");
                Console.WriteLine($"Employee Roll : {emp.Role}");
                Console.WriteLine($"Employee WorkLocation : {emp.workLocation}");
                Console.WriteLine($"Employee Team Name : {emp.TeamName}");
                Console.WriteLine($"Employee DOJ : {emp.DateOfJoining.ToString("dd/MM/yyyy")}");

            }
        }
    }
}