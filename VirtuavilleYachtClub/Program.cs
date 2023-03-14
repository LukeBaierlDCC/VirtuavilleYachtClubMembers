using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtuavilleYachtClub
{
    public class MemberDatabase
    {
        static void Main(string[] args)
        {
            var members = new List<Member>()
            {
                new Member("Luke the Kook", "CEO of the Radio Tower of Power", 2020),
                new Member("Skipper the Synthwave Schipperke", "DJ at WASD FM", 2021),
                new Member("NeonZero", "CEO Advisor", 2021),
                new Member("Elyse De Rochelle", "Owner of Rochelle Oil Industry", 2019),
                new Member("Bill the Chill", "DJ at WASD FM", 2022),
                new Member("Malcolm Jr", "DJ at WASD FM", 2022),
                new Member("Shellie the Star-riding Sheltie", "House-pet and girlfriend to Skipper", 2022),
                new Member("Chipster the Chiptune Chipmunk", "Acorn collector and music connoisseur", 2022),
                new Member("Klaus", "Owner of Hootin Tootin Guten Gluten", 2017),
                new Member("Luka", "Owner of Hootin Tootin Guten Gluten", 2017),
            };

            while (true)
            {
                Console.WriteLine("Welcome to Virtuaville Yacht Club Members!");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Browse all members");
                Console.WriteLine("2. Search by number of years");
                Console.WriteLine("3. Search by name");
                Console.WriteLine("4. Search by occupation");
                Console.WriteLine("5. Update member occupation");
                Console.WriteLine("6. Add a member");
                Console.WriteLine("7. Remove a member");
                Console.WriteLine("8. Exit");

                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        DisplayMembers(members);
                        break;

                    case "2":
                        Console.WriteLine("Please enter number of years: ");
                        try
                        {
                            int years = int.Parse(Console.ReadLine());
                            var matchingMembers = members.Where(m => m.YearJoined == years).ToList();
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
                        Console.WriteLine("Please enter occupation: ");
                        string occupation = Console.ReadLine();
                        var matchingMemberByOccupation = members.Where(m => m.Occupation.ToLower().Contains(occupation.ToLower())).ToList();
                        DisplayMembers(matchingMemberByOccupation);
                        break;

                    case "5":
                        Console.WriteLine("Please enter the name of the member to update: ");
                        string memberNameToUpdate = Console.ReadLine();
                        var memberToUpdate = members.FirstOrDefault(m => m.Name.ToLower() == memberNameToUpdate.ToLower());
                        if (memberToUpdate != null)
                        {
                            Console.WriteLine($"Current occupation of {memberToUpdate.Name} is {memberToUpdate.Occupation}");
                            Console.WriteLine("Please enter new occupation:");
                            string newOccupation = Console.ReadLine();
                            memberToUpdate.Occupation = newOccupation;
                            Console.WriteLine($"{memberToUpdate.Name}'s occupation has been updated to {memberToUpdate.Occupation}");
                        }
                        else
                        {
                            Console.WriteLine($"Member with name {memberNameToUpdate} not found.");
                        }
                        break;

                    case "6":
                        Console.WriteLine("Please enter the name of the member to add: ");
                        string memberNameToAdd = Console.ReadLine();
                        Console.WriteLine("Please enter the occupation of the member:");
                        string memberOccupationToAdd = Console.ReadLine();
                        Console.WriteLine("Please enter the years of membership of the member:");
                        int memberYearJoined;
                        while (true)
                        {
                            try
                            {
                                memberYearJoined = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Invalid input. Please enter a number.");
                            }
                        }
                        var newMember = new Member(memberNameToAdd, memberOccupationToAdd, memberYearJoined);
                        members.Add(newMember);
                        Console.WriteLine($"{newMember.Name} has been added as a member with occupation {newMember.Occupation} and years of membership {newMember.YearJoined}");
                        break;

                    case "7":
                        Console.WriteLine("Please enter the name of the member to remove: ");
                        string memberNameToRemove = Console.ReadLine();
                        var memberToRemove = members.FirstOrDefault(m => m.Name.ToLower() == memberNameToRemove.ToLower());
                        if (memberToRemove != null)
                        {
                            members.Remove(memberToRemove);
                            Console.WriteLine($"{memberNameToRemove} has been removed from the members list.");
                        }
                        else
                        {
                            Console.WriteLine($"Member with name {memberNameToRemove} not found.");
                        }
                        break;

                    case "8":
                        Console.WriteLine("Thank you for using Virtuaville Yacht Club Members.");
                        Console.ReadLine();
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
            Console.WriteLine("Name\t\t\t\tOccupation\t\tYear");
            Console.WriteLine("--------------------------------------------------");
            foreach (var member in members)
            {
                Console.WriteLine($"{member.Name}\t\t{member.Occupation}\t\t{member.YearJoined}");
            }
        }
    }
}
