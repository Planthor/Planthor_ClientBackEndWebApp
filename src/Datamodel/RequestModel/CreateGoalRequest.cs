using System;

namespace PlanthorWebApiServer.Datamodel.RequestModel
{
    public class CreateGoalRequest
    {
        public string GoalName { get; set; }
        public float GoalTarget { get; set; }
        public float GoalCurrent { get; set; }
        public DateTime GoalDeadline { get; set; }
        public string GoalUnitMeasurement { get; set; }
        public int GoalPriority { get; set;}
    }
}