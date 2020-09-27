using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AEMOTechTest.Extensions
{
    public static class StringExtensions
    {
        public static ICollection<int> indexesOf(this string corpus, string term)
        {
            if (string.IsNullOrEmpty(corpus) || string.IsNullOrEmpty(term) || term.Length > corpus.Length)
                return new List<int>();


            int index = 0, start = 0;
            List<int> results = new List<int>();

            while (index != -1)
            {
                index = corpus.IndexOf(term, start, StringComparison.InvariantCultureIgnoreCase);

                if (index != -1)
                {
                    results.Add(index);
                    start = index + term.Length;
                }
            }

            return results;
        }
    }
}
