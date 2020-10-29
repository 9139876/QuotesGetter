using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graal.QuotesGetter.DataParser.ExpressionsSequences
{
    class ExpressionsSequenceDecimal : ExpressionsSequence
    {
        public override ExpressionsSequenceType Type => ExpressionsSequenceType.Decimal;

        public override DateTime GetData(string row)
        {
            throw new InvalidOperationException("Данная цепочка должна возвращать число");
        }

        public override decimal GetDecimal(string row) => decimal.Parse(Calculate(row));
    }
}
