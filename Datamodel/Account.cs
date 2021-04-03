using System;

namespace Planthor_ClientBackEndWebApp.Datamodel
{
    public class Account : BaseEntity
    {
        public Guid AcocuntId { get; set; }
        public string AccountEmail { get; set; }
        public string AccountFullname { get; set; }
        public char AccountGender { get; set; }
        public Uri AccountAvatar { get; set; }

        public Member Memeber { get; set; }

        public Goal Goal { get; set; }

        public Identity Identity { get; set; }
    }
}