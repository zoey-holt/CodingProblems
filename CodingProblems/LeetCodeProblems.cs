using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingProblems
{
    public class LeetCodeProblems
    {
        // 1. Two Sum
        // Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        // You may assume that each input would have exactly one solution, and you may not use the same element twice.
        // You can return the answer in any order.
        // This solution has a time complexity of O(N²) where N = nums.Length.
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
        // TODO: optimize speed.
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

        // 6. ZigZag Conversion
        // The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)
        // P   A   H   N
        // A P L S I I G
        // Y   I   R
        // And then read line by line: "PAHNAPLSIIGYIR"
        // Write the code that will take a string and make this conversion given a number of rows
        // TODO: optimize memory and speed.
        public string ZigZagConvert(string s, int numRows)
        {
            if (numRows == 1 || numRows >= s.Length)
                return s;

            var array = new string[numRows, s.Length / 2 + 1];
            var x = 0;
            var y = 0;
            bool down = true;
            for (int i = 0; i < s.Length; i++)
            {
                array[x, y] = s[i].ToString();
                if (down)
                {
                    x++;
                }
                else
                {
                    x--;
                    y++;
                }

                if (x >= numRows)
                {
                    down = false;
                    y++;
                    x -= 2;
                }

                if (x < 1)
                {
                    down = true;
                }
            }

            var result = "";
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < s.Length / 2 + 1; j++)
                {
                    if (array[i, j] != null)
                    {
                        result += array[i, j];
                    }
                }
            }

            return result;
        }

        // 7. Reverse Integer
        // Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.
        // Assume the environment does not allow you to store 64-bit integers (signed or unsigned).
        public int ReverseInt(int x)
        {
            var negative = x < 0;
            if (negative)
                x *= -1;

            var result = 0;
            try
            {
                while (x > 0)
                {
                    result += x % 10;
                    x /= 10;
                    if (x > 0)
                        result = checked(result * 10);
                }
            }
            catch (System.OverflowException)
            {
                return 0;
            }

            return negative ? result * -1 : result;
        }

        // 8. String to Integer (atoi)
        // Implement the myAtoi(string s) function, which converts a string to a 32-bit signed integer (similar to C/C++'s atoi function).
        // The algorithm for myAtoi(string s) is as follows:
        //   1. Read in and ignore any leading whitespace.
        //   2. Check if the next character (if not already at the end of the string) is '-' or '+'. Read this character in if it is either. This determines if the final result is negative or positive respectively. Assume the result is positive if neither is present.
        //   3. Read in next the characters until the next non-digit charcter or the end of the input is reached. The rest of the string is ignored.
        //   4. Convert these digits into an integer (i.e. "123" -> 123, "0032" -> 32). If no digits were read, then the integer is 0. Change the sign as necessary (from step 2).
        //   5. If the integer is out of the 32-bit signed integer range [-231, 231 - 1], then clamp the integer so that it remains in the range. Specifically, integers less than -231 should be clamped to -231, and integers greater than 231 - 1 should be clamped to 231 - 1.
        //   6. Return the integer as the final result.
        // TODO: optimize speed.
        public int MyAtoi(string s)
        {
            s = s.TrimStart();
            if (s.Length == 0)
                return 0;

            int sign;
            int start;
            if (s[0] == '+')
            {
                sign = 1;
                start = 1;
            }
            else if (s[0] == '-')
            {
                sign = -1;
                start = 1;
            }
            else
            {
                sign = 1;
                start = 0;
            }

            long result = 0;
            for (int i = start; i < s.Length; i++)
            {
                int value = s[i] - '0';
                if (value >= 0 && value < 10)
                {
                    result += value;
                    if (result > int.MaxValue)
                    {
                        return sign > 0 ? int.MaxValue : int.MinValue;
                    }
                    if (i < s.Length - 1)
                    {
                        var next = s[i + 1] - '0';
                        if (next >= 0 && next < 10)
                        {
                            result *= 10;
                            if (result > int.MaxValue)
                            {
                                return sign > 0 ? int.MaxValue : int.MinValue;
                            }
                        }
                    }
                }
                else
                {
                    return (int)result * sign;
                }
            }
            return (int)result * sign;
        }

        // 9. Palindrome Number
        // Given an integer x, return true if x is palindrome integer.
        // An integer is a palindrome when it reads the same backward as forward. For example, 121 is palindrome while 123 is not.
        public bool IsPalindrome(int x)
        {
            if (x < 0)
                return false;
            int digitCount = (int)(Math.Log10(x) + 1);
            for (int i = 1; i <= digitCount / 2; i++)
            {
                int tenToTheDigitCount = (int)Math.Pow(10, digitCount - (2 * i - 1));
                int left = x / tenToTheDigitCount;
                int right = x - x / 10 * 10;
                if (left != right)
                {
                    return false;
                }
                x -= left * tenToTheDigitCount;
                x /= 10;
            }
            return true;
        }

        // 10. Regular Expression Matching
        // Given an input string (s) and a pattern (p), implement regular expression matching with support for '.' and '*' where: 
        //   '.' Matches any single character.​​​​
        //   '*' Matches zero or more of the preceding element.
        // The matching should cover the entire input string (not partial).
        // TODO: redesign using recursion for validating repeating portions. This is currently a wrong answer.
        public bool IsMatch(string s, string p)
        {
            if (s.Length == 0 && p.Length == 0)
                return true;
            if (p.Length == 0 || s.Length == 0)
                return false;

            char repeatChar = ' ';
            bool repeat = false;
            int si = 0;
            int pi = 0;
            while (true)
            {
                if (pi >= p.Length && si < s.Length)
                    return false;

                if (si >= s.Length)
                {
                    if (repeat && pi < p.Length - 2)
                    {
                        si--;
                        repeat = false;
                        pi += 2;
                    }
                    else
                    {
                        break;
                    }
                }

                if (!repeat && pi + 1 < p.Length && p[pi + 1] == '*')
                {
                    repeatChar = p[pi];
                    repeat = true; 
                }

                if (repeat)
                {
                    if (s[si] == repeatChar || repeatChar == '.')
                    {
                        si++;
                    }
                    else
                    {
                        repeat = false;
                        pi += 2;
                    }
                    continue;
                }

                if (p[pi] == '.' || s[si] == p[pi])
                {
                    si++;
                    pi++;
                    continue;
                }

                return false;
            }

            return true;
        }

        // 11. Container With Most Water
        // Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate (i, ai). n vertical lines are drawn such that the two endpoints of the line i is at (i, ai) and (i, 0). Find two lines, which, together with the x-axis forms a container, such that the container contains the most water.
        // Notice that you may not slant the container.
        public int MaxArea(int[] height)
        {
            int maxHeight = 10000;
            int maxArea = 0;
            int left = 0;
            int right = height.Length - 1;
            while (left < right)
            {
                var length = right - left;
                if (length * maxHeight < maxArea)
                    return maxArea;

                var testArea = Math.Min(height[left], height[right]) * length;
                maxArea = Math.Max(maxArea, testArea);

                if (height[left] > height[right])
                    right--;
                else
                    left++;
            }
            return maxArea;
        }

        // 12. Integer to Roman
        // Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
        // For example, 2 is written as II in Roman numeral, just two one's added together. 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.
        // Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:
        // Given an integer, convert it to a roman numeral.
        public string IntToRoman(int num)
        {
            var romanDictionary = new Dictionary<string, int>
            {
                {"M", 1000},
                {"CM", 900},
                {"D", 500},
                {"CD", 400},
                {"C", 100},
                {"XC", 90},
                {"L", 50},
                {"XL", 40},
                {"X", 10},
                {"IX", 9},
                {"V", 5},
                {"IV", 4},
                {"I", 1},
            };
            string roman = "";
            while (num > 0)
            {
                foreach (var k in romanDictionary)
                {
                    if (num >= k.Value)
                    {
                        roman += k.Key;
                        num -= k.Value;
                        break;
                    }
                }
            }
            return roman;
        }

        // 13. Roman to Integer
        // Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
        // For example, 2 is written as II in Roman numeral, just two one's added together. 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.
        // Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:
        // Given a roman numeral, convert it to an integer.
        public int RomanToInt(string s)
        {
            var romanDictionary = new Dictionary<string, int>
            {
                {"CM", 900},
                {"CD", 400},
                {"XC", 90},
                {"XL", 40},
                {"IX", 9},
                {"IV", 4},
                {"M", 1000},
                {"D", 500},
                {"C", 100},
                {"L", 50},
                {"X", 10},
                {"V", 5},
                {"I", 1},
            };
            int num = 0;
            while (s.Length > 0)
            {
                foreach (var i in romanDictionary)
                {
                    if ((s.Length > 1 && s.Substring(0, 2) == i.Key) || (s.Substring(0, 1) == i.Key))
                    {
                        num += i.Value;
                        s = s.Substring(i.Key.Length, s.Length - i.Key.Length);
                        break;
                    }
                }
            }
            return num;
        }

        // 14. Longest Common Prefix
        // Write a function to find the longest common prefix string amongst an array of strings.
        // If there is no common prefix, return an empty string "".
        public string LongestCommonPrefix(string[] strs)
        {
            var prefix = strs[0];
            var found = false;
            for (int i = 1; i < strs.Length; i++)
            {
                for (int j = Math.Min(prefix.Length, strs[i].Length); j > 0; j--)
                {
                    var test = prefix.Substring(0, j);
                    if (test == strs[i].Substring(0, j))
                    {
                        prefix = test;
                        found = true;
                        break;
                    }
                }

                if (!found)
                    return "";
                found = false;
            }
            return prefix;
        }

        // 15. 3Sum
        // Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
        // Notice that the solution set must not contain duplicate triplets.
        // This solution has a time complexity of O(N²*Nlog(N)) where N = nums.Length, which reduces to O(N²). 
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums.Length < 3)
                return new List<IList<int>>();

            nums = nums.OrderBy(n => n).ToArray();

            var list = new List<IList<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                int l = i + 1;
                int r = nums.Length - 1;
                while (l < r)
                {
                    if (l > i + 1 && nums[l] == nums[l - 1])
                    {
                        l++;
                        continue;
                    }
                    if (r < nums.Length - 1 && nums[r] == nums[r + 1])
                    {
                        r--;
                        continue;
                    }

                    var sum = nums[i] + nums[l] + nums[r];
                    if (sum > 0)
                        r--;
                    else if (sum < 0)
                        l++;
                    else
                    {
                        list.Add(new int[] { nums[i], nums[l], nums[r] });
                        l++;
                    }
                }
            }
            return list;
        }

        // 16. 3Sum Closest
        // Given an array nums of n integers and an integer target, find three integers in nums such that the sum is closest to target. Return the sum of the three integers. You may assume that each input would have exactly one solution.
        // This solution has a time complexity of O(N²Nlog(N)) where N = nums.Length, which reduces to O(N²). 
        public int ThreeSumClosest(int[] nums, int target)
        {
            bool closestSet = false;
            int closest = 0;
            nums = nums.OrderBy(n => n).ToArray();

            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                int l = i + 1;
                int r = nums.Length - 1;
                while (l < r)
                {
                    if (closestSet && l > i + 1 && nums[l] == nums[l - 1])
                    {
                        l++;
                        continue;
                    }
                    if (closestSet && r < nums.Length - 1 && nums[r] == nums[r + 1])
                    {
                        r--;
                        continue;
                    }

                    var sum = nums[i] + nums[l] + nums[r];
                    if (sum == target)
                        return sum;

                    if (Math.Abs(sum - target) < Math.Abs(closest - target) || !closestSet)
                    {
                        closestSet = true;
                        closest = sum;
                    }

                    if (sum < target) 
                        l++;
                    else 
                        r--;
                }
            }

            return closest;
        }

        // 17. Letter Combinations of a Phone Number
        // Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.
        // A mapping of digit to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.
        // This solution has a time complexity of O(C^N) where N = digits.Length and C = the max length of the array of letters corresponding to a keypad number (4). 
        private static readonly Dictionary<char, char[]> _keypad = new Dictionary<char, char[]>
            {
                { '2', new char[] { 'a', 'b', 'c' } },
                { '3', new char[] { 'd', 'e', 'f' } },
                { '4', new char[] { 'g', 'h', 'i' } },
                { '5', new char[] { 'j', 'k', 'l' } },
                { '6', new char[] { 'm', 'n', 'o' } },
                { '7', new char[] { 'p', 'q', 'r', 's' } },
                { '8', new char[] { 't', 'u', 'v' } },
                { '9', new char[] { 'w', 'x', 'y', 'z' } },
            };

        public IList<string> LetterCombinations(string digits)
        {
            var result = new List<string>();
            LetterCombinations("", digits, 0, result);
            return result;
        }

        private void LetterCombinations(string prefix, string digits, int index, List<string> result)
        {
            if (index < digits.Length)
            {
                foreach (char letter in _keypad[digits[index]])
                {
                    LetterCombinations(prefix + letter, digits, index + 1, result);
                }
            }
            else if (prefix.Length > 0)
            {
                result.Add(prefix);
            }
        }

        // 18. 4Sum
        // Given an array nums of n integers, return an array of all the unique quadruplets [nums[a], nums[b], nums[c], nums[d]] such that:
        // 0 <= a, b, c, d < n
        // a, b, c, and d are distinct.
        // nums[a] + nums[b] + nums[c] + nums[d] == target
        // You may return the answer in any order.
        // Constraints:
        // 1 <= nums.length <= 200
        // -10^9 <= nums[i] <= 10^9
        // -10^9 <= target <= 10^9
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            throw new NotImplementedException();
        }

        // 19. Remove Nth Node From End of List
        // Given the head of a linked list, remove the nth node from the end of the list and return its head.
        // Follow up: Could you do this in one pass?
        // This solution has a time complexity of O(N) where N = the number of nodes in the list. 
        // This solution has a space complexity of O(1). 
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            int i = 0;
            var current = head;
            while (current.next != null)
            {
                current = current.next;
                i++;
            }

            if (i + 1 == n)
                return head.next;

            current = head;
            for (int j = 0; j < i - n; j++)
            {
                current = current.next;
            }
            current.next = current.next.next;
            return head;
        }

        // 19. Remove Nth Node From End of List
        // Given the head of a linked list, remove the nth node from the end of the list and return its head.
        // Follow up: Could you do this in one pass?
        // This solution has a time complexity of O(N) where N = the number of nodes in the list. 
        // This solution has a space complexity of O(1). 
        public ListNode RemoveNthFromEndOnePass(ListNode head, int n)
        {
            var ahead = head;
            var behind = head;
            var i = 0;
            while (i < n + 1 && ahead != null)
            {
                ahead = ahead.next;
                i++;
            }
            while (ahead != null)
            {
                ahead = ahead.next;
                behind = behind.next;
            }
            if (i == n)
            {
                return head.next;
            }
            behind.next = behind.next.next;
            return head;
        }

        // 20. Valid Parentheses
        // Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        // An input string is valid if:
        // Open brackets must be closed by the same type of brackets.
        // Open brackets must be closed in the correct order.
        // This solution has a time complexity of O(N) where N = the number of nodes in the list. 
        // This solution has a space complexity of O(N) where N = the number of nodes in the list. 
        public bool ValidParentheses(string s)
        {
            if (s.Length % 2 != 0)
                return false;

            var parens = new Dictionary<char, char>
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' },
            };
            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (parens.ContainsKey(s[i]))
                {
                    stack.Push(parens[s[i]]);
                }
                else
                {
                    if (stack.Any() && stack.Peek() == s[i])
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }

        // 21. Merge Two Sorted Lists
        // Merge two sorted linked lists and return it as a sorted list. The list should be made by splicing together the nodes of the first two lists.
        // Example 1:
        // Input: l1 = [1,2,4], l2 = [1,3,4]
        // Output: [1,1,2,3,4,4]
        // Example 2:
        // Input: l1 = [], l2 = []
        // Output: []
        // Example 3:
        // Input: l1 = [], l2 = [0]
        // Output: [0]
        // Constraints:
        // The number of nodes in both lists is in the range[0, 50].
        // -100 <= Node.val <= 100
        // Both l1 and l2 are sorted in non-decreasing order.
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            throw new NotImplementedException();
        }

        // 22. Generate Parentheses
        // Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
        // Example 1:
        // Input: n = 3
        // Output: ["((()))","(()())","(())()","()(())","()()()"]
        // Example 2:
        // Input: n = 1
        // Output: ["()"]
        // Constraints:
        // 1 <= n <= 8
        public IList<string> GenerateParenthesis(int n)
        {
            throw new NotImplementedException();
        }

        // 23. Merge k Sorted Lists
        // You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.
        // Merge all the linked-lists into one sorted linked-list and return it.
        // Example 1:
        // Input: lists = [[1, 4, 5], [1,3,4], [2,6]]
        // Output: [1,1,2,3,4,4,5,6]
        // Explanation: The linked-lists are:
        // [
        // 1->4->5,
        // 1->3->4,
        // 2->6
        // ]
        // merging them into one sorted list:
        // 1->1->2->3->4->4->5->6
        // Example 2:
        // Input: lists = []
        // Output: []
        // Example 3:
        // Input: lists = [[]]
        // Output: []
        // Constraints:
        // k == lists.length
        // 0 <= k <= 10^4
        // 0 <= lists[i].length <= 500
        // -10^4 <= lists[i][j] <= 10^4
        // lists[i] is sorted in ascending order.
        // The sum of lists[i].length won't exceed 10^4.'
        public ListNode MergeKLists(ListNode[] lists)
        {
            throw new NotImplementedException();
        }

        // 24. Swap Nodes in Pairs
        // Given a linked list, swap every two adjacent nodes and return its head.You must solve the problem without modifying the values in the list's nodes (i.e., only nodes themselves may be changed.)
        // Example 1:
        // Input: head = [1, 2, 3, 4]
        // Output: [2,1,4,3]
        // Example 2:
        // Input: head = []
        // Output: []
        // Example 3:
        // Input: head = [1]
        // Output: [1]
        // Constraints:
        // The number of nodes in the list is in the range [0, 100].
        // 0 <= Node.val <= 100
        public ListNode SwapPairs(ListNode head)
        {
            throw new NotImplementedException();
        }

        // 25. Reverse Nodes in k-Group
        // Given a linked list, reverse the nodes of a linked list k at a time and return its modified list.
        // k is a positive integer and is less than or equal to the length of the linked list.If the number of nodes is not a multiple of k then left-out nodes, in the end, should remain as it is.
        // You may not alter the values in the list's nodes, only nodes themselves may be changed.
        // Example 1:
        // Input: head = [1,2,3,4,5], k = 2
        // Output: [2,1,4,3,5]
        // Example 2:
        // Input: head = [1,2,3,4,5], k = 3
        // Output: [3,2,1,4,5]
        // Example 3:
        // Input: head = [1,2,3,4,5], k = 1
        // Output: [1,2,3,4,5]
        // Example 4:
        // Input: head = [1], k = 1
        // Output: [1]
        // Constraints:           
        // The number of nodes in the list is in the range sz.
        // 1 <= sz <= 5000
        // 0 <= Node.val <= 1000
        // 1 <= k <= sz
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            throw new NotImplementedException();
        }
    }
}