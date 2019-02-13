using System;

namespace BabysitterKata.App.Models
{
    public class HomeViewModel : ViewModel<Home>
    {
        public HomeViewModel(String selfUrl, Home data)
            : base(selfUrl, data)
        {
        }
    }
}
