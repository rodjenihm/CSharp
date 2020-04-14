using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.Tests
{
    public class StringOperationsShould
    {
        private readonly StringOperations sut;

        public StringOperationsShould()
        {
            sut = new StringOperations();
        }

        [Theory]
        [InlineData("aaabcccdeeef", 'b')]
        [InlineData("abcbad", 'c')]
        [InlineData("abcabcabc", '_')]
        public void ReturnFirstNonRepeatingCharacter(string inputString, char actual)
        {
            Assert.Equal(sut.FirstNonRepeatingCharacter(inputString), actual);
        }

        [Theory]
        [InlineData("hlbeeykoqqqokyeeblh", true)]
        [InlineData("aabaa", true)]
        [InlineData("abac", false)]
        [InlineData("a", true)]
        public void CheckIfInputStringIsPalindrome(string inputString, bool actual)
        {
            Assert.Equal(sut.CheckPalindrome(inputString), actual);
        }
    }
}
