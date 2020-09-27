using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace AmimirMVC.CustomValidations
{
    public class DecimalPoints:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string valueStr = value.ToString();
            Decimal valueDec = Convert.ToDecimal(valueStr);
            Regex rx = new Regex(@"^\d(\.\d{1,2})?$");

            bool result = rx.IsMatch(valueStr) && valueDec >= 1 && valueDec <= 5;

            return result;
        }
    }
}