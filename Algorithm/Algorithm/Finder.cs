using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Algorithm.FindRules;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<RealPerson> people;

        public Finder(List<RealPerson> people)
        {
            this.people = people;
        }

        public FindResults FindUsing(Rule rule)
        {
            return rule.ApplyOn(people);
        }
    }
}