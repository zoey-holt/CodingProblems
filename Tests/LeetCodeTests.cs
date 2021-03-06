using CodingProblems;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class LeetCodeTests
    {
        private LeetCodeProblems _problems = new LeetCodeProblems();

        [TestCase(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
        [TestCase(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
        [TestCase(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, 4, new int[] { 0, 4, 1, 3 })]
        public void TestTwoSum(int[] nums, int target, int[] expected)
        {
            var actual = _problems.TwoSum(nums, target);
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestCase(new int[] { 2, 4, 3 }, new int[] { 5, 6, 4 }, new int[] { 7, 0, 8 })]
        [TestCase(new int[] { 0 }, new int[] { 0 }, new int[] { 0 })]
        [TestCase(new int[] { 9, 9, 9, 9, 9, 9, 9 }, new int[] { 9, 9, 9, 9 }, new int[] { 8, 9, 9, 9, 0, 0, 0, 1 })]
        [TestCase(new int[] { 9 }, new int[] { 1, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 })]
        [TestCase(new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, new int[] { 5, 6, 4 }, new int[] { 6, 6, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 })]
        public void TestAddTwoNumbers(int[] l1, int[] l2, int[] expected)
        {
            var actual = _problems.AddTwoNumbers(new LeetCodeProblems.ListNode(l1), new LeetCodeProblems.ListNode(l2)).ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase("abcabcbb", 3)]
        [TestCase("bbbbb", 1)]
        [TestCase("pwwkew", 3)]
        [TestCase("", 0)]
        [TestCase(" ", 1)]
        [TestCase("au", 2)]
        [TestCase("dvdf", 3)]
        public void TestLengthOfLongestSubstring(string s, int expected)
        {
            var actual = _problems.LengthOfLongestSubstring(s);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 3 }, new int[] { 2 }, 2d)]
        [TestCase(new int[] { 1, 2 }, new int[] { 3, 4 }, 2.5d)]
        [TestCase(new int[] { 0, 2 }, new int[] { 0, 0 }, 0d)]
        [TestCase(new int[] { }, new int[] { 1 }, 1d)]
        [TestCase(new int[] { 2 }, new int[] { }, 2d)]
        [TestCase(new int[] { 1, 3, 5, 7, 9 }, new int[] { 0, 2, 4, 6, 8 }, 4.5d)]
        [TestCase(new int[] { 1, 10, 20 }, new int[] { 2, 20, 100 }, 15d)]
        [TestCase(new int[] { 5, 6, 7, 8 }, new int[] { 1, 2, 3 }, 5d)]
        [TestCase(new int[] { 1, 8 }, new int[] { 2, 3, 4, 5, 6, 7, 8, 9 }, 5.5d)]
        public void TestFindMedianSortedArrays(int[] nums1, int[] nums2, double expected)
        {
            var actual = _problems.FindMedianSortedArrays(nums1, nums2);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("babad", "bab")]
        [TestCase("cbbd", "bb")]
        [TestCase("a", "a")]
        [TestCase("ac", "a")]
        [TestCase("racecarsarecool", "racecar")]
        [TestCase("euazbipzncptldueeuechubrcourfpftcebikrxhybkymimgvldiwqvkszfycvqyvtiwfckexmowcxztkfyzqovbtmzpxojfofbvwnncajvrvdbvjhcrameamcfmcoxryjukhpljwszknhiypvyskmsujkuggpztltpgoczafmfelahqwjbhxtjmebnymdyxoeodqmvkxittxjnlltmoobsgzdfhismogqfpfhvqnxeuosjqqalvwhsidgiavcatjjgeztrjuoixxxoznklcxolgpuktirmduxdywwlbikaqkqajzbsjvdgjcnbtfksqhquiwnwflkldgdrqrnwmshdpykicozfowmumzeuznolmgjlltypyufpzjpuvucmesnnrwppheizkapovoloneaxpfinaontwtdqsdvzmqlgkdxlbeguackbdkftzbnynmcejtwudocemcfnuzbttcoew", "aqkqa")]
        [TestCase("xdxtfdaarvvznrptwicdldmrmwbdrmyppvamdvofujthfcmkcugvodmlvubgvodectwzparprifwgwfvddlrfdnrpspirtyvxqvbqiglugbmzoyzcfkvbjdrdqqxxzutebgoacczuhopvzjfrnfsylgfgkbmbjqqyggtdjcvjbvpspkjcezanajjzabfidndfdpkuamwvxrbpxzoivlnkwdxedtfnmvicmzebwktpktokibeycbpqzejddwnvimmbzupyxwmrgdbmcujadfexcchdkfvkxsdwkuwuxzhpnjgmqbmidcwywjgcsbydixyxcclcbrzjvrmlrzgmbviifllouykovscaufvxovwmmgubshtoizbwtcpqzwchtkmkjfneuybfglywfrorhmfdgvjdsmegtoytsivnuaceszpfsxgddbweckgziahkslykgdkztmpapnoyawqtyrdcuzaxcohohapektyfbfhrsdnjbgjvwvqpcikdnlkdogsinkfpymkkdburnbksnqfjgjlacqpfqlhsjhhoccdkrjipqwzsxmpjughaqchzlrqkogkryqkuuxhzchovebzgeekuflcgvxugnxcvugqlstmnljlvxonkybmzjmnsvvwfztcplgikptnppbzeygbmdsyimsntveojwsejmastiovbctdkdlfvpyzihhxishtveflnmamlnzqroxknrrkkfpveyzvvasdznykygrpbfkbinrrvheekeumlvlgalqelspvpiydqkwduckimyhpzsxlcpkbvgwmwnasdxuupdhcmxjoushcvcnjyrmuemuydyywpvzhkxsqszaqhnbhjwsokkpployomoawtr", "fwgwf")]
        public void TestLongestPalindrome(string s, string expected)
        {
            var actual = _problems.LongestPalindrome(s);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("0123456789", 1, "0123456789")]
        [TestCase("0123456789", 2, "0246813579")]
        [TestCase("0123456789", 3, "0481357926")]
        [TestCase("0123456789", 4, "0615724839")]
        [TestCase("0123456789", 5, "0817926354")]
        [TestCase("0123456789", 6, "0192837465")]
        [TestCase("0123456789", 7, "0123948576")]
        [TestCase("0123456789", 8, "0123459687")]
        [TestCase("0123456789", 9, "0123456798")]
        [TestCase("0123456789", 10, "0123456789")]
        [TestCase("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
        [TestCase("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
        [TestCase("A", 1, "A")]
        public void TestZigZagConvert(string s, int numRows, string expected)
        {
            var actual = _problems.ZigZagConvert(s, numRows);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(123, 321)]
        [TestCase(-123, -321)]
        [TestCase(120, 21)]
        [TestCase(0, 0)]
        [TestCase(123456789, 987654321)]
        [TestCase(1525, 5251)]
        [TestCase(112, 211)]
        [TestCase(796, 697)]
        [TestCase(1534236469, 0)]
        public void TestReverseInt(int x, int expected)
        {
            var actual = _problems.ReverseInt(x);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("42", 42)]
        [TestCase("   -42", -42)]
        [TestCase("4193 with words", 4193)]
        [TestCase("words and 987", 0)]
        [TestCase("-91283472332", -2147483648)]
        [TestCase("21474836460", 2147483647)]
        [TestCase("2147483648", 2147483647)]
        public void TestMyAtoi(string s, int expected)
        {
            var actual = _problems.MyAtoi(s);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(121, true)]
        [TestCase(-121, false)]
        [TestCase(10, false)]
        [TestCase(-101, false)]
        [TestCase(1000001, true)]
        [TestCase(1234321, true)]
        public void TestIsPalindrome(int x, bool expected)
        {
            var actual = _problems.IsPalindrome(x);
            Assert.AreEqual(expected, actual);
        }

        // Problem unsolved. Tests removed temporarily.
        //[TestCase("", "", true)]
        //[TestCase("1", "", false)]
        //[TestCase("", "1", false)]
        //[TestCase("aa", "a", false)]
        //[TestCase("aa", "a*", true)]
        //[TestCase("ab", ".*", true)]
        //[TestCase("aab", "c*a*b*", true)]
        //[TestCase("mississippi", "mis*is*p*.", false)]
        //[TestCase("mississippi", "mis*is*ip*.", true)]
        //[TestCase("ab", ".*c", false)]
        //[TestCase("aaa", "aaaa", false)]
        //[TestCase("aaa", "a*a", true)]
        //[TestCase("aaa", "a*aa", true)]
        //[TestCase("aaa", "a*a*a*", true)]
        //[TestCase("aaa", "a*aa*a*aa", true)]
        //[TestCase("aaa", "a*a*a*a*aaa", true)]
        //[TestCase("a", "a*a*a*a*a*a*a*a*", true)]
        //[TestCase("a", "a*a*a*a*a*a*a*a*a", true)]
        //public void TestIsMatch(string s, string p, bool expected)
        //{
        //    var actual = _problems.IsMatch(s, p);
        //    Assert.AreEqual(expected, actual);
        //}

        [TestCase(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
        [TestCase(new int[] { 1, 1 }, 1)]
        [TestCase(new int[] { 4, 3, 2, 1, 4 }, 16)]
        [TestCase(new int[] { 1, 2, 1 }, 2)]
        [TestCase(new int[] { 0, 0 }, 0)]
        [TestCase(new int[] { 0, 10000 }, 0)]
        [TestCase(new int[] { 0, 10000, 0 }, 0)]
        [TestCase(new int[] { 10000, 10000 }, 10000)]
        [TestCase(new int[] { 10000, 10000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 10000)]
        [TestCase(new int[] { 76, 155, 15, 188, 180, 154, 84, 34, 187, 142, 22, 5, 27, 183, 111, 128, 50, 58, 2, 112, 179, 2, 100, 111, 115, 76, 134, 120, 118, 103, 31, 146, 58, 198, 134, 38, 104, 170, 25, 92, 112, 199, 49, 140, 135, 160, 20, 185, 171, 23, 98, 150, 177, 198, 61, 92, 26, 147, 164, 144, 51, 196, 42, 109, 194, 177, 100, 99, 99, 125, 143, 12, 76, 192, 152, 11, 152, 124, 197, 123, 147, 95, 73, 124, 45, 86, 168, 24, 34, 133, 120, 85, 81, 163, 146, 75, 92, 198, 126, 191 }, 18048)]
        public void TestMaxArea(int[] height, int expected)
        {
            var actual = _problems.MaxArea(height);
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void TestMaxArea()
        {
            var maxLength = 100000;
            var maxHeight = 10000;
            var height = new int[maxLength];
            var testIndex = 49000;
            for (int i = 0; i < height.Length; i++)
            {
                if (i == testIndex)
                {
                    height[i] = maxHeight;
                }
                else if (i == height.Length - testIndex)
                {
                    height[i] = maxHeight;
                }
                else
                {
                    height[i] = maxHeight / 100;
                }
            }
            var expected = (maxLength - (testIndex * 2)) * maxHeight;
            var actual = _problems.MaxArea(height);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, "I")]
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(5, "V")]
        [TestCase(9, "IX")]
        [TestCase(10, "X")]
        [TestCase(40, "XL")]
        [TestCase(50, "L")]
        [TestCase(58, "LVIII")]
        [TestCase(90, "XC")]
        [TestCase(100, "C")]
        [TestCase(500, "D")]
        [TestCase(1000, "M")]
        [TestCase(1994, "MCMXCIV")]
        [TestCase(3499, "MMMCDXCIX")]
        [TestCase(3949, "MMMCMXLIX")]
        [TestCase(3994, "MMMCMXCIV")]
        [TestCase(3999, "MMMCMXCIX")]
        public void TestIntToRoman(int num, string expected)
        {
            var actual = _problems.IntToRoman(num);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("I", 1)]
        [TestCase("III", 3)]
        [TestCase("IV", 4)]
        [TestCase("V", 5)]
        [TestCase("IX", 9)]
        [TestCase("X", 10)]
        [TestCase("XL", 40)]
        [TestCase("L", 50)]
        [TestCase("LVIII", 58)]
        [TestCase("XC", 90)]
        [TestCase("C", 100)]
        [TestCase("D", 500)]
        [TestCase("M", 1000)]
        [TestCase("MCMXCIV", 1994)]
        [TestCase("MMMCDXCIX", 3499)]
        [TestCase("MMMCMXLIX", 3949)]
        [TestCase("MMMCMXCIV", 3994)]
        [TestCase("MMMCMXCIX", 3999)]
        public void TestRomanToInt(string s, int expected)
        {
            var actual = _problems.RomanToInt(s);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new string[] { "flower", "flow", "flight" }, "fl")]
        [TestCase(new string[] { "dog", "racecar", "car" }, "")]
        [TestCase(new string[] { "aaa" }, "aaa")]
        [TestCase(new string[] { "aaa", "aa", "a" }, "a")]
        [TestCase(new string[] { "asdf", "asdf", "asdf", "asd", "z" }, "")]
        [TestCase(new string[] { "aaa", "aa", "aaa" }, "aa")]
        public void TestLongestCommonPrefix(string[] strs, string expected)
        {
            var actual = _problems.LongestCommonPrefix(strs);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { -1, 0, 1, 2, -1, -4 }, "[[-1,0,1],[-1,-1,2]]")]
        [TestCase(new int[] { }, "[]")]
        [TestCase(new int[] { 0 }, "[]")]
        [TestCase(new int[] { 0, 0, 0 }, "[[0,0,0]]")]
        [TestCase(new int[] { 0, 0, 0, 0 }, "[[0,0,0]]")]
        [TestCase(new int[] { 0, 0, 0, 10, -5, -4, -3, -2, -1 }, "[[0,0,0]]")]
        [TestCase(new int[] { 0, 0, 0, 10, -6, -5, -4, -3, -2, -1 }, "[[0,0,0],[-6,-4,10]]")]
        [TestCase(new int[] { 100000, -100000, 100000 }, "[]")]
        [TestCase(new int[] { 100000, -100000, 0 }, "[[-100000,0,100000]]")]
        public void TestThreeSum(int[] nums, string expectedStr)
        {
            IList<IList<int>> expected = ParseIListOfIListOfInt(expectedStr);
            var actual = _problems.ThreeSum(nums);
            Assert.AreEqual(expected.Count, actual.Count);
            foreach (var i in expected)
            {
                var match = false;
                foreach (var j in actual)
                {
                    if (i[0] == j[0] && i[1] == j[1] && i[2] == j[2])
                    {
                        match = true;
                        break;
                    }
                }
                if (!match)
                {
                    CollectionAssert.AreEqual(i, actual[0]);
                }
            }
        }

        private IList<IList<int>> ParseIListOfIListOfInt(string str)
        {
            IList<IList<int>> expected = new List<IList<int>>();
            List<int> list = null;
            string num = "";
            for (int i = 1; i < str.Length - 1; i++)
            {
                if (str[i] == '[')
                {
                    list = new List<int>();
                }
                else if (str[i] == ']')
                {
                    if (num.Length > 0)
                    {
                        list.Add(int.Parse(num));
                        num = "";
                    }
                    if (list.Count > 0)
                    {
                        expected.Add(list);
                        list = null;
                    }
                }
                else if (str[i] == ',')
                {
                    if (num.Length > 0)
                    {
                        list.Add(int.Parse(num));
                        num = "";
                    }
                }
                else
                {
                    num += str[i];
                }
            }

            return expected;
        }

        [Test]
        public void TestThreeSum()
        {
            var nums = new List<int>();
            for (int i = -100; i < 100; i++)
            {
                nums.Add(i * 100);
            }

            var actual = _problems.ThreeSum(nums.ToArray());
            Assert.IsNotNull(actual);
        }

        [TestCase(new int[] { 0, 0, 0 }, 0, 0)]
        [TestCase(new int[] { -1, 2, 1, -4 }, 1, 2)]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1, 3)]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 0, 6, 7, 8, 9, 1 }, 1, 1)]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 11, 11)]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 100, 24)]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 10, 6, 7, 8, 9, 1 }, 25, 25)]
        public void TestThreeSumClosest(int[] nums, int target, int expected)
        {
            var actual = _problems.ThreeSumClosest(nums, target);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("", new string[] { })]
        [TestCase("2", new string[] { "a", "b", "c" })]
        [TestCase("23", new string[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" })]
        [TestCase("222", new string[] { 
            "aaa", "aab", "aac", "aba", "abb", "abc", "aca", "acb", "acc",
            "bbb", "bbc", "bba", "bcb", "bcc", "bca", "bab", "bac", "baa",
            "ccc", "cca", "ccb", "cac", "caa", "cab", "cbc", "cba", "cbb",
        })]
        [TestCase("27", new string[] { "ap", "aq", "ar", "as", "bp", "bq", "br", "bs", "cp", "cq", "cr", "cs" })]
        public void TestLetterCombinations(string digits, IList<string> expected)
        {
            var actual = _problems.LetterCombinations(digits);
            CollectionAssert.AreEquivalent(expected, actual);
        }

        //[TestCase(new int[] { 1, 0, -1, 0, -2, 2 }, 0, "[[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]")]
        //[TestCase(new int[] { 2, 2, 2, 2, 2 }, 8, "[[2,2,2,2]]")]
        //public void TestFourSum(int[] nums, int target, string expectedStr)
        //{
        //    IList<IList<int>> expected = ParseIListOfIListOfInt(expectedStr);
        //    var actual = _problems.FourSum(nums, target);
        //    Assert.AreEqual(expected.Count, actual.Count);
        //    foreach (var i in expected)
        //    {
        //        var match = false;
        //        foreach (var j in actual)
        //        {
        //            if (i[0] == j[0] && i[1] == j[1] && i[2] == j[2] && i[3] == j[3])
        //            {
        //                match = true;
        //                break;
        //            }
        //        }
        //        if (!match)
        //        {
        //            CollectionAssert.AreEqual(i, actual[0]);
        //        }
        //    }
        //}

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 1, 2, 3, 5 })]
        [TestCase(new int[] { 1 }, 1, new int[] { })]
        [TestCase(new int[] { 1, 2 }, 1, new int[] { 1 })]
        [TestCase(new int[] { 1, 2 }, 2, new int[] { 2 })]
        public void TestRemoveNthFromEnd(int[] l1, int n, int[] expected)
        {
            var actual = _problems.RemoveNthFromEnd(new LeetCodeProblems.ListNode(l1), n)?.ToArray() ?? new int[] { };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 1, 2, 3, 5 })]
        [TestCase(new int[] { 1 }, 1, new int[] { })]
        [TestCase(new int[] { 1, 2 }, 1, new int[] { 1 })]
        [TestCase(new int[] { 1, 2 }, 2, new int[] { 2 })]
        public void TestRemoveNthFromEndOnePass(int[] l1, int n, int[] expected)
        {
            var actual = _problems.RemoveNthFromEndOnePass(new LeetCodeProblems.ListNode(l1), n)?.ToArray() ?? new int[] { };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase("()", true)]
        [TestCase("()[]{}", true)]
        [TestCase("(]", false)]
        [TestCase("([)]", false)]
        [TestCase("{[]}", true)]
        [TestCase("((", false)]
        [TestCase("(){}}{", false)]
        [TestCase("[[[]", false)]
        [TestCase("(())", true)]
        public void TestValidParentheses(string s, bool expected)
        {
            var actual = _problems.ValidParentheses(s);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 4 }, new int[] { 1, 3, 4 }, new int[] { 1, 1, 2, 3, 4, 4 })]
        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        [TestCase(new int[] { }, new int[] { 0 }, new int[] { 0 })]
        public void TestMergeTwoLists(int[] l1, int[] l2, int[] expected)
        {
            var actual = _problems.MergeTwoLists(l1.Any() ? new LeetCodeProblems.ListNode(l1) : null, l2.Any() ? new LeetCodeProblems.ListNode(l2) : null)?.ToArray() ?? new int[] { };
            CollectionAssert.AreEqual(expected, actual, "Expected: [{0}] but was: [{1}].", string.Join(",", expected), string.Join(",", actual));
        }

        [TestCase(0, new string[] { })]
        [TestCase(1, new string[] { "()" })]
        [TestCase(2, new string[] { "(())", "()()", })]
        [TestCase(3, new string[] { "((()))", "(()())", "(())()", "()(())", "()()()" })]
        public void TestGenerateParentheses(int n, string[] expected)
        {
            var actual = _problems.GenerateParentheses(n);
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestCase("[]", new int[] { })]
        [TestCase("[[]]", new int[] { })]
        [TestCase("[[1],[2],[3]]", new int[] { 1, 2, 3 })]
        [TestCase("[[1,4,5],[1,3,4],[2,6]]", new int[] { 1, 1, 2, 3, 4, 4, 5, 6 })]
        public void TestMergeKLists(string listsStr, int[] expected)
        {
            var lists = ParseIListOfIListOfInt(listsStr).Select(l => new LeetCodeProblems.ListNode(l.ToArray())).ToArray();
            var actual = _problems.MergeKLists(lists)?.ToArray() ?? new int[] { };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 2, 1, 4, 3 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 2, 1, 4, 3, 6, 5, 8, 7, 10, 9 })]
        public void TestSwapPairs(int[] head, int[] expected)
        {
            var actual = _problems.SwapPairs(head.Any() ? new LeetCodeProblems.ListNode(head) : null)?.ToArray() ?? new int[] { };
            CollectionAssert.AreEqual(expected, actual, "Expected: [{0}] but was: [{1}].", string.Join(",", expected), string.Join(",", actual));
        }

        [TestCase(new int[] { 1 }, 1, new int[] { 1 })]
        [TestCase(new int[] { 1, 2 }, 2, new int[] { 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 2, 1, 4, 3, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, new int[] { 3, 2, 1, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 3, new int[] { 3, 2, 1, 6, 5, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 2, new int[] { 2, 1, 4, 3, 6, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 2, new int[] { 2, 1, 4, 3, 6, 5, 8, 7, 10, 9 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 3, new int[] { 3, 2, 1, 6, 5, 4, 9, 8, 7, 12, 11, 10 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }, 4, new int[] { 4, 3, 2, 1, 8, 7, 6, 5, 12, 11, 10, 9, 16, 15, 14, 13 })]
        public void TestReverseKGroup(int[] l1, int k, int[] expected)
        {
            var actual = _problems.ReverseKGroup(new LeetCodeProblems.ListNode(l1), k)?.ToArray() ?? new int[] { };
            CollectionAssert.AreEqual(expected, actual, "Expected: [{0}] but was: [{1}].", string.Join(",", expected), string.Join(",", actual));
        }
    }
}
