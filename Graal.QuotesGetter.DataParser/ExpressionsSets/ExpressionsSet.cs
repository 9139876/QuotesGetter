using Graal.Library.Common;
using Graal.Library.Common.Quotes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Graal.QuotesGetter.DataParser.ExpressionsSets
{
    public class ExpressionsSet : AbstractExpressionsSet<decimal>
    {
        protected override Dictionary<string, ExpressionsSequence<decimal>> Set { get; } = new Dictionary<string, ExpressionsSequence<decimal>>()
        {
            { "Open", new ExpressionsSequence<decimal>() },
            { "Hi", new ExpressionsSequence<decimal>() },
            { "Low", new ExpressionsSequence<decimal>() },
            { "Close", new ExpressionsSequence<decimal>() },
            { "Volume", new ExpressionsSequence<decimal>() }
        };

        public int RowSkipCount { get; set; } = 0;

        public DateExpressionsSet DateExpressionsSet { get; set; } = new DateExpressionsSet();

        public ExpressionsSet() { }

        public ExpressionsSet(string serailize)
        {
            Deserialize(serailize);
        }

        public List<Quote> TryParse(IEnumerable<string> rows)
        {
            List<Quote> result = new List<Quote>();

            try
            {
                foreach (var row in rows.Skip(RowSkipCount))
                {
                    var tq = new TestingQuote();

                    foreach (var key in Set.Keys)
                    {
                        try
                        {
                            tq.Values["Date"] = DateExpressionsSet.TryParse(row);

                            tq.Values[key] = Set[key].GetValue(row);
                        }
                        catch (Exception ex)
                        {
                            AppGlobal.ErrorMessage($"Ошибка {ex.Message}, строка {row}, выражение для {key}");
                        }
                    }

                    result.Add(tq.GetQuote());
                }
            }
            catch (Exception ex)
            {
                AppGlobal.ErrorMessage($"Ошибка {ex.Message}");
            }


            return result;
        }

        public override string Serialize()
        {
            JObject res = new JObject();

            foreach (var key in Set.Keys)
                res.Add(key, Set[key].Serialize());

            res.Add(nameof(RowSkipCount), RowSkipCount);

            res.Add(nameof(DateExpressionsSet), DateExpressionsSet.Serialize());

            return res.ToString();
        }

        protected override void Deserialize(string serailize)
        {
            JObject jobj = JObject.Parse(serailize);

            foreach (var key in Set.Keys)
                Set[key] = new ExpressionsSequence<decimal>((JObject)jobj.SelectToken(key));

            RowSkipCount = int.Parse(jobj.SelectToken(nameof(RowSkipCount)).ToString());

            DateExpressionsSet = new DateExpressionsSet(jobj.SelectToken(nameof(DateExpressionsSet)).ToString());
        }
    }
}
