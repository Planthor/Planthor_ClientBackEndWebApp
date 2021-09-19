using System;
using System.Collections.Generic;
using System.Linq;
using PlanthorWebApiServer.Authorization.Interfaces;
using PlanthorWebApiServer.Context;
using PlanthorWebApiServer.Exceptions;
using PlanthorWebApiServer.Models;
using PlanthorWebApiServer.Models.RequestModels;
using PlanthorWebApiServer.Models.ResponseModels;
using PlanthorWebApiServer.Services.Interfaces;
using BCryptNet = BCrypt.Net.BCrypt;

namespace PlanthorWebApiServer.Services
{
    public class AccountService : IAccountService
    {
        private readonly PlanthorDbContext _dbcontext;
        private readonly IJwtUtils _jwtUtils;

        public AccountService(PlanthorDbContext dbcontext, IJwtUtils jwtUtils)
        {
            _dbcontext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
            _jwtUtils = jwtUtils ?? throw new ArgumentNullException(nameof(jwtUtils));
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model, string v)
        {
            var user = _dbcontext.Accounts.SingleOrDefault(x => x.AccountUsername == model.Username);

            // validate
            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
                throw new BusinessException("Username or password is incorrect");

            // authentication successful so generate jwt and refresh tokens
            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            var refreshToken = _jwtUtils.GenerateRefreshToken(ipAddress);
            user.RefreshTokens.Add(refreshToken);

            // remove old refresh tokens from user
            removeOldRefreshTokens(user);

            // save changes to db
            _dbcontext.Update(user);
            _dbcontext.SaveChanges();

            return new AuthenticateResponse(user, jwtToken, refreshToken.Token);
        }

        public Account GetById(Guid id)
        {
            var user = _dbcontext.Accounts.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}