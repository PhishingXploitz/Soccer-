﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Soccer.Web.Data.Entities
{
    public class MatchEntity
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0}:yyyy/MM/dd hh:mm", ApplyFormatInEditMode = false)]
        public DateTime Date { get; set; }

        [DisplayFormat(DataFormatString = "{0}:yyyy/MM/dd hh:mm", ApplyFormatInEditMode = false)]
        public DateTime DateLocal => Date.ToLocalTime();

        public TeamEntity Local { get; set; }

        public TeamEntity Visitor { get; set; }

        [Display(Name ="Goals Local")]
        public int GoalsLocal { get; set; }

        [Display(Name = "Goals Visitor")]
        public int GoalsVisitor { get; set; }

        [Display(Name = "Is closed ?")]
        public bool IsClosed { get; set; }

        public GroupEntity Group { get; set; }
    }
}
