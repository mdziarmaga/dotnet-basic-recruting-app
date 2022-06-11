﻿using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.DTO.Teams.Commands
{
    public class AddTeamCommand : IRequest<Team>
    {
        public Team Team { get; set; }
    }
}