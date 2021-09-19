using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlanthorWebApiServer.Context;
using PlanthorWebApiServer.Models;

namespace PlanthorWebApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly ILogger<MemberController> _logger;
        private readonly PlanthorDbContext _dbcontext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MemberController(ILogger<MemberController> logger, PlanthorDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _logger.LogDebug("Nlog injected into GoalController");

            _dbcontext = dbContext;
            _logger.LogDebug("dbContext injected into GoalController");
            _httpContextAccessor = httpContextAccessor;
        }
        #region Test cases create new member
        /*
        {
            "createdDate": "2021-09-03T12:52:45.280Z",
            "lastUpdatedDate": "2021-09-03T12:52:45.280Z",
            "memberId": "9e4c221f-01e4-4be1-ae00-c47579e31348",
            "memberNickname": "string",
            "memberNoOfObjectives": 0,
            "accountId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
        }
        */
        #endregion
        [HttpPost()]
        public ActionResult<Member> CreateMember(Member newMemberRequest)
        {
            try
            {
                _logger.LogWarning($"{newMemberRequest.MemberId}");
                _dbcontext.Members.Add(newMemberRequest);
                _dbcontext.SaveChanges();

                
                return CreatedAtAction(nameof(GetMember), new { id = newMemberRequest.MemberId }, newMemberRequest);
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, Ex.Message, Ex.StackTrace);
                return BadRequest();
            }
        }
        
        [HttpGet("{id}")]
        public ActionResult<Member> GetMember(Guid id)
        {

            try
            {
                _logger.LogWarning($"GetTribe {id}");
                var member = _dbcontext.Members.Find(id);
                if (member == null)
                {
                    return NotFound();
                }

                return member;
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, Ex.Message, Ex.StackTrace);
                return BadRequest();
            }

        }

        [HttpGet("Users/me")]
        public ActionResult<Member> GetMyInformation()
        {

            try
            {
                //TODO: get userId from FE
                var userId = new Guid("9e4c221f-01e4-4be1-ae00-c47579e31348");
                _logger.LogDebug($"{userId}");
                var user = _dbcontext.Members.Find(userId);
                if (user == null)
                {
                    return NotFound();
                }

                return user;
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, Ex.Message, Ex.StackTrace);
                return BadRequest();
            }
        }

        [HttpGet("Users/me/Goals")]
        public ActionResult<ICollection<Goal>> GetMyGoals()
        {

            try
            {
                //TODO: get userId from FE
                var userId = new Guid("9e4c221f-01e4-4be1-ae00-c47579e31348");
                _logger.LogDebug($"{userId}");
                var user = _dbcontext.Members.Find(userId);
                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user.Goals);
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, Ex.Message, Ex.StackTrace);
                return BadRequest();
            }
        }
    }
}