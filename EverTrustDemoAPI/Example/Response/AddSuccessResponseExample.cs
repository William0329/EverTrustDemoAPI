using TverTrustDemoModel.Models.Enums;
using TverTrustDemoModel.Models.Shared;
using Swashbuckle.AspNetCore.Filters;

namespace EverTrustDemoAPI.Example.Response
{
    public class AddSuccessResponseExample : IExamplesProvider<ResponseModel<string>>
    {
        public ResponseModel<string> GetExamples()
        {
            return new ResponseModel<string>
            {
                Status = ResponseStatusEnum.success.ToString("G"),
                Message = string.Empty,
                ResponseData = Guid.NewGuid().ToString()
            };
        }
    }
}
