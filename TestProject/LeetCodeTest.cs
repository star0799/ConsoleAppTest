using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            //var result = ConvertFun("PAYPALISHIRING", 3);
            //var result = ReverseFun(120);
            //var result = MyAtoi("a          -852166    ");
            //var result = IsPalindrome(122);
            var result = IsMatch("aa", "a");
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
                    maxLength = Math.Max(maxLength, right - left + 1);
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

        //6. Zigzag Conversion 鋸齒文字
        //Medium
        //Topics
        //Companies
        //The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

        //P   A   H   N
        //A P L S I I G
        //Y   I   R
        //And then read line by line: "PAHNAPLSIIGYIR"

        //Write the code that will take a string and make this conversion given a number of rows:

        //string convert(string s, int numRows);


        //Example 1:
        //Input: s = "PAYPALISHIRING", numRows = 3
        //Output: "PAHNAPLSIIGYIR"

        //Example 2:
        //Input: s = "PAYPALISHIRING", numRows = 4
        //Output: "PINALSIGYAHRPI"
        //Explanation:
        //P     I    N
        //A   L S  I G
        //Y A   H R
        //P     I

        //Example 3:
        //Input: s = "A", numRows = 1
        //Output: "A"

        //Constraints:

        //1 <= s.length <= 1000
        //s consists of English letters(lower-case and upper-case), ',' and '.'.
        //1 <= numRows <= 1000

        //自解
        //public string ConvertFun(string s, int numRows)
        //{
        //    if (numRows <= 1)
        //        return s;
        //    string result = string.Empty;
        //    Dictionary<Tuple<int,int>, char> points = new Dictionary<Tuple<int, int>, char>();
        //    bool isUp = false;
        //    int x = 0;
        //    int y = 0;
        //    int maxy = 0;
        //    for (int i=0;i< s.Length; i++)
        //    {
        //        points.Add(Tuple.Create(x,y), s[i]);

        //        if (i % (numRows-1) == 0 && i != 0)
        //        {
        //            isUp = !isUp;
        //        }

        //        if (isUp)
        //        {
        //            x++;
        //            y--;
        //        }
        //        else
        //        {
        //            y++;
        //            maxy++;
        //        }
        //    }

        //    for (int j = 0; j <= maxy; j++)
        //    {
        //        for(int i = 0; i <= x; i++)
        //        {
        //            if(points.ContainsKey(Tuple.Create(i,j)))
        //            {
        //               result += points[Tuple.Create(i, j)].ToString();
        //            }                   
        //        }
        //    }
        //    return result;
        //}

        //Solution 2 GPT
        //
        //public static string ConvertFun(string s, int numRows)
        //{
        //    if (numRows == 1 || numRows >= s.Length)
        //    {
        //        return s;
        //    }

        //    StringBuilder[] rows = new StringBuilder[numRows];
        //    for (int i = 0; i < numRows; i++)
        //    {
        //        rows[i] = new StringBuilder();
        //    }

        //    int index = 0;
        //    int direction = 1;

        //    foreach (char c in s)
        //    {
        //        rows[index].Append(c);

        //        if (index == 0)
        //        {
        //            direction = 1;
        //        }
        //        else if (index == numRows - 1)
        //        {
        //            direction = -1;
        //        }

        //        index += direction;
        //    }

        //    StringBuilder result = new StringBuilder();
        //    foreach (var row in rows)
        //    {
        //        result.Append(row);
        //    }

        //    return result.ToString();
        //}

        //Solution 3 用GPT方法改編
        public static string ConvertFun(string s, int numRows)
        {
            string result = string.Empty;
            int index = 0;
            string[] array = new string[numRows];
            bool isDown = true;
            foreach (var c in s)
            {
                array[index] += c.ToString();
                if (isDown)
                {
                    index++;
                }
                else
                {
                    index--;
                }
                if (index == 0 || index == numRows - 1)
                    isDown = !isDown;
            }
            foreach (var a in array)
            {
                result += a;
            }
            return result;
        }

        //7. Reverse Integer 反轉數字
        //Medium
        //Topics
        //Companies
        //Given a signed 32-bit integer x, return x with its digits reversed.If reversing x causes the value to go outside the signed 32-bit integer range[-231, 231 - 1], then return 0.

        //Assume the environment does not allow you to store 64-bit integers(signed or unsigned).



        //Example 1:

        //Input: x = 123
        //Output: 321
        //Example 2:

        //Input: x = -123
        //Output: -321
        //Example 3:

        //Input: x = 120
        //Output: 21


        //GPT
        //public int ReverseFun(int x)
        //{
        //    // 处理特殊情况 int.MinValue
        //    if (x == int.MinValue)
        //    {
        //        return 0;
        //    }

        //    // 将整数转换为字符串
        //    string numString = Math.Abs(x).ToString();
        //    // 利用 StringBuilder 存储反转后的字符串
        //    StringBuilder reversedString = new StringBuilder();

        //    // 反转字符串
        //    for (int i = numString.Length - 1; i >= 0; i--)
        //    {
        //        reversedString.Append(numString[i]);
        //    }

        //    // 尝试将反转后的字符串转换为长整数
        //    long reversed;
        //    if (long.TryParse(reversedString.ToString(), out reversed))
        //    {
        //        // 若原数字为负数，则反转后也是负数
        //        if (x < 0)
        //        {
        //            reversed *= -1;
        //        }
        //        // 检查是否溢出 int 范围
        //        if (reversed > int.MaxValue || reversed < int.MinValue)
        //        {
        //            return 0;
        //        }
        //        return (int)reversed;
        //    }
        //    else
        //    {
        //        // 转换失败，说明溢出了，返回0
        //        return 0;
        //    }
        //}

        //自解
        public int ReverseFun(int x)
        {
            try
            {
                string result = string.Empty;
                string numString = x.ToString();
                string dight = string.Empty;
                int variable = 0;
                if (numString[0] == '-')
                {
                    dight = "-";
                    variable = 1;
                }
                for (int i = numString.Length - 1; i >= 0 + variable; i--)
                {
                    result += numString[i];
                }
                result = dight + result;
                return Convert.ToInt32(result);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        // 8. String to Integer(atoi)
        //Medium
        //Topics
        //Companies
        //Implement the myAtoi(string s) function, which converts a string to a 32-bit signed integer(similar to C/C++'s atoi function).

        //The algorithm for myAtoi(string s) is as follows:

        //Read in and ignore any leading whitespace.
        //Check if the next character (if not already at the end of the string) is '-' or '+'. Read this character in if it is either.This determines if the final result is negative or positive respectively. Assume the result is positive if neither is present.
        //Read in next the characters until the next non-digit character or the end of the input is reached.The rest of the string is ignored.
        //Convert these digits into an integer (i.e. "123" -> 123, "0032" -> 32). If no digits were read, then the integer is 0. Change the sign as necessary (from step 2).
        //If the integer is out of the 32-bit signed integer range[-231, 231 - 1], then clamp the integer so that it remains in the range.Specifically, integers less than -231 should be clamped to -231, and integers greater than 231 - 1 should be clamped to 231 - 1.
        //Return the integer as the final result.
        //Note:


        //Only the space character ' ' is considered a whitespace character.
        //Do not ignore any characters other than the leading whitespace or the rest of the string after the digits.



        //Example 1:


        //Input: s = "42"
        //Output: 42
        //Explanation: The underlined characters are what is read in, the caret is the current reader position.
        //Step 1: "42" (no characters read because there is no leading whitespace)
        //         ^
        //Step 2: "42" (no characters read because there is neither a '-' nor '+')
        //         ^
        //Step 3: "42" ("42" is read in)
        //           ^
        //The parsed integer is 42.
        //Since 42 is in the range[-231, 231 - 1], the final result is 42.
        //Example 2:

        //Input: s = "   -42"
        //Output: -42
        //Explanation:
        //Step 1: "   -42" (leading whitespace is read and ignored)
        //            ^
        //Step 2: "   -42" ('-' is read, so the result should be negative)
        //             ^
        //Step 3: "   -42" ("42" is read in)
        //               ^
        //The parsed integer is -42.
        //Since -42 is in the range[-231, 231 - 1], the final result is -42.
        //Example 3:

        //Input: s = "4193 with words"
        //Output: 4193
        //Explanation:
        //Step 1: "4193 with words" (no characters read because there is no leading whitespace)
        //         ^
        //Step 2: "4193 with words" (no characters read because there is neither a '-' nor '+')
        //         ^
        //Step 3: "4193 with words" ("4193" is read in; reading stops because the next character is a non-digit)
        //             ^
        //The parsed integer is 4193.
        //Since 4193 is in the range[-231, 231 - 1], the final result is 4193.



        //Constraints:

        //0 <= s.length <= 200
        //s consists of English letters(lower-case and upper-case), digits(0-9), ' ', '+', '-', and '.'.

        //自解
        //public int MyAtoi(string s)
        //{
        //    string result = string.Empty;
        //    s = s.Trim();
        //    if (string.IsNullOrEmpty(s))
        //        return 0;
        //    int dight = 1;
        //    int start = 0;
        //    if (s == "+")
        //        return 0;
        //    else if (s == "-")
        //        return 0;
        //    if (s[0] == '+')
        //    {
        //        start = 1;
        //    }
        //    else if (s[0] == '-')
        //    {
        //        start = 1;
        //        dight = -1;
        //    }
        //    try
        //    {
        //        for (int i = start; i < s.Length; i++)
        //        {
        //            int o = 0;
        //            if (int.TryParse(s[i].ToString(), out o))
        //            {
        //                result += o;
        //            }
        //            else
        //            {
        //                if (result.Trim() == "")
        //                    return 0;
        //                else
        //                    break;
        //            }
        //        }
        //        return dight * Convert.ToInt32(result);
        //    }
        //    catch
        //    {
        //        if (dight == -1)
        //            return int.MinValue;
        //        else
        //            return int.MaxValue;
        //    }
        //}

        //佳解。參考LeetCode
        public int MyAtoi(string s)
        {
            s = s.Trim();
            if (string.IsNullOrEmpty(s)) return 0;
            int sign = 1; long num = 0;
            int i = 0;
            if (s[i] == '+' || s[i] == '-')
            {
                sign = s[i++] == '-' ? -1 : 1;
            }

            for (; i < s.Length && Char.IsDigit(s[i]); i++)
            {
                num = num * 10 + s[i] - '0';
                if (num * sign >= int.MaxValue) return int.MaxValue;
                else if (num * sign <= int.MinValue) return int.MinValue;
            }
            return (int)(num * sign);
        }

        //9. Palindrome Number 判斷數字是否回文
        //Easy
        //Topics
        //Companies
        //Hint
        //Given an integer x, return true if x is a
        //palindrome
        //, and false otherwise.

        //Example 1:
        //Input: x = 121
        //Output: true
        //Explanation: 121 reads as 121 from left to right and from right to left.

        //Example 2:
        //Input: x = -121
        //Output: false
        //Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.

        //Example 3:
        //Input: x = 10
        //Output: false
        //Explanation: Reads 01 from right to left.Therefore it is not a palindrome.

        //Constraints:

        //-231 <= x <= 231 - 1
        //自解
        //public bool IsPalindrome(int x)
        //{
        //    string temp =x.ToString();
        //    string palindromeString = string.Empty;
        //    int i = 0;
        //    if (temp[i]=='-')
        //    {
        //        return false;
        //    }
        //    for (i= temp.Length-1; i >= 0; i--)
        //    {
        //        palindromeString += temp[i];
        //    }
        //    if (palindromeString == x.ToString())
        //        return true;
        //    else
        //        return false;                   
        //}
        //參考
        //public bool IsPalindrome(int x)
        //{
        //    string original = x.ToString();
        //    char[] xArrayToReverse = original.ToCharArray();
        //    Array.Reverse(xArrayToReverse);
        //    string reversed = new string(xArrayToReverse);

        //    return reversed.Equals(original) ? true : false;
        //}

        //最佳解。參考修改
        public bool IsPalindrome(int x)
        {
            var reverseString = new string(x.ToString().ToCharArray().Reverse().ToArray());
            return x.ToString() == reverseString;
        }

        //10. Regular Expression Matching 正規表達式搜尋
        //Hard
        //Topics
        //Companies
        //Given an input string s and a pattern p, implement regular expression matching with support for '.' and '*' where:

        //'.' Matches any single character.​​​​
        //'*' Matches zero or more of the preceding element.
        //The matching should cover the entire input string (not partial).

        //Example 1:

        //Input: s = "aa", p = "a"
        //Output: false
        //Explanation: "a" does not match the entire string "aa".
        //Example 2:

        //Input: s = "aa", p = "a*"
        //Output: true
        //Explanation: '*' means zero or more of the preceding element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".
        //Example 3:

        //Input: s = "ab", p = ".*"
        //Output: true
        //Explanation: ".*" means "zero or more (*) of any character (.)".

        //Constraints:

        //1 <= s.length <= 20
        //1 <= p.length <= 20
        //s contains only lowercase English letters.
        //p contains only lowercase English letters, '.', and '*'.
        //It is guaranteed for each appearance of the character '*', there will be a previous valid character to match.

        //參考。使用正規表示式
        public bool IsMatch(string s, string p)
        {
            if (p.Contains("**"))
            {
                return Regex.IsMatch(s, String.Format("^{0}$", Regex.Replace(p, "[**]+", "*")));
            }
            return Regex.IsMatch(s, String.Format("^{0}$", p));
        }
    }
}
