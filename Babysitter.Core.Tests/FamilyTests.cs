using BabysitterKata.Entities;
using Exceptionless;
using GenFu;
using System;
using Shouldly;
using Xunit;

namespace BabysitterKata.Core.Tests
{
    public class FamilyTests
    {
        
        [Fact]
        public void EqualsShouldReturnTrueIfFamilyIsTheSame()
        {
            //ARRANGE
            var testFamily1 = Family.Create("A");
            var testFamily2 = Family.Create("A");
            //ACT & ASSERT    
            testFamily1.Equals(testFamily2).ShouldBeTrue();
            (testFamily1 == testFamily2).ShouldBeTrue();
        }

        [Fact]
        public void EqualsShouldReturnFalseIfFamilyIsNotTheSame()
        {
            //ARRANGE
            var testFamily1 = Family.Create("A");
            var testFamily2 = Family.Create("B");

            //ACT & ASSERT
            testFamily1.Equals(testFamily2).ShouldBeFalse();
            (testFamily1 == testFamily2).ShouldBeFalse();
        }

        [Fact]
        public void NotEqualsShouldReturnTrueIfFamiliesAreNotTheSame()
        {
            //ARRANGE
            var testFamily1 = Family.Create("A");
            var testFamily2 = Family.Create("B");

            //ACT & ASSERT
            (testFamily1 != testFamily2).ShouldBeTrue();
        }
    }
}
