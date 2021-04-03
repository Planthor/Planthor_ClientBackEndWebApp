using System;

namespace Planthor_ClientBackEndWebApp.Datamodel
{
    public class Identity
    {
        public Guid IndentiyId { get; set; }
        public string IdentityProvider { get; set; }
        public string IndentityUsername { get; set; }
        public string IdentityHashPassword { get; set; }
        public Guid IdentityFacebookToken { get; set; }

        public Guid AccountId { get; set; }
        public Account Account { get; set; 
        
        
        }
    }
}