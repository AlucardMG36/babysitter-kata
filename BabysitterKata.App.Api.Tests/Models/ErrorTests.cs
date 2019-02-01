using System;
using BabysitterKata.App.Models;
using Shouldly;
using Xunit;

namespace BabysitterKata.App.Api.Tests
{
    
    public class ErrorTests
    {
        [Fact()]
        public void ConstructorShouldThrowAnArgumentNullExceptionWhenTheMessageArgumentIsAnEmptyString()
        {
            //ARRANGE
            Action error= () => new Error(String.Empty);

            //ACT & ASSERT
            error.ShouldThrow<ArgumentNullException>();
        }

        [Fact()]
        public void ConstructorShouldThrowAnArgumentNullExceptionWhenTheMessageArgumentIsNull()
        {
            //ARRANGE
            Action error = () => new Error(null);

            //ACT & ASSERT
            error.ShouldThrow<ArgumentNullException>();
        }
    }
}
