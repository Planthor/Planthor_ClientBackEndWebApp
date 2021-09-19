using System;
using System.Collections.Generic;

namespace PlanthorWebApiServer.Models
{
    public class Member : BaseEntity
    {
        public Guid MemberId { get; set; }
        public string MemberNickname { get; set; }
        public int MemberNoOfObjectives { get; set; }

        public Tribe Tribe { get; set; }
        public ICollection<Goal> Goals { get; set; }

        public Guid AccountId { get; set; }
        public Account Account { get; set; }
    }
}