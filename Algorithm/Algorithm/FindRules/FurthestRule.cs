using System.Collections.Generic;
using System.Linq;

namespace Algorithm.FindRules
{
    public class FurthestRule : Rule
    {
        public virtual QueryResult ApplyOn(List<Person> people)
        {
            return NotEnough(people) ? new QueryResult() : Find(people);
        }

        private bool NotEnough(List<Person> people)
        {
            return people.Count < 2;
        }

        private QueryResult Find(List<Person> people)
        {
            var orderPeople = SortInAsceningOrder(people);
            return new QueryResult(orderPeople.First(), orderPeople.Last());
        }

        private List<Person> SortInAsceningOrder(List<Person> people)
        {
            return people.OrderBy(x => x.BirthDate).ToList();
        }
    }
}