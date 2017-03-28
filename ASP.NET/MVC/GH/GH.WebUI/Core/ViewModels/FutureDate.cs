using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GH.WebUI.Core.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            bool isValid = DateTime.TryParseExact(Convert.ToString(value),
                "d MMM yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateTime);

            return (isValid && dateTime > DateTime.Now);
        }
    }
}