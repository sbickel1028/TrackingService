using Tracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Repositories.Interfaces
{
    public interface ISampleRepository
    {
        SampleResponse Get();
    }
}
