using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Rabbit_API.Models;
using Rabbit_API.Models.Dto.Threads;
using Rabbit_API.Repository.IRepository;
using System.Net;

namespace Rabbit_API.Controllers
{
    [EnableCors("AllowAngularApp")]
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

        [HttpGet("{id:int}", Name = "GetThread")]
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
                if (createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                Models.Thread thread = _mapper.Map<Models.Thread>(createDTO);

                thread.UpdatedDate = DateTime.UtcNow;
                thread.CreatedDate = DateTime.UtcNow;

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

        [HttpPut("{id:int}", Name = "UpdateThread")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateThread(int id, [FromBody] UpdateThreadDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id <= 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var prevThread = await _dbThread.GetAsync(u => u.ID == id);
                if (prevThread == null) return NotFound();

                _dbThread.Detach(prevThread);

                Models.Thread model = _mapper.Map<Models.Thread>(updateDTO);

                model.UserId = prevThread.UserId;
                model.CreatedDate = prevThread.CreatedDate;
                model.UpdatedDate = DateTime.UtcNow;

                await _dbThread.UpdateAsync(model); 

                if (!ModelState.IsValid) return BadRequest(ModelState);

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;

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

        [HttpDelete("{id:int}", Name = "DeleteThread")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteThread(int id)
        {
            try
            {
                if (id <= 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var thread = await _dbThread.GetAsync(u => u.ID == id);
                if (thread == null) return NotFound();

                await _dbThread.RemoveAsync(thread);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string> { ex.ToString() };
            }
            return _response;

        }
    }
}
