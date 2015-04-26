﻿using Zk.Services;
using Zk.Repositories;

using Autofac.Features.Indexed;

namespace Zk.Tests
{
    public class FakeUserServices : IIndex<AuthenticatedStatus, IUserService>
    {
        readonly Repository repository;

        public FakeUserServices(Repository repository)
        {
            this.repository = repository;
        }

        public bool TryGetValue(AuthenticatedStatus key, out IUserService value)
        {
            if (key == AuthenticatedStatus.Authenticated)
            {
                value = new UserService(repository);
            }
            else
            {
                value = new AnonymousUserService(repository);
            }
            return true;
        }

        public IUserService this[AuthenticatedStatus index]
        {
            get
            {
                return index == AuthenticatedStatus.Authenticated 
                    ? new UserService(repository) as IUserService
                    : new AnonymousUserService(repository);
            }
        }

    }
}

