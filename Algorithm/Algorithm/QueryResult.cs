using System;

namespace Algorithm
{
    public class QueryResult
    {
        public Person FirstPerson { get; set; }
        public Person SecondPerson { get; set; }
        public TimeSpan BirthDateDiference { get; set; }

        public QueryResult(Person firstPerson, Person secondPerson)
        {
            FirstPerson = firstPerson;
            SecondPerson = secondPerson;
            BirthDateDiference = secondPerson.BirthDate - firstPerson.BirthDate;
        }

        public QueryResult()
        {

        }

    }
}