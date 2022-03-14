using Tracking.Models;
using Tracking.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Repositories
{
    public class SampleRepository : ISampleRepository
    {
        private readonly IOptions<ConnectionString> _connectionString;

        public SampleRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }

        public SampleResponse Get()
        {
            return new SampleResponse()
            {
                Items = new List<int>() { 1, 2, 3, 4, 5 },
                IsSuccess = true
            };
        }
    }
}
