using System;
using System.Collections.Generic;

namespace PlanthorWebApiServer.Datamodel
{
    /// <summary>
    /// Model corresponding to Account
    /// </summary>
    public class Account : BaseEntity
    {
        public Guid AccountId { get; set; }
        public string AccountEmail { get; set; }
        public string AccountFullname { get; set; }
        public char AccountGender { get; set; }
        public Uri AccountAvatar { get; set; }

#nullable enable
        public ICollection<Member>? Member { get; set; }

        public ICollection<Goal>? Goals { get; set; }
#nullable disable

        public ICollection<Identity> Identity { get; set; }
    }
}