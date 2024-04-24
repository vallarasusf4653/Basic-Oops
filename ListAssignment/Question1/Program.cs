using System;
using System.Collections.Generic;
namespace Question1;
class Program 
{
    public static void Main(string[] args)
    {
            List<BankAccount> bank=new List<BankAccount>();
            string exit=string.Empty;
            do
            {

            Console.WriteLine("\nWelcome to HDFC Bank !!!");
            Console.WriteLine("Main Menu\n\t1.Registration\n\t2.Login\n\t3.Exit");
            Console.Write("\tPlease Mention your choice : ");
            int option=int.Parse(Console.ReadLine());
            BankAccount customer = new BankAccount();
            switch(option)
            {
                case 1:
                {
                    
                    Console.Write("Enter your name: ");
                    customer.CustomerName=Console.ReadLine();
                    Console.Write("Enter your balance : ");
                    customer.Balance=double.Parse(Console.ReadLine());
                    Console.Write("Enter your gender Male Female Transgender : ");
                    customer.Gender=Enum.Parse<Gender>(Console.ReadLine(),true);
                    Console.Write("Enter your Phone Number: ");
                    customer.Phone=long.Parse(Console.ReadLine());
                    Console.Write("Enter your Mail Id : ");
                    customer.MailId=Console.ReadLine();
                    Console.Write("Enter your Date of Birth(dd/MM/yyyy): ");
                    customer.DateOfBirth=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                    Console.WriteLine($"Your are Successfully Registered and Customer Id: {customer.CustomerId} ");
                    bank.Add(customer);
                    break;
                }
                case 2:
                {
                    Console.WriteLine();
                    Console.Write("Please Enter your Customer Id:");
                    string custId=Console.ReadLine();
                    bool flag=false;
                    foreach (BankAccount item in bank)
                    {
                    
                        if(item.CustomerId.Equals(custId))
                        {
                            flag=true;
                            Console.WriteLine($"Welcome {item.CustomerName}" );
                            Console.WriteLine("\nSub Menu :\n\t1.Deposit\n\t2.Withdraw\n\t3.Balance Check\n\t4.Exist");
                            Console.Write("Please Mention your Choice : ");
                            int choice=int.Parse(Console.ReadLine());
                            switch(choice)
                            {
                                case 1:
                                {
                                    Console.Write("Enter the ammount to deposit : ");
                                    double deposit=double.Parse(Console.ReadLine());
                                    item.Deposit(item.Balance,deposit);
                                    Console.WriteLine($"Current Balance :{item.Balance}");
                                    break;
                                }
                                case 2:
                                {
                                    Console.Write("Enter the ammount to withdraw : ");
                                    double withdraw=double.Parse(Console.ReadLine());
                                    item.Withdraw(item.Balance,withdraw);
                                    Console.WriteLine($"Current Balance :{item.Balance}");
                                    break;
                                }
                                case 3:
                                {
                                    Console.WriteLine($"Current Balance :{item.Balance}");
                                    break;
                                }
                                case 4:
                                {

                                    break;
                                }
                            }
                        }
                    }
                    if(flag==false)
                    {
                        Console.WriteLine("Invalid User");
                    }
                    break;
                }
                case 3:
                {
                    Environment.Exit(0);
                    break;
                }
            }
             Console.WriteLine();
             Console.Write("Do you want to go to Main Menu :\nPlease Mention yes/no : ");
             exit=Console.ReadLine();
            }while(exit=="yes");
    }
}
