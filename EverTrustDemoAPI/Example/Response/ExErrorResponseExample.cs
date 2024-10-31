using TverTrustDemoModel.Models.Enums;
using TverTrustDemoModel.Models.Shared;
using Swashbuckle.AspNetCore.Filters;

namespace EverTrustDemoAPI.Example.Response
{
    public class ExErrorResponseExample : IExamplesProvider<ResponseModel<object>>
    {
        public ResponseModel<object> GetExamples()
        {
            return new ResponseModel<object>()
            {
                Status = ResponseStatusEnum.error.ToString(),
                Message = "error msg",
                ResponseData = null
            };
        }
    }
}
