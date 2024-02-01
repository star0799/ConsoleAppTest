using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    internal class _300LongestIncreasingSubsequence
    {
        [Test]
        public void Main()
        {
            int[] nums = { 10, 9, 2, 5, 3, 7, 101, 18 };
            LengthOfLIS(nums);
        }
        public int LengthOfLIS(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            int[] dp = new int[nums.Length];
            dp[0] = 1;
            int maxLength = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                dp[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
                maxLength = Math.Max(maxLength, dp[i]);
            }

            return maxLength;
        }
    }
}
