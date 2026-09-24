using System;
using System.Collections.Generic;
using System.Text;

namespace schaktet_fangelse_platform
{
    //Abstract för att den endast ska kunna skapa konkreta typer; utsvulten, hamstraren och bödeln.
    internal abstract class Medfange
    {
        //Public get, private set - utomstående ska kunna läsa värdena, men bara klassen ska kunna ändra dem.
        public string Namn { get; private set; }
        public int HP { get; private set; }
        public int Attack { get; private set; }
        public int XPBeloning { get; private set; }
        public int GuldMin { get; private set; } //Intervall för guld drop inte ett fast belopp
        public int GuldMax { get; private set; } //


        //Protected konstruktor för att endast subklasserna ska kunna anropa konstruktorn
        protected Medfange(string namn, int hp, int attack, int xpBeloning, int guldMin, int guldMax)
        {
            Namn = namn;
            HP = hp;
            Attack = attack;
            XPBeloning = xpBeloning;
            GuldMin = guldMin;
            GuldMax = guldMax;
        }
        public bool TakeDamage(int skada)
        {
            HP = HP - skada;
            if (HP <= 0)
                return true;
            else
                return false;
        }

    }
}
