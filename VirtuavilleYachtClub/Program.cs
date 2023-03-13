using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtuavilleYachtClub
{
    class Program
    {
        static void Main(string[] args)
        {
            var members = new List<Member>()
            {
                new Member("Luke the Kook", "CEO of the Radio Tower of Power", 3),
                new Member("Skipper the Synthwave Schipperke", "DJ at WASD FM", 2),
                new Member("NeonZero", "CEO Advisor", 2),
                new Member("Elyse De Rochelle", "Owner of Rochelle Oil Industry", 4),
                new Member("Bill the Chill", "DJ at WASD FM", 2),
                new Member("Malcolm Jr", "DJ at WASD FM", 1),
                new Member("Shellie the Star-riding Sheltie", "House-pet and girlfriend to Skipper", 1),
                new Member("Chipster the Chiptune Chipmunk", "Acorn collector and music connoisseur", 1),
                new Member("Klaus", "Owner of Hootin Tootin Guten Gluten", 5),
                new Member("Luka", "Owner of Hootin Tootin Guten Gluten", 5),
            };

            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("Welcome to Virtuaville Yacht Club Members!");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Browse all members");
                Console.WriteLine("2. Search by number of years");
                Console.WriteLine("3. Search by name");
                Console.WriteLine("4. Search by occupation");
                Console.WriteLine("5. Update member's years of membership");
                Console.WriteLine("6. Quit");

                string userInput = Console.ReadLine();
                int selection;

                try
                {
                    selection = Convert.ToInt32(userInput);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }
                //Console.WriteLine();

                switch (userInput)
                {
                    case "1":
                        // Browse all members
                        foreach (Member member in members)
                        {
                            Console.WriteLine(member);
                        }
                        break;

                    case "2":
                        // Search by number of years as a member
                        Console.WriteLine("Enter the number of years:");
                        int yearsOfMembership = int.Parse(Console.ReadLine());

                        IEnumerable<Member> membersByYears = members.Where(m => m.YearsOfMembership == yearsOfMembership);
                        if (membersByYears.Any())
                        {
                            foreach (Member member in membersByYears)
                            {
                                Console.WriteLine(member);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No members found.");
                        }
                        break;

                    case "3":
                        // Search by name
                        Console.WriteLine("Enter the name:");
                        string name = Console.ReadLine();

                        IEnumerable<Member> membersByName = members.Where(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                        if (membersByName.Any())
                        {
                            foreach (Member member in membersByName)
                            {
                                Console.WriteLine(member);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No members found.");
                        }
                        break;

                    case "4":
                        // Search by occupation
                        Console.WriteLine("Enter the occupation:");
                        string occupation = Console.ReadLine();

                        IEnumerable<Member> membersByOccupation = members.Where(m => m.Occupation.Equals(occupation, StringComparison.OrdinalIgnoreCase));
                        if (membersByOccupation.Any())
                        {
                            foreach (Member member in membersByOccupation)
                            {
                                Console.WriteLine(member);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No members found.");
                        }
                        break;

                    case "5":
                        // Update member's years of membership
                        Console.WriteLine("Enter the name of the member to update:");
                        string nameToUpdate = Console.ReadLine();

                        Member memberToUpdate = members.FirstOrDefault(m => m.Name.Equals(nameToUpdate, StringComparison.OrdinalIgnoreCase));

                        if (memberToUpdate == null)
                        {
                            Console.WriteLine("Member not found.");
                        }
                        else
                        {
                            Console.WriteLine($"Enter the new number of years of membership for {memberToUpdate.Name}:");
                            int newYearsOfMembership = 0;
                            if (int.TryParse(Console.ReadLine(), out newYearsOfMembership))
                            {
                                memberToUpdate.UpdateYearsOfMembership(newYearsOfMembership);
                                Console.WriteLine($"{memberToUpdate.Name}'s years of membership have been updated to {memberToUpdate.YearsOfMembership}.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number of years of membership.");
                            }
                        }
                        break;

                    case "6":
                        // Quit the program
                        quit = true;
                        break;

                    default:
                        // Invalid input
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }

                // Wait for the user to press a key to continue
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void DisplayMembers(List<Member> members)
        {
            Console.WriteLine("Name\t\t\t\tOccupation\t\tYears");
            Console.WriteLine("---------------------------------------------------------");
            foreach (var member in members)
            {
                Console.WriteLine($"{member.Name}\t\t{member.Occupation}\t\t{member.YearsOfMembership}");
            }
        }
    }
}
