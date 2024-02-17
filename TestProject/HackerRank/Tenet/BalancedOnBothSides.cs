using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.HackerRank.Tenet
{
    public class BalancedOnBothSides
    {
        [Test]
        public void Main()
        {
            //var result = balancedSum(new List<int> { 1, 2, 3, 4, 1, 1, 6 });
            //var result = balancedSum(new List<int> { 1, 1, 1, 3 });
            //var result = balancedSum(new List<int> { 1,2,8,1,2 });
            //var result = balancedSum(new List<int>());
            //var result = balancedSum(new List<int> { 10,7,8,1, 2, 3, 5 });
            //var result = balancedSum(new List<int> { 1,2,1,2});
            //var result = balancedSum(new List<int> { 1, 2,3,4,5,6,7,8,1 });
            //var result = balancedSum(new List<int> { 1, 2, 3, 3 });
            var result = balancedSum(new List<int> { 1, 2, 1, 1 });
        }
        //14. Balanced on both sides
        //Given an array of numbers, find 2 indexes of the smallest
        //array element(the pivot) on both right and left sides, for
        //which the sums of all elements to the left and to the right are
        //equal.The array may not be reordered.
        //Example
        //arr=[1, 2, 3, 4, 1, 1, 6]
        //the sum of the first three elements, 1+2+3=6. The value of the
        //last element is 6.
        //• Using zero based indexing for the left side, summing from left
        //to right, arr[3]= 4, is the smallest array element (the
        //pivot) between the two subarrays.For the right sides,
        //summing from right to left, arr[5]= 1, is the smallest array
        //element (the pivot) between the two subarrays.
        //• The index of the pivot is "3,5".
        //Function Description
        //Complete the function balancedSum in the editor below.
        //balancedSum has the following parameter(s):
        //int arr[n]: an array of integers
        //Returns:
        //string: 2 integers representing the indexes of the pivot on
        //both sides.
        public static string balancedSum(List<int> arr)
        {
            int left = 0;
            int right = arr.Count-1;
            int leftSum = 0;
            int rightSum = 0;
            while (left <= right)
            {
                leftSum += arr[left];
                rightSum += arr[right];
                if (leftSum == rightSum)
                {
                    return $"{left + 1},{right - 1}";
                }
                else if(leftSum > rightSum)
                {
                    right--;
                    leftSum -= arr[left];
                }
                else
                {
                    left++;
                    rightSum -= arr[right];
                }
            }
            return string.Empty;
        }
    }
}
