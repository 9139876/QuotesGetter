using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graal.QuotesGetter.DataParser.ExpressionsSequences
{
    class ExpressionsSequenceDate : ExpressionsSequence
    {
        public override ExpressionsSequenceType Type => ExpressionsSequenceType.Date;

        public override DateTime GetData(string row) => DateTime.Parse(Calculate(row));

        public override decimal GetDecimal(string row)
        {
            throw new InvalidOperationException("Данная цепочка должна возвращать дaту");
        }
    }
}
