using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BabysitterKata.App.Controllers;
using BabysitterKata.App.IntegrationTests.Fixtures;
using BabysitterKata.App.IntegrationTests.Http;
using Shouldly;
using Xunit;

namespace BabysitterKata.App.IntegrationTests.Steps
{
    public class HomeControllerSteps: IClassFixture<ControllerTestServerFixture>
    {

        private ControllerTestServerFixture _fixture;
        private HttpResponseMessage _responseMessage;
        private Resource _responseContent;

        public HomeControllerSteps(ControllerTestServerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact()]
        public async void HomeControllerProvidesCorrectLinksWhenRequestForRootResourceIsSuccessful()
        {
            GivenIAmABabysitterForAFamily();

            await WhenIRequestTheRootResource();

            await ThenIShouldGetASuccessfulResponse();

            AndIShouldBeAbleToSeeTheRootResourceSelfLink();

            AndIShouldBeAbleToSeeTheBabysitterShiftLink();
        }


        private void GivenIAmABabysitterForAFamily()
        {
        }
        
        private async Task<HttpResponseMessage> WhenIRequestTheRootResource()
        {
            using (var client = _fixture.Client)
            {
                _responseMessage = await client.GetAsync(HomeController.GetHref);
            }
                return _responseMessage;
        }
        
        private async Task<HttpResponseMessage> ThenIShouldGetASuccessfulResponse()
        {
            _responseMessage.ShouldNotBeNull();
            _responseMessage.StatusCode.ShouldBe(HttpStatusCode.OK);

            _responseMessage.Content.ShouldNotBeNull();

            var content = await _responseMessage.Content.ReadAsStringAsync();

            _responseContent = Resource.From(content);

            return _responseMessage;
        }

        private void AndIShouldBeAbleToSeeTheRootResourceSelfLink()
        {
            var expectedSelfLink = new Link() { Name = "self", Href = HomeController.GetHref };

            _responseContent.Links.ShouldContain(expectedSelfLink);
        }

        private void AndIShouldBeAbleToSeeTheBabysitterShiftLink()
        {
            var expectedBabysitterShiftLink = new Link() { Name = "babysitterShift", Href = "/Babysitter" };

            _responseContent.Links.ShouldContain(expectedBabysitterShiftLink);
        }




    }
}
