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
        [Description("Применение разделителя")]
        applySeparator,
        [Description("Получение столбца")]
        getRow
    }
}
