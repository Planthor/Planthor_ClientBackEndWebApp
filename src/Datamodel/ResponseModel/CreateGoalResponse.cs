using System;

namespace PlanthorWebApiServer.Datamodel.ResponseModel
{
    public class CreateGoalResponse
    {
        public Guid GoalId { get; set; }
        public string GoalName { get; set; }
        public float GoalTarget { get; set; }
        public float GoalCurrent { get; set; }
        public DateTime GoalDeadline { get; set; }
        public string GoalUnitMeasurement { get; set; }
    }
}