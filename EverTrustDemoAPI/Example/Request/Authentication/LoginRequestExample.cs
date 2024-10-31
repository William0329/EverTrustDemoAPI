﻿using TverTrustDemoModel.Dtos.Authentication;
using Swashbuckle.AspNetCore.Filters;

namespace EverTrustDemoAPI.Example.Request.Authentication
{
    public class LoginRequestExample : IExamplesProvider<LoginRequestDto>
    {
        public LoginRequestDto GetExamples()
        {
            return new LoginRequestDto
            {
                Ac = "administrator@ch-si.com.tw",
                Sw = "1qaz@WSX"
            };
        }
    }
}