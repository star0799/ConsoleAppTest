using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class RecursiveTest
    {
        string result;
        [Test]
        public void Main()
        {
            //ReciprocalNum(20);
            int n = 10;
            for (int i = 0; i < n; i++)
            {
                result += " " + Fibonacci(i);
            }
        }
        //數字倒數
        void ReciprocalNum(int n)
        {
            if (n == 0)
            {
                result += "0";
                return;
            }
            result += n + ",";
            ReciprocalNum(n - 1);
        }

        int Fibonacci(int n)
        {
            if (n <= 1)
                return n;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
