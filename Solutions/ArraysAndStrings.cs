using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions
{
    public static class ArraysAndStrings
    {
        /// <summary>
        /// Given an integer array nums of size n, return the number with the value closest to 0 in nums. 
        /// If there are multiple answers, return the number with the largest value.
        /// LeetCode: <see href="https://leetcode.com/problems/find-closest-number-to-zero/submissions/1339298603"/>
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int ClosestNumberToZero(int[] nums)
        {
            int closest = nums[0];

            foreach (int n in nums)
            {
                if (Math.Abs(n) < Math.Abs(closest))
                {
                    closest = n;
                }
            }

            if (closest < 0 && nums.Contains(Math.Abs(closest)))
                return Math.Abs(closest);
            else
                return closest;
        }

        /// <summary>
        /// You are given two strings word1 and word2. 
        /// Merge the strings by adding letters in alternating order, starting with word1. 
        /// If a string is longer than the other, append the additional letters onto the end of the merged string.
        /// Return the merged string.
        /// LeetCode: <see href="https://leetcode.com/problems/merge-strings-alternately/submissions/1339304595/"/>
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public static string MergeAlternately(string word1, string word2)
        {
            int w1Length = word1.Length;
            int w2Length = word2.Length;
            int minLenght = Math.Min(w1Length, w2Length);

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < minLenght; i++)
            {
                stringBuilder.Append(word1[i]);
                stringBuilder.Append(word2[i]);
            }

            string longest = w1Length > w2Length ? word1 : word2;
            stringBuilder.Append(longest.Substring(minLenght));


            return stringBuilder.ToString();
        }

        /// <summary>
        /// Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
        /// LeetCode: <see href="https://leetcode.com/problems/roman-to-integer/submissions/1339322089/"/>
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int RomanToInt(string s)
        {
            Dictionary<char, int> charMap = new Dictionary<char, int>
            {
                {'I', 1 },
                {'V', 5 },
                {'X', 10 },
                {'L', 50 },
                {'C', 100 },
                {'D', 500 },
                {'M', 1000 }
            };

            int finalResult = 0;

            int sLength = s.Length;
            int i = 0;

            while (i < sLength)
            {
                if (i < sLength - 1 && charMap[s[i]] < charMap[s[i + 1]])
                {
                    int v1 = charMap[s[i]];
                    int v2 = charMap[s[i + 1]];

                    finalResult += v2 - v1;

                    i += 2;
                }
                else
                {
                    finalResult += charMap[s[i]];

                    i++;
                }
            }

            return finalResult;
        }

        /// <summary>
        /// Given two strings s and t, return true if s is a subsequence of t, or false otherwise.
        /// A subsequence of a string is a new string that is formed from the original 
        /// string by deleting some(can be none) of the characters without disturbing the 
        /// relative positions of the remaining characters. 
        /// (i.e., "ace" is a subsequence of "abcde" while "aec" is not).
        /// LeetCode: <see href="https://leetcode.com/problems/is-subsequence/submissions/1339336490/"/>
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsSybsequence(string s, string t)
        {
            if (string.IsNullOrWhiteSpace(s))
                return true;

            if (s.Length > t.Length)
                return false;

            int count = 0;

            for (int i = 0; i < t.Length; i++)
            {
                if (s[count] == t[i])
                {
                    count++;
                    if (count >= s.Length)
                        break;
                }
                    
            }

            return count == s.Length;
        }

        /// <summary>
        /// You are given an array prices where prices[i] is the price of a given stock on the ith day.
        /// You want to maximize your profit by choosing a single day to buy one 
        /// stock and choosing a different day in the future to sell that stock.
        /// Return the maximum profit you can achieve from this transaction.
        /// If you cannot achieve any profit, return 0.
        /// LeetCode: <see href="https://leetcode.com/problems/best-time-to-buy-and-sell-stock/submissions/1339348901/"/>
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public static int MaxProfit(int[] prices)
        {
            
            int buyValue = prices[0];
            int sellValue = 0;

            foreach (int item in prices)
            {
                if (item < buyValue)
                    buyValue = item;

                if (item - buyValue > sellValue)
                    sellValue = item - buyValue;
            }

            return sellValue;
        }

        /// <summary>
        /// Write a function to find the longest common prefix string amongst an array of strings.
        /// If there is no common prefix, return an empty string "".
        /// LeetCode: <see href="https://leetcode.com/problems/longest-common-prefix/submissions/1339358118/"/>
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static string LongestCommonPrefix(string[] strs)
        {
            StringBuilder prefixBuilder = new StringBuilder();

            Array.Sort(strs);

            string first = strs[0];
            string last = strs[^1];

            for (int i = 0; i < Math.Min(first.Length, last.Length); i++)
            {
                if (first[i] != last[i])
                    break;

                prefixBuilder.Append(first[i]);
            }

            return prefixBuilder.ToString();
        }

        /// <summary>
        /// You are given a sorted unique integer array nums.
        /// A range[a, b] is the set of all integers from a to b(inclusive).
        /// Return the smallest sorted list of ranges that cover all the numbers in the array exactly.
        /// That is, each element of nums is covered by exactly one of the ranges, and there 
        /// is no integer x such that x is in one of the ranges but not in nums.
        /// LeetCode: <see href="https://leetcode.com/problems/summary-ranges/submissions/1339405135/"/>
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<string> SummaryRange(int[] nums)
        {
            List<string> results = new List<string>();

            if (nums.Length == 0)
                return results;

            int start = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[i - 1] + 1)
                {
                    if (start == nums[i - 1])
                    {
                        results.Add(start.ToString());
                    }
                    else
                    {
                        results.Add($"{start}->{nums[i - 1]}");
                    }

                    start = nums[i];
                }
            }

            if (start == nums[^1])
                results.Add(start.ToString());
            else
                results.Add($"{start}->{nums[^1]}");

            return results;
        }

        /// <summary>
        /// Given an integer array nums, return an array answer such that answer[i] is equal
        /// to the product of all the elements of nums except nums[i].
        /// The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
        /// You must write an algorithm that runs in O(n) time and without using the division operation.
        /// LeetCode: <see href="https://leetcode.com/problems/product-of-array-except-self/submissions/1339424316/"/>
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] ProductExceptSelf(int[] nums)
        {
            int numsLength = nums.Length;

            int[] answers = new int[numsLength];
            Array.Fill(answers, 1);

            int current = 1;
            
            for (int i = 0; i < numsLength; i++)
            {
                answers[i] *= current;
                current *= nums[i];
            }

            current = 1;
            for (int i = numsLength - 1; i >= 0; i--)
            {
                answers[i] *= current;
                current *= nums[i];
            }

            return answers;
        }

        /// <summary>
        /// Given an array of intervals where intervals[i] = [starti, endi], merge all 
        /// overlapping intervals, and return an array of the non-overlapping intervals 
        /// that cover all the intervals in the input.
        /// LeetCode: <see href="https://leetcode.com/problems/merge-intervals/submissions/1339452024/" />
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public static int[][] Merge(int[][] intervals)
        {
            List<int[]> results = new List<int[]>();

            intervals = intervals.OrderBy(x => x[0]).ToArray();

            int[] prevRange = intervals[0];

            for (int i = 1; i < intervals.Length; i++)
            {
                int[] current = intervals[i];
                if (current[0] <= prevRange[1])
                    prevRange[1] = Math.Max(prevRange[1], current[1]);
                else
                {
                    results.Add(prevRange);
                    prevRange = intervals[i];
                }
            }

            results.Add(prevRange);

            return results.ToArray();
        }
    }
}
