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
            SvartaMarknaden marknad = new SvartaMarknaden();
            


            Random rnd = new Random();

            // Huvudloop som körs till spelaren dör
            while (fange.HP > 0)
            {
                Console.WriteLine("Vad vill du göra idag?");
                Console.WriteLine("1) Vänta på plattformen");
                Console.WriteLine("2) Vila och Läka");
                Console.WriteLine("3) Hoppa på plattform och åk ner till Svarta Marknaden");
                int val = int.Parse(Console.ReadLine());
                int Level = fange.Level;

                if (val == 1)
                {

                    List<Medfange> monsterTyper = new List<Medfange>
                    {
                        new Utsvulten(),
                        new Hamstraren(),
                        new Bodeln()

                    };

                    Medfange monster = monsterTyper[rnd.Next(0, monsterTyper.Count)];

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

                        int monsterSkada = monster.Attack - fange.Forsvar;
                        if (monsterSkada < 1)
                        {
                            monsterSkada = 1;
                        }


                        if (val2 == 1) //Försvara
                        {
                            int skada = monsterSkada / 2;
                            if (skada < 1)
                            {
                                skada = 1;
                            }

                            fangeDog = fange.TakeDamage(skada);

                        }
                        else if (val2 == 2) //Anfall
                        {
                            int skada = fange.Attack - monster.Forsvar;
                            if (skada < 1)
                            {
                                skada = 1;
                            }

                            monsterDog = monster.TakeDamage(skada);

                            if (monsterDog == false)
                            {
                                fangeDog = fange.TakeDamage(monsterSkada);
                            }

                        }
                        else if (val2 == 3) // Spring
                        {
                            int skada = rnd.Next(1, monster.Attack + 1);

                            fangeDog = fange.TakeDamage(skada);

                            if (fangeDog == false)
                            {
                                Console.WriteLine("Du flydde!");
                                striden = false;
                            }
                        }
                        if (monsterDog)
                        {

                            Console.WriteLine($"{monster.Namn} blev besegrad. ");

                            fange.GainXP(monster.XPBeloning);

                            int guld = monster.TappaGuld();
                            fange.LaggTillGuld(guld);

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

                else if (val == 3) // Svarta Marknaden
                {
                    bool Arena = true;
                    if (Level >= 0)
                    {
                       
                            Console.WriteLine("Du hoppar på plattformen och åker djupare ner i schaktet");
                            Console.WriteLine();
                             while (Arena)
                        {
                            marknad.VisaSortiment();
                            int köp = int.Parse(Console.ReadLine());
                            Metallror metallror = new Metallror();
                            ImproviseradKniv kniv = new ImproviseradKniv();

                            if (köp == 1)
                            {
                                if (fange.Guld >= 15)
                                {
                                    int nyAttackSkada = fange.Attack + kniv.AttackBonus;
                                    fange.Guld = fange.Guld - 15;
                                    fange.Attack = fange.Attack + 4;
                                    Console.WriteLine($"Du har köpt {kniv.Namn}. Du gör nu {nyAttackSkada} skada. Guld kvar: {fange.Guld}");
                                    Console.WriteLine();
                                }
                                else if (fange.Guld < 15)
                                {
                                    Console.WriteLine($"Du har inte råd med {kniv.Namn} du har {fange.Guld} Guld");
                                }

                            }
                            else if (köp == 2)
                            {
                                if (fange.Guld >= 40)
                                {
                                    int nyAttackSkada = fange.Attack + metallror.AttackBonus;
                                    fange.Guld = fange.Guld - 40;
                                    Console.WriteLine($"Du har köpt {metallror.Namn}. Du gör nu {nyAttackSkada} skada. Guld kvar: {fange.Guld}");
                                    Console.WriteLine();
                                }
                                else if (fange.Guld < 40)
                                {
                                    Console.WriteLine($"Du har inte råd med {metallror.Namn} du har {fange.Guld} Guld");
                                }
                            }
                            else if (köp == 0)
                            {
                                Arena = false;
                                
                            }
                        }

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
  