using Graal.Library.Common;
using Graal.Library.Common.Quotes;
using Graal.QuotesGetter.DataParser.Expressions;
using Graal.QuotesGetter.DataParser.ExpressionsSequences;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graal.QuotesGetter.DataParser
{
    public class ExpressionsSet
    {
        readonly Dictionary<string, ExpressionsSequence> Set = new Dictionary<string, ExpressionsSequence>()
        {
            { "Date", new ExpressionsSequenceDate() },
            { "Open", new ExpressionsSequenceDecimal() },
            { "Hi", new ExpressionsSequenceDecimal() },
            { "Low", new ExpressionsSequenceDecimal() },
            { "Close", new ExpressionsSequenceDecimal() },
            { "Volume", new ExpressionsSequenceDecimal() }
        };

        public int RowSkipCount { get; set; } = 0;

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
                            if (key == "Date")
                                tq.Values[key] = Set[key].GetData(row);
                            else
                                tq.Values[key] = Set[key].GetDecimal(row);
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

        public string Serialize()
        {
            JObject res = new JObject();

            foreach (var key in Set.Keys)
                res.Add(key, Set[key].Serialize());

            return res.ToString();
        }

        void Deserialize(string serailize)
        {
            JObject jobj = JObject.Parse(serailize);

            foreach (var key in Set.Keys)
                Set[key] = ExpressionsSequence.GetExpressionSequence(jobj.SelectToken(key).ToString());
        }
    }
}
