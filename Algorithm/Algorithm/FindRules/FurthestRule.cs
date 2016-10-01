using System.Collections.Generic;
using System.Linq;

namespace Algorithm.FindRules
{
    public class FurthestRule : Rule
    {
        public virtual QueryResult ApplyOn(List<Person> people)
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
            return new QueryResult(orderPeople.First(), orderPeople.Last());
        }

        private List<Person> OrderInAsceningOrder(List<Person> people)
        {
            return people.OrderBy(x => x.BirthDate).ToList();
        }
    }
}