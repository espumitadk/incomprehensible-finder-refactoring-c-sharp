using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Algorithm.FindRules;

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
            return Applly(rule);
        }

        private bool NotEnougthPeople()
        {
            return people.Count < 2;
        }

        private QueryResult Applly(Rule rule)
        {
            return rule.ApplyOn(people);
        }
    }
}