using System;
using System.Collections.Generic;
using System.Text;

namespace VBooX.Application.Interfaces
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
    }
}
