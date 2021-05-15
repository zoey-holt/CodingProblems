using System;
using System.Collections.Generic;

namespace CodingProblems
{
    public class LeetCodeProblems
    {
        // 1. Two Sum
        // Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        // You may assume that each input would have exactly one solution, and you may not use the same element twice.
        // You can return the answer in any order.
        public int[] TwoSum(int[] nums, int target)
        {
            var result = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (result.Contains(i))
                {
                    continue;
                }
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (result.Contains(j))
                    {
                        continue;
                    }
                    if (nums[i] + nums[j] == target)
                    {
                        result.Add(i);
                        result.Add(j);
                    }
                }
            }
            return result.ToArray();
        }

        // 2. Add Two Numbers
        // You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
        // You may assume the two numbers do not contain any leading zero, except the number 0 itself.
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }

            public ListNode(int[] values)
            {
                var start = new ListNode();
                var node = start;
                for (int i = 0; i < values.Length; i++)
                {
                    int val = values[i];
                    node.val = val;
                    if (i < values.Length - 1)
                    {
                        node.next = new ListNode();
                        node = node.next;
                    }
                }
                val = start.val;
                next = start.next;
            }

            public int[] ToArray()
            {
                var result = new List<int>();
                var node = this;
                while (true)
                {
                    result.Add(node.val);
                    node = node.next;
                    if (node == null) break;
                }
                return result.ToArray();
            }
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {            
            return AddTwoNumbers(l1, l2, false);
        }

        private ListNode AddTwoNumbers(ListNode l1, ListNode l2, bool carry)
        {
            var sum = (l1?.val ?? 0) + (l2?.val ?? 0) + (carry ? 1 : 0);
            if (sum > 9)
            {
                carry = true;
                sum -= 10;
            }
            else
            {
                carry = false;
            }
            ListNode next;
            if (l1?.next != null || l2?.next != null || carry)
            {
                next = AddTwoNumbers(l1?.next, l2?.next, carry);
            }
            else
            {
                next = null;
            }
            return new ListNode(sum, next);
        }

        // 3. Longest Substring Without Repeating Characters
        // Given a string s, find the length of the longest substring without repeating characters.
        public int LengthOfLongestSubstring(string s)
        {
            var length = 0;
            var chars = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (chars.Length == 0)
                {
                    chars += s[i];
                    continue;
                }

                if (chars.Contains(s[i].ToString()))
                {
                    length = length > chars.Length ? length : chars.Length;
                    i -= chars.Length;
                    chars = "";
                }
                else
                {
                    chars += s[i];
                }
            }
            length = length > chars.Length ? length : chars.Length;
            return length;
        }

        // 4. Median of Two Sorted Arrays
        // Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
        // The overall run time complexity should be O(log (m+n)).
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var sum = new int[nums1.Length + nums2.Length];
            var i = 0;
            var j = 0;
            while (i < nums1.Length || j < nums2.Length)
            {
                if (i < nums1.Length && j < nums2.Length)
                {
                    if (nums1[i] <= nums2[j])
                    {
                        sum[i + j] = nums1[i];
                        i++;
                    }
                    else
                    {
                        sum[i + j] = nums2[j];
                        j++;
                    }
                }
                else if (i < nums1.Length)
                {
                    sum[i + j] = nums1[i];
                    i++;
                }
                else
                {
                    sum[i + j] = nums2[j];
                    j++;
                }
            }

            if (sum.Length == 1)
                return sum[0];

            var median = (nums1.Length + nums2.Length) / 2;
            if (median * 2 == nums1.Length + nums2.Length)
                return (sum[median - 1] + sum[median]) / 2d;
            return sum[median];
        }

        // 5. Longest Palindromic Substring
        // Given a string s, return the longest palindromic substring in s.
        public string LongestPalindrome(string s)
        {
            var longest = s.Substring(0, 1);
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = longest.Length + 1; i + j <= s.Length; j++)
                {
                    var test = s.Substring(i, j);
                    if (IsPalindrome(test) && test.Length > longest.Length)
                    {
                        longest = test;
                    }
                }
            }
            return longest;
        }

        private bool IsPalindrome(string s)
        {
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
