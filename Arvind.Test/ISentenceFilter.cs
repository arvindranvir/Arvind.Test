using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvind.Test
{
    /// <summary>
    /// ISentenceFilter
    /// </summary>
    internal interface ISentenceFilter
    {
        /// <summary>
        /// find the words and word count in any sentence
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        IDictionary<string, int> FindWordsAndCount(string sentence);
    }
}
