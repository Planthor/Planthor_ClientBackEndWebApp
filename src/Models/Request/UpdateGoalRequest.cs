using System;

namespace PlanthorWebApiServer.Models.RequestModels
{
    public class UpdateGoalRequest
    {
        public Guid GoalId { get; set; }
        public string GoalName { get; set; }
        public float GoalTarget { get; set; }
        public float GoalCurrent { get; set; }
        public DateTime GoalDeadline { get; set; }
        public string GoalUnitMeasurement { get; set; }
        public int GoalPriority { get; set; }
    }
}