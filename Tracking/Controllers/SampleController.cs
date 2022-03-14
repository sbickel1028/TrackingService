using Tracking.Applications.Interfaces;
using Tracking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly ILogger<SampleController> _logger;
        private readonly ISampleService _iSampleService;

        public SampleController(ISampleService iSampleService, ILogger<SampleController> logger)
        {
            _logger = logger;
            _iSampleService = iSampleService;
        }

        [HttpGet]
        public SampleResponse Get()
        {
            return _iSampleService.Get();
        }

        [Route("{Id}")]
        [HttpGet]
        public GetItemResponse GetItem(string Id)
        {
            return _iSampleService.GetItem(Id);
        }

        [HttpPost]
        public SampleResponse Item()
        {
            return _iSampleService.Get();
        }
    }
}
