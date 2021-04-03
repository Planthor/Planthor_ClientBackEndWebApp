using System;
using System.Collections.Generic;

namespace Planthor_ClientBackEndWebApp.Datamodel
{
    public class Goal : BaseEntity
    {
        public Guid GoalId { get; set; }
        public string GoalName { get; set; }
        public float GoalTarget { get; set; }
        public float GoalCurrent { get; set; }
        public DateTime GoalDeadline { get; set; }
        public string GoalUnitMeasurement { get; set; }

        public IList<MemberGoals> MemberGoals { get; set; }

        public Guid AccountId { get; set; }
        public Account Account { get; set; }
    }
}