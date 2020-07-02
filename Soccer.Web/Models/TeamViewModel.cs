using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Soccer.Web.Data.Entities;

namespace Soccer.Web.Models
{
    public class TeamViewModel:TeamEntity
    {
        [Display(Name = "Logo")]
        public IFormFile LogoFile { get; set; }
    }
}
