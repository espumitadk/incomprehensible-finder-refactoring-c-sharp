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
            var sortPeople = SortInAsceningOrder(people);
            var youngestIndex = YoungestIndex(BirthDateDifferences(sortPeople));
            return new FindResults(sortPeople[youngestIndex], sortPeople[youngestIndex + 1]);
        }

        private static int YoungestIndex(List<TimeSpan> birthDateDiferences)
        {
            return birthDateDiferences.IndexOf(birthDateDiferences.Min());
        }

        private static List<TimeSpan> BirthDateDifferences(List<RealPerson> sortPeople)
        {
            return sortPeople
                .Take(sortPeople.Count - 1)
                .Select((x, i) => sortPeople[i + 1].BirthDate - x.BirthDate)
                .ToList();
        }

        private List<RealPerson> SortInAsceningOrder(List<RealPerson> people)
        {
            return people.OrderBy(x => x.BirthDate).ToList();
        }
    }
}