using System;
using System.Collections.Generic;

namespace PlanthorWebApiServer.Datamodel
{
    public class Tribe : BaseEntity
    {
        public Guid TribeId { get; set; }
        public string TribeName { get; set; }
        public string TribeDescription { get; set; }
        public int TribeNoOfMemebers { get; set; }
        public Uri TribeAvatar { get; set;}

        public ICollection<Member> Members { get; set; }
    }
}