﻿using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace TverTrustDemoModel.CustomAttribute.Validations
{
    /// <summary>
    /// 驗證密碼強度(6-12位英數字，至少包含一位數字和一位英文字，會區分英文大小寫)
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public class PasswordVerifyAttribute : ValidationAttribute
    {
        /// <summary>
        /// Gets or sets the timeout to use when matching the regular expression pattern (in milliseconds)
        /// (-1 means never timeout).
        /// </summary>
        public int MatchTimeoutInMilliseconds { get; set; }

        private Regex? Regex { get; set; }

        /// <summary>
        /// Gets the regular expression pattern to use
        /// </summary>
        private readonly string _pattern = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d$@$!%*?&]{6,12}$";

        public PasswordVerifyAttribute()
        {
            MatchTimeoutInMilliseconds = 2000;
        }

        public override bool IsValid(object? value)
        {
            SetupRegex();

            // Convert the value to a string
            string? stringValue = Convert.ToString(value, CultureInfo.CurrentCulture);

            // Automatically pass if value is null or empty. RequiredAttribute should be used to assert a value is not empty.
            if (string.IsNullOrEmpty(stringValue))
            {
                return true;
            }

            var m = Regex!.Match(stringValue);

            // We are looking for an exact match, not just a search hit. This matches what
            // the RegularExpressionValidator control does
            return (m.Success && m.Index == 0 && m.Length == stringValue.Length);
        }

        public override string FormatErrorMessage(string name)
        {
            SetupRegex();

            return string.Format(CultureInfo.CurrentCulture, "{0}必須6-12位英數字，至少包含一位數字和一位英文字，會區分英文大小寫", name, _pattern);
        }

        private void SetupRegex()
        {
            if (Regex == null)
            {
                if (string.IsNullOrEmpty(_pattern))
                {
                    throw new InvalidOperationException();
                }

                Regex = MatchTimeoutInMilliseconds == -1
                    ? new Regex(_pattern)
                    : new Regex(_pattern, default, TimeSpan.FromMilliseconds(MatchTimeoutInMilliseconds));
            }
        }
    }
}