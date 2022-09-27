using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;


namespace GigHub.ViewModels
{
    public class FutureDate:ValidationAttribute
    {
        //Validateion for Date string
        public override bool IsValid(object value)
        {
            DateTime date;
            var isval = DateTime.TryParseExact(Convert.ToString(value),
                "yyyy-mm-d",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out date);

            //return true if DateTime can parse and gig data > data.now
            //return (isval && date > DateTime.Now);
            return (isval);
        }
    }

    
}