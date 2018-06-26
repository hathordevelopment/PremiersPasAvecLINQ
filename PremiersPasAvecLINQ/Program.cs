using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiersPasAvecLINQ
{
    class Program
    {
        static IEnumerable<int> MultiplesDeTrois()
        {
            var num = 0;
            while (true)
            {
                yield return num;
                num += 3;
            }
        }

        delegate void ForEachDelegate<T>(T elt);
        
        static void MyForEach<T>(IEnumerable<T> collection, ForEachDelegate<T> body)
        {
            var it = collection.GetEnumerator();

            while (it.MoveNext())
            {
                body(it.Current);
            }
        }

        static void Main(string[] args)
        {
            var tab = new int[]
            {
                4,2,6,13,42
            };

            var pairs = tab.Where((elt) =>
            {
                Console.WriteLine($"Je teste l'élément : {elt}");
                return elt % 2 == 0;
            });

            Console.WriteLine("Avant de rentrer dans le foreach");

            foreach (var elt in pairs)
            {
                Console.WriteLine(elt);
            }

            MyForEach(pairs,
                (elt) =>
                {
                    Console.WriteLine(elt);
                });

            /// Affiche les 15 premiers multiples de 3 
            foreach (var elt in MultiplesDeTrois().Where((elt) => elt % 2 == 0).Take(15))
            {
                Console.WriteLine(elt);
            }

            Console.ReadLine();
        }
    }
}
