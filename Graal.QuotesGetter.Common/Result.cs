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
    public class Result
    {
        public bool Success { get; set; }

        public string Error { get; set; }

        public OperationType Type { get; set; } = OperationType.Unknown;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Market { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Ticker { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public TimeFrame TimeFrame { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string[] Data { get; set; }

        public string Serialize() => ((JObject)JToken.FromObject(this)).ToString();

        public static Result Parse(string serialize) => JsonConvert.DeserializeObject<Result>(serialize);
    }
}
