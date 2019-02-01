﻿using System;
using BabysitterKata.App.Models;
using BabysitterKata.Core.Accessors;
using BabysitterKata.Core.Data;
using BabysitterKata.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BabysitterKata.App.Controllers
{
    [ApiController()]
    [Route("[controller]")]
    public class BabysitterController : ControllerBase
    {
        private readonly IBabysitterAccessor _babysitter;
        
        public BabysitterController(IBabysitterAccessor babysitter)
            :base()
        {
            _babysitter = babysitter ?? throw new ArgumentException(nameof(babysitter));
        }
        
        [HttpGet()]
        [ProducesResponseType(200, Type=typeof(BabysitterViewModel))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<ViewModel<Babysitter>> Get(String familyId, int startTime, int endTime)
        {
            var requestData = new BabysitterRequestData()
            {
                FamilyId = familyId,
                StartTime = startTime,
                EndTime = endTime
            };

            try
            {
             
                var babysitter = _babysitter.GetBabysitterWorkingShift(requestData);

                if (babysitter is null)
                {
                    return NoContent();
                }

                var vm = BabysitterViewModel.From(Request, babysitter);

                return Ok(vm);
            }
            catch(Exception ex)
            {
                
               var vm = new ViewModel<Babysitter>(String.Empty);
                vm.AddError(ex.Message);
                return BadRequest(vm);
            }
        }
    }
}
