using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Soccer.Web.Data.Entities;
using Soccer.Web.Models;

namespace Soccer.Web.Helpers
{
    public class ConverterHelper : IConvertHelper
    {
        public TeamEntity ToTeamEntity(TeamViewModel model, string path, bool isNew)
        {
            return new TeamEntity
            {
                Id = isNew ? 0 : model.Id,
                LogoPath = path,
                Name = model.Name
            };
        }

        public TeamViewModel ToTeamViewModel(TeamEntity teamEntity)
        {
            return new TeamViewModel
            {
                Id = teamEntity.Id,
                LogoPath = teamEntity.LogoPath,
                Name = teamEntity.Name
            };
        }
    }
}
