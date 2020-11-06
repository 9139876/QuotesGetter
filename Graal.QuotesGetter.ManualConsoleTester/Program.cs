using Graal.Library.Common.Enums;
using Graal.QuotesGetter.Common;
using Graal.QuotesGetter.Finam;
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
            ////var arg = new Command() {Type = OperationType.GetQuotes }.Serialize();
            //////var arg = "fff";

            ////using (Process compiler = new Process())
            ////{
            ////    compiler.StartInfo.FileName = @"D:\Projects\Temp\Graal.QuotesGetter\Graal.QuotesGetter.Finam\bin\Debug\Graal.QuotesGetter.Finam.exe";
            ////    compiler.StartInfo.Arguments = arg;
            ////    compiler.StartInfo.UseShellExecute = false;
            ////    compiler.StartInfo.RedirectStandardOutput = true;
            ////    compiler.Start();

            ////    Console.WriteLine(compiler.StandardOutput.ReadToEnd());

            ////    compiler.WaitForExit();
            ////}

            //string path = @"d:\finam2.txt";

            //string data = "";

            //using (var sr = new StreamReader(path))
            //    data = sr.ReadToEnd();

            //string pref = "https://finam.ru";
            //string post = "export";

            //data = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault(s => s.Contains("data-json"));

            //List<string> urls = new List<string>();

            //int start, end = 0;

            //while (true)
            //{

            //    start = data.IndexOf("instrument", end) - 5;
            //    end = Index(data, start, '{', '}');

            //    if (end == -1)
            //        break;

            //    var jobj = JObject.Parse(data.Substring(start, end - start).Replace("&quot;", "\""));

            //    urls.Add(pref + jobj.SelectToken("url").ToString() + post);
            //}



            ////






            ////int end = data.LastIndexOf('}');

            ////int end2 = data.IndexOf("</div>");

            ////int count = (data.Length - data.Replace("\"", "").Length);



            ////var ch = data[start];
            ////ch = data[end];

            ////data = data.Substring(start, end - start).Replace("&quot;", "\"");

            //////data = data.Substring(data.IndexOf('{'), data.LastIndexOf('}'));

            ////var jobj = JObject.Parse(data);
            //////

            var ti = MarketsInfoDownloader.GetTickersInfos("currencies/crypto");




            Console.ReadKey();
        }

        static int Index(string s, int start, char open, char close)
        {
            if (start == -1)
                return -1;

            int openCount = 0, closeCount = 0;

            for (int i = start; i < s.Length; i++)
            {
                if (s[i] == open)
                    openCount++;
                else if (s[i] == close)
                    closeCount++;

                if (openCount != 0 && openCount == closeCount)
                    return i + 1;
            }

            return -1;
        }



    }
}
