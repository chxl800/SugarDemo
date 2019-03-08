using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SugarDemo.DB;

namespace SugarDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var time = DateTime.Now.AddMonths(-1);
            int daylast = time.AddMonths(1).AddDays(-time.Day).Day;
            Console.WriteLine(daylast);
            Console.ReadKey();
        }

        public static void AddTime()
        {
            var time = DateTime.Now;
            for (int i = 0; i < 100; i++)
            {
                time = time.AddSeconds(1);
                Console.WriteLine(time.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            Console.ReadKey();
        }


        public static void TimeDifference()
        {
            DateTime date1 = DateTime.Parse("2018-07-19 18:10:11");
            DateTime date2 = DateTime.Parse("2018-07-19 18:08:10");
            TimeSpan timeSpan = date2 - date1;
            Console.WriteLine("两次时间相差" + timeSpan.TotalSeconds + "秒钟");
            Console.ReadKey();

        }

        public void MysqlSugarTest() {
            using (var db = SugarFactory.GetInstance())
            {
                Console.WriteLine("生成时间：" + DateTime.Now.ToLongTimeString());
                var list = new List<Model.SugarDemo>();
                for (var i = 0; i < 10000; i++)
                {
                    list.Add(new Model.SugarDemo()
                    {
                        Id = Guid.NewGuid().ToString("N"),
                        Name = "江雄" + i,
                        Num = i,
                    });

                    if (list.Count >= 100)
                    {
                        db.SqlBulkCopy(list);
                        list.Clear();
                    }
                }

                Console.WriteLine("开始时间：" + DateTime.Now.ToLongTimeString());


                if (list.Count >= 0)
                {
                    db.SqlBulkCopy(list);
                    list.Clear();
                }

                Console.WriteLine("结束时间：" + DateTime.Now.ToLongTimeString());

                Console.ReadKey();
            }
        }
    }
}
