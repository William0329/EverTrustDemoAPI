using TverTrustDemoModel.CustomAttribute.Validations;
using System.ComponentModel.DataAnnotations;

namespace TverTrustDemoModel.Dtos.Business
{
    /// <summary>
    /// 員工 資料
    /// </summary>
    public class EmployeeDto
    {
        public EmployeeDto()
        {
            InverseReportsToNavigation = new List<EmployeeDto>();
        }
        /// <summary>
        /// 索引
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// 姓
        /// </summary>
        public string LastName { get; set; } = null!;
        /// <summary>
        /// 名
        /// </summary>
        public string FirstName { get; set; } = null!;
        /// <summary>
        /// 稱謂
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// 敬稱
        /// </summary>
        public string? TitleOfCourtesy { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public string? BirthDate { get; set; }
        /// <summary>
        /// 雇用日期
        /// </summary>
        public string? HireDate { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        public string? Address { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string? City { get; set; }
        /// <summary>
        /// 區
        /// </summary>
        public string? Region { get; set; }
        /// <summary>
        /// 郵遞區號
        /// </summary>
        public string? PostalCode { get; set; }
        /// <summary>
        /// 國家
        /// </summary>
        public string? Country { get; set; }
        /// <summary>
        /// 住家電話
        /// </summary>
        public string? HomePhone { get; set; }
        /// <summary>
        /// 擴充
        /// </summary>
        public string? Extension { get; set; }
        /// <summary>
        /// 相片
        /// </summary>
        public string? Photo { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string? Notes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? ReportsTo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PhotoPath { get; set; }
        public List<EmployeeDto> InverseReportsToNavigation { get; set; }
    }
    /// <summary>
    /// 新增 員工 資料
    /// </summary>
    public class AddEmployeeDto
    {
        /// <summary>
        /// 員工姓
        /// </summary>
        [RequiredCheck]
        [MaxLength(20)]
        public string LastName { get; set; } = null!;
        /// <summary>
        /// 員工名
        /// </summary>
        [RequiredCheck]
        [MaxLength(10)]
        public string FirstName { get; set; } = null!;
        /// <summary>
        /// 稱謂
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// 敬稱
        /// </summary>
        public string? TitleOfCourtesy { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public string? BirthDate { get; set; }
        /// <summary>
        /// 雇用日期
        /// </summary>
        public string? HireDate { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        public string? Address { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string? City { get; set; }
        /// <summary>
        /// 區
        /// </summary>
        public string? Region { get; set; }
        /// <summary>
        /// 郵遞區號
        /// </summary>
        public string? PostalCode { get; set; }
        /// <summary>
        /// 國家
        /// </summary>
        public string? Country { get; set; }
        /// <summary>
        /// 住家電話
        /// </summary>
        public string? HomePhone { get; set; }
        /// <summary>
        /// 擴充
        /// </summary>
        public string? Extension { get; set; }
        /// <summary>
        /// 相片
        /// </summary>
        public string? Photo { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string? Notes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? ReportsTo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PhotoPath { get; set; }
    }

    /// <summary>
    /// 更新 員工 資料
    /// </summary>
    public class UpdateEmployeeDto
    {
        /// <summary>
        /// 索引
        /// </summary>
        [RequiredCheck]
        public int EmployeeId { get; set; }
        /// <summary>
        /// 姓
        /// </summary>
        [RequiredCheck]
        [MaxLength(20)]
        public string LastName { get; set; } = null!;
        /// <summary>
        /// 名
        /// </summary>
        [RequiredCheck]
        [MaxLength(10)]
        public string FirstName { get; set; } = null!;
        /// <summary>
        /// 稱謂
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// 敬稱
        /// </summary>
        public string? TitleOfCourtesy { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public string? BirthDate { get; set; }
        /// <summary>
        /// 雇用日期
        /// </summary>
        public string? HireDate { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        public string? Address { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string? City { get; set; }
        /// <summary>
        /// 區
        /// </summary>
        public string? Region { get; set; }
        /// <summary>
        /// 郵遞區號
        /// </summary>
        public string? PostalCode { get; set; }
        /// <summary>
        /// 國家
        /// </summary>
        public string? Country { get; set; }
        /// <summary>
        /// 住家電話
        /// </summary>
        public string? HomePhone { get; set; }
        /// <summary>
        /// 擴充
        /// </summary>
        public string? Extension { get; set; }
        /// <summary>
        /// 相片
        /// </summary>
        public string? Photo { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string? Notes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? ReportsTo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PhotoPath { get; set; }
    }
}
