using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rabbit_API.Models;
using Rabbit_API.Models.Dto;
using Rabbit_API.Repository.IRepository;
using System.Net;

namespace Rabbit_API.Controllers
{
    [Route("api/Threads")]
    [ApiController]
    public class ThreadController : Controller
    {
        protected APIResponse _response;
        private readonly IThreadRepository _dbThread;
        private readonly IMapper _mapper;

        public ThreadController(IThreadRepository dbThread, IMapper mapper)
        {
            _dbThread = dbThread;
            _mapper = mapper;
            _response = new APIResponse();
        }
        /*public IActionResult Index()
        {
            return View();
        }*/

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetThreads()
        {
            try
            {
                IEnumerable<Models.Thread> threadList;

                threadList = await _dbThread.GetAllAsync();

                _response.Result = _mapper.Map<List<ThreadDTO>>(threadList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
