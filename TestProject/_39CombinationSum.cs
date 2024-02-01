using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    internal class _39CombinationSum
    {
        [Test]
        public void Main()
        {
            int[] candidates = new int[] { 2, 3, 6, 7,10,11,12,23 };
            int target = 23;
            CombinationSum(candidates, target);
        }
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            List<int> currentCombination = new List<int>();
            List<int> indices = new List<int>();

            int index = 0;
            int sum = 0;

            while (true)
            {
                if (sum == target)
                {
                    List<int> combination = new List<int>();
                    foreach (int idx in indices)
                    {
                        combination.Add(candidates[idx]);
                    }
                    result.Add(combination);
                }

                if (sum >= target)
                {
                    if (indices.Count == 0)
                        break;

                    index = indices[indices.Count - 1];
                    indices.RemoveAt(indices.Count - 1);
                    sum -= candidates[index];
                    index++;
                }
                else
                {
                    if (index == candidates.Length)
                    {
                        if (indices.Count == 0)
                            break;

                        index = indices[indices.Count - 1];
                        indices.RemoveAt(indices.Count - 1);
                        sum -= candidates[index];
                        index++;
                    }
                    else
                    {
                        indices.Add(index);
                        sum += candidates[index];
                    }
                }
            }

            return result;
        }
    }
}
