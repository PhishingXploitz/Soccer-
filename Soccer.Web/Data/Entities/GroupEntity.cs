using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Soccer.Web.Data.Entities
{
    public class GroupEntity
    {
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "The field {0} can not have more than {1} characteres ")]
        [Required(ErrorMessage = "The field {0} is mandatory")]
        public string Name { get; set; }

        public TournamentEnity Tournament { get; set; }

        public ICollection<GroupDetailEntity> GroupDetails { get; set; }

        public ICollection<MatchEntity> Matches { get; set; }
    }
}
