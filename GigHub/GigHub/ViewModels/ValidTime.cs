using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.ViewModels
{
    public class ValidTime : ValidationAttribute
    {
        //Validateion for Time string
        public override bool IsValid(object value)
        {
            DateTime date;
            var isval = DateTime.TryParseExact(Convert.ToString(value),
                "HH:mm",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None, out date);

            return (isval);
        }
    }
}