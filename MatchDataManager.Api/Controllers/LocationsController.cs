using AutoWrapper.Wrappers;
using MatchDataManager.Api.Controllers.Common;
using MatchDataManager.Api.DTO.Locations.Commands;
using MatchDataManager.Api.DTO.Locations.Queries;
using MatchDataManager.Api.DTO.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MatchDataManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationsController : ApiController
{
    public LocationsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<ApiResponse> AddLocation(Location location)
    {
        return new ApiResponse(await Send(new AddLocationCommand { Location = location }));
    }

    [HttpDelete("{id:guid}")]
    public async Task<ApiResponse> DeleteLocation(Guid id)
    {
        return new ApiResponse(await Send(new DeleteLocationCommand { Id = id }));
    }

    [HttpGet]
    public async Task<ApiResponse> Get()
    {
        return new ApiResponse(await Send(new GetLocationsQuery()));
    }

    [HttpGet("{id:guid}")]
    public async Task<ApiResponse> GetById(Guid id)
    {
        return new ApiResponse(await Send(new GetLocationByIdQuery { Id = id }));
    }

    [HttpPut]
    public async Task<ApiResponse> UpdateLocation(Location location)
    {
        return new ApiResponse(await Send(new UpdateLocationCommand { Location = location }));
    }
}