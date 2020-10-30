using Graal.Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graal.QuotesGetter.DataParser.ExpressionsSets
{
    public class DateExpressionsSet : AbstractExpressionsSet<int>
    {
        public DateExpressionsSet() { }

        public DateExpressionsSet(string serailize)
        {
            Deserialize(serailize);
        }

        protected override Dictionary<string, ExpressionsSequence<int>> Set { get; } = new Dictionary<string, ExpressionsSequence<int>>()
        {
            {"Year", new ExpressionsSequence<int>() },
            {"Month", new ExpressionsSequence<int>() },
            {"Day", new ExpressionsSequence<int>() },
            {"Hour", new ExpressionsSequence<int>() },
            {"Minute", new ExpressionsSequence<int>() }
        };

        public DateTime TryParse(string row)
        {
            try
            {
                return new DateTime(
                    Set["Year"].GetValue(row),
                    Set["Month"].GetValue(row),
                    Set["Day"].GetValue(row),
                    Set["Hour"].GetValue(row),
                    Set["Minute"].GetValue(row),
                    0
                    );
            }
            catch (Exception ex)
            {
                AppGlobal.ErrorMessage($"Ошибка {ex.Message}");
                return DateTime.MinValue;
            }
        }

        public override string Serialize()
        {
            throw new NotImplementedException();
        }

        protected override void Deserialize(string serailize)
        {
            throw new NotImplementedException();
        }
    }
}
