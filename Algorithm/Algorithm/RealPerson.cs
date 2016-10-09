using System;

namespace Algorithm
{
    public class RealPerson : Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public RealPerson(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }


    }
}