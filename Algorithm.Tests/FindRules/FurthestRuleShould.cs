using System;
using System.Collections.Generic;
using Algorithm.FindRules;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Tests.FindRules
{    
    [TestFixture]
    public class FinderTests
    {
        private readonly Person sue = new Person("Sue", new DateTime(1950, 1, 1));
        private readonly Person greg = new Person("Greg", new DateTime(1952, 6, 1));
        private readonly Person sarah = new Person("Sarah", new DateTime(1982, 1, 1));
        private readonly Person mike = new Person("Mike", new DateTime(1979, 1, 1));
        private FurthestRule furthestRule;


        [SetUp]
        public void SetUp()
        {
            furthestRule = new FurthestRule();
        }

        [Test]
        public void Returns_Empty_Results_When_Given_Empty_List()
        {
            var people = new List<Person>();

            var queryResult = furthestRule.ApplyOn(people);

            queryResult.FirstPerson.Should().BeNull();
            queryResult.SecondPerson.Should().BeNull();
        }


        [Test]
        public void Returns_Empty_Results_When_Given_One_Person()
        {
            var people = new List<Person> { sue };

            var queryResult = furthestRule.ApplyOn(people);

            queryResult.FirstPerson.Should().BeNull();
            queryResult.SecondPerson.Should().BeNull();
        }

        [Test]
        public void Returns_Furthest_Two_For_Two_People()
        {
            var people = new List<Person> { greg, mike };

            var queryResult = furthestRule.ApplyOn(people);

            queryResult.FirstPerson.Should().Be(greg);
            queryResult.SecondPerson.Should().Be(mike);
        }

        [Test]
        public void Returns_Furthest_Two_For_Four_People()
        {
            var people = new List<Person> { greg, mike, sarah, sue };

            var queryResult = furthestRule.ApplyOn(people);

            queryResult.FirstPerson.Should().Be(sue);
            queryResult.SecondPerson.Should().Be(sarah);
        }

    }
}