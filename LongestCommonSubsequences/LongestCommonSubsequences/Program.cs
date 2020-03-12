using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCommonSubsequences
{
    class Program
    {
        static void Main(string[] args)
        {
            String s2 = "AGGTAB";
            String s1 = "GXTXAYB";
            // Beklenen Sonuc: "GTAB"

            LCS lcs = new LCS(s1, s2);
            lcs.CreateSolutionMatrix();
            lcs.FindSequences();
        }
    }
}
