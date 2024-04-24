using System;
using System.Collections.Generic;
namespace Question3;
class Program
{
    static List<Eb_BillCalculation> eblist = new List<Eb_BillCalculation>();
    public static void Main(string[] args)
    {
        Console.WriteLine();
        Console.WriteLine("*****Welcome EB Bill Calculation Portal******");
        string exit = string.Empty;
        do
        {

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
        Eb_BillCalculation eb = new Eb_BillCalculation();
        Console.Write("Enter username : ");
        eb.Username = Console.ReadLine();
        Console.Write("Enter Your Phone Number : ");
        eb.PhoneNumber = long.Parse(Console.ReadLine());
        Console.Write("Enter your Mail Id : ");
        eb.MailId = Console.ReadLine();
        eblist.Add(eb);
        Console.WriteLine("Successfully Registered");
        Console.WriteLine($"Your Meter ID : {eb.MeterId}");
    }
    public static void Login()
    {
        Console.Write("Enter Your Meter Id :");
        string meterId = Console.ReadLine();
        foreach (Eb_BillCalculation item in eblist)
        {
            if (item.MeterId.Equals(meterId))
            {
                Console.WriteLine("Sub Menu :\n\t1.Calculate Amount\n\t2.Display Details\n\t3.Exit");
                Console.Write("Please mention :");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.Write("Enter the Unit : ");
                            int Units = int.Parse(Console.ReadLine());
                            double amount = item.CalculateAmount(Units);
                            Console.WriteLine($"Meter Id : {item.MeterId}");
                            Console.WriteLine($"UserName : {item.Username}");
                            Console.WriteLine($"Units : {item.Units}");
                            Console.WriteLine($"Amount : {amount}");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine($"Meter Id : {item.MeterId}");
                            Console.WriteLine($"UserName : {item.Username}");
                            Console.WriteLine($"Phone Number : {item.PhoneNumber}");
                            Console.WriteLine($"Mail Id : {item.MailId}");
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
                Console.WriteLine("Invalid Meter ID");
            }
        }


    }
}
