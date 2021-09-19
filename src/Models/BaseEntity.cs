using System;

namespace PlanthorWebApiServer.Models
{
    public class BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}