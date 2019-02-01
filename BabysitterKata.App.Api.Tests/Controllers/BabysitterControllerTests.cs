using BabysitterKata.App.Controllers;
using BabysitterKata.Core.Accessors;
using BabysitterKata.Entities;
using Exceptionless;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using System;
using Xunit;

namespace BabysitterKata.App.Api.Tests
{
    public class BabysitterControllerTests
    {
        private Mock<IBabysitterAccessor> _mockBabysitter;
        private BabysitterRequestData _requestData;

        [Fact()]
        public void GetShouldReturnABabysitter()
        {
            //ARRANGE
            var controller = NewBabysitterController("Test");

            //ACT
            var result = controller.Get(_requestData.FamilyId, _requestData.StartTime, _requestData.EndTime);

            //ASSERT
            result.ShouldNotBeNull();

            var value = (result.Result as OkObjectResult).Value;

            value.ShouldNotBeNull();
        }

        [Fact()]
        public void GetShouldReturnNoContentWhenNoBabysitterIsReturned()
        {
            //ARRANGE
            var controller = NewBabysitterController("NC");

            //ACT
            var result = controller.Get(_requestData.FamilyId, _requestData.StartTime, _requestData.EndTime);

            //ASSERT
            result.ShouldNotBeNull();

            var value = (result.Result as NoContentResult);

            value.ShouldNotBeNull();
        }

        private BabysitterController NewBabysitterController(String mode)
        {
            if (mode is "Test")
            {
                SetTestFixture();
            }
            else if (mode is "NC")
            {
                SetNoContentFixture();
            }

            var controller = new BabysitterController(_mockBabysitter.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext()
                }
            };

            return controller;
        }

        private void SetTestFixture()
        {
            _requestData = new BabysitterRequestData()
            {
                FamilyId = SetFamily(),
                StartTime = RandomData.GetInt(17,23),
                EndTime = RandomData.GetInt(0,4)
            };

            _mockBabysitter = new Mock<IBabysitterAccessor>();

            _mockBabysitter.Setup(x => x.GetBabysitterWorkingShift(It.IsAny<BabysitterRequestData>()))
                           .Returns(new Babysitter(_requestData.FamilyId)
                                        {PayForShift = RandomData.GetInt(80,280)
                                        });
        }

        private void SetNoContentFixture()
        {
            _requestData = new BabysitterRequestData()
            {
                FamilyId = SetFamily(),
                StartTime = RandomData.GetInt(17, 23),
                EndTime = RandomData.GetInt(0, 4)
            };

            _mockBabysitter = new Mock<IBabysitterAccessor>();

            _mockBabysitter.Setup(x => x.GetBabysitterWorkingShift(It.IsAny<BabysitterRequestData>()));
        }

        private String SetFamily()
        {
            var determinationFactor = RandomData.GetInt(1, 3);

            if (determinationFactor == 1)
            {
                return "A";
            }
            else if (determinationFactor == 2)
            {
                return "B";
            }
            else
            {
                return "C";
            }
        }

    }
}
