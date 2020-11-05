using Graal.QuotesGetter.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graal.QuotesGetter.Finam
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (!Environment.CommandLine.Contains('{'))
                    throw new ArgumentException("Не удалось получить параметры из входной строки");

                var cmd = Environment.CommandLine.Remove(0, Environment.CommandLine.IndexOf('{'));

                //Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);



                Console.WriteLine(ExecuteCommand(cmd).Serialize());
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    new Result()
                    {
                        Success = false,
                        Error = ex.Message
                    }
                    .Serialize());
            }
        }

        static Result ExecuteCommand(string command)
        {
            Command cmd;
            try
            {
                cmd = Command.Parse(command);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка чтения параметров - '{ex.Message}'");
            }

            switch (cmd.Type)
            {
                case OperationType.GetInfo: return ResultGenerator.GetInfo(cmd);
                case OperationType.GetMarkets: return ResultGenerator.GetMarkets(cmd);
                case OperationType.GetQuotes: return ResultGenerator.GetQuotes(cmd);
                case OperationType.GetTickers: return ResultGenerator.GetTickers(cmd);

                default: throw new ArgumentException($"Неизвестная команда - '{cmd.Type.ToString()}'");
            }
        }
    }
}
