using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class UnitTest2
    {
        [Test]
        public static void MainDynamicArray()
        {
            //dynamicArray(1,new List<List<int>>());
            //rotateLeft(4, new List<int>() { 1, 2, 3,4,5});
            //matchingStrings(new List<string> { "aba", "baba", "aba", "xzxb" }, new List<string> { "aba", "xzxb", "ab" });

            //arrayManipulationGPT(10, new List<List<int>> 
            //{  
            //    new List<int> { 2,6,8 },
            //    new List<int> { 3,5,7 },
            //    new List<int> { 1,8,1 },
            //    new List<int> { 5,9,15 }
            //});

            // solve2(new long[] {1,2,7,3,4}, new long[][] 
            // {
            //   new long[] { 1, 5, 3 },
            //   new long[] { 2, 4, 6 },
            //   new long[] { 3, 5, 2 }
            //});
            ReflectionFun();
;        }

        public static List<int> dynamicArray(int n, List<List<int>> queries)
        {
            //塞入測試參數
            n = 2;
            // 添加第一個查詢 [1, 0, 5]
            List<int> query1 = new List<int> { 1, 0, 5 };
            queries.Add(query1);

            // 添加第二個查詢 [1, 1, 7]
            List<int> query2 = new List<int> { 1, 1, 7 };
            queries.Add(query2);

            // 添加第三個查詢 [1, 0, 3]
            List<int> query3 = new List<int> { 1, 0, 3 };
            queries.Add(query3);

            // 添加第四個查詢 [2, 1, 0]
            List<int> query4 = new List<int> { 2, 1, 0 };
            queries.Add(query4);

            // 添加第五個查詢 [2, 1, 1]
            List<int> query5 = new List<int> { 2, 1, 1 };
            queries.Add(query5);

            //開始方法
            List<List<int>> arr = new List<List<int>>(n);
            for (int i = 0; i < n; i++)
            {
                arr.Add(new List<int>());
            }

            List<int> answers = new List<int>();
            int lastAnswer = 0;

            foreach (List<int> query in queries)
            {
                int queryType = query[0];
                int x = query[1];
                int y = query[2];

                int index = (x ^ lastAnswer) % n;
                List<int> seq = arr[index];

                if (queryType == 1)
                {
                    seq.Add(y);
                }
                else if (queryType == 2)
                {
                    int size = seq.Count;
                    lastAnswer = seq[y % size];
                    answers.Add(lastAnswer);
                }
            }
            return answers;
        }
        public static List<int> dynamicArray2(int n, List<List<int>> queries)
        {
            //塞入測試參數
            n = 2;
            // 添加第一個查詢 [1, 0, 5]
            List<int> query1 = new List<int> { 1, 0, 5 };
            queries.Add(query1);

            // 添加第二個查詢 [1, 1, 7]
            List<int> query2 = new List<int> { 1, 1, 7 };
            queries.Add(query2);

            // 添加第三個查詢 [1, 0, 3]
            List<int> query3 = new List<int> { 1, 0, 3 };
            queries.Add(query3);

            // 添加第四個查詢 [2, 1, 0]
            List<int> query4 = new List<int> { 2, 1, 0 };
            queries.Add(query4);

            // 添加第五個查詢 [2, 1, 1]
            List<int> query5 = new List<int> { 2, 1, 1 };
            queries.Add(query5);

            List<int> result=new List<int>();
            List<List<int>> arr = new List<List<int>>();
            for(int i = 0; i < n; i++)
            {
                arr.Add(new List<int>());
            }
            int lastAnswer = 0;
            foreach (var q in queries)
            {
                int queryType = q[0];
                int x = q[1];
                int y = q[2];
                
                int idx = (x ^ lastAnswer) % n;
                if (queryType == 1)
                {
                    arr[idx].Add(y);
                }
                else if (queryType == 2)
                {
                    int count = arr[idx].Count;
                    lastAnswer = arr[idx][y % count];
                    result.Add(lastAnswer);
                }
            }
            return result;
        }
        public static List<int> rotateLeft(int d, List<int> arr)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < d; i++)
            {
                arr.Add(arr[arr.Count - 1]);
                arr.Remove(arr[0]);
            }
            return arr;
        }
        //public static List<int> rotateLeftGpt(int d, List<int> arr)
        //{
        //    int n = arr.Count;
        //    int rotateCount = d % n;

        //    List<int> rotatedArr = new List<int>(n);

        //    for (int i = rotateCount; i < n; i++)
        //    {
        //        rotatedArr.Add(arr[i]);
        //    }

        //    for (int i = 0; i < rotateCount; i++)
        //    {
        //        rotatedArr.Add(arr[i]);
        //    }

        //    return rotatedArr;
        //}

        public static List<int> matchingStrings(List<string> stringList, List<string> queries)
        {
            List<int> result = new List<int>();
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (var q in queries)
            {
                foreach (var s in stringList)
                {
                    if (!dic.ContainsKey(q))
                    {
                        dic.Add(q, 0);
                    }
                    if (q == s)
                    {
                        dic[q]++;
                    }
                }
            }
            foreach (var d in dic.Values)
            {
                result.Add(d);
            }
            return result;
        }

        //會死在執行超過時間
        //public static long arrayManipulation(int n, List<List<int>> queries)
        //{
        //    long result = 0;
        //    List<int> resultList = new List<int>();
        //    for (int i = 0; i < n; i++)
        //    {
        //        resultList.Add(0);
        //    }
        //    for (int i = 0; i < queries.Count; i++)
        //    {
        //        int a = queries[i][0];
        //        int b = queries[i][1];
        //        int k = queries[i][2];
        //        for (int j = a - 1; j <= b - 1; j++)
        //        {
        //            resultList[j] += k;
        //        }
        //    }
        //    result = resultList.Max();
        //    return result;
        //}

        //利用差分数组和前缀和求出最大值
        public static long arrayManipulationGPT(int n, List<List<int>> queries)
        {
            long[] arr = new long[n + 1];

            // 执行每个查询操作
            foreach (List<int> query in queries)
            {
                int a = query[0];
                int b = query[1];
                int k = query[2];

                // 更新前缀和数组，不用範圍內都增加只需起始位置+k，(終點+1)-k，一加一減差值才相同
                arr[a] += k;
                if (b + 1 <= n)
                    arr[b + 1] -= k;
            }

            // 计算前缀和并找到最大值，從第一項壘加加完後結果再加到第二項...
            long max = 0;
            long prefixSum = 0;
            for (int i = 1; i <= n; i++)
            {
                prefixSum += arr[i];
                if (prefixSum > max)
                    max = prefixSum;
            }

            return max;
        }
        //額外使用差分数组和前缀和取陣列的方式
        //public static List<long> arrayManipulationList(int n, List<List<int>> queries)
        //{
        //    //当我们计算前缀和时，前缀和数组中的第一个元素 arr[0] 通常被初始化为0，所以在這邊一開始第一項塞0後續才塞資料
        //    //之後在取總合那的迴圈則是用1為起始
        //    long[] arr = new long[n + 1];
        //    List<long> result=new List<long> ();

        //    // 执行每个查询操作
        //    foreach (List<int> query in queries)
        //    {
        //        int a = query[0];
        //        int b = query[1];
        //        int k = query[2];

        //        // 更新前缀和数组，不用範圍內都增加只需起始位置+k，(終點+1)-k，一加一減差值才相同
        //        arr[a] += k;
        //        if (b + 1 <= n)
        //            arr[b + 1] -= k;
        //    }

        //    long prefixSum = 0;
        //    for (int i = 1; i <= n; i++)
        //    {
        //        prefixSum += arr[i];
        //        result.Add(prefixSum);
        //    }
        //    return result;
        //}
        static long[] solve(long[] a, long[][] queries)
        {
            long[] result = new long[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                long l = queries[i][0];
                long r = queries[i][1];
                long x = queries[i][2];
                long count = 0;
                for (int j = 0; j < a.Length; j++)
                {
                    long bitwiseAnd = a[j];
                    for (int k = j; k < a.Length; k++)
                    {
                        bitwiseAnd &= a[k];
                        if (bitwiseAnd <= x)
                            count++;
                        //else
                        //    break;
                    }
                }

                result[i] = count;
            }
            return result;
        }

        static long[] solve2(long[] a, long[][] queries)
        {
            int q = queries.Length;
            long[] result = new long[q];

            for (int k = 0; k < q; ++k)
            {
                long l = queries[k][0] - 1;
                long r = queries[k][1] - 1;
                long x = queries[k][2];
                long count = 0;
                long start = l;
                long end = l;

                while (start <= r)
                {
                    long prod = 1;

                    for (long j = start; j <= end; ++j)
                    {
                        prod = (j == start) ? a[j] : (prod & a[j]);
                    }

                    if (prod <= x)
                    {
                        ++count;
                    }

                    if (end < r)
                    {
                        ++end;
                    }
                    else
                    {
                        ++start;
                        end = start;
                    }
                }

                result[k] = count;
            }

            return result;
        }
        static void ReflectionFun()
        {
            string myString = "Hello, Reflection!";

            // 使用 GetType() 獲取物件的型別
            Type typeOfString = myString.GetType();

            // 顯示型別名稱
            Console.WriteLine($"Type of myString: {typeOfString.FullName}");

            // 獲取物件的方法
            MethodInfo[] methods = typeOfString.GetMethods();
            Console.WriteLine("Methods in myString:");
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }
        }
    }
}
