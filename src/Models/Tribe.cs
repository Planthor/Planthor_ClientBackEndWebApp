using System;
using System.Collections.Generic;

namespace PlanthorWebApiServer.Models
{
    public class Tribe : BaseEntity
    {
        //TribeId: primary key
        public Guid TribeId { get; set; }
        //TribeName
        public string TribeName { get; set; }
        public string TribeDescription { get; set; }
        public int TribeNoOfMemebers { get; set; }
        public Uri TribeAvatar { get; set; }

        public ICollection<Member> Members { get; set; }
    }
}