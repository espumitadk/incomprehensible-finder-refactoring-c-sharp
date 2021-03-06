﻿using System.Collections.Generic;
using System.Linq;

namespace Algorithm.FindRules
{
    public class FurthestRule : Rule
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
            return new FindResults(sortPeople.First(), sortPeople.Last());
        }

        private List<RealPerson> SortInAsceningOrder(List<RealPerson> people)
        {
            return people.OrderBy(x => x.BirthDate).ToList();
        }
    }
}