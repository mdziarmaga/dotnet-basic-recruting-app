using AutoWrapper.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace MatchDataManager.Api.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IMediator _meditor;

        public ApiController(IMediator meditor)
        {
            _meditor = meditor;
        }

        public async Task<ApiResponse> Send<T>(T request)
        {
            try
            {
                return new ApiResponse(await _meditor.Send(request));
            }
            catch (Exception exception)
            {
                throw new ApiProblemDetailsException(exception.Message, Status500InternalServerError);
            }
        }
    }
}
