using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITE1_FINAL_CONDE
{
    class Menu
    {
        public void Display()
        {
            
        }
    }
    class Test
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=====MAIN MENU=====");
            Console.WriteLine("[1] Store to ASEAN phonebook");
            Console.WriteLine("[2] Edit entry in ASEAN phonebook");
            Console.WriteLine("[3] Search ASEAN phonebook by country ");
            Console.WriteLine("[4] Exit");

            Console.WriteLine("Enter Choice");
            int choice = Convert.ToInt32(Console.ReadLine());
        }
    }
}
