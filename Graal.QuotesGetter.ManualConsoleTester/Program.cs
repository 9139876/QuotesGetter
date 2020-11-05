using Graal.Library.Common.Enums;
using Graal.QuotesGetter.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graal.QuotesGetter.ManualConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            //var arg = new Command() {Type = OperationType.GetQuotes }.Serialize();
            ////var arg = "fff";

            //using (Process compiler = new Process())
            //{
            //    compiler.StartInfo.FileName = @"D:\Projects\Temp\Graal.QuotesGetter\Graal.QuotesGetter.Finam\bin\Debug\Graal.QuotesGetter.Finam.exe";
            //    compiler.StartInfo.Arguments = arg;
            //    compiler.StartInfo.UseShellExecute = false;
            //    compiler.StartInfo.RedirectStandardOutput = true;
            //    compiler.Start();

            //    Console.WriteLine(compiler.StandardOutput.ReadToEnd());

            //    compiler.WaitForExit();
            //}

            string path = @"d:\finam.txt";

            string data = "";

            using (var sr = new StreamReader(path))
                data = sr.ReadToEnd();

            data = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault(s => s.Contains("Finam.IssuerProfile.Main.issue = "));

            data = data.Replace("Finam.IssuerProfile.Main.issue = ", "").Replace(";", "");

            var jobj = JObject.Parse(data);

            var quote = jobj.SelectToken("quote");
            var market = quote.SelectToken("market");
            var info = quote.SelectToken("info");

            var finamTI = new Graal.QuotesGetter.Finam.FinamTickerInfo()
            {
                TickerId = quote.SelectToken("id").ToString(),
                Code = quote.SelectToken("code").ToString(),
                Title = quote.SelectToken("title").ToString(),
                MarketId = market.SelectToken("id").ToString(),
                MarketTitle = market.SelectToken("title").ToString(),
                Currency = info.SelectToken("currency").ToString(),
                VolumeCode = info.SelectToken("volumeCode").ToString(),
                Url = quote.SelectToken("fullUrl").ToString(),
            };

            Console.ReadKey();
        }
    }
}
