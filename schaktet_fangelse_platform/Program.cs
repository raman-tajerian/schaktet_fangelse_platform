using System;
using System.Collections.Generic;
using System.Globalization;

namespace schaktet_fangelse_platform
{
    class Program
    {
        static void Main(string[] args)
        {

            // Här skapar vi spelaren
            Console.WriteLine("Välkommen till schaktet!");
            Console.Write("Skriv ditt namn: ");
            string namn = Console.ReadLine();
            Fange fange = new Fange(namn);

            // Lista av monstertyper
            List<Medfange> monsterTyper = new List<Medfange>
            {
                new Utsvulten(),
                new Hamstraren(),
                new Bodeln()
            };

            Random rnd = new Random();

            // Huvudloop som körs till spelaren dör
            while (fange.HP > 0)
                {
                Console.WriteLine("Vad vill du göra idag?");
                Console.WriteLine("1) Vänta på plattformen");
                Console.WriteLine("2) Vila och Läka");
                Console.WriteLine("3) Hoppa på plattform och åk ner");
                int val = int.Parse(Console.ReadLine());
                int Level = fange.Level;

                if (val == 1)
                {
                   
                    Medfange monster = monsterTyper[rnd.Next(0, monsterTyper.Count)]; //Slumpar ett monster ur listan

                    bool striden = true;
                    while (striden == true)
                    {
                        Console.WriteLine($"{monster.Namn} har {monster.HP}HP");
                        Console.WriteLine();
                        Console.WriteLine($"Du har {fange.HP}HP");
                        Console.WriteLine();

                        Console.WriteLine("1) Försvara dig");
                        Console.WriteLine("2) Anfall");
                        Console.WriteLine("3) Spring");
                        int val2 = int.Parse(Console.ReadLine());

                        bool monsterDog = false;
                        bool fangeDog = false;
                        

                        if (val2 == 1) //Försvara
                        {
                            int skada = monster.Attack/2;
                            
                            fangeDog = fange.TakeDamage(skada);

                        }
                        else if (val2 == 2) //Anfall
                        {
                            int skada = fange.Attack - monster.Forsvar;
                            int skada2 = monster.Attack;
                           
                            fangeDog = fange.TakeDamage(skada2);
                            monsterDog = monster.TakeDamage(skada);

                        }
                        else if (val2 == 3) //spring
                        {
                            int skada = rnd.Next(1, monster.Attack + 1);
                            
                            fangeDog = fange.TakeDamage(skada);
                        }
                        if (monsterDog)
                        {
                            fange.GainXP(monster.XPBeloning);
                            
                            int Guld = monster.TappaGuld();

                            Console.WriteLine($"{monster.Namn} blev besegrad");

                            striden = false;

                        }
                        if (fangeDog)
                        {
                            Console.WriteLine($"{fange.Namn} dog\nGAME OVER");
                            striden = false;
                        }
                    }

                    if (fange.HP > 0)
                    {
                        fange.NyDag();
                    }

                }

                else if (val == 2)
                {
                    fange.Heal();
                    fange.NyDag();
                }

                else if (val == 3)
                {
                    if (Level >= 5)
                    {
                        Console.WriteLine("Du hoppar på plattformen och åker djupare ner i schaktet");
                        fange.GainXP(10);
                        fange.NyDag();
                    }
                    else
                    {
                        Console.WriteLine($"{fange.Namn} måste vara minst level 5 för att åka ner i schaktet");
                    }
                }
            }

            Console.WriteLine($"\nSpelet är slut! Du överlevde i {fange.Dagar} dagar och nådde level {fange.Level}. Total XP: {fange.XP}");

        }
    }
}