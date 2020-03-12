using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCommonSubsequences
{
    public class LCS
    {
        private string String1;
        private string String2;
        private int[,] Array;
        private int S1Lenght;
        private int S2Lenght;


        public LCS(string _s1, string _s2)
        {
            String1 = _s1;
            String2 = _s2;
            S1Lenght = String1.Length + 1;
            S2Lenght = String2.Length + 1;
            Array = new int[S1Lenght, S2Lenght];
        }

        // Bas - ShowFirstMatrix()
        #region Matris'in o anki halini gosterir
        public void ShowMatrix()
        {
            for (int i = 0; i < S1Lenght; i++)
            {
                for (int j = 0; j < S2Lenght; j++)
                {
                    Console.Write((Array[i, j]) + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
          
        }
        #endregion
        // Son - ShowFirstMatrix()

        // Bas - CreateSolutionMatrix()
        #region Cozum Matrisi Fonksiyonu
        public void CreateSolutionMatrix()
        {
            for (int j = 0; j < S2Lenght - 1; j++)
            {
                for (int i = 0; i < S1Lenght - 1; i++)
                {
                    // s2 stringinin [j] indisli karakteri esitse s1 stringinin [i] indisli karakterine ( s1[0]=="A" ve s2[0]=="G")
                    if (String2[j] == String1[i])
                    {
                        // Sol-ust caprazindaki hucrenin degerine +1 ekleyerek ilgili hucreye ata
                        Array[i + 1, j + 1] = Array[i, j] + 1;
                    }
                    else // s2 stringinin [j] indisli karakteri esit degilse s1 stringinin [i] indisli karakterine
                    {
                        // Ilgili hucrenin sol hucresi buyuk ve esitse ust hucresine
                        if (Array[i + 1, j] >= Array[i, j + 1])
                        {
                            // Ilgili hucrenin degerine sol hucrenin degerini ata
                            Array[i + 1, j + 1] = Array[i + 1, j];
                        }
                        else //Ilgili hucrenin sol hucresi kucukse ust hucresinden
                        {
                            // Ilgili hucrenin degerine ust hucrenin degerini ata
                            Array[i + 1, j + 1] = Array[i, j + 1];
                        }
                    }
                }
            }
            ShowMatrix();
        }
        #endregion
        // Son - CreateSolutionMatrix()

        public void FindSequences()
        {
            CellLastLocation lastLoc;
            lastLoc.i = S1Lenght - 1;
            lastLoc.j = S2Lenght - 1;
            string lcsStr="";

            // lastLoc 0,0 noktasina gelene kadar isleme devam et
            while (lastLoc.i != 0 && lastLoc.j != 0)
            {
                if (Array[lastLoc.i, lastLoc.j] > Array[lastLoc.i, lastLoc.j - 1] &&
                    Array[lastLoc.i, lastLoc.j] > Array[lastLoc.i - 1, lastLoc.j])
                {
                    
                    lcsStr += String1[lastLoc.i - 1];

                    // ust sol capraz konumuna al
                    lastLoc.i -= 1;
                    lastLoc.j -= 1;
                }
                else
                {
                    // hucrenin sol tarafi kendinden kucuk olana kadar devam et
                    while (Array[lastLoc.i, lastLoc.j] == Array[lastLoc.i - 1, lastLoc.j])
                    {
                        // bir sola kaydir
                        lastLoc.i -= 1;
                    }

                    // ustunu kontrol et, uste esitse yukari cik
                    if (Array[lastLoc.i, lastLoc.j] == Array[lastLoc.i, lastLoc.j - 1])
                    {
                        lastLoc.j -= 1;
                    }
                }
            }

            Console.WriteLine($"____________________");
            Console.WriteLine($"String 1: {String1}");
            Console.WriteLine($"String 2: {String2}");
            Console.WriteLine($"____________________");
            Console.Write($"Sonuc: ");
            // Son ciktiyi ters cevirerek ekrana bas
            for (int i = lcsStr.Length; i > 0; i--)
            {
                Console.Write(lcsStr[i - 1]);
            }
            Console.WriteLine("");
            Console.WriteLine($"____________________");
            Console.ReadKey();
        }
    }
}
