using System;
using System.Text.Json.Serialization;

namespace PlanthorWebApiServer.Models.ResponseModels
{
    public class AuthenticateResponse
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string JwtToken { get; set; }

        [JsonIgnore] // refresh token is returned in http only cookie
        public string RefreshToken { get; set; }

        public AuthenticateResponse(Account user, string jwtToken, string refreshToken)
        {
            Id = user.AccountId;
            Fullname = user.AccountFullname;
            JwtToken = jwtToken;
            RefreshToken = refreshToken;
        }
    }
}