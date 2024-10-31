using TverTrustDemoModel.Models.Enums;
using TverTrustDemoModel.Models.Shared;
using Swashbuckle.AspNetCore.Filters;

namespace EverTrustDemoAPI.Example.Response
{
    public class ValidFailResponseExample : IExamplesProvider<ResponseModel<object>>
    {
        public ResponseModel<object> GetExamples()
        {
            return new ResponseModel<object>()
            {
                Status = ResponseStatusEnum.fail.ToString(),
                Message = "fail msg",
                ResponseData = null
            };
        }
    }
}
