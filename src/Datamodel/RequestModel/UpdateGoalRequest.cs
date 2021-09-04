using System;

namespace src.Datamodel.RequestModel
{
    public class UpdateGoalRequest
    {
        public Guid GoalId { get; set; }
        public string GoalName { get; set; }
        public float GoalTarget { get; set; }
        public float GoalCurrent { get; set; }
        public DateTime GoalDeadline { get; set; }
        public string GoalUnitMeasurement { get; set; }
        public int GoalPriority { get; set;}
    }
}