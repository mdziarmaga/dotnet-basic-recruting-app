using AutoWrapper.Wrappers;
using MatchDataManager.Api.Controllers.Common;
using MatchDataManager.Api.DTO.Teams.Commands;
using MatchDataManager.Api.DTO.Teams.Queries;
using MatchDataManager.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace MatchDataManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamsController : ApiController
{
    public TeamsController(IMediator mediator) : base(mediator)
    {

    }

    [HttpPost]
    public async Task<ApiResponse> AddTeam(Team team)
    {
        return new ApiResponse(await Send(new AddTeamCommand { Team = team }));
    }

    [HttpDelete("{id:guid}")]
    public async Task<ApiResponse> DeleteTeam(Guid id)
    {
        return new ApiResponse(await Send(new DeleteTeamCommand { Id = id }));
    }

    [HttpGet]
    public async Task<ApiResponse> Get()
    {
        return new ApiResponse(await Send(new GetTeamsQuery()));
    }

    [HttpGet("{id:guid}")]
    public async Task<ApiResponse> GetById(Guid id)
    {
        return new ApiResponse(await Send(new GetTeamByIdQuery { Id = id }));
    }

    [HttpPut]
    public async Task<ApiResponse> UpdateTeam(Team team)
    {
        return new ApiResponse(await Send(new UpdateTeamCommand { Team = team }));
    }
}