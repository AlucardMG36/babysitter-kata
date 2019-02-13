using BabysitterKata.Entities;
using Exceptionless;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BabysitterKata.App.IntegrationTests.Helpers
{
    public class BabysitterShiftsBuilder
    {
        public BabysitterShiftsBuilder()
        {
        }

        public IEnumerable<Babysitter> SetupTestData()
        {
            using (var context = new BabysitterTestDbContext())
            {
                context.RemoveRange(context.Babysitter);

                var testData = CreateTestData();

                context.AddRange(testData);
                context.SaveChanges();

                return testData;
            }
        }

        private IEnumerable<Babysitter> CreateTestData()
        {

            var beforeMidnightData = CreateRequestTestDataBeforeMidnight();

            var afterMidnightData = CreateRequestTestDataAfterMidnight();

            var overnightData = CreateRequestTestDataForOverNight();

            return new List<Babysitter>
            {
                new Babysitter(beforeMidnightData) { PayForShift = CalculatePay(beforeMidnightData)},
                new Babysitter(afterMidnightData)  { PayForShift = CalculatePay(afterMidnightData)},
                new Babysitter(overnightData)      { PayForShift = CalculatePay(overnightData)}
            };
        }

        private Int32 CalculatePay(BabysitterRequestData data)
        {
            var shiftWorked = Shift.Create(data.FamilyId, data.StartTime, data.EndTime);

            return shiftWorked.CalculatePayForNightWorked();
        }

        private BabysitterRequestData CreateRequestTestDataForOverNight()
        {
            return new BabysitterRequestData()
            {
                FamilyId = FamilyDetermination(),
                StartTime = RandomData.GetInt(17, 23),
                EndTime = RandomData.GetInt(0, 4)
            };
        }

        private BabysitterRequestData CreateRequestTestDataAfterMidnight()
        {
            return new BabysitterRequestData()
            {
                FamilyId = FamilyDetermination(),
                StartTime = 0,
                EndTime = RandomData.GetInt(1, 4)
            };
        }

        private BabysitterRequestData CreateRequestTestDataBeforeMidnight()
        {
            return new BabysitterRequestData()
            {
                FamilyId = FamilyDetermination(),
                StartTime = 17,
                EndTime = RandomData.GetInt(18, 23)
            };
        }

        private string FamilyDetermination()
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