using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using Graal.Library.Common.Quotes;
using Graal.Library.Common.Enums;
using Graal.Library.Storage.Common;
using static Graal.Library.Storage.Common.SQLNames;

namespace Graal.QuotesGetter.DataParser.Storage
{
    public class QuotesPostgresSqlDriver : CommonPostgresSqlDriver
    {
        public QuotesPostgresSqlDriver() : base() { }

        List<string> GetAllExpressions()
        {
            List<string> result = new List<string>();

            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText =
                    $"select {QuotesParserExpressions_Specification} " +
                    $"from {SchemaName}.{Tbl_QuotesParserExpressions}";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        result.Add(reader[0].ToString());
                }
            }

            return result;
        }

        void SaveExpressions(List<string> expSerialize)
        {
            expSerialize = expSerialize.Except(GetAllExpressions()).ToList();

            if(expSerialize.Count > 0)
            {
                using (var cmd = (Npgsql.NpgsqlCommand)connection.CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO {SchemaName}.{Tbl_QuotesParserExpressions} " +
                                $"select {citCode} citizenships, :cyr cyr, :lat lat, :popular popular from DUAL ";

                    cmd.BindByName = true;
                    cmd.ArrayBindCount = expSerialize.Count;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(":cyr", OracleDbType.NVarchar2).Value = cyr;
                    cmd.Parameters.Add(":lat", OracleDbType.NVarchar2).Value = lat;
                    cmd.Parameters.Add(":popular", OracleDbType.Int32).Value = popular;
                    cmd.ExecuteNonQuery();
                }
            }
        }



        //#region GetId

        //int GetTickerInfoId(TickerInfo tickerInfo, bool firstTry = true)
        //{
        //    using (var cmd = connection.CreateCommand())
        //    {
        //        cmd.CommandText =
        //            $"select id " +
        //            $"from {SchemaName}.{Tbl_TickersInfoes} " +
        //            $"where {TickersInfoes_MarketTitle}='{tickerInfo.MarketTitle}' and {TickersInfoes_TickerTitle}='{tickerInfo.Title}'";

        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            if (reader.Read())
        //                return int.Parse(reader[0].ToString());
        //            else if (firstTry)
        //            {
        //                TickerInfosToStorage(new List<TickerInfo>() { tickerInfo });
        //                return GetTickerInfoId(tickerInfo, false);
        //            }
        //            else
        //                throw new ArgumentException($"Не удалось получить информацию о тикере {tickerInfo} в БД в схеме {SchemaName}");
        //        }
        //    }
        //}

        //int GetTickerTFId(TickerTF tickerTF, bool firstTry = false)
        //{
        //    using (var cmd = connection.CreateCommand())
        //    {
        //        cmd.CommandText =
        //            $"select {TickerTFs_Id} " +
        //            $"from {SchemaName}.{Tbl_TickerTFs} " +
        //            $"where {TickerTFs_Period}={(int)tickerTF.TimeFrame} and {TickerTFs_TickerInfoId}={tickerTF.ParentTickerInfo.StorageId.Get()}";

        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            if (reader.Read())
        //                return int.Parse(reader[0].ToString());
        //            else if (firstTry)
        //            {
        //                TickerTFsToStorage(new List<TickerTF>() { tickerTF });
        //                return GetTickerTFId(tickerTF, false);
        //            }
        //            else
        //                throw new ArgumentException($"Не удалось получить информацию о {tickerTF} в БД в схеме {SchemaName}");
        //        }
        //    }
        //}

        ////int GetQuoteId(Quote quote)
        ////{
        ////    using (var cmd = connection.CreateCommand())
        ////    {
        ////        cmd.CommandText =
        ////            $"select id " +
        ////            $"from {schemaName}.{Tbl_Quotes} " +
        ////            $"where {Quotes_Date}={quote.Date} and {Quotes_TickerTFId}={quote.ParentTickerTF.StorageId.Get()}";

        ////        using (var reader = cmd.ExecuteReader())
        ////        {
        ////            if (reader.Read())
        ////                return int.Parse(reader[0].ToString());
        ////            else
        ////                throw new ArgumentException($"Информация о котировке {quote.ParentTickerTF} за {quote.Date} не найдена в БД в схеме {schemaName}");
        ////        }
        ////    }
        ////}

        ////int GetPointPtId(PointPT pointPT, bool firstTry = true)
        ////{
        ////    using (var cmd = connection.CreateCommand())
        ////    {
        ////        cmd.CommandText =
        ////            $"select id " +
        ////            $"from {schemaName}.{Tbl_PointsPT} " +
        ////            $"where {PointsPT_Date}='{pointPT.DateS}' and {PointsPT_Price}={pointPT.PriceS}";

        ////        using (var reader = cmd.ExecuteReader())
        ////        {
        ////            if (reader.Read())
        ////                return int.Parse(reader[0].ToString());
        ////            else if (firstTry)
        ////            {
        ////                PointsPTToStorage(new List<PointPT>() { pointPT });
        ////                return GetPointPtId(pointPT, false);
        ////            }
        ////            else
        ////                throw new ArgumentException($"Не удалось получить информацию о точке {pointPT} в БД в схеме {schemaName}");
        ////        }
        ////    }
        ////}

        //#endregion

        //#region TickersToStorage

        //public void TickerInfosToStorage(IEnumerable<TickerInfo> tickerInfos)
        //{
        //    StringBuilder sb = new StringBuilder(1000);

        //    foreach (var ti in tickerInfos)
        //        sb.Append($"insert into {SchemaName}.{Tbl_TickersInfoes} " +
        //            $"({TickersInfoes_TickerId}, {TickersInfoes_Code}, {TickersInfoes_TickerTitle}, {TickersInfoes_MarketId}, {TickersInfoes_MarketTitle}, {TickersInfoes_Currency}, {TickersInfoes_VolumeCode}, {TickersInfoes_GetUrl})" +
        //            $"values ('{ti.TickerId}', '{ti.Code}', '{ti.Title}', '{ti.MarketId}', '{ti.MarketTitle}', '{ti.Currency}', '{ti.VolumeCode}', '{ti.GetUrl}') " +
        //            $"on conflict do nothing;");

        //    ToStorage(sb.Remove(sb.Length - 1, 1).ToString());

        //    //Производные TickerTF
        //    List<TickerTF> tickerTFs = new List<TickerTF>();

        //    foreach (var ti in tickerInfos)
        //        tickerTFs.AddRange(ti.GetTickerTFs());

        //    TickerTFsToStorage(tickerTFs);
        //}

        //public void TickerInfoToStorage(TickerInfo tickerInfo)
        //{
        //    ToStorage($"insert into {SchemaName}.{Tbl_TickersInfoes} " +
        //        $"({TickersInfoes_TickerId}, {TickersInfoes_Code}, {TickersInfoes_TickerTitle}, {TickersInfoes_MarketId}, {TickersInfoes_MarketTitle}, {TickersInfoes_Currency}, {TickersInfoes_VolumeCode}, {TickersInfoes_GetUrl})" +
        //        $"values ('{tickerInfo.TickerId}', '{tickerInfo.Code}', '{tickerInfo.Title}', '{tickerInfo.MarketId}', '{tickerInfo.MarketTitle}', '{tickerInfo.Currency}', '{tickerInfo.VolumeCode}', '{tickerInfo.GetUrl}') " +
        //        $"on conflict do nothing;");

        //    //Производные TickerTF
        //    TickerTFsToStorage(tickerInfo.GetTickerTFs());
        //}

        //public void TickerTFsToStorage(IEnumerable<TickerTF> tickerTFs)
        //{
        //    //Проверка корректности id
        //    foreach (var ti in tickerTFs.Select(ttf => ttf.ParentTickerInfo).Distinct())
        //        if (ti.StorageId.Get() < 0)
        //            ti.StorageId.Set(GetTickerInfoId(ti));

        //    StringBuilder sb = new StringBuilder(1000);

        //    foreach (var ttf in tickerTFs)
        //        sb.Append($"insert into {SchemaName}.{Tbl_TickerTFs} " +
        //            $"({TickerTFs_Period}, {TickerTFs_TickerInfoId}, {TickerTFs_TradingTimeRules}, {TickerTFs_QuotesDateOfLastUpdate})" +
        //            $"values ('{((int)ttf.TimeFrame).ToString()}', '{ttf.ParentTickerInfo.StorageId.Get().ToString()}', '{ttf.TradingTimeRulesSerialize()}', '{DateTime.Now}') " +
        //            $"on conflict do nothing;");

        //    ToStorage(sb.Remove(sb.Length - 1, 1).ToString());
        //}

        //public void TickerTF_UpdateTradingTimeRules(TickerTF tickerTF)
        //{
        //    string cmd = $"update {SchemaName}.{Tbl_TickerTFs} set {TickerTFs_TradingTimeRules} = '{tickerTF.TradingTimeRulesSerialize()}' where {TickerTFs_Id} = {tickerTF.StorageId.Get().ToString()}";
        //    ToStorage(cmd);
        //}

        //public void QuotesToStorage(IEnumerable<Quote> quotes)
        //{
        //    if (quotes.Count() > 0)
        //    {
        //        //Проверка корректности id
        //        foreach (var ttf in quotes.Select(q => q.ParentTickerTF).Distinct())
        //            if (ttf.StorageId.Get() < 0)
        //                ttf.StorageId.Set(GetTickerTFId(ttf));

        //        StringBuilder sb = new StringBuilder(1000);

        //        foreach (var q in quotes)
        //            sb.Append($"insert into {SchemaName}.{Tbl_Quotes} " +
        //                $"({Quotes_Date}, {Quotes_Open}, {Quotes_High}, {Quotes_Low}, {Quotes_Close}, {Quotes_Volume}, {Quotes_TickerTFId}) " +
        //                $"values ('{q.DateS}', {q.OpenS}, {q.HiS}, {q.LowS}, {q.CloseS}, {q.VolumeS}, {q.ParentTickerTF.StorageId.Get()}) " +
        //                $"on conflict do nothing;");

        //        ToStorage(sb.Remove(sb.Length - 1, 1).ToString());
        //    }
        //}

        //#endregion

        //#region TickersFromStorage
        //public List<TickerInfo> GetAllTickerInfos()
        //{
        //    var res = new List<TickerInfo>();

        //    using (var cmd = connection.CreateCommand())
        //    {
        //        cmd.CommandText = $"select * from {SchemaName}.{Tbl_TickersInfoes}";

        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //                res.Add(new TickerInfo(
        //                    reader[TickersInfoes_TickerId].ToString(),
        //                    reader[TickersInfoes_Code].ToString(),
        //                    reader[TickersInfoes_TickerTitle].ToString(),
        //                    reader[TickersInfoes_MarketId].ToString(),
        //                    reader[TickersInfoes_MarketTitle].ToString(),
        //                    reader[TickersInfoes_Currency].ToString(),
        //                    reader[TickersInfoes_VolumeCode].ToString(),
        //                    reader[TickersInfoes_GetUrl].ToString(),
        //                    int.Parse(reader[TickersInfoes_Id].ToString())
        //                    ));
        //        }
        //    }

        //    return res;
        //}

        //public TickerTF GetTickerTF(TickerInfo tickerInfo, int timeFrame)
        //{
        //    //Проверка корректности id
        //    if (tickerInfo.StorageId.Get() < 0)
        //        tickerInfo.StorageId.Set(GetTickerInfoId(tickerInfo));

        //    TickerTF res = null;

        //    using (var cmd = connection.CreateCommand())
        //    {
        //        cmd.CommandText =
        //            $"select * " +
        //            $"from {SchemaName}.{Tbl_TickerTFs} " +
        //            $"where {TickerTFs_TickerInfoId}={tickerInfo.StorageId.Get()} and {TickerTFs_Period}={(int)timeFrame}";

        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            if (reader.Read())
        //                res = new TickerTF(
        //                    timeFrame,
        //                    tickerInfo,
        //                    null,
        //                    reader[TickerTFs_TradingTimeRules].ToString(),
        //                    int.Parse(reader[TickerTFs_Id].ToString()),
        //                    DateTime.Parse(reader[TickerTFs_QuotesDateOfLastUpdate].ToString()));
        //            else
        //                throw new ArgumentException($"Информация о {new TickerTF(timeFrame, tickerInfo, null, null)} не найдена в БД в схеме {SchemaName}");
        //        }
        //    }

        //    res.Quotes.AddRange(GetQuotes(res).OrderBy(q => q.Date));

        //    return res;
        //}

        //public Tuple<TimeFrame, string> GetPatternTickerInfoIdAndTF(string patternId)
        //{
        //    using (var cmd = connection.CreateCommand())
        //    {
        //        cmd.CommandText =
        //            $"select {TickerTFs_Period}, {TickerTFs_TickerInfoId} from {Tbl_TickerTFs} where {TickerTFs_Id} in (" +
        //               $"select {Tendentions_TickerTFId} from {Tbl_Tendentions} where {Tendentions_Id} in (" +
        //                  $"select {SimplePatterns_TendentionId} from {Tbl_SimplePatterns} where {SimplePatterns_Id} = {patternId}" +
        //               $")" +
        //            $")";

        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            if (reader.Read())
        //                return new Tuple<TimeFrame, string>((TimeFrame)reader.GetInt32(0), reader.GetInt32(1).ToString());
        //            else
        //                throw new ArgumentException($"Информация о тикере и периоде для паттерна с id '{patternId}' не найдена в хранилище");
        //        }
        //    }
        //}

        //public TickerInfo TickerInfo_Get(string id)
        //{
        //    using (var cmd = connection.CreateCommand())
        //    {
        //        cmd.CommandText = $"select * from {SchemaName}.{Tbl_TickersInfoes} where {TickersInfoes_Id} = {id}";

        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            if (reader.Read())
        //                return new TickerInfo(
        //                    reader[TickersInfoes_TickerId].ToString(),
        //                    reader[TickersInfoes_Code].ToString(),
        //                    reader[TickersInfoes_TickerTitle].ToString(),
        //                    reader[TickersInfoes_MarketId].ToString(),
        //                    reader[TickersInfoes_MarketTitle].ToString(),
        //                    reader[TickersInfoes_Currency].ToString(),
        //                    reader[TickersInfoes_VolumeCode].ToString(),
        //                    reader[TickersInfoes_GetUrl].ToString(),
        //                    int.Parse(reader[TickersInfoes_Id].ToString())
        //                    );
        //        }
        //    }

        //    throw new ArgumentException($"Информация о тикере с id '{id}' не найдена в хранилище.");
        //}

        //public List<Quote> GetQuotes(TickerTF tickerTF, Quote lastQuote = null)
        //{
        //    //Проверка корректности id
        //    if (tickerTF.StorageId.Get() < 0)
        //        tickerTF.StorageId.Set(GetTickerTFId(tickerTF));

        //    var res = new List<Quote>();

        //    using (var cmd = connection.CreateCommand())
        //    {
        //        cmd.CommandText =
        //           $"select * " +
        //           $"from {SchemaName}.{Tbl_Quotes} " +
        //           $"where {Quotes_TickerTFId}={tickerTF.StorageId.Get()}";

        //        if (lastQuote != null)
        //            cmd.CommandText += $" and {Quotes_Date} > {lastQuote.Date}";

        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //                res.Add(new Quote(
        //                    tickerTF,
        //                    DateTime.Parse(reader[Quotes_Date].ToString()),
        //                    double.Parse(reader[Quotes_Open].ToString()),
        //                    double.Parse(reader[Quotes_High].ToString()),
        //                    double.Parse(reader[Quotes_Low].ToString()),
        //                    double.Parse(reader[Quotes_Close].ToString()),
        //                    double.Parse(reader[Quotes_Volume].ToString()),
        //                    int.Parse(reader[Quotes_Id].ToString())
        //                    ));
        //        }
        //    }

        //    return res;
        //}

        //public DateTime GetLastDate(TickerTF tickerTF)
        //{
        //    //Проверка корректности id
        //    if (tickerTF.StorageId.Get() < 0)
        //        tickerTF.StorageId.Set(GetTickerTFId(tickerTF));

        //    var res = TickerTF.FirstDate;

        //    using (var cmd = connection.CreateCommand())
        //    {
        //        cmd.CommandText =
        //           $"select max({Quotes_Date}) " +
        //           $"from {SchemaName}.{Tbl_Quotes} " +
        //           $"where {Quotes_TickerTFId}={tickerTF.StorageId.Get()}";

        //        using (var reader = cmd.ExecuteReader())
        //            if (reader.Read() && DateTime.TryParse(reader[0].ToString(), out DateTime parse))
        //                res = parse;
        //    }

        //    return res;
        //}

        //public DateTime GetFirstDate(TickerTF tickerTF)
        //{
        //    //Проверка корректности id
        //    if (tickerTF.StorageId.Get() < 0)
        //        tickerTF.StorageId.Set(GetTickerTFId(tickerTF));

        //    var res = TickerTF.FirstDate;

        //    using (var cmd = connection.CreateCommand())
        //    {
        //        cmd.CommandText =
        //           $"select min({Quotes_Date}) " +
        //           $"from {SchemaName}.{Tbl_Quotes} " +
        //           $"where {Quotes_TickerTFId}={tickerTF.StorageId.Get()}";

        //        using (var reader = cmd.ExecuteReader())
        //            if (reader.Read() && DateTime.TryParse(reader[0].ToString(), out DateTime parse))
        //                res = parse;
        //    }

        //    return res;
        //}

        //public double GetMinPrice(TickerTF tickerTF)
        //{
        //    //Проверка корректности id
        //    if (tickerTF.StorageId.Get() < 0)
        //        tickerTF.StorageId.Set(GetTickerTFId(tickerTF));

        //    double res = 0;

        //    using (var cmd = connection.CreateCommand())
        //    {
        //        cmd.CommandText =
        //           $"select min({Quotes_Low}) " +
        //           $"from {SchemaName}.{Tbl_Quotes} " +
        //           $"where {Quotes_TickerTFId}={tickerTF.StorageId.Get()}";

        //        using (var reader = cmd.ExecuteReader())
        //            if (reader.Read() && double.TryParse(reader[0].ToString(), out double parse))
        //                res = parse;
        //    }

        //    return res;
        //}

        //public double GetMaxPrice(TickerTF tickerTF)
        //{
        //    //Проверка корректности id
        //    if (tickerTF.StorageId.Get() < 0)
        //        tickerTF.StorageId.Set(GetTickerTFId(tickerTF));

        //    double res = 0;

        //    using (var cmd = connection.CreateCommand())
        //    {
        //        cmd.CommandText =
        //           $"select max({Quotes_High}) " +
        //           $"from {SchemaName}.{Tbl_Quotes} " +
        //           $"where {Quotes_TickerTFId}={tickerTF.StorageId.Get()}";

        //        using (var reader = cmd.ExecuteReader())
        //            if (reader.Read() && double.TryParse(reader[0].ToString(), out double parse))
        //                res = parse;
        //    }

        //    return res;
        //}

        //public int GetQuotesCount(TickerTF tickerTF)
        //{
        //    //Проверка корректности id
        //    if (tickerTF.StorageId.Get() < 0)
        //        tickerTF.StorageId.Set(GetTickerTFId(tickerTF));

        //    int res = 0;

        //    using (var cmd = connection.CreateCommand())
        //    {
        //        cmd.CommandText =
        //           $"select count(*) " +
        //           $"from {SchemaName}.{Tbl_Quotes} " +
        //           $"where {Quotes_TickerTFId}={tickerTF.StorageId.Get()}";

        //        using (var reader = cmd.ExecuteReader())
        //            if (reader.Read())
        //                res = int.Parse(reader[0].ToString());
        //    }

        //    return res;
        //}

        //#endregion
    }
}
