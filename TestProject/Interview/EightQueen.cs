using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Interview
{
    public class EightQueen
    {
        static List<int> queenX = new List<int>();
        static List<int> queenY = new List<int>();
        static int succCount = 0;
        public static void QueenFun(int n)
        {
            int rj = 1;
            for (int i = queenX.Count + 1; i <= n; i++)
            {
                for (int j = rj; j <= n; j++)
                {
                    if (CheckQueen(i, j, queenX, queenY))
                    {
                        queenX.Add(i);
                        queenY.Add(j);
                        rj = 1;
                        if (queenX.Count == n && queenY.Count == n)
                        {
                            InsertSucc();
                            rj = queenY[i - 1] + 1;
                            if (rj > n)
                            {
                                int temp = queenY[i - 2] + 1;
                                queenX.RemoveAt(i - 1);
                                queenY.RemoveAt(i - 1);
                                queenX.RemoveAt(i - 2);
                                queenY.RemoveAt(i - 2);
                                i -= 2;
                                rj = temp;
                            }
                            else
                            {
                                queenX.RemoveAt(i - 1);
                                queenY.RemoveAt(i - 1);
                                i--;
                            }

                        }
                        break;
                    }
                    if (j == n)
                    {
                        if (i < 2)
                        {
                            i = n + 1;
                            break;
                        }
                        rj = queenY[i - 2] + 1;
                        if (rj > n)
                        {
                            if (i < 3)
                            {
                                i = n + 1;
                                break;
                            }
                            int temp = queenY[i - 3] + 1;
                            queenX.RemoveAt(i - 2);
                            queenY.RemoveAt(i - 2);
                            queenX.RemoveAt(i - 3);
                            queenY.RemoveAt(i - 3);
                            i = queenX.Count;
                            rj = temp;
                        }
                        else
                        {
                            queenX.RemoveAt(i - 2);
                            queenY.RemoveAt(i - 2);
                            i -= 2;
                        }
                        break;
                    }
                }
            }
        }
        public static bool CheckQueen(int putX, int putY, List<int> x, List<int> y)
        {
            for (int i = 0; i < x.Count; i++)
            {
                if (putX == x[i])
                    return false;
                if (putY == y[i])
                    return false;
                if (putX - putY == x[i] - y[i])
                    return false;
                if (putX + putY == x[i] + y[i])
                    return false;
            }
            return true;
        }
        static void InsertSucc()
        {
            string temp = "";
            string result = "";
            succCount++;
            Console.WriteLine("Solution: " + succCount);
            for (int i = 0; i < queenX.Count; i++)
            {
                for (int y = 1; y <= queenY.Count - 1; y++)
                    temp += ".";
                result = temp.Insert(queenY[i] - 1, "Q");
                Console.WriteLine(result);
                temp = "";
            }
        }
    }
}
