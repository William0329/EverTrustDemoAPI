using Swashbuckle.AspNetCore.Filters;

using TverTrustDemoModel.Dtos.Business;

namespace EverTrustDemoAPI.Example.Request.User
{
    public class AddEmployeeRequestExample : IExamplesProvider<AddEmployeeDto>
    {
        public AddEmployeeDto GetExamples()
        {
            return new AddEmployeeDto
            {
                LastName = "測試人123456789",
                FirstName = "測試",
                Title = "測試Title",
                BirthDate = "2000-01-01",
                HireDate = "2018-01-01"
            };
        }
    }
}
