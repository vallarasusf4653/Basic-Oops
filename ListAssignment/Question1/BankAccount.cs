using System;

namespace Question1
{
    public enum Gender{Select,Male,Female,Transgender}
    /// <summary>
    /// This is uesd to create Bank account details
    /// </summary>  <summary>
    /// 
    /// </summary>
    public class BankAccount
    {
        private static int s_customerId=1001; 
       
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public double Balance { get; set;}
        public Gender Gender { get; set; }
        public long Phone { get; set; }
        public string MailId { get; set; }
        public DateTime DateOfBirth { get; set; }

        public BankAccount()
        {
            CustomerId="HDFC"+s_customerId;
            s_customerId++;
        }
        public double Deposit(double balance,double deposit)
        {
            
            Balance+=deposit;
            return Balance;
           
        }

        public double Withdraw(double balance,double withdraw)
        {
            
            if(balance>0)
            {
                Balance-=withdraw;
                
            }
            
            return Balance;
        }

       
    }
}
