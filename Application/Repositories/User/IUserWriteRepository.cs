﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.User
{
    public interface IUserWriteRepository : IAuthWriteRepository<Domain.Identity.User>
    {
    }
}
