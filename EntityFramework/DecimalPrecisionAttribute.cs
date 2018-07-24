using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Standard.EntityFramework
{
    public class DecimalPrecisionAttribute : ColumnAttribute
    {
        public DecimalPrecisionAttribute(int precision, int scale)
            :base()
        {
            TypeName = $"decimal({precision},{scale})";
        }
    }
}
