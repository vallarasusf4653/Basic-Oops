using System;

namespace Question3
{
    public class Eb_BillCalculation
    {
        private static int s_meterid = 1001;
        public string MeterId { get; set; }
        public string Username { get; set; }
        public long PhoneNumber { get; set; }
        public string MailId { get; set; }
        public double Units { get; set; }

        public Eb_BillCalculation()
        {
            Units = 0;
            s_meterid++;
            MeterId = "EB" + s_meterid;

        }

        public double CalculateAmount(int units)
        {
            Units = units;
            return units * 5;

        }
    }
}
