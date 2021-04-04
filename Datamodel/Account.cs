using System;
using System.Collections.Generic;

namespace Planthor_ClientBackEndWebApp.Datamodel
{
    public class Account : BaseEntity
    {
        public Guid AcocuntId { get; set; }
        public string AccountEmail { get; set; }
        public string AccountFullname { get; set; }
        public char AccountGender { get; set; }
        public Uri AccountAvatar { get; set; }

        #nullable enable
        public Member? Member { get; set; }

        public ICollection<Goal>? Goals { get; set; }
        #nullable disable

        public ICollection<Identity> Identity { get; set; }
    }
}