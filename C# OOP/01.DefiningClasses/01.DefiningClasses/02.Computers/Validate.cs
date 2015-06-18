using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _02.Computers
{
    public static class Validate
    {
        public static void IsEmpty(string value,string name)
        {
            if (value == String.Empty)
            {
                string msg = String.Format(String.Format(Messages.StringCannotBeEmpty, name));
                throw new ArgumentOutOfRangeException(msg);
            }
        }

        public static void IsNegative<T>(T number, string name)
        {
            if (number < (dynamic)0)
            {
                string msg = String.Format(String.Format(Messages.ValueCannotBeNegative, name));
                throw new ArgumentOutOfRangeException(msg);
            }
        }
    }
}
