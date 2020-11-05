using Graal.Library.Common.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graal.QuotesGetter.Common
{
    public class Command
    {
        public OperationType Type { get; set; } = OperationType.GetInfo;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string MarketName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string TickerName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime StartDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public TimeFrame TimeFrame { get; set; }

        public string Serialize() => ((JObject)JToken.FromObject(this)).ToString();

        public static Command Parse(string serialize) => JsonConvert.DeserializeObject<Command>(serialize);

    }
}
