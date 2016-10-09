using System;

namespace Algorithm
{
    public class FindResults
    {
        public Person OldestRealPerson { get; set; }
        public Person YoungestRealPerson { get; set; }
        public TimeSpan BirthDateDifference { get; set; }

        public static FindResults NoResults()
        {
            return new FindResults(new NoPerson(), new NoPerson());
        }

        public FindResults(Person oldestRealPerson, Person youngestRealPerson)
        {
            this.OldestRealPerson = oldestRealPerson;
            YoungestRealPerson = youngestRealPerson;
            CalculateBirthDateDifference(oldestRealPerson, youngestRealPerson);
        }
        

        private void CalculateBirthDateDifference(Person oldestRealPerson, Person youngestRealPerson)
        {
            if (oldestRealPerson is RealPerson && youngestRealPerson is RealPerson)
                    BirthDateDifference =  ((RealPerson) youngestRealPerson).BirthDate - ((RealPerson) oldestRealPerson).BirthDate;
        }
    }
}