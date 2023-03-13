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

            while (true)
            {
                Console.WriteLine("Welcome to Virtuaville Yacht Club Members!");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Browse all members");
                Console.WriteLine("2. Search by number of years");
                Console.WriteLine("3. Search by name");
                Console.WriteLine("4. Search by occupation");
                Console.WriteLine("5. Exit");

                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        DisplayMembers(members);
                        break;

                    case "2":
                        Console.WriteLine("Please enter number of years:");
                        try
                        {
                            int years = int.Parse(Console.ReadLine());
                            var matchingMembers = members.Where(m => m.YearsOfMembership == years).ToList();
                            DisplayMembers(matchingMembers);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Please enter name:");
                        string name = Console.ReadLine();
                        var matchingMemberByName = members.Where(m => m.Name.ToLower().Contains(name.ToLower())).ToList();
                        DisplayMembers(matchingMemberByName);
                        break;

                    case "4":
                        Console.WriteLine("Please enter occupation:");
                        string occupation = Console.ReadLine();
                        var matchingMemberByOccupation = members.Where(m => m.Occupation.ToLower().Contains(occupation.ToLower())).ToList();
                        DisplayMembers(matchingMemberByOccupation);
                        break;

                    case "5":
                        Console.WriteLine("Thank you for using Virtuaville Yacht Club Members.");
                        return;

                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void DisplayMembers(List<Member> members)
        {
            Console.WriteLine("Name\t\t\t\tOccupation\t\tYears");
            Console.WriteLine("--------------------------------------------------");
            foreach (var member in members)
            {
                Console.WriteLine($"{member.Name}\t\t{member.Occupation}\t\t{member.YearsOfMembership}");
            }
        }
    }
}
