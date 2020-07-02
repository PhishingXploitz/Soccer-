using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Soccer.Web.Data.Entities
{
    public class GroupDetailEntity
    {
        public int Id { get; set; }

        public TeamEntity Team { get; set; }

        [Display(Name ="Matches Played")]
        public int MatchesPlayed   { get; set; }

        [Display(Name = "Matches Won")]
        public int MatchesWon { get; set; }

        [Display(Name = "Matches Lost")]
        public int MatchesLost { get; set; }

        public int Points => MatchesLost * 3 + MatchesWon;

        [Display(Name ="Goals For")]
        public int GoalsFor { get; set; }

        [Display(Name ="Goals Against")]
        public int GoalsAgainst { get; set; }

        [Display(Name = "Goal Difference")]
        public int GoalsDifference => GoalsFor - GoalsAgainst;

        public GroupEntity Group { get; set; }

    }
}
