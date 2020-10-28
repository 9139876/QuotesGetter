using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            NpgsqlConnectionStringBuilder sb = new NpgsqlConnectionStringBuilder
            {
                Host = "localhost",
                Port = 5432,
                Database = "test",
                Username = "graal",
                Password = "123"
            };

            var connection = new NpgsqlConnection(sb.ConnectionString);

            try
            {
                connection.Open();
                Console.WriteLine("Ok");

                //using (var cmd = connection.CreateCommand())
                //{
                //    cmd.CommandText = "select * from get_all_quotes(139);";

                //    var reader = cmd.ExecuteReader();

                //    while (reader.Read())
                //        Console.WriteLine($"{reader[0]} - {reader[1]}");




                //}

                var cmd = connection.CreateCommand();
                cmd.CommandText = "select * from get_all_quotes(139);";

                var adapter = new NpgsqlDataAdapter(cmd);

                DataSet dataSet = new DataSet("1");

                adapter.Fill(dataSet);

                var productsQuery = dataSet.Tables[0].AsEnumerable();
                    //from dt in dataSet.Tables[0].AsEnumerable()
                    //select dt;

                foreach (var b in productsQuery)
                {
                    //b.

                    Console.WriteLine($"{b.Field<DateTime>("dt")} - {b.Field<decimal>("hi")}");
                }
                    



                //int i = 0;


                //var adapter = new NpgsqlDataAdapter
                //{
                //    SelectCommand = new NpgsqlCommand(),
                //    InsertCommand = new NpgsqlCommand(),
                //    DeleteCommand = new NpgsqlCommand(),
                //    UpdateCommand = new NpgsqlCommand()
                //};
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            


            


            Console.ReadKey();







        }
    }
}
