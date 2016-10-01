using System;
using System.Collections.Generic;
using Algorithm.FindRules;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Test
{    
    [TestFixture]
    public class FinderTests
    {
        private readonly Person sue = new Person("Sue", new DateTime(1950, 1, 1));
        private readonly Person greg = new Person("Greg", new DateTime(1952, 6, 1));
        private readonly Person sarah = new Person("Sarah", new DateTime(1982, 1, 1));
        private readonly Person mike = new Person("Mike", new DateTime(1979, 1, 1));

        [Test]
        public void Returns_Empty_Results_When_Given_Empty_List()
        {
            var people = new List<Person>();
            var finder = new Finder(people);

            var result = finder.FindUsing(new ClosestRule());

            result.FirstPerson.Should().BeNull();
            result.SecondPerson.Should().BeNull();
        }

        [Test]
        public void Returns_Empty_Results_When_Given_One_Person()
        {
            var people = new List<Person> { sue };
            var finder = new Finder(people);

            var result = finder.FindUsing(new ClosestRule());

            result.FirstPerson.Should().BeNull();
            result.SecondPerson.Should().BeNull();
        }

        [Test]
        public void Returns_Closest_Two_For_Two_People()
        {
            var people = new List<Person> { sue, greg };
            var finder = new Finder(people);

            var result = finder.FindUsing(new ClosestRule());

            result.FirstPerson.Should().Be(sue);
            result.SecondPerson.Should().Be(greg);
        }

        [Test]
        public void Returns_Furthest_Two_For_Two_People()
        {
            var people = new List<Person> { greg, mike };
            var finder = new Finder(people);

            var result = finder.FindUsing(new FurthestRule());

            result.FirstPerson.Should().Be(greg);
            result.SecondPerson.Should().Be(mike);
        }

        [Test]
        public void Returns_Furthest_Two_For_Four_People()
        {
            var people = new List<Person> { greg, mike, sarah, sue };
            var finder = new Finder(people);

            var result = finder.FindUsing(new FurthestRule());

            result.FirstPerson.Should().Be(sue);
            result.SecondPerson.Should().Be(sarah);
        }

        [Test]
        public void Returns_Closest_Two_For_Four_People()
        {
            var people = new List<Person> { greg, mike, sarah, sue };
            var finder = new Finder(people);

            var result = finder.FindUsing(new ClosestRule());

            result.FirstPerson.Should().Be(sue);
            result.SecondPerson.Should().Be(greg);
        }
    }
}