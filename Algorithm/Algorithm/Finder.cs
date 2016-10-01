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
            return rule.ApplyOn(people);
        }
    }
}