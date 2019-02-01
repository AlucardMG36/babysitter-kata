using BabysitterKata.Core.Accessors;
using BabysitterKata.Core.Data;
using BabysitterKata.Entities;
using BabysitterKata.Extensions;
using System;
using System.Linq;

namespace BabysitterKata.Data
{
    internal sealed class BabysitterRepository : IBabysitterAccessor, IBabysitterRepository
    {
        private readonly BabysitterDBContext _dBContext;

        public BabysitterRepository(BabysitterDBContext dBContext)
        {
            _dBContext = dBContext ?? throw new ArgumentException(nameof(dBContext));
        }
        

        public Babysitter GetBabysitterWorkingShift(BabysitterRequestData babysitterRequest)
        {
            var babysitter = new Babysitter(babysitterRequest.FamilyId)
            {
                PayForShift = WorkShift(babysitterRequest.FamilyId, babysitterRequest.StartTime, babysitterRequest.EndTime)
            };

            _dBContext.Babysitters.Add(babysitter);
            _dBContext.SaveChanges();

            return _dBContext.Babysitters.FirstOrDefault();
        }
        
        private Int32 WorkShift(String familyId, int start, int end)
        {
                if (start.IsBetween(5, 16) || end.IsBetween(5, 16))
                {
                    throw new ArgumentException("Start time or End Time outside of valid working hours");
                }
                var shiftWorked = Shift.Create(familyId, start, end);

                return shiftWorked.CalculatePayForNightWorked();
         }
    }
}
