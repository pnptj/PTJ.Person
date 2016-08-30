using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTJ.Person.DataLayer
{
    public static class DBDateTimeHelper
    {
        public static DateTime getDefaultDateTime()
        {
            return new DateTime(1800, 01, 01);
        }
    }
}
