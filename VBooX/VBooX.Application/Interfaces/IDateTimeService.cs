using System;
using System.Collections.Generic;
using System.Text;

namespace VBooX.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
