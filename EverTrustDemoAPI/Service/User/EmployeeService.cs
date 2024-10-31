using AutoMapper;

using EverTrustDemoAPI.Helpers;

using TverTrustDemoModel.Dtos.Business;
using TverTrustDemoModel.Dtos.Shared;
using TverTrustDemoModel.Models;

namespace EverTrustDemoAPI.Services;

/// <summary>
/// 商店
/// </summary>
public interface IEmployeeService
{
    /// <summary>
    /// 取得商店清單
    /// </summary>
    /// <returns></returns>
    Task<(List<EmployeeDto> EmployeeDto, int total)> GetEmployees(ListRequestDto requestDto);

    /// <summary>
    /// 取得指定的商店
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    Task<EmployeeDto> GetEmployee(string Id);
    /// <summary>
    /// 新增商店
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    Task<string?> AddEmployee(AddEmployeeDto data);

    /// <summary>
    /// 更新商店
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>/// 
    Task<string?> UpdateEmployee(UpdateEmployeeDto data);

    /// <summary>
    /// 刪除商店
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    Task<string?> DeleteEmployee(string Id);
}

public class EmployeeService : IEmployeeService
{
    private readonly EverTrustDbContext _db;
    private readonly IMapper _mapper;
    public EmployeeService(EverTrustDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    /// <summary>
    /// 取得商店清單
    /// </summary>
    /// <returns></returns>
    public async Task<(List<EmployeeDto> EmployeeDto, int total)> GetEmployees(ListRequestDto requestDto)
    {
        var Employees = _db.Employees.AsQueryable();
        if (!string.IsNullOrEmpty(requestDto.KeyWord))
        {
            Employees = Employees.Where(x => x.FirstName.Contains(requestDto.KeyWord)||
                                             x.LastName.Contains(requestDto.KeyWord));
        }
        var total = Employees.Count();
        var allEmployees = Employees.OrderByDescending(x => x.EmployeeId)
                              .Skip((requestDto.Page - 1) * requestDto.PageSize)
                              .Take(requestDto.PageSize)
                              .ToList();
        var result = _mapper.Map<List<EmployeeDto>>(allEmployees);
        return (result, total);
    }

    /// <summary>
    /// 取得指定的商店
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public async Task<EmployeeDto> GetEmployee(string Id)
    {
        EmployeeDto result = null;
        var Employees = _db.Employees.FirstOrDefault(x =>  x.EmployeeId.ToString() == Id);
        if (Employees != null)
        {
            result = _mapper.Map<EmployeeDto>(Employees);
        }
        return result;
    }
    /// <summary>
    /// 新增商店
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public async Task<string?> AddEmployee(AddEmployeeDto data)
    {
        _db.Database.BeginTransaction();
        try
        {
            var Employees = _mapper.Map<Employee>(data);
            _db.Employees.Add(Employees);
            _db.SaveChanges();
            _db.Database.CommitTransaction();
            return Employees.EmployeeId.ToString();
        }
        catch (Exception ex)
        {
            _db.Database.RollbackTransaction();
            return $"Error : {ex.Message} StackTrace:{ex.StackTrace}"; ;
        }
    }

    /// <summary>
    /// 更新商店
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public async Task<string?> UpdateEmployee(UpdateEmployeeDto data)
    {
        var result = string.Empty;
        _db.Database.BeginTransaction();
        try
        {
            var Employees = _db.Employees.FirstOrDefault(x => x.EmployeeId == data.EmployeeId);
            if (Employees != null)
            {
                _mapper.Map(data, Employees);
            }
            var flag = _db.SaveChanges() > 0;
            _db.Database.CommitTransaction();
            if (!flag)
            {
                result = $"Employees Id : {data.EmployeeId} 更新異常";
            }
        }
        catch (Exception ex)
        {
            result = $"Error : {ex.Message} StackTrace:{ex.StackTrace}";
            _db.Database.RollbackTransaction();
        }
        return result;
    }

    /// <summary>
    /// 刪除商店
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public async Task<string?> DeleteEmployee(string Id)
    {
        var result = string.Empty;
        _db.Database.BeginTransaction();
        try
        {
            var Employees = _db.Employees.FirstOrDefault(x => x.EmployeeId.ToString() == Id);
            if (Employees != null)
            {
                _db.Remove(Employees);
            }
            var flag = _db.SaveChanges() > 0;
            _db.Database.CommitTransaction();
            if (!flag)
            {
                result = $"Employees Id : {Id} 刪除異常";
            }
        }
        catch (Exception ex)
        {
            result = $"Error : {ex.Message} StackTrace:{ex.StackTrace}"; ;
            _db.Database.RollbackTransaction();
        }
        return result;
    }
}
