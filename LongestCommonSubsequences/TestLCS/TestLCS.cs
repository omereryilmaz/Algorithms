using System;
using LongestCommonSubsequences;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLCS
{
    [TestClass]
    public class TestLCS
    {
        [TestMethod]
        public void FindSequences1()
        {
            String s2 = "AGGTAB";
            String s1 = "GXTXAYB";

            // Beklenen Sonuc: "GTAB"

            LCS lcs = new LCS(s1, s2);

            String sonuc = lcs.FindSequences();

            // Assert.AreEqual("Beklenen Deger", "Donen Sonuc");
            Assert.AreEqual("GTAB", sonuc);

        }

        [TestMethod]
        public void FindSequences2()
        {
            String s2 = "ABAZDC";
            String s1 = "BACBAD";

            // Beklenen Sonuc: "GTAB"

            LCS lcs = new LCS(s1, s2);

            String sonuc = lcs.FindSequences();

            // Assert.AreEqual("Beklenen Deger", "Donen Sonuc");
            Assert.AreEqual("ABAD", sonuc);
        }
    }
}
