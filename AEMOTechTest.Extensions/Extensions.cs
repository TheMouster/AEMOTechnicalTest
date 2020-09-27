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


            return new List<int>();
        }
    }
}
