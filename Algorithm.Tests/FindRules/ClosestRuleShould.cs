using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Algorithm.FindRules;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Tests.FindRules
{
    [TestFixture]
    public class ClosestRuleShould
    {
        private readonly Person sue = new Person("Sue", new DateTime(1950, 1, 1));
        private readonly Person greg = new Person("Greg", new DateTime(1952, 6, 1));
        private readonly Person sarah = new Person("Sarah", new DateTime(1982, 1, 1));
        private readonly Person mike = new Person("Mike", new DateTime(1979, 1, 1));
        private ClosestRule closestRule;


        [SetUp]
        public void SetUp()
        {
            closestRule = new ClosestRule();
        }


        [Test]
        public void Returns_Empty_Results_When_Given_Empty_List()
        {
            var people = new List<Person>();

            var queryResult  = closestRule.ApplyOn(people);

            queryResult.FirstPerson.Should().BeNull();
            queryResult.SecondPerson.Should().BeNull();
        }


        [Test]
        public void Returns_Empty_Results_When_Given_One_Person()
        {
            var people = new List<Person> { sue };

            var queryResult = closestRule.ApplyOn(people);

            queryResult.FirstPerson.Should().BeNull();
            queryResult.SecondPerson.Should().BeNull();
        }


        [Test]
        public void Returns_Closest_Two_For_Two_People()
        {
            var people = new List<Person> { sue, greg };


            var queryResult = closestRule.ApplyOn(people);

            queryResult.FirstPerson.Should().Be(sue);
            queryResult.SecondPerson.Should().Be(greg);
        }


        [Test]
        public void Returns_Closest_Two_For_Four_People()
        {
            var people = new List<Person> { greg, mike, sarah, sue };

            var queryResult = closestRule.ApplyOn(people);

            queryResult.FirstPerson.Should().Be(sue);
            queryResult.SecondPerson.Should().Be(greg);
        }
    }

}
