using BabysitterKata.App.Models;
using BabysitterKata.App.Properties;
using Exceptionless;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BabysitterKata.App.Api.Tests
{
    public class ViewModelTests
    {
        private readonly String data;
        private readonly String href;
        private readonly String name;
        private readonly ViewModel<String> sut;

        public ViewModelTests()
        {
            data = RandomData.GetAlphaString(1, 10);
            href = "/" + RandomData.GetAlphaString(1, 10);
            name = RandomData.GetAlphaString(1, 10);
            sut = new ViewModel<string>(href);
        }


        [Fact()]
        public void AddErrorShouldAddEachErrorWhenDataIsNull()
        {
            //ARRANGE
            var count = RandomData.GetInt(2, 10);
            var messages = new String[count];
            //ACT
            for (var i = 0; i < count; i++)
            {
                messages[i] = RandomData.GetAlphaString(1, 10);

                sut.AddError(messages[i]);
            }

            //ASSERT
            sut.Errors.Count().ShouldBe(count);

            for (var i = 0; i < count; i++)
            {
                sut.Errors.SingleOrDefault(x => x.Message == messages[i]).ShouldNotBeNull();
            }

        }

        [Fact()]
        public void AddErrorShouldThrowAnInvalidOperationExceptionWhenDataIsNotNull()
        {
            //ARRANGE
            var message = RandomData.GetAlphaString(1, 10);
            sut.Data = data;

            //ACT
            Action act = () => sut.AddError(message);

            //ASSERT
            act.ShouldThrow<InvalidOperationException>(Resources.ViewModelCannotAddError);
        }

        [Fact()]
        public void AddLinkShouldAddEachLink()
        {
            //ARRANGE
            var secondName = RandomData.GetAlphaString(1, 10);
            var secondHref = "/" + RandomData.GetAlphaString(1, 10);

            //ACT
            sut.AddLink(name, href);
            sut.AddLink(secondName, secondHref);

            //ASSERT
            sut.Links.Count().ShouldBe(3); //The "self" link is added automatically when the view model is instantiated
            sut.Links.SingleOrDefault(x => x.Name == name && x.Href == href).ShouldNotBeNull();
            sut.Links.SingleOrDefault(x => x.Name == name && x.Href == href).ShouldNotBeNull();
        }

        [Fact()]
        public void DataShouldReturnNullWhenItDoesNotExist()
        {
            //ARRANGE

            //ACT
            var result = sut.Data;

            //ASSERT
            result.ShouldBeNull();
        }

        [Fact()]
        public void DataShouldREturnTheObjectWhenItExists()
        {
            //ARRANGE
            sut.Data = data;

            //ACT
            var result = sut.Data;

            //ASSERT
            result.ShouldBe(data);
        }

        [Fact()]
        public void DataShouldThrowAnInvalidOperationExceptionWhenSettingItToAnObjectAfterAnErrorWasAdded()
        {
            //ARRANGE
            var message = RandomData.GetAlphaString(1, 10);

            sut.AddError(message);

            //ACT
            Action act = () => sut.Data = data;

            //ASSERT
            act.ShouldThrow<InvalidOperationException>(Resources.ViewModelCannotSetDataProperty);
        }

        [Fact()]
        public void GetLinkShouldReturnTheCorrectlinkWhenItExists()
        {
            //ARRANGE
            sut.AddLink(name, href);

            //ACT
            var result = sut.GetLink(name);

            //ASSERT
            result.Href.ShouldBe(href);
            result.Name.ShouldBe(name);
        }

        [Fact()]
        public void GetLinkShouldReturnNullWhenTheLinkDoesNotExist()
        {
            //ARRANGE

            //ACT
            var result = sut.GetLink(name);

            //ASSERT
            result.ShouldBeNull();
        }
    }
}

