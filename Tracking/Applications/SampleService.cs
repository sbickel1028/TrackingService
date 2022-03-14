using Tracking.Applications.Interfaces;
using Tracking.Models;
using Tracking.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elastic.Apm;

namespace Tracking.Applications
{
    public class SampleService : ISampleService
    {
        private readonly ISampleRepository _iSampleRepository;

        public SampleService(ISampleRepository iSampleRepository)
        {
            _iSampleRepository = iSampleRepository;
        }

        public SampleResponse Get()
        {
            SampleResponse response = new SampleResponse();

            try
            {
                response = _iSampleRepository.Get();
            }
            catch (Exception ex)
            {
                Agent.Tracer.CaptureException(ex, "Failed to get all sample items.", false, null, null);
            }

            return response;
        }

        public GetItemResponse GetItem(string Id)
        {
            GetItemResponse response = new GetItemResponse();
            
            try
            {
                int itemId = 0;

                if (Int32.TryParse(Id, out itemId))
                {
                    response.ItemId = itemId;
                }
                else
                {
                    response.Errors = new List<ResponseError>() { new ResponseError("-1", $"Invalid input. Id={Id}.", false) };
                }
            }
            catch (Exception ex)
            {
                response.Errors = new List<ResponseError>() { new ResponseError("-1", ex.InnerException != null ? ex.InnerException.Message : ex.Message, false) };
                
                Agent.Tracer.CaptureException(ex, $"Failed to get item. Id={Id}.", false, null, 
                    new Dictionary<string, Elastic.Apm.Api.Label> 
                    {
                        { "Id", new Elastic.Apm.Api.Label(Id) }
                    });
            }

            return response;
        }
    }
}
