using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Model;

namespace TestProject
{
    public class LeetCodeTest
    {
        [Test]
        public void Main()
        {
            //int[]取出兩個值相加為target最後回傳Index  ex. { 2, 7, 11, 14, 13, 196, 15 } , 26
            //11+15=26所以回傳2,6
            //var result = TwoSum(new int[] { 2, 7, 11, 14, 13, 196, 15 }, 26);

            //Merge(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3);

            //var result= AddTwoNumbers(new ListNode { val=2,next= new ListNode { val=4,next =new ListNode {val= 3,next=null} } }, new ListNode { val = 5, next = new ListNode { val = 6, next = new ListNode { val = 8, next= new ListNode { val = 9, next = null } } } });
            //var result = LengthOfLongestSubstring("pwwkew");
            //var result = FindMedianSortedArrays(new int[] { 11, 13 },new int[] {12});
            //var result = LongestPalindrome("abaccccqwerewq");
        }
        //1. Two Sum 從陣列裡取出兩個數字相加等於target
        //Solved
        //Easy
        //Topics
        //Companies
        //Hint
        //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

        //You may assume that each input would have exactly one solution, and you may not use the same element twice.

        //You can return the answer in any order.

        //Example 1:
        //Input: nums = [2, 7, 11, 15], target = 9
        //Output: [0,1]
        //Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

        //Example 2:
        //Input: nums = [3, 2, 4], target = 6
        //Output: [1,2]

        //Example 3:
        //Input: nums = [3, 3], target = 6
        //Output: [0,1]


        //Constraints:

        //2 <= nums.length <= 104
        //-109 <= nums[i] <= 109
        //-109 <= target <= 109
        //Only one valid answer exists.

        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> numIndexMap = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                if (numIndexMap.ContainsKey(complement))
                {
                    return new int[] { numIndexMap[complement], i };
                }

                if (!numIndexMap.ContainsKey(nums[i]))
                {
                    numIndexMap[nums[i]] = i;
                }
            }

            throw new InvalidOperationException("找不到解答");
        }
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int p1 = m - 1;
            int p2 = n - 1;
            int p = m + n - 1;

            while (p1 >= 0 && p2 >= 0)
            {
                if (nums1[p1] > nums2[p2])
                {
                    nums1[p] = nums1[p1];
                    p1--;
                }
                else
                {
                    nums1[p] = nums2[p2];
                    p2--;
                }
                p--;
            }

            while (p2 >= 0)
            {
                nums1[p] = nums2[p2];
                p2--;
                p--;
            }
        }

        //2. Add Two Numbers 兩節點相加
        //Medium
        //Topics
        //Companies
        //You are given two non-empty linked lists representing two non-negative integers.The digits are stored in reverse order, and each of their nodes contains a single digit.Add the two numbers and return the sum as a linked list.

        //You may assume the two numbers do not contain any leading zero, except the number 0 itself.

        //Example 1:
        //Input: l1 = [2,4,3], l2 = [5,6,4]
        //Output: [7,0,8]
        //Explanation: 342 + 465 = 807.

        //Example 2:
        //Input: l1 = [0], l2 = [0]
        //Output: [0]

        //Example 3:
        //Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
        //Output: [8,9,9,9,0,0,0,1]

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode();
            ListNode current = dummyHead;
            int carry = 0;

            while (l1 != null || l2 != null || carry != 0)
            {
                int val1 = (l1 != null) ? l1.val : 0;
                int val2 = (l2 != null) ? l2.val : 0;

                int sum = val1 + val2 + carry;

                carry = sum / 10;
                int digit = sum % 10;

                current.next = new ListNode(digit);
                current = current.next;

                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }

            return dummyHead.next;
        }

        //3. Longest Substring Without Repeating Characters (沒有重複字元的最長子串)
        //Medium
        //Topics
        //Companies
        //Given a string s, find the length of the longest
        //substring
        // without repeating characters.

        //Example 1:       
        //Input: s = "abcabcbb"
        //Output: 3
        //Explanation: The answer is "abc", with the length of 3.

        //Example 2:       
        //Input: s = "bbbbb"
        //Output: 1
        //Explanation: The answer is "b", with the length of 1.

        //Example 3:      
        //Input: s = "pwwkew"
        //Output: 3
        //Explanation: The answer is "wke", with the length of 3.
        //Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.


        //Constraints:

        //0 <= s.length <= 5 * 104
        //s consists of English letters, digits, symbols and spaces.

        public int LengthOfLongestSubstring(string s)
        {
            //雙指標做法
            HashSet<char> charIndexMap = new HashSet<char>();
            int maxLength = 0;
            int left = 0;
            int right = 0;
            //從右指標開始往前跑
            while (right < s.Length)
            {
                //沒遇到重覆值則把此字符寫入，並且取出目前的長度(頭-尾+1)
                if (!charIndexMap.Contains(s[right]))
                {
                    charIndexMap.Add(s[right]);
                    maxLength=Math.Max(maxLength, right-left+1);
                    right++;
                }
                //遇到重覆字符則移除左邊一格
                else
                {
                    charIndexMap.Remove(s[left]);
                    left++;
                }
            }
            return maxLength;
        }


        //4. Median of Two Sorted Arrays
        //Hard
        //Topics
        //Companies
        //Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.

        //The overall run time complexity should be O(log (m+n)).

        //Example 1:
        //Input: nums1 = [1,3], nums2 = [2]
        //        Output: 2.00000
        //Explanation: merged array = [1, 2, 3] and median is 2.

        //Example 2:
        //Input: nums1 = [1,2], nums2 = [3,4]
        //        Output: 2.50000
        //Explanation: merged array = [1, 2, 3, 4] and median is (2 + 3) / 2 = 2.5.

        //Constraints:

        //nums1.length == m
        //nums2.length == n
        //0 <= m <= 1000
        //0 <= n <= 1000
        //1 <= m + n <= 2000
        //-106 <= nums1[i], nums2[i] <= 106

        //自行完成
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            List<int> list = new List<int>();
            list.AddRange(nums1);
            list.AddRange(nums2);
            list.Sort();
            if (list.Count == 0)
                return 0;
            if (list.Count % 2 == 0)
            {
                return (double)(list[(list.Count / 2) - 1] + list[(list.Count / 2)]) / 2;
            }
            else
            {
                return list[(int)(list.Count / 2)];
            }
        }


        //4.1兩個陣列排序
        private int[] MergeArrays(int[] nums1, int[] nums2)
        {
            int[] mergedArray = new int[nums1.Length + nums2.Length];
            int i = 0, j = 0, k = 0;

            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] < nums2[j])
                {
                    mergedArray[k] = nums1[i];
                    i++;
                    k++;
                }
                else
                {
                    mergedArray[k] = nums2[j];
                    k++;
                    j++;
                }
            }

            while (i < nums1.Length)
            {
                mergedArray[k] = nums1[i];
                k++;
                i++;
            }

            while (j < nums2.Length)
            {
                mergedArray[k] = nums2[j];
                k++;
                j++;
            }

            return mergedArray;
        }

        //5. Longest Palindromic Substring (取最長的回文字串)
        //Medium
        //Topics
        //Companies
        //Hint
        //Given a string s, return the longest
        //palindromic

        //substring
        // in s.

        //Example 1:
        //Input: s = "babad"
        //Output: "bab"
        //Explanation: "aba" is also a valid answer.

        //Example 2:
        //Input: s = "cbbd"
        //Output: "bb"


        //Constraints:

        //1 <= s.length <= 1000
        //s consist of only digits and English letters.
        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            string currentLongest = "";

            for (int i = 0; i < s.Length; i++)
            {
                // 以当前字符为中心的最长回文串（奇数长度）
                string odd = GetLongest(s, i - 1, i + 1);
                // 以当前字符和下一个字符的间隙为中心的最长回文串（偶数长度）
                string even = GetLongest(s, i, i + 1);

                // 取两者中的较长者
                string longest = odd.Length > even.Length ? odd : even;

                // 更新当前最长回文串
                currentLongest = currentLongest.Length > longest.Length ? currentLongest : longest;
            }

            return currentLongest;
        }

        private string GetLongest(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }
            // 返回回文串的部分字符串
            return s.Substring(left + 1, right - left - 1);
        }
    }
}
