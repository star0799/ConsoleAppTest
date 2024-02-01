using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    internal class _2761PrimePairsWithTargetSum
    {
        [Test]
        public void Main()
        {
            int num = 100;
            FindPrimePairs(num);
        }
        public IList<IList<int>> FindPrimePairs(int n)
        {
            IList<IList<int>> result = new List<IList<int>>();
            for (int i = 1; i <= n / 2; i++)
            {
                if (IsPrimeNumber(i) && IsPrimeNumber(n - i))
                {
                    IList<int> list = new List<int>();
                    list.Add(i);
                    list.Add(n - i);
                    result.Add(list);
                }
            }
            return result;
        }
        
        bool IsPrimeNumber(int num)
        {
            if (num <= 1)
            {
                return false;
            }

            if (num == 2)
            {
                return true;
            }

            if (num % 2 == 0)
            {
                return false;
            }

            // Check divisibility up to the square root of num
            //直接排除偶數，偶數除了2必定是合數
            for (int i = 3; i <= Math.Sqrt(num); i += 2)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
