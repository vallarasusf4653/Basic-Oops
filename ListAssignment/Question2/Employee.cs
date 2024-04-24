using System;

namespace Question2
{
    public enum Gender { Male, Female, }
    public enum WorkLocation { Home, Office }

    public class Employee
    {
        private static int s_employeeId = 1001;

        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        public Gender Gender { get; set; }


        public WorkLocation workLocation { get; set; }

        public string TeamName { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int NoOfWorkingDays { get; set; }
        public int NoOfLeave { get; set; }


        public Employee()
        {
            EmployeeId = "SF" + s_employeeId;
            s_employeeId++;
        }
        public double SalaryCalculation(int noOfDays, int noOfLeave)
        {

            int totalWorkingDays = noOfDays - noOfLeave;
            int totalSalary = totalWorkingDays * 500;
            return (double)totalSalary;

        }


    }
}
