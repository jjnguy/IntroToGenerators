using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessExample
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeSpan time;
            var nums = Time(() => AllNumbers(), out time);
            Console.WriteLine("Total seconds: " + time.TotalSeconds);
            foreach (var num in nums)
            {
                Console.WriteLine(num);
            }
            Console.ReadKey();
        }

        public static IEnumerable<string> AllNumbers()
        {
            using (var con = GetConnection())
            {
                var sqlCommand = new MySqlCommand("SELECT * FROM positivenumbers", con);
                var rdr = sqlCommand.ExecuteReader();
                while (rdr.Read())
                {
                    yield return rdr["number"].ToString();
                }
            }
        }

        private static MySqlConnection GetConnection()
        {
            string connStr = "server=localhost;user=jjnguy;database=generatorexample;port=3307;password=asdf1234;";
            var con = new MySqlConnection(connStr);
            con.Open();
            return con;
        }

        private static T Time<T>(Func<T> code, out TimeSpan timeResult)
        {
            var start = DateTime.UtcNow;
            var codeResult = code();
            var end = DateTime.UtcNow;
            timeResult = end.Subtract(start);
            return codeResult;
        }
    }
}
