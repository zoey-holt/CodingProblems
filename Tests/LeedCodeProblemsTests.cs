using CodingProblems;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class LeedCodeProblemsTests
    {
        [TestCase(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
        [TestCase(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
        [TestCase(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, 4, new int[] { 0, 4, 1, 3 })]
        public void TestTwoSum(int[] nums, int target, int[] expected)
        {
            var actual = new LeetCodeProblems().TwoSum(nums, target);
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestCase(new int[] { 2, 4, 3 }, new int[] { 5, 6, 4 }, new int[] { 7, 0, 8 })]
        [TestCase(new int[] { 0 }, new int[] { 0 }, new int[] { 0 })]
        [TestCase(new int[] { 9, 9, 9, 9, 9, 9, 9 }, new int[] { 9, 9, 9, 9 }, new int[] { 8, 9, 9, 9, 0, 0, 0, 1 })]
        [TestCase(new int[] { 9 }, new int[] { 1, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 })]
        [TestCase(new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, new int[] { 5, 6, 4 }, new int[] { 6, 6, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 })]
        public void TestAddTwoNumbers(int[] l1, int[] l2, int[] expected)
        {
            var actual = new LeetCodeProblems().AddTwoNumbers(new LeetCodeProblems.ListNode(l1), new LeetCodeProblems.ListNode(l2)).ToArray();
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
            var actual = new LeetCodeProblems().LengthOfLongestSubstring(s);
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
            var actual = new LeetCodeProblems().FindMedianSortedArrays(nums1, nums2);
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
            var actual = new LeetCodeProblems().LongestPalindrome(s);
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
            var actual = new LeetCodeProblems().ZigZagConvert(s, numRows);
            Assert.AreEqual(expected, actual);
        }
    }
}
