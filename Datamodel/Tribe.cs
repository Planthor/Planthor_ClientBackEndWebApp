using System;

namespace Planthor_ClientBackEndWebApp.Datamodel
{
    public class Tribe : BaseEntity
    {
        public Guid TribeId { get; set; }
        public string TribeName { get; set; }
        public string TribeDescription { get; set; }
        public int TribeNoOfMemebers { get; set; }
        public Uri TribeAvatar { get; set;}

        public Member Member { get; set; }
    }
}