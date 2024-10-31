using AutoMapper;

using TverTrustDemoModel.Dtos.Authentication;
using TverTrustDemoModel.Models;
using EverTrustDemoAPI.Helpers;

namespace EverTrustDemoAPI.Services;

/// <summary>
/// 驗證
/// </summary>
public interface IAuthenticationService
{
    /// <summary>
    /// 以AcSw登入
    /// </summary>
    /// <param name="loginRequestDto"></param>
    /// <returns></returns>
    Task<LoginResponseDto> LoginByAcSw(LoginRequestDto loginRequestDto);
}

public class AuthenticationService : IAuthenticationService
{
    private readonly EverTrustDbContext _db;
    private readonly IMapper _mapper;
    private readonly EncryptHelper _encryptHelper;
    private readonly JwtHelper _jwtHelper;
    public AuthenticationService(EverTrustDbContext db, IMapper mapper, EncryptHelper encryptHelper, JwtHelper jwtHelper)
    {
        _db = db;
        _mapper = mapper;
        _encryptHelper = encryptHelper;
        _jwtHelper = jwtHelper;
    }

    /// <summary>
    /// 以AcSw登入
    /// </summary>
    /// <returns></returns>
    public async Task<LoginResponseDto> LoginByAcSw(LoginRequestDto loginRequestDto)
    {
        LoginResponseDto result = new LoginResponseDto();
        loginRequestDto.Sw = _encryptHelper.HMACSHA256Password(loginRequestDto.Sw);
        //var user = _db.Users.FirstOrDefault(x => !x.IsDelete &&
        //                                          x.Is_Active &&
        //                                          x.Ac == loginRequestDto.Ac &&
        //                                          x.Sw == loginRequestDto.Sw);
        //if (user != null)
        if(true)
        {
            result.Name = loginRequestDto.Ac;
            result.Token = _jwtHelper.GenerateToken(loginRequestDto.Ac);
            //result.Token = _jwtHelper.GenerateToken(user.Ac);
            //_mapper.Map(user, result);
        }
        return result;
    }
}
