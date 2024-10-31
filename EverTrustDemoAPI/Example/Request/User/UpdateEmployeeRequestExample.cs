using Swashbuckle.AspNetCore.Filters;

using TverTrustDemoModel.Dtos.Business;

namespace EverTrustDemoAPI.Example.Request.User
{
    public class UpdateEmployeeRequestExample : IExamplesProvider<UpdateEmployeeDto>
    {
        public UpdateEmployeeDto GetExamples()
        {
            return new UpdateEmployeeDto
            {
                EmployeeId = 1,
                LastName = "測試人123456789",
                FirstName = "測試",
                Title = "測試Title",
                Address ="高雄市",
                City ="高雄",
                BirthDate = "2000-01-01",
                HireDate = "2020-01-01",
                Photo = null
            };
        }
    }
}
