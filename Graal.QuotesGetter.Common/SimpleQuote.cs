using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graal.QuotesGetter.Common
{
    public class SimpleQuote
    {
        public DateTime Date { get; }

        public decimal Open { get; }

        public decimal Hi { get; }

        public decimal Low { get; }

        public decimal Close { get; }

        public decimal Volume { get; }

        public SimpleQuote(DateTime date, decimal open, decimal hi, decimal low, decimal close, decimal volume = 0)
        {
            Date = date;
            Open = open;
            Hi = hi;
            Low = low;
            Close = close;
            Volume = volume;
        }

        public string Serialize() => ((JObject)JToken.FromObject(this)).ToString();

        public static SimpleQuote GetResult(string serialize) => JsonConvert.DeserializeObject<SimpleQuote>(serialize);

        //public SimpleQuote(JObject serialize)
        //{
        //    Date = DateTime.Parse(serialize.SelectToken(nameof(Date)).ToString());
        //    Open = decimal.Parse(serialize.SelectToken(nameof(Open)).ToString());
        //    Hi = decimal.Parse(serialize.SelectToken(nameof(Hi)).ToString());
        //    Low = decimal.Parse(serialize.SelectToken(nameof(Low)).ToString());
        //    Close = decimal.Parse(serialize.SelectToken(nameof(Close)).ToString());
        //    Volume = decimal.Parse(serialize.SelectToken(nameof(Volume)).ToString());
        //}

        //public string Serialize()
        //{
        //    return new JObject(
        //        new JProperty(nameof(Date), Date),
        //        new JProperty(nameof(Open), Open),
        //        new JProperty(nameof(Hi), Hi),
        //        new JProperty(nameof(Low), Low),
        //        new JProperty(nameof(Close), Close),
        //        new JProperty(nameof(Volume), Volume)
        //        ).ToString();
        //}
    }
}
