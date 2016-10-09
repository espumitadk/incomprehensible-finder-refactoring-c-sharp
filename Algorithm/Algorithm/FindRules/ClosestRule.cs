using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.FindRules
{
    public class ClosestRule : Rule
    {
        public virtual FindResults ApplyOn(List<RealPerson> people)
        {
            return NotEnough(people) ? FindResults.NoResults() : Find(people);
        }

        private bool NotEnough(List<RealPerson> people)
        {
            return people.Count < 2;
        }
        
        private FindResults Find(List<RealPerson> people)
        {     
            var orderPeople = OrderInAsceningOrder(people);
            var queryResult = new FindResults(orderPeople.First(), orderPeople[1]);
            for (int i = 2; i < orderPeople.Count; i++)
            {
                if (PeopleHasCloserBirthDate(orderPeople[i - 1], orderPeople[i], queryResult))
                {
                    queryResult = new FindResults(orderPeople[i - 1], orderPeople[i]);
                }
            }
            return queryResult;
        }

        private List<RealPerson> OrderInAsceningOrder(List<RealPerson> people)
        {
            return people.OrderBy(x => x.BirthDate).ToList();
        }

        private bool PeopleHasCloserBirthDate(RealPerson younger, RealPerson older, FindResults findResults)
        {
            return BirthDateDiference(younger, older) < findResults.BirthDateDiference;
        }

        private static TimeSpan BirthDateDiference(RealPerson younger, RealPerson older)
        {
            return older.BirthDate - younger.BirthDate;
        }
    }
}