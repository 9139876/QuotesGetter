using Graal.Library.Common.Quotes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graal.QuotesGetter.Finam
{
    public class FinamTickerInfo
    {
        public string Url { get; set; }

        public string TickerId { get; set; }

        public string Code { get; set; }

        public string MarketId { get; set; }

        public string MarketTitle { get; set; }

        public string Title { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string VolumeCode { get; set; } = string.Empty;

        public TickerInfo GetStandartTickerInfo() => new TickerInfo(Title, MarketTitle, Currency, VolumeCode);

        public string Serialize() => ((JObject)JToken.FromObject(this)).ToString();

        public static FinamTickerInfo Parse(string serialize) => JsonConvert.DeserializeObject<FinamTickerInfo>(serialize);
    }
}
