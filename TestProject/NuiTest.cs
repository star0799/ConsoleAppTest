using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class NuiTest
    {
        [Test]
        public void Pocker()
        {
            //♦♣♥♠
            //♦K,♣A,♣5,♥3,♥9,♠8,♠K,♦A,♦6,♠5
            int[] drawNumbers = { 13, 14, 18, 29, 35, 47, 52, 1, 6, 44 };
            //int[] drawNumbers = { 11, 12, 3, 24,25, 45, 46, 47, 48, 49 };

            int[] firstFive = drawNumbers.Take(5).ToArray(); // 获取前5个数字
            int[] lastFive = drawNumbers.Skip(5).Take(5).ToArray(); // 获取后5个数字

            string firstFiveMatchedKey = FindMatchedKey(firstFive);
            string lastFiveMatchedKey = FindMatchedKey(lastFive);

            Console.WriteLine("前五个数字匹配的键: " + firstFiveMatchedKey);
            Console.WriteLine("后五个数字匹配的键: " + lastFiveMatchedKey);
        }
        static string FindMatchedKey(int[] numbers)
        {
            foreach (var kvp in Nui)
            {
                string key = kvp.Key;
                Tuple<decimal, Func<int[], bool>> nuiInfo = kvp.Value;
                Func<int[], bool> nuiFunction = nuiInfo.Item2;

                bool isMatch = nuiFunction(numbers);

                if (isMatch)
                {
                    return key;
                }
            }
            return "未找到匹配的键";
        }
        /// <summary>
        /// 牛牛的算法
        /// </summary>
        private static IDictionary<string, Tuple<decimal, Func<int[], bool>>> Nui => new Dictionary<string, Tuple<decimal, Func<int[], bool>>>()
        {
            {
                "无牛",
                new Tuple<decimal, Func<int[], bool>>(2.764M,
                    (drawNumbers) =>
                    {
                        var niuResult = GetNiu(drawNumbers);
                        return !niuResult.Item2;
                    })
            },
            {
                "牛一",
                new Tuple<decimal, Func<int[], bool>>(13.921M,
                    (drawNumbers) =>
                    {
                        var niuResult = GetNiu(drawNumbers);
                        return niuResult.Item2 && (niuResult.Item3 == 1);
                    })
            },
            {
                "牛二",
                new Tuple<decimal, Func<int[], bool>>(13.921M,
                    (drawNumbers) =>
                    {
                        var niuResult = GetNiu(drawNumbers);
                        return niuResult.Item2 && (niuResult.Item3 == 2);
                    })
            },
            {
                "牛三",
                new Tuple<decimal, Func<int[], bool>>(13.921M,
                    (drawNumbers) =>
                    {
                        var niuResult = GetNiu(drawNumbers);
                        return niuResult.Item2 && (niuResult.Item3 == 3);
                    })
            },
            {
                "牛四",
                new Tuple<decimal, Func<int[], bool>>(13.921M,
                    (drawNumbers) =>
                    {
                        var niuResult = GetNiu(drawNumbers);
                        return niuResult.Item2 && (niuResult.Item3 == 4);
                    })
            },
            {
                "牛五",
                new Tuple<decimal, Func<int[], bool>>(13.921M,
                    (drawNumbers) =>
                    {
                        var niuResult = GetNiu(drawNumbers);
                        return niuResult.Item2 && (niuResult.Item3 == 5);
                    })
            },
            {
                "牛六",
                new Tuple<decimal, Func<int[], bool>>(13.921M,
                    (drawNumbers) =>
                    {
                        var niuResult = GetNiu(drawNumbers);
                        return niuResult.Item2 && (niuResult.Item3 == 6);
                    })
            },
            {
                "牛七",
                new Tuple<decimal, Func<int[], bool>>(13.921M,
                    (drawNumbers) =>
                    {
                        var niuResult = GetNiu(drawNumbers);
                        return niuResult.Item2 && (niuResult.Item3 == 7);
                    })
            },
            {
                "牛八",
                new Tuple<decimal, Func<int[], bool>>(13.921M,
                    (drawNumbers) =>
                    {
                        var niuResult = GetNiu(drawNumbers);
                        return niuResult.Item2 && (niuResult.Item3 == 8);
                    })
            },
            {
                "牛九",
                new Tuple<decimal, Func<int[], bool>>(13.921M,
                    (drawNumbers) =>
                    {
                        var niuResult = GetNiu(drawNumbers);
                        return niuResult.Item2 && (niuResult.Item3 == 9);
                    })
            },
            {
                "花色牛",
                new Tuple<decimal, Func<int[], bool>>(1022.518M,
                    (drawNumbers) =>
                    {
                        var cards = GetCards(drawNumbers);
                        return cards.All(x => x.Item2 >= 11);
                    })
            },
            {
                "牛牛",
                new Tuple<decimal, Func<int[], bool>>(12.795M,
                    (drawNumbers) =>
                    {
                        var niuResult = GetNiu(drawNumbers);
                        return niuResult.Item2 && (niuResult.Item3 == 10);
                    })
            }
        };
        /// <summary>
        /// 取得牛牛的資料
        /// </summary>
        /// <param name="list">開出獎號</param>
        /// <returns>牛牛的資料</returns>
        public static Tuple<IList<int>, bool, int, bool> GetNiu(int[] list)
        {
            var converts = list.Select(x =>
            {
                var card = GetCard(x);
                if (card.Item2 < 10)
                {
                    return card.Item2;
                }
                return 10;
            }).ToArray();
            var candidate = Enumerable.Range(0, 5).ToList();
            var isNiu = false;
            for (var i = 0; i < converts.Length - 2; i++)
            {
                for (var j = i + 1; j < converts.Length - 1; j++)
                {
                    for (var k = j + 1; k < converts.Length; k++)
                    {
                        if ((converts[i] + converts[j] + converts[k]) % 10 == 0)
                        {
                            candidate.Remove(i);
                            candidate.Remove(j);
                            candidate.Remove(k);
                            isNiu = true;
                            var last = (converts[candidate[0]] +
                                converts[candidate[1]]) % 10;
                            return new Tuple<IList<int>, bool, int, bool>(candidate, isNiu, last == 0 ? 10 : last, list.All(x => x > 10));
                        }
                    }
                }
            }

            return new Tuple<IList<int>, bool, int, bool>(candidate, isNiu, 0, false);
        }
        /// <summary>
        /// 由獎號取得花色
        /// </summary>
        /// <param name="number">開出獎號</param>
        /// <returns>花色</returns>
        public static Tuple<int, int> GetCard(int number)
        {
            return new Tuple<int, int>((number - 1) / 13, (number - 1) % 13 + 1);
        }

        /// <summary>
        /// 由獎號取得花色
        /// </summary>
        /// <param name="numbers">開出獎號</param>
        /// <returns>花色</returns>
        public static Tuple<int, int>[] GetCards(int[] numbers)
        {
            return numbers.Select(x => GetCard(x)).ToArray();
        }
     }
}
