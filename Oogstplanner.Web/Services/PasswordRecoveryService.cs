﻿using System;
using Oogstplanner.Repositories;
using System.Web.Security;

namespace Oogstplanner.Services
{
    public class PasswordRecoveryService
    {
        readonly PasswordRecoveryRepository repository;

        public PasswordRecoveryService(PasswordRecoveryRepository repository)
        {
            this.repository = repository;
        }

        public void StoreResetToken(string email, string token)
        {
            var timeResetRequested = DateTime.Now;
            repository.StoreResetToken(email, timeResetRequested, token);
        }

        public MembershipUser GetMembershipUserFromToken(string token)
        {
            return repository.GetMembershipUserFromToken(token);
        }

        public MembershipUser GetMembershipUserByEmail(string email)
        {
            return repository.GetMembershipUserByEmail(email);
        }

        public DateTime? GetTokenTimeStamp(string token)
        {
            return repository.GetTokenTimeStamp(token);
        }

        public string GenerateToken()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }
    }
}
    