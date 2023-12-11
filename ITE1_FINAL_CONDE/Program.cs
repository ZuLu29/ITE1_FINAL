using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ITE1_FINAL_CONDE
{
    class UserInfo
    {
        public string StudentNumber { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Occupation { get; set; }
        public char Gender { get; set; }
        public int CountryCode { get; set; }
        public int AreaCode { get; set; }
        public long PhoneNumber { get; set; }

        public UserInfo(string studentNumber, string surname, string firstname, string occupation, char gender, int countryCode, int areaCode, long phoneNumber)
        {
            StudentNumber = studentNumber;
            Surname = surname;
            FirstName = firstname;
            Occupation = occupation;
            Gender = char.ToUpper(gender);
            CountryCode = countryCode;
            AreaCode = areaCode;
            PhoneNumber = phoneNumber;
        }
    }  
    
    class ASEANPhonebook
    {
        private List<UserInfo> users = new List<UserInfo>();
        public void StoreEntry()
        {
            do
            {
                Console.WriteLine("Provide the student details below.");

                Console.Write("Enter student number: ");
                string studentNumber = Console.ReadLine();

                Console.Write("Enter surname: ");
                string surname = Console.ReadLine();

                Console.Write("Enter firstname: ");
                string firstname = Console.ReadLine();

                Console.Write("Enter occupation: ");
                string occupation = Console.ReadLine();

                Console.Write("Enter gender (M for male F for female): ");
                char gender = Console.ReadKey().KeyChar;
                Console.WriteLine();

                Console.Write("Enter country code: ");
                int countryCode = int.Parse(Console.ReadLine());

                Console.Write("Enter area code: ");
                int areaCode = int.Parse(Console.ReadLine());

                Console.Write("Enter number: ");
                long phoneNumber = long.Parse(Console.ReadLine());

                UserInfo entry = new UserInfo(studentNumber, surname, firstname, occupation, gender, countryCode, areaCode, phoneNumber);
                users.Add(entry);

                Console.Write("Do you want to add another entry [Y/N]? ");
            } while (char.ToUpper(Console.ReadKey().KeyChar) == 'Y');

            Console.WriteLine();
        }
        public void EditEntry()
        {
            Console.WriteLine("Enter the student number that you want to edit: ");
            string userNumberEdit = Console.ReadLine();
            UserInfo userEdit = users.FirstOrDefault(users => users.StudentNumber == userNumberEdit);
            if (userEdit == null)
            {
                Console.WriteLine("Student not found. Cannot proceed with editing.");
                return;
            }
            int choice;
            do
            {
                Console.WriteLine($"Here is the existing information about {userNumberEdit}:");
                string pronoun = (userNumberEdit.gender == "M") ? "His" : "her";
            } 
        }


    }
    class Test
    {
        static void Main(string[] args)
        {
            ASEANPhonebook phonebook = new ASEANPhonebook();
            while (true)
            {
                Console.WriteLine("=====MAIN MENU=====");
                Console.WriteLine("[1] Store to ASEAN phonebook");
                Console.WriteLine("[2] Edit entry in ASEAN phonebook");
                Console.WriteLine("[3] Search ASEAN phonebook by country ");
                Console.WriteLine("[4] Exit");

                Console.Write("Enter Choice: ");
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            phonebook.StoreEntry();
                            break;
                        case 2:
                            phonebook.EditEntry();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input. try again");
                }
            }
        }
    }
}
