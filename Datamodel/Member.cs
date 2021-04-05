using System;
using System.Collections.Generic;

namespace Planthor_ClientBackEndWebApp.Datamodel
{
    public class Member : BaseEntity
    {
        public Guid MemberId { get; set; }
        public string MemberNickname { get; set;}
        public int MemberNoOfObjectives { get; set; }

        public Tribe Tribe { get; set; }
        public IList<MemberGoals> MemberObjectives { get; set; }
        
        public Guid AccountId { get; set;}
        public Account Account { get; set; }
    }
}