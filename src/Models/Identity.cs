using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PlanthorWebApiServer.Models.Authorization;

namespace PlanthorWebApiServer.Models
{
    public class Identity
    {
        public Guid IdentityId { get; set; }
        public string IdentityProvider { get; set; }
        public string IdentityHashPassword { get; set; }
        public Guid IdentityFacebookToken { get; set; }

        public Guid AccountId { get; set; }
        public Account Account
        {
            get; set;
        }

        [JsonIgnore]
        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}