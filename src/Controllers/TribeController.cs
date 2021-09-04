using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlanthorWebApiServer.Context;
using PlanthorWebApiServer.Datamodel;

namespace PlanthorWebApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TribeController : ControllerBase
    {
        private readonly ILogger<TribeController> _logger;
        private readonly PlanthorDbContext _dbcontext;

        public TribeController(ILogger<TribeController> logger, PlanthorDbContext dbContext)
        {
            _logger = logger;
            _logger.LogDebug("Nlog injected into GoalController");

            _dbcontext = dbContext;
            _logger.LogDebug("dbContext injected into GoalController");
        }

        [HttpPost()]
        public ActionResult<Goal> CreateTribe(Tribe newTribeRequest)
        {

            try
            {
                _logger.LogWarning($"{newTribeRequest.TribeId}");
                _dbcontext.Tribes.Add(newTribeRequest);
                _dbcontext.SaveChanges();

                
                return CreatedAtAction(nameof(GetTribe), new { id = newTribeRequest.TribeId }, newTribeRequest);
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, Ex.Message, Ex.StackTrace);
                return BadRequest();
            }
        }
        

        [HttpGet("{id}")]
        public ActionResult<Tribe> GetTribe(Guid id)
        {

            try
            {
                _logger.LogWarning($"GetTribe {id}");
                var tribe = _dbcontext.Tribes.Find(id);
                if (tribe == null)
                {
                    return NotFound();
                }

                return tribe;
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, Ex.Message, Ex.StackTrace);
                return BadRequest();
            }

        }

        [HttpGet("{id}/Members")]
        public ActionResult<IList<Member>> GetTribeMembers(Guid id)
        {
            try
            {
                var tribe = _dbcontext.Tribes.Find(id);
                if (tribe == null)
                {
                    return NotFound();
                }

                return tribe.Members.ToList();
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, Ex.Message, Ex.StackTrace);
                return BadRequest();
            }
        }

        #region Test data JSON Create new Tribe
        /* 
        {
        "createdDate": "2021-09-03T03:29:00.876Z",
        "lastUpdatedDate": "2021-09-03T03:29:00.876Z",
        "tribeId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "tribeName": "string",
        "tribeDescription": "string",
        "tribeNoOfMemebers": 0,
        "tribeAvatar": "string"
        }
        */      
        #endregion
    }
}