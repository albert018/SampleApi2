using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SampleApi2.Requests
{
    public class CurrencyAttribute:ValidationAttribute
    {
        private readonly List<string> _currencyList = new List<string> { "RMB", "SGD", "TWD" };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return _currencyList.Any(x => x == value.ToString().ToUpper()) ?
                ValidationResult.Success :
                new ValidationResult($"{validationContext.MemberName} is wrong");
        }
    }
}
