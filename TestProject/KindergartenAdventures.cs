using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class KindergartenAdventures
    {
        [Test]
        public void Main()
        {
            //Test case
            //solve(new int[] { 1, 0, 0 });  //2
            //solve(new int[] { 0, 1, 2 });  //1
            //solve(new int[] { 1,2,3});
            solve(new int[] { 2, 4, 5 });
        }
        //Own run ok,submit fail
        //static int solve(int[] t)
        //{
        //    int len = t.Length;
        //    Dictionary<int, int> resultDic = new Dictionary<int, int>();
        //    for (int i = 0; i < len; i++)
        //    {
        //        int[] tempList = t;
        //        int count = 0;
        //        for (int j = 0; j < len; j++)
        //        {
        //            if (tempList[j] <= 0)
        //            {
        //                count++;
        //            }
        //            for (int k = 0; k < len; k++)
        //            {
        //                tempList[k] -= 1;
        //            }

        //        }
        //        resultDic.Add(i, count);
        //    }

        //    int max = 0;
        //    int result = int.MaxValue;
        //    foreach (var d in resultDic)
        //    {
        //        if (d.Value > max)
        //        {
        //            max = d.Value;
        //            result = d.Key;
        //        }
        //    }
        //    result += 1;
        //    return result;
        //}

        //other OK
        //static int solve(int[] t)
        //{
        //    int n = t.Length;
        //    int[] arr = new int[n + 1];

        //    for (int i = 0; i < n; i++)
        //    {
        //        if (t[i] - i > 0)
        //        {
        //            arr[i + 1] += 1;
        //            if (n - (t[i] - i) + 1 < n)
        //            {
        //                arr[n - (t[i] - i) + 1] -= 1;
        //            }
        //        }
        //        else
        //        {
        //            arr[0] += 1;
        //            if (i - t[i] + 1 < n)
        //            {
        //                arr[i - t[i] + 1] -= 1;
        //            }
        //            arr[i + 1] += 1;
        //            arr[n] -= 1;
        //        }
        //    }

        //    int index = 0;
        //    int count = 0;
        //    int max = 0;

        //    for (int i = 0; i < n; i++)
        //    {
        //        count += arr[i];
        //        if (count > max)
        //        {
        //            max = count;
        //            index = i + 1;
        //        }
        //    }

        //    return index;
        //}

        //other2 OK Good
        static int solve(int[] t)
        {
            int n = t.Length;
            int[] a = new int[n + 1];

            for (int i = 0; i < n; i++)
            {
                if (t[i] != 0 && t[i] != n)
                {
                    a[i + 1] += 1;
                    a[(i - t[i] + 1 + n) % n] -= 1;
                }
            }

            long maxSum = int.MinValue;
            long s = 0;
            int maxIndex = 1;

            for (int i = 0; i < n; i++)
            {
                s += a[i];

                if (s > maxSum)
                {
                    maxSum = s;
                    maxIndex = i + 1;
                }
            }

            return maxIndex;
        }

        //GPT Solution 1 , Run ok, Submit Time limit exceeded
        //static int solve(int[] t)
        //{
        //    int n = t.Length;
        //    int maxCompleted = 0;
        //    int startID = 0;

        //    for (int i = 0; i < n; i++)
        //    {
        //        int completed = 0;

        //        for (int j = 0; j < n; j++)
        //        {
        //            int index = (i + j) % n;
        //            if (t[index] <= j)
        //            {
        //                completed++;
        //            }
        //        }

        //        if (completed > maxCompleted)
        //        {
        //            maxCompleted = completed;
        //            startID = i + 1; // IDs are 1-indexed
        //        }
        //    }

        //    return startID;
        //}
    }
}
