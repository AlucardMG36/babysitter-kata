using BabysitterKata.Data.Tests;
using BabysitterKata.Entities;
using Exceptionless;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BabysitterKata.Data.EntityFramework.Tests
{
    public class BabysitterRepositoryTests
    {
        private readonly BabysitterRepository _babysitterRepository;
        private readonly TestBabysitterDbContext _testBabysitterDb;
        private readonly BabysitterRequestData _testBabysitter;

        public BabysitterRepositoryTests()
        {
            _testBabysitter = new BabysitterRequestData
            {
                FamilyId = SetFamily(),
                StartTime = RandomData.GetInt(17, 23),
                EndTime = RandomData.GetInt(0, 4)
            };

            _testBabysitterDb = new TestBabysitterDbContext();

            _babysitterRepository = new BabysitterRepository(_testBabysitterDb);
        }

        [Fact()]
        public void GetBabysitterWorkingShiftShouldReturnABabysitterWithPay()
        {
            //ARRANGE
            using (_testBabysitterDb)
            {
                //ACT
                var testBabysitter = _babysitterRepository.GetBabysitterWorkingShift(_testBabysitter);

                //ASSERT
                testBabysitter.ShouldNotBeNull();
                testBabysitter.PayForShift.ShouldNotBeNull();
            }
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
