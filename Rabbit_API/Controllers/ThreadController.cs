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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetThread(int id)
        {
            try
            {
                if (id <= 0)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                Models.Thread thread = await _dbThread.GetAsync(item => item.ID == id);

                if (thread == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<ThreadDTO>(thread);
                _response.IsSuccess = true;
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateThread([FromBody] CreateThreadDTO createDTO)
        {
            try
            {
                //if (await _dbThread.GetAsync(u => u.ID == createDTO.ID != null))
                if (createDTO == null) return BadRequest(createDTO);

                Models.Thread thread = _mapper.Map<Models.Thread>(createDTO);

                await _dbThread.CreateAsync(thread);

                _response.Result = _mapper.Map<ThreadDTO>(thread);
                _response.StatusCode = HttpStatusCode.Created;

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
