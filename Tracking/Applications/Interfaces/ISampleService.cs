using Tracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Applications.Interfaces
{
    public interface ISampleService
    {
        SampleResponse Get();
        GetItemResponse GetItem(string Id);
    }
}
