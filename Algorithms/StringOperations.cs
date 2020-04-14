using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class StringOperations
    {
        /// <summary>
        /// CodeSignal interview practice - Arrays
        /// Given input string this method returns first non-repeating character.
        /// Returns '_' if there is no such character.
        /// </summary>
        /// <param name="s"></param>
        /// <returns>First non-repeating character in input string</returns>
        public char FirstNonRepeatingCharacter(string s)
        {
            var dic = new Dictionary<char, bool>();

            for (int i = 0; i < s.Length; i++)
            {
                if (!dic.ContainsKey(s[i])) dic.Add(s[i], true);
                else dic[s[i]] = false;
            }

            for (int i = 0; i < s.Length; i++)
                if (dic[s[i]] == true) return s[i];

            return '_';
        }

        /// <summary>
        /// CodeSignal arcade intro
        /// Given input string this method checks if it is palindrome
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>True if input string is palindrome, false otherwise</returns>
        public bool CheckPalindrome(string inputString)
        {
            int i = 0;
            int j = inputString.Length - 1;

            while (i < j && inputString[i] == inputString[j])
            {
                i++;
                j--;
            }

            return i >= j;
        }

    }
}
