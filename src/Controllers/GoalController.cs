using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlanthorWebApiServer.Context;
using PlanthorWebApiServer.Datamodel;

namespace PlanthorWebApiServer.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly ILogger<GoalController> _logger;
        private readonly PlanthorDbContext _dbcontext;

        public GoalController(ILogger<GoalController> logger, PlanthorDbContext dbContext)
        {
            _logger = logger;
            _logger.LogDebug("Nlog injected into GoalController");

            _dbcontext = dbContext;
            _logger.LogDebug("dbContext injected into GoalController");
        }

        // GET: api/Goals/5
        [HttpGet("{id}")]
        public ActionResult<Goal> GetGoal(Guid id)
        {

            try
            {
                var goal = _dbcontext.Goals.Find(id);
                if (goal == null)
                {
                    return NotFound();
                }

                return goal;
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, Ex.Message, Ex.StackTrace);
                return BadRequest();
            }

        }

        // <summary>
        // Create Goal 
        // </summary>
        // <param name="newGoalRequest"></param>
        // <returns></returns>
        [HttpPost()]
        public ActionResult<Goal> CreateGoal(Goal newGoalRequest)
        {
            // TODO - Fixing error that always Add new Account 
            
            Goal newGoal = new Goal()
            {
                GoalName = newGoalRequest.GoalName,
                GoalTarget = newGoalRequest.GoalTarget,
                GoalCurrent = newGoalRequest.GoalCurrent,
                GoalDeadline = newGoalRequest.GoalDeadline,
                GoalUnitMeasurement = newGoalRequest.GoalUnitMeasurement
            };

            _dbcontext.Goals.Add(newGoalRequest);
            _dbcontext.SaveChanges();

            return CreatedAtAction(nameof(GetGoal), new { id = newGoalRequest.GoalId }, newGoalRequest);
        }
        
        #region Test data JSON Create new Goals
/* 
{
  "createdDate": "2021-06-13T06:55:17.159Z",
  "lastUpdatedDate": "2021-06-13T06:55:17.159Z",
  "goalName": "string",
  "goalTarget": 0,
  "goalCurrent": 0,
  "goalDeadline": "2021-06-13T06:55:17.159Z",
  "goalUnitMeasurement": "string",  
  "accountId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
}
 */      
        #endregion

    


    }
}