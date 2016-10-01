using System;
using System.Collections.Generic;
using Algorithm.FindRules;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Algorithm.Tests
{
    [TestFixture]
    public class FinderShould
    {
        private List<Person> people;
        private Finder finder;

        [SetUp]
        public void SetUp()
        {
            people = new List<Person>();
            finder = new Finder(people);
        }

        [Test]
        public void apply_the_find_closest_rule()
        {
            var closestRule = Substitute.For<ClosestRule>();
            closestRule.ApplyOn(people).Returns(new QueryResult());

            finder.FindUsing(closestRule);

            closestRule.Received().ApplyOn(Arg.Is<List<Person>>(x => x == people));
        }

        [Test]
        public void apply_the_find_furthest_rule()
        {
            var furthestRule = Substitute.For<FurthestRule>();
            furthestRule.ApplyOn(people).Returns(new QueryResult());

            finder.FindUsing(furthestRule);

            furthestRule.Received().ApplyOn(Arg.Is<List<Person>>( x => x == people));
        }
    }
}