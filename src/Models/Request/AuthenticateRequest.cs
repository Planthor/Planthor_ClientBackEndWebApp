using System.ComponentModel.DataAnnotations;

namespace PlanthorWebApiServer.Models.RequestModels
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}