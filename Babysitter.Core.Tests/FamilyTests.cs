using Babysitter.Core.Entities;
using Exceptionless;
using GenFu;
using System;
using Shouldly;
using Xunit;

namespace Babysitter.Core.Tests
{
    public class FamilyTests
    {
        private readonly Family _familyA = new FamilyA();
        private readonly Family _familyB = new FamilyB();
        private readonly Family _familyC = new FamilyC();


        [Fact]
        public void EqualsShouldReturnTrueIfFamilyIsTheSame()
        {
            //ARRANGE
            var testFamily1 = _familyA;
            var testFamily2 = _familyA;
            //ACT & ASSERT    
            testFamily1.Equals(testFamily2).ShouldBeTrue();
            (testFamily1 == testFamily2).ShouldBeTrue();
        }

        [Fact]
        public void EqualsShouldReturnFalseIfFamilyIsNotTheSame()
        {
            //ARRANGE
            var testFamily1 = _familyA;
            var testFamily2 = _familyB;

            //ACT & ASSERT
            testFamily1.Equals(testFamily2).ShouldBeFalse();
            (testFamily1 == testFamily2).ShouldBeFalse();
        }

        [Fact]
        public void NotEqualsShouldReturnTrueIfFamiliesAreNotTheSame()
        {
            //ARRANGE
            var testFamily1 = _familyA;
            var testFamily2 = _familyB;

            //ACT & ASSERT
            (testFamily1 != testFamily2).ShouldBeTrue();
        }
    }
}
