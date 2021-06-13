using System;

namespace PlanthorWebApiServer.Datamodel
{
    public class BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}