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
            List<Member> members = new List<Member>
        {
            new Member { Name = "Luke the Kook", Occupation = "CEO of the Radio Tower of Power", Years = 3 },
            new Member { Name = "Skipper the Synthwave Schipperke", Occupation = "DJ at WASD FM", Years = 2 },
            new Member { Name = "NeonZero", Occupation = "CEO Advisor", Years = 2 },
            new Member { Name = "Elyse De Rochelle", Occupation = "Owner of Rochelle Oil Industry", Years = 4 },
            new Member { Name = "Bill the Chill", Occupation = "DJ at WASD FM", Years = 2 },
            new Member { Name = "Malcolm Jr", Occupation = "DJ at WASD FM", Years = 1 },
            new Member { Name = "Shellie the Star-riding Sheltie", Occupation = "House-pet and girlfriend to Skipper", Years = 1 },
            new Member { Name = "Chipster the Chiptune Chipmunk", Occupation = "Acorn collector and music connoisseur", Years = 1 },
            new Member { Name = "Klaus", Occupation = "Owner of Hootin Tootin Guten Gluten", Years = 5 },
            new Member { Name = "Luka", Occupation = "Owner of Hootin Tootin Guten Gluten", Years = 5 }
        };

            // Prompt the user for a search term
            Console.WriteLine("Please enter a search term: ");
            string searchTerm = Console.ReadLine();

            // Query the list of members by name, occupation, and years
            var query = from member in members
                        where member.Name.Contains(searchTerm) || member.Years.ToString().Contains(searchTerm)
                        orderby member.Name
                        select new
                        {
                            Name = member.Name,
                            Occupation = member.Occupation,
                            Years = member.Years
                        };

            // Print the results
            Console.WriteLine("Results: ");
            foreach (var result in query)
            {
                Console.WriteLine($"{result.Name}, {result.Occupation}, {result.Years} years Virtuaville Yacht Club member");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
