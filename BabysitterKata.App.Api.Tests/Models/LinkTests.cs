using BabysitterKata.App.Models;
using Exceptionless;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BabysitterKata.App.Api.Tests
{
   public class LinkTests
    {
        [Fact()]
        public void ConstructorShouldThrowAnArgumentNullExceptionWhenTheHrefArgumentIsNull()
        {
            //ARRANGE
            var name = RandomData.GetAlphaString(1, 10);

            //ACT
            Action link = () => new Link(name, null);

            //ASSERT
            link.ShouldThrow<ArgumentNullException>();
        }

        [Fact()]
        public void ConstructorShouldThrowAnArgumentNullExceptionWhenTheNameArgumentIsAnEmptyString()
        {
            //ARRANGE
            var href = "/" + RandomData.GetAlphaString(1, 10);

            //ACT
            Action link = () => new Link(String.Empty, href);

            //ASSERT
            link.ShouldThrow<ArgumentNullException>();
        }

        [Fact()]
        public void ConstructorShouldThrowAnArgumentNullExceptionWhenTheNameArgumentIsNull()
        {
            //ARRANGE
            var href = "/" + RandomData.GetAlphaString(1, 10);

            //ACT
            Action link = () => new Link(null, href);

            //ASSERT
            link.ShouldThrow<ArgumentNullException>();

        }
    }
}
