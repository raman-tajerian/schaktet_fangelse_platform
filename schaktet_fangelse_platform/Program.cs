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





        }
    }
}