using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\monitor\Desktop\KNN\iris.txt");

            List<Flor> flores = new List<Flor>();

            for (int i = 0; i < lines.Length; i++)
            {
                string[] aux;
                aux = lines[i].Split(',');
                Vector2 sepala = new Vector2(float.Parse(aux[0], new CultureInfo("en-US")), float.Parse(aux[1], new CultureInfo("en-US")));
                Vector2 petala = new Vector2(float.Parse(aux[2], new CultureInfo("en-US")), float.Parse(aux[3], new CultureInfo("en-US")));
                string type = aux[4];

                flores.Add(new Flor(type, sepala, petala));
            }

            do
            {
                double[] distancias = new double[flores.Count];

                Vector2 sepala = new Vector2();
                Vector2 petala = new Vector2();

                Console.Write("Insira o comprimento da sepala: ");
                sepala.x = float.Parse(Console.ReadLine(), new CultureInfo("en-US"));

                Console.Write("Insira a largura da sepala: ");
                sepala.y = float.Parse(Console.ReadLine(), new CultureInfo("en-US"));

                Console.Write("Insira a comprimento da petala: ");
                petala.x = float.Parse(Console.ReadLine(), new CultureInfo("en-US"));

                Console.Write("Insira a largura da petala: ");
                petala.y = float.Parse(Console.ReadLine(), new CultureInfo("en-US"));

                Flor amostra = new Flor("", sepala, petala);

                for (int i = 0; i < distancias.Length; i++)
                {
                    distancias[i] = amostra.Distance(flores[i]);
                }

                Console.WriteLine("Distancias:");


                flores = TimSort.InsertionSort(distancias, flores);

                Console.Write("Insira o valor K: ");
                int K = int.Parse(Console.ReadLine());

                Console.WriteLine("Maior probalidade da planta inserida ser uma " + ChooseType(flores, K));

                Console.Write("Deseja repetir? 1-Sim / 0-Não ");
            } while (int.Parse(Console.ReadLine()) != 0);

            Console.ReadKey();
        }

        public static string ChooseType(List<Flor> flores, int K)
        {
            int set = 0, ver = 0, vir = 0;
            for (int i = 0; i < K; i++)
            {
                switch (flores[i].type)
                {
                    case "Iris-setosa":
                        set++;
                        break;
                    case "Iris-versicolor":
                        ver++;
                        break;
                    case "Iris-virginica":
                        vir++;
                        break;
                }
            }
            if (set > ver && set > vir)
                return "Iris-setosa";
            else if (ver > vir)
                return "Iris-versicolor";
            else
                return "Iris-virginica";
        }
    }
}
