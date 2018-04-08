using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZV.ConUI
{
    public class Question5
    {
        public static void Solution()
        {
            // İlgili tüm permütasyonların listesi çıkarılıyor
            // En fazla üç adet virgül alabileceği için adet de virgül ekleniyor dizine
            Permutations<string> Per = new Permutations<string>(new List<string> { "A", "B", "C", "D",",",",","," }, GenerateOption.WithoutRepetition);


            List<string> list = new List<string>();
            foreach (List<string> line in Per)
            {
                // Permütasyon listesindeki string dizileri stringe çeviriliyor
                string sol = "";
                foreach (string s in line)
                {
                    sol += s;
                }

                // Ardarda gelen virgüller teke indiriliyor
                sol = sol.Replace(",,,", ",");
                sol = sol.Replace(",,", ",");

                // İlk karakteri virgül olan stringlerden ilk virgül kaldırılıyor
                if (sol[0] == ',')
                    sol = sol.Remove(0, 1);

                // Son karakteri virgül olan stringlerden son virgül kaldırılıyor
                if (sol[sol.Length - 1] == ',')
                    sol = sol.Remove(sol.Length - 1, 1);

                // Baştan ve sondan boşluk varsa temizleniyor
                sol.Trim();

                // String virgüllerden bölünerek tekrar biz dizi haline getiriliyor
                string[] elements = sol.Split(',');

                // Dizideki elemanlar ilk elemanında göre sıralanıp tekrar bir stringe dönüştürülüyor
                string newString = "";
                foreach (string s in elements.OrderBy(a=>a))
                {
                    newString += s + ",";
                }

                // String'e dönüştürme esnasında en sona eklenen virgül siliniyor.
                newString = newString.Remove(newString.Length - 1, 1);

                // Elde edilen yeni string listeye ekleniyor
                list.Add(newString);                
            }

            // Oluşan listedeki dublike elemanlar temizlenerek yeni liste başka bir listeye atanıyor.
            List<string> newList = list.Distinct().ToList();

            // Oluşan temizlenmiş yeni liste ilk elemana göre yeniden sıralandırılarak ekrana yazdırılıyor
            foreach (string sol in newList.OrderBy(a=>a[0]).ThenBy(a=>a))
            {
                Console.WriteLine(sol);
            }
            Console.WriteLine(newList.Count);

            Console.ReadLine();
        }
    }
}
