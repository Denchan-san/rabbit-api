using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rabbit_API.Models;
using Rabbit_API.Models.Dto.Posts;
using Rabbit_API.Repository.IRepository;
using System.Net;

namespace Rabbit_API.Controllers
{
    [Route("api/Reply")]
    [ApiController]
    public class ReplyController : Controller
    {
        protected APIResponse _response;
        private readonly IReplyRepository _dbReply;
        private readonly IMapper _mapper;

        public ReplyController(IReplyRepository dbReply, IMapper mapper)
        {
            _dbReply = dbReply;
            _mapper = mapper;
            _response = new APIResponse();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetReplies()
        {
            try
            {
                List<Reply> replies = await _dbReply.GetAllAsync();

                if (replies == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<List<ReplyDTO>>(replies);

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

        [HttpGet("{id:int}", Name = "GetReply")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetReply(int id)
        {
            try
            {
                if (id <= 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                Reply reply = await _dbReply.GetAsync(u => u.ID == id);
                if (reply == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<ReplyDTO>(reply);

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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateReply([FromBody] CreateReplyDTO createDTO)
        {
            try
            {
                if (createDTO is null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                Reply reply = _mapper.Map<Reply>(createDTO);
                reply.CreatedDate = DateTime.UtcNow;
                reply.UpdatedDate = DateTime.UtcNow;

                await _dbReply.CreateAsync(reply);

                _response.Result = _mapper.Map<Reply>(createDTO);
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

        [HttpPut("{id:int}", Name = "UpdateReply")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateReply(int id, [FromBody] UpdateReplyDTO updateDTO)
        {
            try
            {

                var prevReply = await _dbReply.GetAsync(u => u.ID == id);

                if (prevReply is null)
                {
                    return NotFound(_response);
                }

                // Detach the existing entity
                _dbReply.Detach(prevReply);

                if (updateDTO is null || id <= 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                Reply updatedReply = _mapper.Map<Reply>(updateDTO);

                updatedReply.UserId = prevReply.UserId;
                updatedReply.ParentalCommentaryId = prevReply.ParentalCommentaryId;
                updatedReply.ChildCommentaryId = prevReply.ChildCommentaryId;
                updatedReply.UpdatedDate = DateTime.UtcNow;

                await _dbReply.UpdateAsync(updatedReply);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

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

        [HttpDelete("{id:int}", Name = "DeleteReply")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteReply(int id)
        {
            try
            {
                if (id <= 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var reply = await _dbReply.GetAsync(u => u.ID == id);

                if (reply is null)
                {
                    return NotFound(_response);
                }

                await _dbReply.RemoveAsync(reply);

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
