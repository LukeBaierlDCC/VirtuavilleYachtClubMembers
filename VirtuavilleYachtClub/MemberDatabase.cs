using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtuavilleYachtClub
{
    public class MemberDatabase
    {
        private List<Member> members;

        public MemberDatabase()
        {
            members = new List<Member>
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
            new Member("Luka", "Owner of Hootin Tootin Guten Gluten", 5)
        };
        }

        public List<Member> GetMembers()
        {
            return members;
        }

        public void UpdateYears(string name, int years)
        {
            var matchingMembers = FindByName(name);

            if (matchingMembers.Count == 0)
            {
                Console.WriteLine($"No member found with the name '{name}'.");
            }
            else if (matchingMembers.Count == 1)
            {
                matchingMembers[0].YearsOfMembership = years;
                Console.WriteLine($"Years of membership updated for {matchingMembers[0].Name}.");
            }
            else
            {
                Console.WriteLine($"Multiple members found with the name '{name}'.");
                Console.WriteLine("Please select a member from the list:");
                for (int i = 0; i < matchingMembers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {matchingMembers[i].Name}");
                }
                Console.Write("Selection: ");
                int selection = int.Parse(Console.ReadLine());

                if (selection < 1 || selection > matchingMembers.Count)
                {
                    Console.WriteLine("Invalid selection.");
                    return;
                }

                matchingMembers[selection - 1].YearsOfMembership = years;
                Console.WriteLine($"Years of membership updated for {matchingMembers[selection - 1].Name}.");
            }
        }

        public List<Member> FindByName(string name)
        {
            List<Member> results = new List<Member>();
            foreach (Member member in members)
            {
                if (member.Name.ToLower().Contains(name.ToLower()))
                {
                    results.Add(member);
                }
            }
            return results;
        }
    }

}
