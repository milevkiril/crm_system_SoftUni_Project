namespace CRMSystem.Web.ViewModels.Users
{
    using CRMSystem.Data.Models;
    using CRMSystem.Services.Mapping;
    using System;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public DateTime CreatedOn { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string UserName { get; set; }
    }
}
