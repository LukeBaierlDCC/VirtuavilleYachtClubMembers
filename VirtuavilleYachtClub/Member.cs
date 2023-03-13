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

        public void UpdateYearsOfMembership(int newYearsOfMembership)
        {
            YearsOfMembership = newYearsOfMembership;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Member otherMember = (Member)obj;

            return Name.Equals(otherMember.Name)
                && Occupation.Equals(otherMember.Occupation)
                && YearsOfMembership == otherMember.YearsOfMembership;
        }

    }
}
