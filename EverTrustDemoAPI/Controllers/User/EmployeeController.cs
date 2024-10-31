using EverTrustDemoAPI.Example.Request.User;
using EverTrustDemoAPI.Example.Response;
using EverTrustDemoAPI.Services;

using TverTrustDemoModel.CustomAttribute.Validations;
using TverTrustDemoModel.Dtos.Business;
using TverTrustDemoModel.Dtos.Shared;
using TverTrustDemoModel.Models.Enums;
using TverTrustDemoModel.Models.Shared;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace EverTrustDemoAPI.Controllers.Business
{
    [ApiController]
    [Route("api/User")]
    [Authorize(Policy = "Demo")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _EmployeeService;

        public EmployeeController(ILogger<EmployeeController> logger,
                              IConfiguration configuration,
                              IEmployeeService EmployeeService)
        {
            _logger = logger;
            _EmployeeService = EmployeeService;
        }
        /// <summary>
        /// 查詢員工列表
        /// </summary>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        [SwaggerResponse(StatusCodes.Status200OK, "查詢成功", typeof(ResponseWithPageModel<List<EmployeeDto>>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "格式錯誤", typeof(ValidFailResponseExample))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "系統錯誤", typeof(ExErrorResponseExample))]
        [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(ValidFailResponseExample))]
        [SwaggerResponseExample(StatusCodes.Status500InternalServerError, typeof(ExErrorResponseExample))]
        [SwaggerOperation(Tags = new[] { "User" })]
        [HttpGet("Employee")]
        public async Task<IActionResult> GetEmployeeList([FromQuery] ListRequestDto requestDto)
        {
            var (_result, _total) = await _EmployeeService.GetEmployees(requestDto);
            ResponseWithPageModel<List<EmployeeDto>> _response =
            new()
            {
                Status = ResponseStatusEnum.success.ToString("G"),
                Message = string.Empty,
                ResponseData = new ResponseWithPageDataModel<List<EmployeeDto>> { Total = _total, Rows = _result }
            };

            return Ok(_response);
        }
        /// <summary>
        /// 查詢員工
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [SwaggerResponse(StatusCodes.Status200OK, "查詢成功", typeof(ResponseModel<EmployeeDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "格式錯誤", typeof(ValidFailResponseExample))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "系統錯誤", typeof(ExErrorResponseExample))]
        [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(ValidFailResponseExample))]
        [SwaggerResponseExample(StatusCodes.Status500InternalServerError, typeof(ExErrorResponseExample))]
        [SwaggerOperation(Tags = new[] { "User" })]
        [HttpGet("Employee/{Id}")]
        public async Task<IActionResult> GetEmployee([RequiredCheck] string Id)
        {
            var result = await _EmployeeService.GetEmployee(Id);
            return Ok(new ResponseModel<EmployeeDto>
            {
                Status = ResponseStatusEnum.success.ToString("G"),
                Message = string.Empty,
                ResponseData = result
            });
        }
        /// <summary>
        /// 新增 員工
        /// </summary>
        /// <param name="EmployeeDto"></param>
        /// <returns></returns>
        [SwaggerResponse(StatusCodes.Status200OK, "新增成功", typeof(ResponseModel<string>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "格式錯誤", typeof(ValidFailResponseExample))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "系統錯誤", typeof(ExErrorResponseExample))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(AddSuccessResponseExample))]
        [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(ValidFailResponseExample))]
        [SwaggerResponseExample(StatusCodes.Status500InternalServerError, typeof(ExErrorResponseExample))]
        [SwaggerRequestExample(typeof(AddEmployeeDto), typeof(AddEmployeeRequestExample))]
        [SwaggerOperation(Tags = new[] { "User" })]
        [HttpPost("Employee")]
        public async Task<IActionResult> AddEmployee(AddEmployeeDto EmployeeDto)
        {
            var result = await _EmployeeService.AddEmployee(EmployeeDto);
            if (Guid.TryParse(result, out Guid tempGuid))
            {
                return Ok(new ResponseModel<string>
                {
                    Status = ResponseStatusEnum.success.ToString("G"),
                    Message = string.Empty,
                    ResponseData = result ?? ""
                });
            }
            else
            {
                return BadRequest(new ResponseModel<bool>
                {
                    Status = ResponseStatusEnum.fail.ToString("G"),
                    Message = result ?? "",
                    ResponseData = false
                });
            }
        }
        /// <summary>
        /// 更新 員工
        /// </summary>
        /// <param name="EmployeeDto"></param>
        /// <returns></returns>
        [SwaggerResponse(StatusCodes.Status200OK, "更新成功", typeof(ResponseModel<bool>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "格式錯誤", typeof(ValidFailResponseExample))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "系統錯誤", typeof(ExErrorResponseExample))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(UpdateSuccessResponseExample))]
        [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(ValidFailResponseExample))]
        [SwaggerResponseExample(StatusCodes.Status500InternalServerError, typeof(ExErrorResponseExample))]
        [SwaggerRequestExample(typeof(UpdateEmployeeDto), typeof(UpdateEmployeeRequestExample))]
        [SwaggerOperation(Tags = new[] { "User" })]
        [HttpPut("Employee")]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto EmployeeDto)
        {
            var result = await _EmployeeService.UpdateEmployee(EmployeeDto);
            if (string.IsNullOrEmpty(result))
            {
                return Ok(new ResponseModel<bool>
                {
                    Status = ResponseStatusEnum.success.ToString("G"),
                    Message = string.Empty,
                    ResponseData = true
                });
            }
            else
            {
                return BadRequest(new ResponseModel<bool>
                {
                    Status = ResponseStatusEnum.fail.ToString("G"),
                    Message = result ?? "",
                    ResponseData = false
                });
            }
        }
        /// <summary>
        /// 刪除 員工
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [SwaggerResponse(StatusCodes.Status200OK, "刪除成功", typeof(ResponseModel<bool>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "格式錯誤", typeof(ValidFailResponseExample))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "系統錯誤", typeof(ExErrorResponseExample))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(UpdateSuccessResponseExample))]
        [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(ValidFailResponseExample))]
        [SwaggerResponseExample(StatusCodes.Status500InternalServerError, typeof(ExErrorResponseExample))]
        [SwaggerOperation(Tags = new[] { "User" })]
        [HttpDelete("Employee/{Id}")]
        public async Task<IActionResult> DeleteEmployee([RequiredCheck] string Id)
        {
            var result = await _EmployeeService.DeleteEmployee(Id);
            if (string.IsNullOrEmpty(result))
            {
                return Ok(new ResponseModel<bool>
                {
                    Status = ResponseStatusEnum.success.ToString("G"),
                    Message = string.Empty,
                    ResponseData = true
                });
            }
            else
            {
                return BadRequest(new ResponseModel<bool>
                {
                    Status = ResponseStatusEnum.fail.ToString("G"),
                    Message = result ?? "",
                    ResponseData = false
                });
            }
        }
    }
}
