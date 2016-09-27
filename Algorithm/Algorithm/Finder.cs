using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> people;

        public Finder(List<Person> people)
        {
            this.people = people;
        }

        public QueryResult FindUsing(Rule rule)
        {
            if (people.Count < 2) return new QueryResult();
            var orderPeople = OrderInAsceningOrder();
            if (Rule.Furthest.Equals(rule))
            {
                return new QueryResult(orderPeople.First(), orderPeople.Last());
            }
            else
            {
                var queryResult = new QueryResult(orderPeople.First(), orderPeople[1]);
                for (int i = 2; i < orderPeople.Count; i++)
                {
                    if (PeopleHasCloserBirthDate(orderPeople[i - 1], orderPeople[i], queryResult))
                    {
                        queryResult = new QueryResult(orderPeople[i - 1], orderPeople[i]);
                    }
                }
                return queryResult;

            }
        }

        private List<Person> OrderInAsceningOrder()
        {
            return people.OrderBy(x => x.BirthDate).ToList();
        }

        private bool PeopleHasCloserBirthDate(Person younger, Person older, QueryResult queryResult)
        {
            return BirthDateDiference(younger, older) < queryResult.BirthDateDiference;
        }

        private static TimeSpan BirthDateDiference(Person younger, Person older)
        {
            return older.BirthDate - younger.BirthDate;
        }
    }
}