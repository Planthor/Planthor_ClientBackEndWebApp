using System;
using PlanthorWebApiServer.Models;
using PlanthorWebApiServer.Models.RequestModels;
using PlanthorWebApiServer.Models.ResponseModels;

namespace PlanthorWebApiServer.Services.Interfaces
{
    public interface IAccountService
    {
        Account GetById(Guid value);
        AuthenticateResponse Authenticate(AuthenticateRequest model, string v);
    }
}