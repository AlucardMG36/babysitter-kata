using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BabysitterKata.App.IntegrationTests.Fixtures;
using BabysitterKata.App.IntegrationTests.Helpers;
using BabysitterKata.App.IntegrationTests.Http;
using BabysitterKata.Entities;
using Shouldly;
using Xunit;

namespace BabysitterKata.App.IntegrationTests.Steps
{
    public class BabysitterControllerSteps : IClassFixture<ControllerTestServerFixture>
    {
        private BabysitterShiftsBuilder _dummyBuilder;
        private ResourceCollection<Babysitter> _actualCollection;
        private ResourceCollection<Babysitter> _expectedCollection;
        private HttpResponseMessage _response;
        private ControllerTestServerFixture _testsFixture;

        public BabysitterControllerSteps(ControllerTestServerFixture fixture)
        {
            _testsFixture = fixture;

            if (_dummyBuilder is null)
            {
                _dummyBuilder = new BabysitterShiftsBuilder();
            }

            _expectedCollection = new ResourceCollection<Babysitter>()
            {
                Data = new List<Resource<Babysitter>>(),
                Links = new List<Link>()
                {
                    new Link() {Name = "self", Href=""}
                }
            };

            _actualCollection = new ResourceCollection<Babysitter>()
            {
                Data = new List<Resource<Babysitter>>(),
                Links = new List<Link>()
                {
                    new Link() {Name = "self", Href=""}
                }
            };

            foreach (var entry in _dummyBuilder.SetupTestData())
            {
                var resource = new Resource<Babysitter>()
                {
                    Data = entry,
                    Links = new List<Link>()
                    {
                        new Link() {Name ="self", Href = $"/Babysitter/{entry.Id}"}
                    }
                };

                _expectedCollection.Data.Add(resource);
            }
        }



        [Fact()]
        public async void PayIsCalculatedAccuratelyForShifts()
        {
            GivenIAmABabysitterForAFamily();

            await WhenIWorkMyShiftForTheNight();

            ThenIShouldBePaidForTheShiftIWorked();
        }

        //[Given(@"Given I am a Babysitter For A Family")]
        private void GivenIAmABabysitterForAFamily()
        {
        }

        //[When(@"When I Work My Shift For The Night")]
        private async Task WhenIWorkMyShiftForTheNight()
        {

            foreach (var entry in _expectedCollection.Data)
            {
                var sitter = entry.Data;
                _response = await _testsFixture.Client.GetAsync($"/Babysitter?familyId={sitter.CurrentFamily}&startTime={sitter.StartTime}&endTime={sitter.EndTime}");

                _response.StatusCode.ShouldBe(HttpStatusCode.OK);

                var content = await _response.Content.ReadAsStringAsync();

                _actualCollection.Data.Add(Resource<Babysitter>.From(content));
            };
        }

        //[Then(@"Then I Should Be Paid For The Shift I Worked")]
        private void ThenIShouldBePaidForTheShiftIWorked()
        {
            var expectedPayForNight = _expectedCollection.Data.Select(resource => resource.Data.PayForShift).ToList();
            var actualPayForNight = _actualCollection.Data.Select(resource => resource.Data.PayForShift).ToList();

            actualPayForNight.ShouldBe(expectedPayForNight);
        }
    }
}
