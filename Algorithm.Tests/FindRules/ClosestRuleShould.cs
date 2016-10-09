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
        private readonly RealPerson sue = new RealPerson("Sue", new DateTime(1950, 1, 1));
        private readonly RealPerson greg = new RealPerson("Greg", new DateTime(1952, 6, 1));
        private readonly RealPerson sarah = new RealPerson("Sarah", new DateTime(1982, 1, 1));
        private readonly RealPerson mike = new RealPerson("Mike", new DateTime(1979, 1, 1));
        private ClosestRule closestRule;


        [SetUp]
        public void SetUp()
        {
            closestRule = new ClosestRule();
        }


        [Test]
        public void Returns_Empty_Results_When_Given_Empty_List()
        {
            var people = new List<RealPerson>();

            var queryResult  = closestRule.ApplyOn(people);

            queryResult.OldestRealPerson.Should().BeOfType<NoPerson>();
            queryResult.YoungestRealPerson.Should().BeOfType<NoPerson>();
        }


        [Test]
        public void Returns_Empty_Results_When_Given_One_Person()
        {
            var people = new List<RealPerson> { sue };

            var queryResult = closestRule.ApplyOn(people);

            queryResult.OldestRealPerson.Should().BeOfType<NoPerson>();
            queryResult.YoungestRealPerson.Should().BeOfType<NoPerson>();
        }


        [Test]
        public void Returns_Closest_Two_For_Two_People()
        {
            var people = new List<RealPerson> { sue, greg };


            var queryResult = closestRule.ApplyOn(people);

            queryResult.OldestRealPerson.Should().Be(sue);
            queryResult.YoungestRealPerson.Should().Be(greg);
        }


        [Test]
        public void Returns_Closest_Two_For_Four_People()
        {
            var people = new List<RealPerson> { greg, mike, sarah, sue };

            var queryResult = closestRule.ApplyOn(people);

            queryResult.OldestRealPerson.Should().Be(sue);
            queryResult.YoungestRealPerson.Should().Be(greg);
        }
    }

}
