﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Please note - THIS IS A BAD APPLICATION - DO NOT REPLICATE WHAT IT DOES
// This application was designed to simulate a poorly-built application that
// you need to support. Do not follow any of these practices. This is for 
// demonstration purposes only. You have been warned.
namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string w, rawTimeWorked;
            int i;
            double t, ttl;
            List<TimeSheetEntry> ents = new List<TimeSheetEntry>();
            Console.Write("Enter what you did: ");
            w = Console.ReadLine();
            Console.Write("How long did you do it for: ");
            rawTimeWorked = Console.ReadLine();
            while (double.TryParse(rawTimeWorked, out t) == false)
            {
                Console.WriteLine();
                Console.WriteLine("Invalid number ");
                Console.Write("How long did you do it for: ");
                rawTimeWorked = Console.ReadLine();
            }
            TimeSheetEntry ent = new TimeSheetEntry();
            ent.HoursWorked = t;
            ent.WorkDone = w;
            ents.Add(ent);
            Console.Write("Do you want to enter more time:");
            string answer = Console.ReadLine();
            bool cont = false;
            if (answer.Equals("yes"))
            {
                cont = true;
            }
            while (cont == true)
            {
                Console.Write("Enter what you did: ");
                w = Console.ReadLine();
                Console.Write("How long did you do it for: ");
                rawTimeWorked = Console.ReadLine();
                while (double.TryParse(rawTimeWorked, out t) == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid number ");
                    Console.Write("How long did you do it for: ");
                    rawTimeWorked = Console.ReadLine();
                }
                ent = new TimeSheetEntry();
                ent.HoursWorked = t;
                ent.WorkDone = w;
                ents.Add(ent);
                Console.Write("Do you want to enter more time:");
                answer = Console.ReadLine();

                if (answer.Equals("no"))
                {
                    cont = false;
                }
            }
            ttl = 0;
            for (i = 0; i < ents.Count; i++)
            {
                if (ents[i].WorkDone.ToLower().Contains("acme"))
                {
                    ttl += ents[i].HoursWorked;
                }
            }
            Console.WriteLine("Simulating Sending email to Acme");
            Console.WriteLine("Your bill is $" + ttl * 150 + " for the hours worked.");
            ttl = 0;
            for (i = 0; i < ents.Count; i++)
            {
                if (ents[i].WorkDone.ToLower().Contains("abc"))
                {
                    ttl += ents[i].HoursWorked;
                }
            }
            Console.WriteLine("Simulating Sending email to ABC");
            Console.WriteLine("Your bill is $" + ttl * 125 + " for the hours worked.");
            ttl = 0;
            for (i = 0; i < ents.Count; i++)
            {
                ttl += ents[i].HoursWorked;
            }
            if (ttl > 40)
            {
                Console.WriteLine("You will get paid $" + (((ttl - 40) * 15) + (40 * 10)) + " for your work.");
            }
            else
            {
                Console.WriteLine("You will get paid $" + ttl * 10 + " for your time.");
            }
            Console.WriteLine();
            Console.Write("Press any key to exit application...");
            Console.ReadKey();
        }
    }

    public class TimeSheetEntry
    {
        public string WorkDone;
        public double HoursWorked;
    }
}
