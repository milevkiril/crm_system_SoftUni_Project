using AutoMapper;
using CRMSystem.Data.Models;
using CRMSystem.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystem.Web.ViewModels.Users
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

    }
}
