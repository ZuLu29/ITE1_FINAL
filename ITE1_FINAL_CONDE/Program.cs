using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Services;
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
                string pronoun = (userEdit.Gender == 'M') ? "His" : "Her";
                Console.WriteLine($"{userEdit.FirstName} {userEdit.Surname} is a {userEdit.Occupation}. {pronoun} number is {userEdit.CountryCode}-{userEdit.AreaCode}-{userEdit.PhoneNumber}");

                Console.WriteLine("Which of the following information do you want to change? ");
                Console.WriteLine("[1] Student number");
                Console.WriteLine("[2] Surname");
                Console.WriteLine("[3] Firstname");
                Console.WriteLine("[4] Gender");
                Console.WriteLine("[5] Occupation");
                Console.WriteLine("[6] Country code");
                Console.WriteLine("[7] Area code");
                Console.WriteLine("[8] Phone number");
                Console.WriteLine("[9] None go back to the main menu");

                Console.Write("Enter choice: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter new student number: ");
                            userEdit.StudentNumber = Console.ReadLine();
                            break;
                        case 2:
                            Console.Write("Enter new surname: ");
                            userEdit.Surname = Console.ReadLine();
                            break;
                        case 3:
                            Console.Write("Enter new firstname: ");
                            userEdit.FirstName = Console.ReadLine();
                            break;
                        case 4:
                            Console.Write("Enter new gender (M for male, F for female): ");
                            char gender;
                            char.TryParse(Console.ReadLine(), out gender);
                            userEdit.Gender = char.ToUpper(gender);
                            pronoun = (gender == 'M') ? "His" : "Her";
                            break;
                        case 5:
                            Console.Write("Enter new occupation: ");
                            userEdit.Occupation = Console.ReadLine();
                            break;
                        case 6:
                            Console.Write("Enter new country code: ");
                            int countrCode;
                            int.TryParse(Console.ReadLine(), out countrCode);
                            userEdit.CountryCode = countrCode;
                            break;
                        case 7:
                            Console.Write("Enter new area code: ");
                            int areaCode;
                            int.TryParse(Console.ReadLine(), out areaCode);
                            userEdit.AreaCode = areaCode;
                            break;
                        case 8:
                            Console.Write("Enter new phone number");
                            long phoneNumber;
                            long.TryParse(Console.ReadLine(), out phoneNumber);
                            userEdit.PhoneNumber = phoneNumber;
                            break;
                        case 9:
                            Console.WriteLine("Go back to the main menu.");
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;




                    }

                    if (choice != 9)
                    {
                        Console.WriteLine("Updated information");
                        pronoun = (userEdit.Gender == 'M') ? "His" : "Her";
                        Console.WriteLine($"{userEdit.FirstName} {userEdit.Surname} is a {userEdit.Occupation}. {pronoun} number is {userEdit.CountryCode}-{userEdit.AreaCode}-{userEdit.PhoneNumber}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number again.");
                }
            } while (choice != 9);
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
