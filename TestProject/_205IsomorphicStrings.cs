using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    internal class _205IsomorphicStrings
    {
        [Test]
        public void Main()
        {
            string s = "egg";
            string t=  "add";
            IsIsomorphic(s,t);
        }

        //myself v2 OK
        //public bool IsIsomorphic(string s, string t)
        //{
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        for (int j = i + 1; j < s.Length; j++)
        //        {
        //            if ((s[i] == s[j] && t[i] != t[j]) || (s[i] != s[j] && t[i] == t[j]))
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    return true;
        //}
        //myself OK
        //public bool IsIsomorphic(string s, string t)
        //{

        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        for (int j = 0; j < s.Length; j++)
        //        {
        //            if (i != j)
        //            {
        //                if (s[i] == s[j])
        //                {
        //                    if (t[i] != t[j])
        //                    {
        //                        return false;
        //                    }
        //                }

        //                if (t[i] == t[j])
        //                {
        //                    if (s[i] != s[j])
        //                    {
        //                        return false;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return true;
        //}

        //public bool IsIsomorphic(string s, string t)
        //{
        //    string tempS = s;
        //    string tempT = t;
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        tempS = tempS.Replace(tempS[i], t[i]);
        //        tempT = tempT.Replace(tempT[i], s[i]);
        //    }
        //    if (t == tempS && s == tempT)
        //        return true;
        //    else
        //        return false;
        //}

        //Best 利用字符的代號來壘加某字符出現幾次進行比對是否同構
        public bool IsIsomorphic(string s, string t)
        {
            var n = s.Length;
            // initialized space is 256
            // (Since the whole ASCII size is 256, 128 also works here)
            var m1 = new int[256];
            var m2 = new int[256];

            for (var index = 0; index < n; ++index)
            {
                //It can be, but we've numbers
                //var m1Value = s[index] - 'a';
                //var m2Value = t[index] - 'a';

                if (m1[s[index]] != m2[t[index]]) return false;

                m1[s[index]] = index + 1;
                m2[t[index]] = index + 1;
            }

            return true;
        }



        //Time Limit Exceeded
        //public bool IsIsomorphic(string s, string t)
        //{
        //    List<List<int>> indexListS = new List<List<int>>();
        //    List<List<int>> indexListT = new List<List<int>>();

        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        List<int> listS = new List<int>();
        //        List<int> listT = new List<int>();
        //        for (int j = 0; j < s.Length; j++)
        //        {
        //            if (i != j)
        //            {
        //                if (s[i] == s[j])
        //                {
        //                    listS.Add(i);
        //                    listS.Add(j);
        //                }
        //                if (t[i] == t[j])
        //                {
        //                    listT.Add(i);
        //                    listT.Add(j);
        //                }
        //            }
        //        }
        //        indexListS.Add(listS);
        //        indexListT.Add(listT);
        //    }
        //    for (int i = 0; i < indexListS.Count; i++)
        //    {
        //        if (!indexListS[i].SequenceEqual(indexListT[i]))
        //            return false;
        //    }
        //    return true;
        //}
    }
}
