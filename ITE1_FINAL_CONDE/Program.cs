using System;
using System.Collections.Generic;
using System.Linq;
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

        public UserInfo(string studentNumber, string surname, string firstname, string occumation, char gender, int countryCode, int areaCode, long phoneNumber)
        {
            StudentNumber = studentNumber;
            Surname = surname;
            FirstName = firstname;
            Occupation = occumation;
            Gender = gender;
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
                UserInfo usersInfo = new UserInfo();
                Console.Write("Enter Student Number: ");
                usersInfo.StudentNumber = Console.ReadLine();
                Console.Write("Enter Surname: ");
                usersInfo.Surname = Console.ReadLine();
                Console.Write("Enter First Name: ");
                usersInfo.FirstName = Console.ReadLine();
                Console.Write("Enter Occupation: ");
                usersInfo.Occupation = Console.ReadLine();
                Console.Write("Enter your gender (M) for male, (F) for female: ");
                usersInfo.Gender = char.Parse(Console.ReadLine());
                Console.Write("Enter Country Code: ");
                usersInfo.CountryCode = int.Parse(Console.ReadLine());
                Console.Write("Enter Area Code: ");
                usersInfo.AreaCode = int.Parse(Console.ReadLine());
                Console.Write("Enter Number: ");
                usersInfo.PhoneNumber = int.Parse(Console.ReadLine());

                users.Add(usersInfo);

                Console.Write("Do you want to enter another entry (Y/N)? ");
            } while (Console.ReadLine().ToUpper() == "Y");
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
                            phonebook.StoreEntry();
                            break;
                        case 3:
                            phonebook.StoreEntry();
                            break;
                        case 4:
                            phonebook.StoreEntry();
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
