using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtuavilleYachtClub
{
    public class Member
    {
        public string Name { get; set; }
        public string Occupation { get; set; }
        public int YearsOfMembership { get; set; }

        public Member(string name, string occupation, int yearsOfMembership)
        {
            Name = name;
            Occupation = occupation;
            YearsOfMembership = yearsOfMembership;
        }
    }
}
