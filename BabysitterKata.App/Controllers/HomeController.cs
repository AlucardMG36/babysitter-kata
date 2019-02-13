using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabysitterKata.App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BabysitterKata.App.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        public const String GetHref = "";

        public HomeController()
            :base()
        {

        }
        
        [HttpGet(GetHref)]
        [ProducesResponseType(200, Type=typeof(HomeViewModel))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public ActionResult<HomeViewModel> Get()
        {
            var resource = GetRootResource();

            var viewModel = new HomeViewModel(GetHref, resource);

            viewModel.AddLink("babysitterShift", "/Babysitter");

            return viewModel;
        }

        private Home GetRootResource()
        {
            return new Home();
        }
    }
}
