using System.ComponentModel.DataAnnotations;

namespace TverTrustDemoModel.CustomAttribute.Validations
{
    /// <summary>
    /// 值域檢查
    /// </summary>
    public class RangeCheck : RangeAttribute
    {
        private int _MinValue, _MaxValue;
        public RangeCheck(int min, int max) : base(min, max)
        {
            _MinValue = min;
            _MaxValue = max;
        }

        public override string FormatErrorMessage(string name)
        {
            return !String.IsNullOrEmpty(ErrorMessage)
                ? ErrorMessage
                : $"請確認{name}是否介於{_MinValue}-{_MaxValue}";
        }
    }
}
