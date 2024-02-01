using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using AESTest;
using AutoMapper;
using ConsoleAppTest;
using ConsoleAppTest.Interface;
using ConsoleAppTest.Service;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace TestProject
{

    public class Tests
    {
        //private readonly IUser _user;

        //public Tests(IUser user)
        //{
        //    _user = user;
        //}

        /// <summary>
        /// 亂數產生器
        /// </summary>
        private static System.Random _rand { set; get; } = new Random((int)DateTime.Now.Ticks);
        [Test]
        public void Function1()
        {
            //var a=_user.GetName(1);
            //var b = a;
        }
        
        [Test]
        public void Function2()
        {

            //User user = new User();
            //user.id = result2("");
            //user.name = "a";
        }
         int result2(string param)
        {
            return 2;
        }
        [Test]
        public void Function3()
        {
            List<Teams> ls = new List<Teams>();
            ls.Add(new Teams { Years=2021,TeamName="a"});
            ls.Add(new Teams { Years = 2018, TeamName = "b" });
            ls.Add(new Teams { Years = 2019, TeamName = "c" });
            ls.Add(new Teams { Years = 2022, TeamName = "d" });
            ls.Add(new Teams { Years = 2022, TeamName = "e" });
            ls.Add(new Teams { Years = 2023, TeamName = "f" });
            ls.Add(new Teams { Years = 2021, TeamName = "g" });
            ls.Add(new Teams { Years = 2018, TeamName = "h" });
            //List<int> filter = ls.OrderByDescending(x => x.Years).Select(x => x.Years).Distinct().Take(3).ToList();
            //var result=ls.Where(r => filter.Contains(r.Years)).ToList();
            Teams teams = new Teams();
            Debug.WriteLine(1);
        }
        class Teams{
             public int Years { get; set; }
             public string TeamName { get; set; }
        }
        [Test]
        public void Function4()
        {
            for (int i = 0; i < 20; i++)
            {
                var a = _rand.Next(0, 100);
            }
            Debug.WriteLine(1);
        }

        public string GetName(int id)
        {
            throw new NotImplementedException();
        }
        [Test]
        public void Function5()
        {
            var boo = new Boo
            {
                Val = 2.65,
                id="1",
                name="s"
            };

            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Boo, Foo>());
            var mapper = config.CreateMapper();

            var foo = mapper.Map<Foo>(boo);
            Debug.WriteLine(1);
        }
        [Test]
        public void Function6()
        {
            Regex reg_num = new Regex(@"^[0-9]*[1-9][0-9]*$");
            var result= reg_num.Match("ABC").Success;
            result = reg_num.Match("-10").Success;
            result = reg_num.Match("-1.2").Success;
            result =reg_num.Match("-1").Success;
            result=reg_num.Match("0.1").Success;
            result=reg_num.Match("0").Success;
            result=reg_num.Match("1").Success;
            result=reg_num.Match("10").Success;
            result=reg_num.Match("999").Success;
            result=reg_num.Match("99999999").Success;
        }
        //反轉字串
        [Test]
        public void Function7()
        {
            string originalString = "0123456789";
            string reversedString = new string(originalString.Reverse().ToArray());
        }
        [Test]
        public void Function8()
        {
            string originalString = "0123456789";
            char[] c = originalString.ToArray();
            string reversedString = string.Empty;
            for (int i = c.Length-1; i >= 0; i--)
            {
                reversedString += c[i];
            }

        }

        private delegate void BuyBook();
        //一般委派Delegate
        [Test]
        public void Function9()
        {
            BuyBook buybook = new BuyBook(Book);
            buybook();
        }

        //使用Action,就不用再宣告一個BuyBook
        [Test]
        public void Function10()
        {
            Action BookAction = new Action(Book);
            BookAction();
        }
        public static void Book()
        {
            Console.WriteLine("我是提供書籍的");
        }
        [Test]
        public void Function11()
        {
            Action<string> BookAction = new Action<string>(Book);
            BookAction("百年孤獨");
        }
        public static void Book(string BookName)
        {
            Console.WriteLine("我是買書的是:{0}", BookName);
        }
        [Test]
        public void Function12()
        {
            Action<string, string> BookAction = new Action<string, string>(Book);
            BookAction("百年孤獨", "北京大書店");
        }
        public static void Book(string BookName, string ChangJia)
        {
            Console.WriteLine("我是買書的是:{0}來自{1}", BookName, ChangJia);
        }
        //Func會回傳值
        [Test]
        public void Function13()
        {
            Func<string> RetBook = new Func<string>(FuncBook);
            Console.WriteLine(RetBook);
        }
        public static string FuncBook()
        {
            return "送書來了";
        }

        //Func會回傳值，帶參數
        [Test]
        public void Function14()
        {
            Func<string, string> RetBook = new Func<string, string>(FuncBook);
            Console.WriteLine(RetBook("aaa"));
        }
        public static string FuncBook(string BookName)
        {
            return BookName;
        }

        public class Player
        {
            public string Name { get; set; }
            public int Score { get; set; }
            public DateTime Time { get; set; }
            public int Rank { get; set; }
        }
        public List<Player> players = new List<Player>();

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void SortByScoreAndTime()
        {
            players = players.OrderByDescending(p => p.Score)
                            .ThenBy(p => p.Time)
                            .ToList();
        }

        public void SetRanks()
        {
            int rank = 1;
            int prevScore = players[0].Score;
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Score < prevScore)
                {
                    rank = i + 1;
                    prevScore = players[i].Score;
                }
                players[i].Rank = rank;
            }
        }

        public void PrintLeaderboard()
        {
            Console.WriteLine("{0,-5} {1,-10} {2,-10} {3,-20}", "Rank", "Name", "Score", "Time");
            foreach (var player in players)
            {
                Console.WriteLine("{0,-5} {1,-10} {2,-10} {3,-20}", player.Rank, player.Name, player.Score, player.Time);
            }
            Console.Read();
        }
        [Test]
        public void Leaderboard()
        {
            AddPlayer(new Player { Name = "Alice", Score = 100, Time = new DateTime(2023, 3, 17, 12, 30, 0) });
            AddPlayer(new Player { Name = "Bob", Score = 90, Time = new DateTime(2023, 3, 17, 12, 31, 0) });
            AddPlayer(new Player { Name = "Charlie", Score = 80, Time = new DateTime(2023, 3, 17, 12, 32, 0) });
            AddPlayer(new Player { Name = "David", Score = 90, Time = new DateTime(2023, 3, 17, 12, 33, 0) });
            AddPlayer(new Player { Name = "Eve", Score = 70, Time = new DateTime(2023, 3, 17, 12, 34, 0) });

          SortByScoreAndTime();
          SetRanks();
          PrintLeaderboard();
        }

        [Test]
        public void AESToolTest()
        {
            AESTool aes = new AESTool("2F4D0E7D77D9FD81060B9D2348B57CB9");
            var a = aes.Decrypt("BNucN29KVQ2Q4e8UXfHdQUXsaQQikSKjGXNbYcNvZfOoSWH9YyJolnMWut/NauH4");
            var b = aes.Encrypt("http://localhost:49066/");
        }
        public class Boo
        {
            public double Val { get; set; }
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Foo
        {
            public int Val { get; set; }
            public string id { get; set; }
            public string text { get; set; }
        }
        [Test]
        public void Pocker()
        {
            string result = GetNuiCurrentLotteryNum("13,14,18,29,35,47,52,1,6,44");
        }
        public static string GetNuiCurrentLotteryNum(string numbers)
        {
            string result = string.Empty;
            if (numbers != string.Empty)
            {
                string[] nums = numbers.Split(',');
                for (int i = 0; i < nums.Length; i++)
                {
                    // 在每5个数字后添加文字"红方："
                    if (i == 5)
                    {
                        result += "<br>红方：";
                    }
                    // 在每一个数字后添加 ","
                    else if (i > 0)
                    {
                        result += ",";
                    }

                    result += GetCard(Convert.ToInt16(nums[i]));
                }
                // 在最终结果前添加文字"蓝方："
                result = "蓝方：" + result;
            }
            return result;
        }

        /// <summary>
        /// 由獎號取得花色和數字
        /// </summary>
        /// <param name="number">開出獎號</param>
        /// <returns>花色</returns>
        public static string GetCard(int number)
        {
            int suit = (number - 1) / 13;
            int rank = (number - 1) % 13;

            string suitSymbol = "";
            string rankSymbol = "";

            // 设置默认样式
            string suitStyle = "<span>";
            string rankStyle = "<span>";

            switch (suit)
            {
                case 0:
                    suitSymbol = "♦"; // 方块
                    suitStyle = "<span style=\"font-size:20px; color:red;\">";
                    rankStyle = "<span style=\"color:red;\">";
                    break;
                case 1:
                    suitSymbol = "♣"; // 梅花
                    break;
                case 2:
                    suitSymbol = "♥"; // 红心
                    suitStyle = "<span style=\"font-size:20px; color:red;\">";
                    rankStyle = "<span style=\"color:red;\">";
                    break;
                case 3:
                    suitSymbol = "♠"; // 黑桃
                    break;
            }

            switch (rank)
            {
                case 0:
                    rankSymbol = "A";
                    break;
                case 9:
                    rankSymbol = "10";
                    break;
                case 10:
                    rankSymbol = "J";
                    break;
                case 11:
                    rankSymbol = "Q";
                    break;
                case 12:
                    rankSymbol = "K";
                    break;
                default:
                    rankSymbol = (rank + 1).ToString();
                    break;
            }

            return suitStyle + suitSymbol + "</span>" + rankStyle + rankSymbol + "</span>";
        }
    }
}