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
        [Theory]
        [InlineData("aaabcccdeeef", 'b')]
        [InlineData("abcbad", 'c')]
        [InlineData("abcabcabc", '_')]
        public void ReturnFirstNonRepeatingCharacter(string inputString, char firstNonRepeatingCharacter)
        {
            var sut = new StringOperations();

            Assert.Equal(sut.FirstNonRepeatingCharacter(inputString), firstNonRepeatingCharacter);
        }
    }
}
