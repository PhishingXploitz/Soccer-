using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Soccer.Web.Data.Entities
{
    public class TournamentEnity
    {
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "The field {0} can not have more than {1} characteres ")]
        [Required(ErrorMessage = "The field {0} is mandatory")]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0}:yyyy/MM/dd hh:mm", ApplyFormatInEditMode = false)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0}:yyyy/MM/dd hh:mm", ApplyFormatInEditMode = false)]
        public DateTime StartDateLocal => StartDate.ToLocalTime();

        [DataType(DataType.DateTime)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0}:yyyy/MM/dd hh:mm", ApplyFormatInEditMode = false)]
        public DateTime? EndDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0}:yyyy/MM/dd hh:mm", ApplyFormatInEditMode = false)]
        public DateTime? EndDateLocal => EndDate?.ToLocalTime();


        [Display(Name ="Logo")]

        public string LogoPath { get; set; }

        public ICollection<GroupEntity> Groups { get; set; }

    }
}
