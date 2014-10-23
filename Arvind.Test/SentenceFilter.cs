using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuttingEdge.Conditions;
using System.Text.RegularExpressions;
using System.ComponentModel.Composition;
namespace Arvind.Test
{
    /// <summary>
    /// SentenceFilter
    /// </summary>
    [Export(typeof(ISentenceFilter))]
    internal class SentenceFilter : ISentenceFilter
    {
        /// <summary>
        /// find the words and word count in any sentence
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public IDictionary<string, int> FindWordsAndCount(string sentence)
        {
            Condition.Requires(sentence, "sentence")
            .IsNotNull()
            .IsNotEmpty();

            //find all the words in the sentence
            var words = sentence.Split(new[] { ' ' });

            //regex finds all the words which dont end a-z, A-Z or 0-9
            var regEx = @"^*[A-Za-z0-9]$";
            Regex rgx = new Regex(regEx);

            var allWords = words.Where(w => w.Length > 0)
                .Select(w => rgx.IsMatch(w) ? w : w.Substring(0, w.Length - 1)).ToList();

            return allWords.GroupBy(w => w, w2 => w2, (k, v) => new { Key = k, Value = v.Count() })
                .ToDictionary(k => k.Key, v => v.Value);
        }
    }
    
}
