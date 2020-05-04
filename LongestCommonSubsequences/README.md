## Longest Common Subsequences Algorithm (En Uzun Ortak Altdizi Algoritması)

### Problem:
İki string degerin en uzun ortak altdizisinin dondurulmesi.

### Ornekler:
```
"AGGTAB", "GXTXAYB" => "GTAB"
"ABAZDC", "BACBAD"  => "ABAD"
```

### Algoritmik Cozum
Genellikle iki kümedeki elemanlarin arasından ortak en uzun sıralı alt dizinin bulunması problemi olarak tanimlanmaktadir. Bu problemin cozulmesinde, tablo yaklasimi onerilmektedir.

Ornegin X ve Y kumesini, iki karakter dizisini temsil ettigini düşünelim ve bu iki karakter kümesi arasındaki en uzun ortak altdiziyi bulmaya çalışalım.

```
 X: "GXTXAYB"
 Y: "AGGTAB"
```


#### Cozum Tablosunun Olusturulmasi

Bu kümeleri tabloda temsili yerlerine yerlestirip çözüm islemlerine baslayabiliriz. Oncelikle kumelerin eleman sayilarindan `+1` fazla olacak sekilde satır ve sütuna sahip bir matris olusturulur. Kolonlar `Y` kümesini temsil ederken, satirlar `X` kümesini temsil edecek şekilde ayarlanır ve hucreler eslesmelere gore doldurulur.

Ornegimizdeki tablo; `X` kumesi `7` karaktere sahip olduğundan `7+1=8` satıra, `Y` kümesi `6` karaktere sahip olduğundan `6+1=7` kolona sahip olacaktır. 

![LCS Table 1](https://github.com/omereryilmaz/Algorithms/blob/master/LongestCommonSubsequences/img/lcs_table_1.jpg)

`X` ve `Y`’nin bulundugu satir ve sutunlardaki hucrelerin hepsine 0 degeri verilir. Indis numarasıyla temsil edersek; `[0,i]` 0.satirdaki hucreler ve `[i,0]` 0.kolondaki tum hucreler denilebilir.

![LCS Table 2](https://github.com/omereryilmaz/Algorithms/blob/master/LongestCommonSubsequences/img/lcs_table_2.jpg)

Bu adimdaki islemler ise eslesmeleri kontrol etmek. Bu kontrol yapilirken harflerin cakistigi hucrelere bakilir. 

![LCS Table 3](https://github.com/omereryilmaz/Algorithms/blob/master/LongestCommonSubsequences/img/lcs_table_3.jpg)

Eslesme varsa, hucrenin sol ust caprazindaki degeri `+1` arttirarak bulunulan hucreye yazilir. Ornegin bulunulan hucre indisi `[i,j]` ise sol ust caprazindaki hucrenin indisi `[i-1,j-1]` seklinde olacaktir.

Eslesme yoksa, hucrenin solundaki ve ustundeki hucrelerin degelerine bakilarak, en buyuk degere sahip hangisiyse onun degeri bulunulan hucreye yazilir. Ornegin bulunulan hucre indisi `[i,j]` ise solundaki hucrenin indisi `[i,j-1]` olurken; ustundeki hucrenin indisi ise `[i-1,j]` olacaktir.

Ornegimizde ilgili karsilastirmada eslesme olmadigindan solundaki ve ustundeki hucrelere bakilir. Buradaki hucrelerdeki degerler `0` oldudugundan bulunulan hucreye `0` degeri yazilir.

![LCS Table 4](https://github.com/omereryilmaz/Algorithms/blob/master/LongestCommonSubsequences/img/lcs_table_4.jpg)

Bulunulan hucrenin hemen sagindaki hucre icin eslesme durumuna bakilir ve `G-G` eslesmesinin oldugu gorulur. 

![LCS Table 5](https://github.com/omereryilmaz/Algorithms/blob/master/LongestCommonSubsequences/img/lcs_table_5.jpg)

Bu durumda ise ilgili hucrenin degerini sol ust caprazdaki hucrenin degeri `+1` arttirarak belirlenir. Yani son durumda bulunulan hucrenin degeri `1` olur. 

Ayni islemler butun hucreler icin tekrarlanir ve sonucunda asagidaki gibi bir tablo ortaya cikar.

![LCS Table 6](https://github.com/omereryilmaz/Algorithms/blob/master/LongestCommonSubsequences/img/lcs_table_6.jpg)


#### Cozum Tablosundan Sonucu Bulma

Olusan cozum tablosundan `LCS` cozum kumesinin elemanlarini bulmak icin son satir ve sutunun kesistigi hucreden baslayarak asagidaki sart aranir;

> Eger bulunulan hucrenin degeri, ust-sol capraz hucreden artarak gelmisse ilgili hucrenin cakistigi harf LCS kumesine sondan eklenir.

![LCS Table 7](https://github.com/omereryilmaz/Algorithms/blob/master/LongestCommonSubsequences/img/lcs_table_7.jpg)

Yukaridaki tabloda sonuncu hucrenin degerinin degeri sol-ust caprazdan arttarak geldigi gorulmektedir. `(Programlama kisminda bu sorunun cozumu icin hucrenin sol ve ust komsu hucrelerinin her ikisinden buyuk olup olmadigina bakilarak da bu sonuca varilabilir.)` Sonuc olarak `LCS` kumesine `B` harfi eklenir ve kontrol konumlandirmasi degerin alindigi hucreye yani sol-ust capraza cekilir.

![LCS Table 8](https://github.com/omereryilmaz/Algorithms/blob/master/LongestCommonSubsequences/img/lcs_table_8.jpg)

Simdiki kontrol edilen hucrenin, ust komsusundan degerini aldigi gorulmektedir. Bu yuzden ilgili hucrede cakisan harfler `LCS` kumesine eklenmez. Ayni islemler diger hucreler icin de gerceklestirilir. 

![LCS Table 9](https://github.com/omereryilmaz/Algorithms/blob/master/LongestCommonSubsequences/img/lcs_table_9.jpg)

Sonuc olarak olusan `LCS` kumesinin; `GTAB` elemanlarindan olustugu gorulur.

### Olusturulan KCS Sinifinin Kullanimi
![Longest Common Subsequences Algorithm Code](https://github.com/omereryilmaz/Algorithms/blob/master/LongestCommonSubsequences/img/1.jpg)

### Sonuc Ciktisi
![Longest Common Subsequences Algorithm Output](https://github.com/omereryilmaz/Algorithms/blob/master/LongestCommonSubsequences/img/2.jpg)

### UnitTest Sonuclari
![Longest Common Subsequences Algorithm UnitTest](https://github.com/omereryilmaz/Algorithms/blob/master/LongestCommonSubsequences/img/unittest.jpg)