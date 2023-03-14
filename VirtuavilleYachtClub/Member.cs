using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Member
{
    public string Name { get; set; }
    public string Occupation { get; set; }
    public int YearJoined { get; set; }

    public Member(string name, string occupation, int yearJoined)
    {
        Name = name;
        Occupation = occupation;
        YearJoined = yearJoined;
    }
}