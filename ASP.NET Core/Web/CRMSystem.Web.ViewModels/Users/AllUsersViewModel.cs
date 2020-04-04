namespace CRMSystem.Web.ViewModels.Users
{
    using AutoMapper;
    using CRMSystem.Data.Models;
    using CRMSystem.Services.Mapping;
    using System.Collections.Generic;

    public class AllUsersViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }
    }
}
