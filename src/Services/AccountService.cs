using System;
using PlanthorWebApiServer.Models;
using PlanthorWebApiServer.Models.RequestModels;
using PlanthorWebApiServer.Models.ResponseModels;
using PlanthorWebApiServer.Services.Interfaces;

namespace PlanthorWebApiServer.Services
{
    public class AccountService : IAccountService
    {
        public AuthenticateResponse Authenticate(AuthenticateRequest model, string v)
        {
            throw new NotImplementedException();
        }

        public Account GetById(Guid value)
        {
            throw new NotImplementedException();
        }
    }
}