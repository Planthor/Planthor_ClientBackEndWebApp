using System;

namespace Planthor_ClientBackEndWebApp.Datamodel
{
    public class MemberGoals
    {
        public Guid MemberGoalsId { get; set; }
        public Guid MemberId { get; set; }
        public Member Member { get; set; }

        public Guid GoalId { get; set; }
        public Goal Goal { get; set;}
    }
}