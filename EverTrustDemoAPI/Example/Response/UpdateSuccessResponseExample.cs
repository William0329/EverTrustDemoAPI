using TverTrustDemoModel.Models.Enums;
using TverTrustDemoModel.Models.Shared;
using Swashbuckle.AspNetCore.Filters;

namespace EverTrustDemoAPI.Example.Response
{
    public class UpdateSuccessResponseExample : IExamplesProvider<ResponseModel<bool>>
    {
        public ResponseModel<bool> GetExamples()
        {
            return new ResponseModel<bool>
            {
                Status = ResponseStatusEnum.success.ToString("G"),
                Message = string.Empty,
                ResponseData = true
            };
        }
    }
}
