using BabysitterKata.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabysitterKata.App.Models
{
    public sealed class BabysitterViewModel : ViewModel<Babysitter>
    {
        private BabysitterViewModel(string selfUrl, Babysitter data) 
            : base(selfUrl, data)
        {
        }

        internal static BabysitterViewModel From(HttpRequest request, Babysitter babysitter)
        {
            var selfUrl = $"{request.Path}/{babysitter.Id}";

            var vm = new BabysitterViewModel(selfUrl, babysitter);

            return vm;

        }
    }
}
