using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Arvind.Test.UnitTests
{
    [TestClass]
    public class SentenceFilterTests
    {
        private ISentenceFilter sentenceFilter;

        [TestInitialize()]
        public void Initialize() 
        {
            sentenceFilter = new SentenceFilter();
        }

        [TestMethod]
        public void WordWouldBeConsideredWithoutPunctuation()
        {
            var sentence = "AA, BB; AA. SS!";
            var keyVal= sentenceFilter.FindWordsAndCount(sentence);
            
            Assert.IsTrue(keyVal["AA"]==2);
            Assert.IsTrue(keyVal["BB"] == 1);
        }

        [TestMethod]
        public void WordCountMustBeSetAsValue()
        {
            var sentence = "AA, BB; AA. BB!";
            var keyVal = sentenceFilter.FindWordsAndCount(sentence);

            Assert.IsTrue(keyVal["AA"] == 2);
            Assert.IsTrue(keyVal["BB"] == 2);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BlankSentenceMustThrowError()
        {
            var sentence = "";
            var keyVal = sentenceFilter.FindWordsAndCount(sentence);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NullSentenceMustThrowError()
        {
            var sentence = "";
            var keyVal = sentenceFilter.FindWordsAndCount(sentence);

        }
        [TestMethod]
        public void WordMustBeKeyInTheReturnedValue()
        {
            var sentence = "AA AA AA";
            var keyVal = sentenceFilter.FindWordsAndCount(sentence);
            Assert.IsTrue(keyVal.ContainsKey("AA"));

        }
    }
}
