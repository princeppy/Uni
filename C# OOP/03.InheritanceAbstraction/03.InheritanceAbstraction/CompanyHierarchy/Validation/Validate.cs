using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy.Validation
{
    public static class Validate
    {
        public static void IsNullOrWhitespace(string value, string prop)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(String.Format("The {0} must not be null or empty", prop));
            }
        }

        public static void IsNull<T>(T value, string prop)
        {
            if ((dynamic)value==null)
            {
                throw new ArgumentNullException(String.Format("The {0} must not be null", prop));
            }
        }

        public static void IsNegative(decimal value, string prop)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(String.Format("The {0} must be a positive number", prop));
            }
        }

        public static void IsInThePast(DateTime date)
        {
            if (date < DateTime.Now)
            {
                throw new ArgumentOutOfRangeException("The date must not be in the past");
            }
        }

        public static void IsInTheFuture(DateTime date)
        {
            if (date > DateTime.Now)
            {
                throw new ArgumentOutOfRangeException("The date must not be in the future");
            }
        }

        
    }
}
