using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MaxiKioscos.Web.Comun.Atributos
{
    public class NotEqualToValueAttribute : ValidationAttribute, IClientValidatable
    {
        public object Value { get; private set; }

        public NotEqualToValueAttribute(string value)
        {
            Value = value;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToString(value) == Convert.ToString(Value))
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return null;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = ErrorMessage,
                ValidationType = "notequaltovalue",
            };
            rule.ValidationParameters["value"] = Value;
            yield return rule;
        }
    }
}
