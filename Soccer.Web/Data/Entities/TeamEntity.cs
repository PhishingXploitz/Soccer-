using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Soccer.Web.Data.Entities
{
    public class TeamEntity
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The {0} field cat not have more than {1} letters")]
        [Required(ErrorMessage = "The {0} field is mandatory")]
        public string Name { get; set; }
        
        [Display(Name="Logo")]
        public string LogoPath { get; set; }

    }


}
