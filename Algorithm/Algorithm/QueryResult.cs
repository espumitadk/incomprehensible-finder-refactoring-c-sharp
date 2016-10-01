using System;

namespace Algorithm
{
    public class QueryResult
    {
        public Person FirstPerson { get; set; }
        public Person SecondPerson { get; set; }
        public TimeSpan BirthDateDiference { get; set; }

        public QueryResult()
        {

        }

        public QueryResult(Person firstPerson, Person secondPerson)
        {
            FirstPerson = firstPerson;
            SecondPerson = secondPerson;
            BirthDateDiference = CalculateBirthDateDiference(firstPerson, secondPerson);
        }

        private TimeSpan CalculateBirthDateDiference(Person firstPerson, Person secondPerson)
        {
            return secondPerson.BirthDate - firstPerson.BirthDate;
        }
    }
}