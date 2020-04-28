namespace CRMSystem.Web.ViewModels.Users
{
    using CRMSystem.Data.Models;
    using CRMSystem.Services.Mapping;
    using CRMSystem.Web.ViewModels.Deals;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public DateTime CreatedOn { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string UserName { get; set; }

        public IEnumerable<DealViewModel> MyProperty { get; set; }
    }
}
