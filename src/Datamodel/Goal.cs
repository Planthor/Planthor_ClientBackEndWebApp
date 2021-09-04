using System;
using System.Collections.Generic;

namespace PlanthorWebApiServer.Datamodel
{
    public class Goal : BaseEntity
    {
        public Guid GoalId { get; set; }
        public string GoalName { get; set; }
        public float GoalTarget { get; set; }
        public float GoalCurrent { get; set; }
        public DateTime GoalDeadline { get; set; }
        public string GoalUnitMeasurement { get; set; }
        public int GoalPriority {get; set; }
        public ICollection<Member> Members { get; set; }

        public Guid AccountId { get; set; }
        public Account Account { get; set; }
    }
}