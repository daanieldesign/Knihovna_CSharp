using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class Program
    {
        public class kniha
        {
            public int ID { get; set; }
            public string Nazev { get; set; }
            public string Autor { get; set; }
            public bool Vypujcena { get; set; }

        public kniha(int id, string nazev, string autor)
            {
                ID = id;
                Nazev = Nazev;
                Autor = Autor;
                Vypujcena = false;
            }

            public void Vypujceni()
            {
                if (Vypujcena == true)
                {
                    Console.WriteLine("Bohužel, kniha " + Nazev + " je již vypůjčena.");
                }

                else
                {
                    Vypujcena = true;
                    Console.WriteLine("Kniha" + Nazev + " byla úspěšně zapůjčena.");
                }
            }

            public void vraceni()
            {
                if(!Vypujcena)
                {
                    Console.WriteLine("Kniha není vypůjčena.");
                }

                else
                {
                    Vypujcena = false;
                    Console.WriteLine("Kniha " + Nazev + " byla vrácena. Děkujeme za důvěru!");
                }
            }

            public void Info_O_Knize()
            {
                string stav = Vypujcena ? "vypůjčena" : "dostupná";
                Console.WriteLine("ID: " + ID + " Název: " + Nazev + " Autor: " + Autor + " Stav: " + stav);
            }

        }

        public class knihovna
        {
            public void BezID()
            {
                Console.WriteLine("Kniha s tímto číslem neexistuje.");
            }

            private List<kniha> knihy;
            private int nextId;

            public knihovna()
            {
                knihy = new List<kniha>();
                nextId = 1;
            }

            public void PridatKnihu(string Nazev, string Autor)
            {
                kniha NovaKniha = new kniha(nextId++, Nazev, Autor);
                knihy.Add(NovaKniha);
                Console.WriteLine("Kniha byla úspěšně přidána.");
            }

            public void OdstranitKnihu(int id)
            {
                kniha OdstraneniKniha = knihy.Find(kniha => kniha.ID == id);
                if (OdstraneniKniha != null)
                {
                    knihy.Remove(OdstraneniKniha);
                    Console.WriteLine("Kniha " + OdstraneniKniha.Nazev + " byla odstraněna ze seznamu.");
                }
                else
                {
                    Console.WriteLine("Kniha s tímto číslem v seznamu neexistuje.");
                }
            }

            public void ZapujcitKnihu (int id)
            {
                kniha Kniha = knihy.Find(b => b.ID == id);
                if (Kniha != null)
                {
                    Kniha.Vypujceni();
                }
                else
                {
                    Console.WriteLine("Kniha s tímto číslem neexistuje.");
                }
            }

            public void VratitKnihu(int id)
            {
                
                kniha Kniha = knihy.Find(b => b.ID == id);
                if (Kniha != null)
                {
                    Kniha.vraceni();
                }
                else
                {
                    Console.WriteLine("Kniha s tímto číslem neexistuje.");
                }
            }

            public void DostupneKnihy()
            {
                Console.WriteLine("Dostupné knihy:");
                foreach (kniha Kniha in knihy)
                {
                    if (!Kniha.Vypujcena)
                    {
                        Kniha.Info_O_Knize();
                    }
                }
            }

            public void VypujceneKnihy()
            {
                Console.WriteLine("Vypůjčené knihy:");
                foreach (kniha Kniha in knihy)
                {
                    if (Kniha.Vypujcena)
                    {
                        Kniha.Info_O_Knize();
                    }
                }
            }

            public void VsechnyKnihy()
            {
                Console.WriteLine("Seznam všech knih:");
                foreach (kniha Kniha in knihy)
                {
                    Kniha.Info_O_Knize();
                }
            }
        }

        static void Main(string[] args)
        {
            knihovna Knihovna = new knihovna();
            bool running = true;

            while (running)
            {
                Console.WriteLine("Knihovna");
                Console.WriteLine("1. Přidat knihu");
                Console.WriteLine("2. Odstranit knihu");
                Console.WriteLine("3. Půjčit knihu");
                Console.WriteLine("4. Vrátit knihu");
                Console.WriteLine("5. Zobrazit dostupné knih");
                Console.WriteLine("6. Zobrazit vypůjčené knihy");
                Console.WriteLine("7. Zobrazit všechny knihy");
                Console.WriteLine("8. Konec");
                Console.Write("Vyberte akci (1-8): ");
                string vyber = Console.ReadLine();

                switch (vyber)
                {
                    case "1":
                        Console.Write("Zadejte název knihy: ");
                        string Nazev = Console.ReadLine();
                        Console.Write("Zadejte autora knihy: ");
                        string Autor = Console.ReadLine();
                        Knihovna.PridatKnihu(Nazev, Autor);
                        break;
                }
            }
        }
    }

}