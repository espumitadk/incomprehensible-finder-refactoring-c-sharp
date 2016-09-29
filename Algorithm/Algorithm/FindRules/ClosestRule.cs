using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.FindRules
{
    public class ClosestRule : Rule
    {
        public QueryResult ApplyOn(List<Person> people)
        {
            return NotEnougt(people) ? new QueryResult() : Find(people);
        }

        private bool NotEnougt(List<Person> people)
        {
            return people.Count < 2;
        }
        
        private QueryResult Find(List<Person> people)
        {     
            var orderPeople = OrderInAsceningOrder(people);
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

        private List<Person> OrderInAsceningOrder(List<Person> people)
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