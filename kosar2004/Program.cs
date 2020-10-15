using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kosar2004
{
    class Program
    {
        static List<Meccs> meccsek = new List<Meccs>();
        static Dictionary<string, int> stadionok = new Dictionary<string, int>();


        static void masodik()
        {
            StreamReader sr = new StreamReader("eredmenyek.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                
                string[] a = sr.ReadLine().Split(';');
                
                meccsek.Add(new Meccs(a[0],a[1],int.Parse(a[2]),int.Parse(a[3]),a[4],a[5]));
            }


            sr.Close();
            
        }


        static void harmadik()
        {
            Console.Write("3. feladat: ");
            int haza = 0;
            int ideg = 0;
            foreach (var item in meccsek)
            {
                if (item.Hazai.Contains("Real Madrid"))
                {
                    haza++;
                }
                if (item.Idegen.Contains("Real Madrid"))
                {
                    ideg++;
                }
            }
            Console.Write("Real Madrid: Hazai? {0} Idegen: {1}",haza,ideg);
            Console.WriteLine();
        }


        static void negyedik()
        {
            Console.Write("4. feladat: Volt döntetlen? ");
            int i = 0;
            bool van = false;
            while (i< meccsek.Count && !van)
            {
                if (meccsek[i].HPont == meccsek[i].IPont)
                {
                    Console.WriteLine("igen\n");
                    van = true;
                    

                }
                i++;
            }

            if (van == false)
            {
                Console.Write("nem\n");
            }

        }


        static void otodik()
        {
            Console.Write("5. feladat: barcelonai csapat neve: ");
            int i = 0;
            bool van = false;
            while (i< meccsek.Count && !van)
            {
                if (meccsek[i].Hazai.Contains("Barcelona"))
                {
                    Console.Write(meccsek[i].Hazai+"\n");
                    van = true;
                }
                if (meccsek[i].Idegen.Contains("Barcelona"))
                {
                    Console.Write(meccsek[i].Idegen+"\n");
                    van = true;
                }
                i++;
            }

        }


        static void hatodik()
        {
            Console.WriteLine("6. feladat");
            for (int i = 0; i < meccsek.Count; i++)
            {
                if (meccsek[i].Ido == "2004-11-21")
                {
                    Console.WriteLine("\t"+meccsek[i].Hazai + "-" + meccsek[i].Idegen + " (" + meccsek[i].HPont +":"+ meccsek[i].IPont + ")");
                }
            }
            

            


        }


        static void hetedik()
        {
            Console.WriteLine("\n7. feladat");
            
            foreach (var item in meccsek)
            {
                if (!stadionok.ContainsKey(item.Hely))
                {
                    stadionok.Add(item.Hely,0);
                }
            }

            foreach (var t in meccsek)
            {
                stadionok[t.Hely]++;           
            }
            
            foreach (var item in stadionok)
            {
                if (item.Value > 20)
                {
                    Console.WriteLine("\t" + item.Key + ": " + item.Value);
                }
                
            }

        }


        static void nyolcadik()
        {
            
            Console.WriteLine("8. feladat: ");
            StreamWriter sw = new StreamWriter("meccsek.txt");
            for (int i = 0; i < meccsek.Count; i++)
            {
                sw.WriteLine("\t" + meccsek[i].Hazai + "-" + meccsek[i].Idegen + " (" + meccsek[i].HPont + ":" + meccsek[i].IPont + ")");
            }

            sw.Close();
        }
        static void Main(string[] args)
        {
            //7up Joventut;Adecco Estudiantes;81;73;Palacio Mun. De Deportes De Badalona;2005-04-03
            masodik();
            harmadik();
            negyedik();
            otodik();
            hatodik();
            hetedik();
            nyolcadik();



            Console.ReadKey();
        }
    }
}
