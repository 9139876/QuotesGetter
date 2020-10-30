using Graal.Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graal.QuotesGetter.DataParser.Expressions
{
    public enum ExpressionType
    {
        [Description("Получение значения столбца")]
        getRowValue,
        [Description("Константное значение")]
        constValue,
        [Description("Получение части строки")]
        getSubstring,
        [Description("Замена в строке")]
        replaceString
    }
}
